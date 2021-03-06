module JavaGram where

import ParseLib.Abstract hiding (braced, bracketed, parenthesised)
import JavaLex

        
data Class = Class     Token [Member]          
          deriving Show

data Member = MemberD  Decl
            | MemberM  Type Token [Decl] Stat
          deriving Show
          
data Stat = StatDecl   Decl
          | StatExpr   Expr
          | StatIf     Expr Stat Stat
          | StatWhile  Expr Stat
          | StatReturn Expr
          | StatBlock  [Stat]
          deriving Show

data Position = LHS | RHS deriving (Show,Eq)

data Expr = ExprConst  Token
          | ExprVar    Token
          | ExprOper   Token Expr Expr
          | ExprMethod Token [Expr]
          | ExprIncr   Expr Token Position
          deriving Show
          
data Decl = Decl       Type Token
          deriving Show

data Type = TypeVoid
          | TypePrim   Token
          | TypeObj    Token
          | TypeArray  Type
          deriving (Eq,Show)

parenthesised p = pack (symbol POpen) p (symbol PClose)
bracketed     p = pack (symbol SOpen) p (symbol SClose)
braced        p = pack (symbol COpen) p (symbol CClose)

pExprSimple :: Parser Token Expr
pExprSimple =  ExprConst  <$> sConst
           <|> ExprMethod <$> sLowerId <*> parenthesised ( many pExpr )
           <|> ExprVar    <$> sLowerId
           <|> parenthesised pExpr
           
-------------------------------------
{- TASK 7: Add Increment Operators -}
-------------------------------------
           
pExprIncr = toExprIncr RHS <$> pExprSimple <*> sIncrementor
            <|> pExprSimple
            <|> flip (toExprIncr LHS) <$> sIncrementor <*> pExprSimple
            where toExprIncr pos x y = ExprIncr x y pos
            
-------------------
{- END OF TASK 7 -}
-------------------

-------------------------------------------------
{- TASK 2: Fix the priorities of the operators -}
-------------------------------------------------

pExpr :: Parser Token Expr
pExpr = doPrecs (reverse precedences) (chainl pExprIncr (ExprOper <$> sOperator))

pOp x = ExprOper <$> symbol (Operator x)
pOperList = choice . map pOp

doPrecs ((list,chainfunction):xs) prevPrec = let nextPrec = chainfunction prevPrec (pOperList list)
                                             in doPrecs xs nextPrec
doPrecs [] prevPrec = prevPrec

precedences = [ (["*","/","%"],chainl), 
                (["+", "-"],chainl), 
                (["<=", "<", ">=", ">"], chainl),
                (["==","!="], chainl),
                (["^"], chainl),
                (["&&"], chainl),
                (["||"], chainl),
                (["="], chainr) ]
                
-------------------
{- END OF TASK 2 -}
-------------------

pMember :: Parser Token Member
pMember =   MemberD <$> pDeclSemi
        <|> pMeth

pStatDecl :: Parser Token Stat
pStatDecl =   pStat
          <|> StatDecl <$> pDeclSemi

pStat :: Parser Token Stat
pStat =  StatExpr
         <$> pExpr 
         <*  sSemi
     <|> StatIf
         <$  symbol KeyIf
         <*> parenthesised pExpr
         <*> pStat
         <*> option ((\_ x -> x) <$> symbol KeyElse <*> pStat) (StatBlock [])
     <|> StatWhile
         <$  symbol KeyWhile
         <*> parenthesised pExpr
         <*> pStat
     <|> StatReturn
         <$  symbol KeyReturn
         <*> pExpr
         <*  sSemi
     <|> pBlock
     
     
pBlock :: Parser Token Stat
pBlock  =  StatBlock
           <$> braced( many pStatDecl )



pMeth :: Parser Token Member
pMeth =  MemberM
         <$> (   pType 
             <|> const TypeVoid <$> symbol KeyVoid
             )
         <*> sLowerId
         <*> parenthesised (option (listOf pDecl
                                           (symbol Comma)
                                   )
                                   []
                           )
         <*> pBlock
         
pType0 :: Parser Token Type
pType0 =  TypePrim <$> sStdType
      <|> TypeObj  <$> sUpperId

pType :: Parser Token Type
pType = foldr (const TypeArray) 
        <$> pType0 
        <*> many (bracketed (succeed ()))


pDecl :: Parser Token Decl 
pDecl = Decl
        <$> pType
        <*> sLowerId
        
pDeclSemi :: Parser Token Decl 
pDeclSemi = const <$> pDecl <*> sSemi

pClass :: Parser Token Class
pClass = Class
        <$  symbol KeyClass
        <*> sUpperId
        <*> braced ( many pMember )
