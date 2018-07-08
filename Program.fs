// Learn more about F# at http://fsharp.org

open System
open Maybe
open Validator

module Program =
    let maybeAdd num y = Just(num + y)

    let validateNumber x =
        if x < 10 then 
            printfn "This value is less than 10"
            Valid x 
        else 
            Invalid ([{ FieldName = "number"; ErrorMessage = "Number value is too high!"}], x)
     
    let validateEvenOrOdd x =
        if x % 2 = 0 then
            printfn "This value is even"
            Valid x
        else
            Invalid ([{ FieldName = "number"; ErrorMessage = "Number is odd!"}], x)

    [<EntryPoint>]
    let main argv =
        printfn "Hello World from F#!"

        maybe {
            let! m = Just(10)
            let! x = maybeAdd m 10
            return x
        } |> printfn "Value is %A"

        maybe {
            let! m = Nothing
            let! n = maybeAdd m 10
            return n
        } |> printfn "Value is %A"

        validation {
            yield! validateNumber 11
            yield! validateEvenOrOdd 11
        } |> printfn "Is the number valid %A"
        0 // return an integer exit code