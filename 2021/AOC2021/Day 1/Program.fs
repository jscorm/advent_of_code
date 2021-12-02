printfn "Advent of Code 2021 - Day 1"

let nums = System.IO.File.ReadLines("../../../input.txt") |> Seq.map int

//Part 1
printfn "\nPart 1"
let answer1 = Seq.pairwise nums 
           |> Seq.where (fun (a, b) -> b > a) 
           |> Seq.length
printfn($"The depth measurement increases {answer1} times.")

//Part 2
printfn "\nPart 2"
let sumArray array = Array.fold (+) 0 array
let answer2 = Seq.windowed 3 nums //Part one can also be solved by passing 1 instead of 3
           |> Seq.pairwise 
           |> Seq.where (fun (a, b) -> sumArray b > sumArray a)
           |> Seq.length
printfn($"The sum of measurements in the sliding windows increases {answer2} times.")