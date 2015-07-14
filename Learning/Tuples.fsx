// Tuples
let x = (1, "hello")
let (a, b) = x
let c = fst(x)
let d = snd(x)
let print' tuple = 
    match tuple with
    | (a,b) -> printfn "%A %A" a b

print' x
let y = (1, 2, "a")
print' y

// Brackets not compulsory
let unbracketed = 1, 2, 3, 4, 5

// Partial unbinding
let t = (1,2,3)
let one, _, three = t
