let chrisTest test =
    test "Chris"

let notChrisTest test =
    test "NotChris"

let isMe x =
    if x = "Chris" then
        "yeah!"
    else
        "Nah!"

chrisTest isMe
notChrisTest isMe

let add = (fun x y -> x + y)

let twoTest = (fun x -> x < 0)

let lastOne test = 
    test 2

lastOne (fun x -> x > 0)

lastOne (fun x -> x = 1)

let applyFuncs func1 func2 = 
    func1 func2

// val applyFuncs : func1:('a -> 'b) -> func2:'a -> 'b
// what is going on here?  applyFuncs is a higher order function
// which takes two arguments:
// func1: a function which takes a generic input 'a and returns a generic output 'b
// func2: must resolve to a value of generic type 'a, which becomes the input for func1

let add5ToInteger x = 
    x + 5
// Here's a function that satisfies the above - it takes an int and returns an int
// val add5ToInteger : x:int -> int

applyFuncs add5ToInteger 4
// so this works because add5ToInteger has signature (int -> int) - 
// it takes an int parameter and returns an int parameter
// and in this case, func2 is simply the value 4

// and donewithstring works because its signature is (string -> bool)
let isStringWinner x=
    x = "winner"

applyFuncs isStringWinner "loser"
applyFuncs isStringWinner "winner"

// However - here's a function that takes two integers and returns an int
let addTwoIntegers x y =
    x + y
// val addTwoIntegers : x:int -> y:int -> int

applyFuncs addTwoIntegers 2 3
// so does addTwoIntegers work because applyFuncs resolves the second argument
// to that function, the value 3, as the output of the func2 "function"
// or does it see func2 as a no-op and simply resolve addTwoIntegers 2 3
// as func1?
let returnThree = 3
// I would surmise that the value 3 is the same as a function that 
// returns the static value 3 - therefore any let statement is actually
// a function definition - in other words, there are no values, only
// functions.  So these are equivalent and legal:
applyFuncs addTwoIntegers 2 3
applyFuncs addTwoIntegers 2 returnThree
applyFuncs addTwoIntegers returnThree 2
applyFuncs addTwoIntegers returnThree (addTwoIntegers 2 3)
// (and in fact, applyFuncs doesn't add much here - it only constrains the rules of
// how the following functions are called)
addTwoIntegers 2 3
addTwoIntegers 2 returnThree
addTwoIntegers returnThree 2
addTwoIntegers returnThree (addTwoIntegers 2 3)

// One last thought - how far can this be taken?
let applyMoreFuncs fn1 fn2 fn3 =
    fn1 fn2 fn3
// Is the above a declaration of a function that takes three functions?
// The first parameter, fn1, takes two generic arguments, a' and b', 
// and returns a generic value 'c; but the other two parameters are 
// functions that take no parameters and return values of type a' and b' 
// respectively (the types required by fn1)
// val applyMoreFuncs : fn1:('a -> 'b -> 'c) -> fn2:'a -> fn3:'b -> 'c

// So:
let thisFits x y =
    x + y
// val thisFits : x:int -> y:int -> int
applyMoreFuncs thisFits 2 3

let thisAlsoFits x y = 
    printf "%s %s" x y
// val thisAlsoFits : x:string -> y:string -> unit
applyMoreFuncs thisAlsoFits "concatenation" "works"

// But this is illegal, as add5ToInteger does not take enough arguments
applyMoreFuncs add5ToInteger 5 5
// Of course, you can always use an anonymous function as an argument
// instead, provided that the definition matches what's expected
applyMoreFuncs (fun x y -> add5ToInteger (x + y)) 5 3
