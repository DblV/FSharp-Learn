// Record types - immutable by default

type Book = {
    Name:string;
    AuthorName: string;
    Rating: int;
    ISBN: string}

let aBook = 
    {Name = "The Book Name";
    AuthorName = "Mr Book Writer";
    Rating = 5;
    ISBN = "1234567890"}

let sequel = { 
    aBook with Name = "The Book Sequel"; Rating = 2}

type SpecialBook = {
    Name:string;
    AuthorName:string;
    Rating:string;
    ISBN:string;}

let anotherBook = 
    {Name = "The Book Name";
    AuthorName = "Mr Book Writer";
    Book.Rating = 5;
    ISBN = "1234567890"}

let thisBook = {
    Name = "some book";
    AuthorName = "some writer";
    SpecialBook.Rating = "3 1/2";
    ISBN = "654654"}

type PossiblyRatedBook = {
    Name:string;
    AuthorName:string;
    Rating:int option;
    ISBN:string;}

let unratedBook = {
    Name = "some book";
    AuthorName = "some writer";
    Rating = None;
    ISBN = "654654"}

let getRating book = 
    match book.Rating with
    | Some rating ->
        printfn "I gave this book %i" rating
    | None -> printfn "I didn't rate this book"

getRating unratedBook
getRating thisBook

// Property extraction (like ECMA6!)
let { Name = justTheName } = aBook

// Equality
let aBook2 = aBook
aBook = sequel
aBook = aBook2

// Comparisons

// Pretty printing
printf "%A" aBook