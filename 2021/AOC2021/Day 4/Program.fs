(*
    *****************************************************
    This solution is not working, the problem was solved
    with the "Day 4 CS" project using C#. I decided to
    keep it to maybe come back and fix it later.
    *****************************************************
*)
printfn "Advent of Code 2021 - Day 4"

type CardNumber = 
    val Number: int
    val mutable Marked: bool
    new(number:int) = {Number = number; Marked = false}

    member this.mark() = this.Marked <- true

type BingoCard = 
    val mutable Numbers: CardNumber[,]
    new(numbers:string[]) = 
        let mutable cardNumbers = Array2D.zeroCreate 5 5
        for i in 0..4 do
            let rowNumbers = numbers[i].Split(" ") |> Array.where (fun s -> s <> "")
            for j in 0..4 do
                cardNumbers.SetValue(new CardNumber(int rowNumbers[j]), i, j)
        {Numbers = cardNumbers}

    member this.Winned() =
        let mutable winned = false
        for i in 0..4 do
            if(Seq.forall (fun (cardNumber:CardNumber) -> cardNumber.Marked) this.Numbers[i,*]) then winned <- true
        for j in 0..4 do
            if(Seq.forall (fun (cardNumber:CardNumber) -> cardNumber.Marked) this.Numbers[*,j]) then winned <- true
        winned

    member this.mark(num:int) =
        for i in 0..4 do
            for j in 0..4 do
                if(this.Numbers[i,j].Number = num) then 
                    this.Numbers[i,j].mark()

    member this.sumOfUnmark() =
        let mutable sum = 0
        for i in 0..4 do
            for j in 0..4 do
                if not this.Numbers[i,j].Marked then sum <- sum + 1
        sum

let input = System.IO.File.ReadLines("../../../input.txt") |> Seq.map string
let drawnNumbersString = Seq.head input
let drawnNumbers = drawnNumbersString.Split(",") |> Seq.map int
let remainingInput = Seq.removeAt 0 input
let bingoCards = Seq.where (fun s -> s <> "") remainingInput |> Seq.chunkBySize 5 |> Seq.map (fun s -> new BingoCard(s))

//Part 1
printfn "\nPart 1"
let mutable gameOver = false
let mutable winningCard = None
let mutable lastDrawn = 0
for drawn in drawnNumbers do
    for card in bingoCards do 
        card.mark(drawn)
        if(not gameOver && card.Winned()) then
            winningCard <- Some(card)
            lastDrawn <- drawn
            gameOver <- true

let sum = winningCard.Value.sumOfUnmark()
printfn($"Answer: {sum * lastDrawn}")


