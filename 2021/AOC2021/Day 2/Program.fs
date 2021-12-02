printfn "Advent of Code 2021 - Day 2"

type Direction =
| Forward = 0
| Up = 1
| Down = 2

let tryParseDirection str =
    match str with
    | "forward" -> Direction.Forward
    | "up" -> Direction.Up
    | "down" -> Direction.Down
    | _ -> invalidArg "str" $"Invalid direction {str}"

type Instruction = 
    struct
        val Direction: Direction
        val Value: int
        new(dir: Direction, value: int) = {Direction = dir; Value = value}
    end

let lineToInstruction (line:string) = 
    let values = line.Split(' ')
    new Instruction(tryParseDirection values[0], int values[1])

let instructions = System.IO.File.ReadLines("../../../input.txt") |> Seq.map lineToInstruction

//Part 1
let applyInstruction (distance:int, depth:int) (s:Instruction) =
    match s.Direction with
    | Direction.Forward -> (distance + s.Value, depth)
    | Direction.Up -> (distance, depth - s.Value)
    | Direction.Down -> (distance, depth + s.Value)
    | _ -> invalidArg "s.Direction" $"Invalid direction {s.Direction}"

printfn "\nPart 1"
let (distance, depth) = Seq.fold (fun acc instr -> applyInstruction acc instr) (0, 0) instructions
printfn($"Final horizontal position: {distance} | Final depth: {depth} | Answer: {distance * depth}")

//Part 2
let applyInstructionWithAim (distance:int, depth:int, aim:int) (s:Instruction) =
    match s.Direction with
    | Direction.Forward -> (distance + s.Value, depth + s.Value * aim, aim)
    | Direction.Up -> (distance, depth, aim - s.Value)
    | Direction.Down -> (distance, depth, aim + s.Value)
    | _ -> invalidArg "s.Direction" $"Invalid direction {s.Direction}"

printfn "\nPart 2"
let (distance2, depth2, aim) = Seq.fold (fun acc instr -> applyInstructionWithAim acc instr) (0, 0, 0) instructions
printfn($"Final horizontal position: {distance2} | Final depth: {depth2} | Answer: {distance2 * depth2}")