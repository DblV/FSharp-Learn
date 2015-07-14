// A list in F# is an ordered, immutable series of elements of the same type (or which derive from the same base type).
let empty = []
let basic = [1;2;3;4;5]

// Lists use square brackets and `;` delimiter (or whitespace)
let list1 = [ "a"; "b" ]
let alternativeList1 = [
    "a"
    "b"]
// :: is prepending
let list2 = "c" :: list1
// @ is concatenation
let list3 = list1 @ list2   


// Use range (..) syntax to define a range of values during initialisation
let firstHundred = [0..100]

let evens = [2;4;6;8]
// Can also control sequence application rules
let alternativelyEvens = [2..2..100]

// Can also define lists using looping construct
let loopedInit = [for i in 0 .. 10 -> i * 3]



// List functions
let doubled = List.map (fun x -> x * 2) firstHundred

// Nested...
List.map (fun x -> x * 2)
    (List.filter (fun x -> x % 2 = 0) firstHundred)
// == piplined:
[0..100]
|> List.filter (fun x -> x % 2 = 0)
|> List.map (fun x -> x * 2)
|> List.sum

//"Date,Open,High,Low,Close,Volume,Adj Close"
let stockData =
    [ 
      "2012-03-30,32.40,32.41,32.04,32.26,31749400,32.26";
      "2012-03-29,32.06,32.19,31.81,32.12,37038500,32.12";
      "2012-03-28,32.52,32.70,32.04,32.19,41344800,32.19";
      "2012-03-27,32.65,32.70,32.40,32.52,36274900,32.52";
      "2012-03-26,32.19,32.61,32.15,32.59,36758300,32.59";
      "2012-03-23,32.10,32.11,31.72,32.01,35912200,32.01";
      "2012-03-22,31.81,32.09,31.79,32.00,31749500,32.00";
      "2012-03-21,31.96,32.15,31.82,31.91,37928600,31.91";
      "2012-03-20,32.10,32.15,31.74,31.99,41566800,31.99";
      "2012-03-19,32.54,32.61,32.15,32.20,44789200,32.20";
      "2012-03-16,32.91,32.95,32.50,32.60,65626400,32.60";
      "2012-03-15,32.79,32.94,32.58,32.85,49068300,32.85";
      "2012-03-14,32.53,32.88,32.49,32.77,41986900,32.77";
      "2012-03-13,32.24,32.69,32.15,32.67,48951700,32.67";
      "2012-03-12,31.97,32.20,31.82,32.04,34073600,32.04";
      "2012-03-09,32.10,32.16,31.92,31.99,34628400,31.99";
      "2012-03-08,32.04,32.21,31.90,32.01,36747400,32.01";
      "2012-03-07,31.67,31.92,31.53,31.84,34340400,31.84";
      "2012-03-06,31.54,31.98,31.49,31.56,51932900,31.56";
      "2012-03-05,32.01,32.05,31.62,31.80,45240000,31.80";
      "2012-03-02,32.31,32.44,32.00,32.08,47314200,32.08";
      "2012-03-01,31.93,32.39,31.85,32.29,77344100,32.29";
      "2012-02-29,31.89,32.00,31.61,31.74,59323600,31.74"; ]

let splitCommas (x:string) =
    x.Split([|','|])

stockData
|> List.map splitCommas
|> List.maxBy (fun x -> abs(float x.[1] - float x.[4]))
|> (fun x -> x.[0])


// Recursion on list using (::) operator to pop the head off the list
let rec sum list = 
    match list with
    | [] -> 0
    | x :: xs -> x + sum xs

sum [1..5]


// Recursive function using :: to pop the head off a list
let input = [ (1., 2., 0.); (2., 1., 1.); (3., 0., 1.) ]
let rec search lst =
  match lst with
  | (1., _, z) :: tail ->       // _ is wildcard match
      printfn "found x=1. and z=%f" z; search tail
  | (2., _, _) :: tail ->       // Can use wildcard for multiple arguments
      printfn "found x=2."; search tail
  | _ :: tail -> search tail
  | [] -> printfn "done."
search input


// Arrays:
// - fixed size
// - mutable
// - consecutive
// - all elements of same type
let ar1 = [|"a";"b"|]
// - zero-based indexed access
ar1.[0]

// MUTABLE!
ar1.[0] <- "d"

// Slice notation to access a subrange of the array
ar1.[0..2]
ar1.[..1]
ar1.[1..]


let xs2 = Array.fold (fun str n -> 
            sprintf "%s,%i" str n) "" [| 0..9 |]

// Type of array is .NET Array


// Multidimensional array:
let md = [|[|0..3|];[|0..3|]|]
md.[0].[0]
// Convert to 2D array
let twod = Array2D.init 2 md.[0].Length (fun x y -> md.[x].[y])

// Sequences 
// A sequence is a logical series of elements all of one type.
// Sequence items are only generated on demand
// => better in situations where you have a large collection of data but do not intend to use all of it
// Sequences are IEnumerable<T>, so will be used when you are converting between C# and F# enumerable types

// Array vs seq vs list initialisation comparison
let lstInitRange = [ 1..2..9 ]
let arrInitRange = [|1..2..9|]
let seqInitRange = seq { 1..2..9 }  // or just { 1..2..9 }

let lstInitLoop = [ for i in 0..4 -> 2 * i + 1 ]
let arrInitLoop = [| for i in 0..4 -> 2 * i + 1 |]
let seqInitLoop = seq { for i in 0..4 do yield 2 * i + 1 }  // equivalent to seq { for i in 0..4 -> 2 * i + 1 }

let lstInitFn = List.init 5 (fun i -> 2 * i + 1)
let arrInitFn = Array.init 5 (fun i -> 2 * i + 1)
let seqInitFn = Seq.init 5 (fun i -> 2 * i + 1)
