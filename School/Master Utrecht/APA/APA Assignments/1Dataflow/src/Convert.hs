module Convert where

import Attributes as D
import HJS.Parser.JavaScript as J

import Data.Bifunctor

cLiteral (J.LitInt v) = D.LitInt v
cLiteral (J.LitString v) = D.LitString v
cLiteral (J.LitNull) = D.LitNull
cLiteral (J.LitBool b) = D.LitBool b

cPrimExpr (J.Literal l) = D.Literal (cLiteral l)
cPrimExpr (J.Ident i) = D.Ident i
cPrimExpr (J.Brack e) = D.Brack (cExpr e)
cPrimExpr (J.This) = D.This
cPrimExpr (J.Regex (m,r)) = D.Regex m r
cPrimExpr (J.Array a) = D.Array (cArrayLit a)
cPrimExpr (J.Object o) = D.Object (map (bimap (bimap cPropName cAssignE) cGetterPutter) o)
cPrimExpr (J.PEFuncDecl f) = D.PEFuncDecl (cFuncDecl f)

cGetterPutter (J.GetterPutter pn fd) = D.GetterPutter (cPropName pn) (cFuncDecl fd)
cGetterPutter (J.Putter fd) = D.Putter (cFuncDecl fd)

cPropName (J.PropNameId pn) = D.PropNameId pn
cPropName (J.PropNameStr pn) = D.PropNameStr pn
cPropName (J.PropNameInt pn) = D.PropNameInt pn

cArrayLit (J.ArrSimple ael) = D.ArrSimple (map cAssignE ael)

cMemberExpr (J.MemPrimExpr pe) = D.MemPrimExpr (cPrimExpr pe)
cMemberExpr (J.ArrayExpr me e) = D.ArrayExpr (cMemberExpr me) (cExpr e)
cMemberExpr (J.MemberNew me ael) = D.MemberNew (cMemberExpr me) (map cAssignE ael)
cMemberExpr (J.MemberCall me s) = D.MemberCall (cMemberExpr me) s
cMemberExpr (J.MemberCall2 me me2) = D.MemberCall2 (cMemberExpr me) (cMemberExpr me2)

cCallExpr (J.CallPrim me) = D.CallPrim (cMemberExpr me)
cCallExpr (J.CallMember me ael) = D.CallMember (cMemberExpr me) (map cAssignE ael)
cCallExpr (J.CallCall ce ael) = D.CallCall (cCallExpr ce) (map cAssignE ael)
cCallExpr (J.CallSquare ce e) = D.CallSquare (cCallExpr ce) (cExpr e)
cCallExpr (J.CallDot ce s) = D.CallDot (cCallExpr ce) s

cNewExpr (J.MemberExpr me) = D.MemberExpr (cMemberExpr me)
cNewExpr (J.NewNewExpr ne) = D.NewNewExpr (cNewExpr ne)

cLeftExpr (J.NewExpr ne) = D.NewExpr (cNewExpr ne)
cLeftExpr (J.CallExpr ce) = D.CallExpr (cCallExpr ce)

cPostFix (J.LeftExpr le) = D.LeftExpr (cLeftExpr le)
cPostFix (J.PostInc le) = D.POp "_++" (cLeftExpr le)
cPostFix (J.PostDec le) = D.POp "_--" (cLeftExpr le)

cUExpr (J.PostFix pf) = D.PostFix (cPostFix pf)
cUExpr (J.Delete ue) = D.UOp "delete" (cUExpr ue)
cUExpr (J.Void ue) = D.UOp "void" (cUExpr ue)
cUExpr (J.TypeOf ue) = D.UOp "typeof" (cUExpr ue)
cUExpr (J.DoublePlus ue) = D.UOp "++_" (cUExpr ue)
cUExpr (J.DoubleMinus ue) = D.UOp "--_" (cUExpr ue)
cUExpr (J.UnaryPlus ue) = D.UOp "+_" (cUExpr ue)
cUExpr (J.UnaryMinus ue) = D.UOp "-_" (cUExpr ue)
cUExpr (J.Not ue) = D.UOp "!" (cUExpr ue)
cUExpr (J.BitNot ue) = D.UOp "~" (cUExpr ue)

cAExpr (J.AEUExpr ue) = D.AEUExpr (cUExpr ue)
cAExpr (J.AOp i ae1 ae2) = D.AOp i (cAExpr ae1) (cAExpr ae2)

