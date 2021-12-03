printfn "Advent of Code 2021 - Day 3"

let inputs = System.IO.File.ReadLines("../../../input.txt")

//Part 1
printfn "\nPart 1"
let getBinGammaRate binNums = 
    let mutable buff = ""
    for i in 0 .. (String.length (Seq.head binNums) - 1) do
        let onesCount = Seq.where(fun (bin:string) -> bin[i] = '1') binNums |> Seq.length
        buff <- if(onesCount > Seq.length binNums / 2) then buff + "1" else buff + "0"
    buff

let reverseBits bin =
    String.map (fun b -> if b = '0' then '1' else '0')

let binGammaRate = getBinGammaRate inputs
let decGammaRate = uint ("0b" + binGammaRate)
let binEpsilonRate = String.map (fun b -> if b = '0' then '1' else '0') binGammaRate
let decEpsilonRate = uint ("0b" + binEpsilonRate)
printfn($"Gamma rate: {binGammaRate} => {decGammaRate} | Epsilon rate: {binEpsilonRate} => {decEpsilonRate} | Answer: {decGammaRate * decEpsilonRate}")

//Part 2
printfn "\nPart 2"

let rec getBinO2GenRating binNums pos =
    if Seq.length binNums = 1 
        then Seq.head binNums
    else
        let onesCount = Seq.where(fun (bin:string) -> bin[pos] = '1') binNums |> Seq.length
        let zeroesCount = Seq.length binNums - onesCount
        let mostCommonBit = if(onesCount >= zeroesCount) then '1' else '0'
        getBinO2GenRating (Seq.where(fun (bin:string) -> bin[pos] = mostCommonBit) binNums) (pos + 1)

let rec getBinCO2ScrubRating binNums pos =
    if Seq.length binNums = 1 
        then Seq.head binNums
    else
        let onesCount = Seq.where(fun (bin:string) -> bin[pos] = '1') binNums |> Seq.length
        let zeroesCount = Seq.length binNums - onesCount
        let leastCommonBit = if(onesCount >= zeroesCount) then '0' else '1'
        getBinCO2ScrubRating (Seq.where(fun (bin:string) -> bin[pos] = leastCommonBit) binNums) (pos + 1)

let binO2GenRating = getBinO2GenRating inputs 0
let decO2GenRating = uint ("0b" + binO2GenRating)
let binCO2SrubRating = getBinCO2ScrubRating inputs 0
let decCO2SrubRating = uint ("0b" + binCO2SrubRating)
printfn($"O2 generator rating: {binO2GenRating} => {decO2GenRating} | CO2 scrubber rating: {binCO2SrubRating} => {decCO2SrubRating} | Answer: {decO2GenRating * decCO2SrubRating}")


