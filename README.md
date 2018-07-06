# FSharp Computation Expressions

This is a test repo to try out Computation Expressions in F#, so I can build a deeper understanding. I understand Monads in the Haskell sense, and Computation Expressions are Monads in F#. Understanding how they work isn't a big deal but I needed to try it out myself to really understand.

## Building and Running

Simply run the following after cloning:

`dotnet build`  
`dotnet run`  

This should be with `dotnet --version > 2.1`

## Example Monad

See the `Maybe.fs` file for an example of a simple monad, `Maybe`. `Maybe` has two potential union types, `Just of T` and `Nothing`. When a maybe value is `Nothing`, then all further function invocations should also end up as `Nothing`.

To use, simple `open Maybe` then use the `maybe {}` expression as seen in `Program.fs`