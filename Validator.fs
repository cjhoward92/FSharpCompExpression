module Validator
    type ValidationError = {
        FieldName: string;
        ErrorMessage: string;
    }

    type Validation<'T> =
        | Valid of 'T
        | Invalid of list<ValidationError> * 'T
    

    let private bind m fn =
        printfn "Binding %A with %A" m fn
        match m with
        | Valid value -> fn value
        | _ -> m
     
    let private combine m n =
        printfn "Combinding %A and %A" m n
        match (m, n) with
        | (Invalid (errors, v), Invalid (moreErrors, _)) -> Invalid (List.append errors moreErrors, v)
        | (Valid v, Valid _) -> Valid v
        | (_, Invalid (errors, v)) -> Invalid (errors, v)
        | (Invalid (errors, v), _) -> Invalid (errors, v)

    type ValidationBuilder() =
        member x.Bind(m, fn) = bind m fn
        member x.Return(v) = Valid v
        member x.ReturnFrom(m) = m
        member x.Yield(v) = Valid v
        member x.YieldFrom(m) = m
        member x.Combine(m, n) = combine m n
        member x.Delay(f) = 
            printfn "Delaying %A" f
            f()
    
    let validation = new ValidationBuilder()
