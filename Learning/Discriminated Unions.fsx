type PowerUp = 
    | FireFlower
    | Mushroom
    | Star


let m = Mushroom
let p = FireFlower
let s = Star

let getPowerUp powerUp = 
    match powerUp with
    | FireFlower -> "Hot hot hot!"
    | Mushroom -> "Woop woop woop!" 
    | Star -> "Doo doo doo do-do-do-do-doo doo!"

getPowerUp m

type MushroomColour = 
    | Green
    | Red 
    | Purple

type NewPowerUp = 
    | FireFlower
    | Mushroom of MushroomColour
    | Star of int

let f = FireFlower
let m1 = Mushroom
m1 Red
let s1 = Star
s1 3
let s2 = Star 2

// Order & rank
type Suit = Heart | Diamond | Club | Spade
type Deck = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace
let aceHearts = Ace, Heart
let fiveHearts = Five, Heart
aceHearts > fiveHearts
let aceClub = Ace, Club
aceHearts < aceClub

// Bonus!
let hand = [ Ace,Club; Three,Heart; Ace,Heart; Jack,Spade; Two,Diamond; Ace,Diamond ]
List.min hand
List.max hand
List.sort hand