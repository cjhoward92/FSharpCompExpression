module Maybe
    type Maybe<'T> =
        | Just of 'T
        | Nothing
   
    let private bind comp fn =
        match comp with
        | Just value -> fn value
        | _ -> Nothing
    
    let private result r = Just r

    let private resultFrom (r: Maybe<'T>) = r

    type MaybeBuilder() =
        member x.Bind(comp, func) = bind comp func
        member x.Return(r) = result r
        member x.ReturnFrom(r) = resultFrom r
    
    let maybe = new MaybeBuilder()
 