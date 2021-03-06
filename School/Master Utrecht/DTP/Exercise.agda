module Exercise where

{- Instruction: Fill in all the missing definitions. In most cases,
the type signature enforces that there should be a single unique
definition that fits. 

If you have any questions, don't hesitate to email me.
-}


---------------------
------ Prelude ------
---------------------

data Nat : Set where
  Zero : Nat 
  Succ : Nat -> Nat

{-# BUILTIN NATURAL Nat #-}
{-# BUILTIN SUC Succ #-}
{-# BUILTIN ZERO Zero #-}

_+_ : Nat -> Nat -> Nat
Zero + m = m
Succ k + m = Succ (k + m)

_*_ : Nat -> Nat -> Nat
Zero * n = Zero
(Succ k) * n = n + (k * n)

data Vec (a : Set) : Nat -> Set where
  Nil : Vec a 0
  Cons : {n : Nat} -> (x : a) -> (xs : Vec a n) -> Vec a (Succ n)

head : {a : Set} {n : Nat}-> Vec a (Succ n) -> a
head (Cons x xs) = x

append : {a : Set} {n m : Nat} -> Vec a n -> Vec a m -> Vec a (n + m)
append Nil ys = ys
append (Cons x xs) ys = Cons x (append xs ys)

data _==_ {a : Set} (x : a) : a -> Set where
  Refl : x == x

cong : {a b : Set} {x y : a} -> (f : a -> b) -> x == y -> f x == f y
cong f Refl = Refl

data Fin : Nat -> Set where
  Fz : forall {n} -> Fin (Succ n)
  Fs : forall {n} -> Fin n -> Fin (Succ n)

data Either (a b : Set) : Set where
  Inl : a -> Either a b
  Inr : b -> Either a b

----------------------
----- Exercise 1 -----
----------------------

--Show that the Vec a n type is applicative

pure : {n : Nat} {a : Set} -> a -> Vec a n
pure {Zero} a = Nil
pure {Succ y} a = Cons a (pure a)

_<*>_ : {a b : Set} {n : Nat} -> Vec (a -> b) n -> Vec a n -> Vec b n
Nil <*> xs = Nil
Cons f fs <*> Cons x xs = Cons (f x) (fs <*> xs)

vmap : {a b : Set} {n : Nat} -> (a -> b) -> Vec a n -> Vec b n
vmap f Nil = Nil
vmap f (Cons x xs) = Cons (f x) (vmap f xs)

----------------------
----- Exercise 2 -----
----------------------

-- Using the Vector definitions, define a type for matrices;
-- matrix addition; the identity matrix; and matrix transposition.

Matrix : Set -> Nat -> Nat -> Set
Matrix A n m = Vec (Vec A n) m

vadd : {A : Set} { n : Nat} -> (A -> A -> A) -> Vec A n -> Vec A n -> Vec A n
vadd f xs ys = {!!} 

-- Define matrix addition
madd : {n m : Nat} -> Matrix Nat m n -> Matrix Nat m n -> Matrix Nat m n
madd Nil Nil = Nil
madd (Cons Nil xs) (Cons y ys) = Cons y (madd xs ys)
madd (Cons (Cons x xs) xss) (Cons (Cons y ys) yss) = Cons (Cons (x + y) xs) (madd xss yss)


-- Define the identity matrix
idMatrix : {n : Nat} -> Matrix Nat n n
idMatrix {Zero} = Nil
idMatrix {Succ y} = {!!}

-- Define matrix transposition
transpose : {n m : Nat} {a : Set} -> Matrix a m n -> Matrix a n m
transpose Nil = {!!}
transpose (Cons x xs) = {!!}
  
----------------------
----- Exercise 3 -----
----------------------

-- Define a few functions manipulating finite types.

-- The result of "plan {n}" should be a vector of length n storing all
-- the inhabitants of Fin n in increasing order.
plan : {n : Nat} -> Vec (Fin n) n
plan {Zero} = Nil
plan {Succ y} = Cons Fz (vmap Fs plan)

-- Define a forgetful map, mapping Fin to Nat
forget : {n : Nat} -> Fin n -> Nat
forget Fz = 0
forget (Fs y) = Succ( forget y )

-- There are several ways to embed Fin n in Fin (Succ n).  Try to come
-- up with one that satisfies the correctness property below (and
-- prove that it does).
embed : {n : Nat} -> Fin n -> Fin (Succ n)
embed Fz = Fz
embed (Fs y) = Fs (embed y) 

correct : {n : Nat} -> (i : Fin n) -> forget i == forget (embed i)
correct Fz = Refl
correct (Fs y) = {! !}

----------------------
----- Exercise 4 -----
----------------------

-- Given the following data type definition:

data Compare : Nat -> Nat -> Set where
  LessThan : forall {n} k -> Compare n (n + Succ k)
  Equal : forall {n} -> Compare n n
  GreaterThan : forall {n} k -> Compare (n + Succ k) n

-- Show that there is a 'covering function'
cmp : (n m : Nat) -> Compare n m 
cmp Zero Zero = Equal
cmp Zero (Succ m) = LessThan m
cmp (Succ n) Zero = GreaterThan n
cmp (Succ n) (Succ m) with cmp n m
cmp (Succ n) (Succ .n) | Equal = Equal
cmp (Succ n) (Succ .(n + Succ k)) | LessThan k = LessThan k
cmp (Succ .(n + Succ k)) (Succ n) | GreaterThan k = GreaterThan k 

-- Use the cmp function you defined above to define the absolute
-- difference between two natural numbers.
difference : (n m : Nat) -> Nat
difference n m with cmp n m
difference n .(n + Succ k) | LessThan k = k
difference .(n + Succ k) n | GreaterThan k = k
difference n .n | Equal = Zero

----------------------
----- Exercise 5 -----
----------------------

-- Show that you can always inject a Fin m (or Fin n) into a Fin (m + n)
inl : {n : Nat} -> (m : Nat) -> Fin m -> Fin (m + n)
inl Zero ()
inl (Succ n) Fz = Fz
inl (Succ n) (Fs y) = Fs (inl n y)
inr : {n : Nat} -> (m : Nat) -> Fin n -> Fin (m + n)
inr Zero fin = fin
inr (Succ n) Fz = Fz
inr (Succ n) (Fs y) = Fs (inr n (Fs y))

-- Define another function that shows how to take a Fin (m + n) apart
-- into either a Fin m or a Fin n.
view : {n : Nat} -> (m : Nat) -> (i : Fin (m + n)) -> Either (Fin m) (Fin n)
view {Zero} m i = {!Inl i!} -- m + 0 != m, pfff
view {n} Zero i = Inr i
view {Succ n} (Succ m) i = {!!}

----------------------
----- Exercise 6 -----
----------------------

-- (Hard): Use the view on Fin from exercise 5 to show that Fin to
--   define a new view proving that Fin is closed under products.
--   Defining such a view requires you to finish the following data
--   type definition and function.

-- To help you get started, here is a function you will need to use.
pair : {m n : Nat} -> Fin n -> Fin m -> Fin (n * m)
pair {m} Fz j = inl m j
pair {m} (Fs i) j = inr m (pair i j)

data MultView (m n : Nat) : Fin (m * n) -> Set where
-- Define constructor(s)

mview : {n : Nat} -> (m : Nat) -> (i : Fin (m * n)) -> MultView m n i
mview = {!!}

-- Use this view to define the following two functions:

fst : forall {m n} -> Fin (m * n) -> Fin m
fst i = {!!}

snd : forall {m n} -> Fin (m * n) -> Fin n
snd i = {!!}