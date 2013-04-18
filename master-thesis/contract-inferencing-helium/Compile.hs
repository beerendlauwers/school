-----------------------------------------------------------------------------
-- Copyright 2011, Open Universiteit Nederland. This file is distributed 
-- under the terms of the GNU General Public License. For more information, 
-- see the file "LICENSE.txt", which is included in the distribution.
-----------------------------------------------------------------------------
-- |
-- Maintainer  :  alex.gerdes@ou.nl
-- Stability   :  provisional
-- Portability :  unknown
--
--
-----------------------------------------------------------------------------

module Domain.FP.Compile
   ( -- * Compile functions
     compile, safeCompile, compilePrelude, compileWithRanges, safeCompileWithRanges
   ) where

import Common.Library
import qualified Domain.FP.Helium as H
import Domain.FP.Syntax
import Domain.FP.SyntaxWithRanges
import Domain.FP.Views


-- | Compile using Helium and convert to simpler abstract syntax
safeCompile :: String -> Either String Module
safeCompile txt = H.compile txt >>= matchM heliumView

-- | the compiler/parser
compile :: String -> Module
compile txt = either error id $ safeCompile txt

compilePrelude :: String -> Module
compilePrelude txt = 
  either error id $ H.compilePrelude txt >>= matchM heliumView

compileWithRanges :: String -> ModuleR
compileWithRanges txt = either error id $ safeCompileWithRanges txt

safeCompileWithRanges :: String -> Either String ModuleR
safeCompileWithRanges txt = H.compile txt >>= matchM heliumView