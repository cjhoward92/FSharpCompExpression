// Learn more about F# at http://fsharp.org

open System
open Maybe

module Program =
    let maybeAdd num y = Just(num + y)

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
        0 // return an integer exit code