cCondE (J.AExpr ae) = D.AExpr (cAExpr ae)
cCondE (J.CondIf ae a1 a2) = D.CondIf (cAExpr ae) (cAssignE a1) (cAssignE a2)

cAssignOp (J.AssignNormal) = "="
cAssignOp (J.AssignOpMult) = "*="
cAssignOp (J.AssignOpDiv) = "/="
cAssignOp (J.AssignOpMod) = "%="
cAssignOp (J.AssignOpPlus) = "+="
cAssignOp (J.AssignOpMinus) = "-="

cAssignE (J.CondE ce) = D.CondE (cCondE ce)
cAssignE (J.Assign le op ae) = D.Assign (cLeftExpr le) (cAssignOp op) (cAssignE ae)

cExpr (J.AssignE ae) = D.AssignE (cAssignE ae)

cVarDecl (J.VarDecl i aem) = D.VarDecl i (fmap cAssignE aem)

cIfStmt (J.IfElse e s1 s2) = D.IfElse (cExpr e) (cStmt s1) (cStmt s2)
cIfStmt (J.IfOnly e s1) = D.IfOnly (cExpr e) (cStmt s1)
cIfStmt _ = error "I'm not generated by the parser, so how do I exist?"

cItStmt (J.DoWhile s e) = D.DoWhile (cStmt s) (cExpr e)
cItStmt (J.While e s) = D.While (cExpr e) (cStmt s)
cItStmt (J.For em1 em2 em3 s) = error "I'm not generated by the parser, so how do I exist?"
cItStmt (J.ForVar vdl em1 em2 s) = D.ForVar (map cVarDecl vdl) (fmap cExpr em1) (fmap cExpr em2) (cStmt s)
cItStmt (J.ForIn le e s) = D.ForIn (cLeftExpr le) (cExpr e) (cStmt s)
cItStmt (J.It2 e) = error "I'm not generated by the parser, so how do I exist?"

cTryStmt (J.TryBC b c) = error "I'm not generated by the parser, so how do I exist?"
cTryStmt (J.TryBF b f) = error "I'm not generated by the parser, so how do I exist?"
cTryStmt (J.TryBCF b c f) = error "I'm not generated by the parser, so how do I exist?"
cTryStmt (J.TryTry b c f) = D.TryTry (map cStmt b) (map cCatch c) (map cStmt f)

cCatch (J.Catch i s) = error "I'm not generated by the parser, so how do I exist?"
cCatch (J.CatchIf i s e) = error "I'm not generated by the parser, so how do I exist?"
cCatch (J.CatchCatch i me s) = D.CatchCatch i (fmap cExpr me) (map cStmt s)

cStmt (J.StmtPos (l,c) s) = D.StmtPos l c (cStmt' s)

cStmt' (J.IfStmt s) = D.IfStmt (cIfStmt s)
cStmt' (J.EmptyStmt) = D.EmptyStmt
cStmt' (J.ExprStmt e) = D.ExprStmt (cExpr e)
cStmt' (J.ItStmt is) = D.ItStmt (cItStmt is)
cStmt' (J.Block s) = D.Block (map cStmt s)
cStmt' (J.VarStmt vd) = D.VarStmt (map cVarDecl vd)
cStmt' (J.TryStmt ts) = D.TryStmt (cTryStmt ts)
cStmt' (J.ContStmt sm) = D.ContStmt sm
cStmt' (J.BreakStmt sm) = D.BreakStmt sm
cStmt' (J.ReturnStmt em) = D.ReturnStmt (fmap cExpr em)
cStmt' (J.WithStmt e s) = D.WithStmt (cExpr e) (cStmt s)
cStmt' (J.LabelledStmt l s) = D.LabelledStmt l (cStmt s)
cStmt' (J.Switch e cc) = D.Switch (cExpr e) (map cCauseClause cc)
cStmt' (J.ThrowExpr e) = D.ThrowExpr (cExpr e)

cCauseClause (J.CaseClause e s) = D.CaseClause (cExpr e) (map cStmt s)
cCauseClause (J.DefaultClause s) = D.DefaultClause (map cStmt s)

cFuncDecl (J.FuncDecl sm ss se) = D.FuncDecl sm ss (map cSourceElement se)

cSourceElement (J.Stmt s) = D.Stmt (cStmt s)
cSourceElement (J.SEFuncDecl fd) = D.SEFuncDecl (cFuncDecl fd)

cJSProgram (J.JSProgram se) = D.JSProgram (map cSourceElement se)









