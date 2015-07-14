
// We've seen this already, in the discriminated union examples
let add x y = x + y
let add1 = add 1
add1 2

let isEven x =
    x % 2 = 0
let whereEven aSeq = Seq.where isEven aSeq
let searchEven aSeq = Seq.filter (fun v -> v % 2 = 0) aSeq

// let searchEven = Seq.where (fun v -> v % 2 = 0)
// This does not compile - the last argument has to be specified

printfn "%d even numbers in 1-100"
    ([1..100] |> searchEven |> Seq.length)

let subtract x y = x - y

subtract 5 3 

let subtractFrom1 = subtract 1

subtractFrom1 3

let swap f x y = f y x

let subtract1 = swap subtract 1
subtract1 5

swap subtract 3 5