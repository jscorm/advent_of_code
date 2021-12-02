printfn "Advent of Code 2020 - Day 1"

//Part 1
let rec fy sum num nums =
    match nums with
    | head::tail ->
        if(num + head = sum) then Some(head)
        else fy sum num tail
    | [] -> None
    
let rec fx sum nums = 
    match nums with
      | [] -> None
      | head::tail ->
        let result = fy sum head tail
        match result with
          | Some(x) -> Some(head, x)
          | None -> fx sum tail

printfn "\nPart 1"
let nums = System.IO.File.ReadLines("../../../input.txt") |> Seq.map int
let (a, b) = (fx 2020 (List.ofSeq nums)).Value
let product = a * b
printfn $"The two numbers are {a} et {b} and their product is {product}.\n"

//Part 2
let rec gy sum count terms nums =
    match nums with
    | head::tail ->
        let termsSum = List.fold (+) 0 terms
        if(termsSum + head = sum && terms.Length + 1 = count) 
            then Some(head::terms)
        else if(termsSum + head < sum && terms.Length + 1 < count) 
            then match gy sum count (head::terms) tail with
                  | Some(x) -> Some(x)
                  | None -> gy sum count terms tail
        else gy sum count terms tail
    | [] -> None
    
let rec gx sum count nums = 
    match nums with
      | [] -> None
      | head::tail ->
        let result = gy sum count [head] tail
        match result with
          | Some(x) -> Some(x)
          | None -> gx sum count tail

printfn "\nPart 2"
let answers = (gx 2020 3 (List.ofSeq nums)).Value //Part 1 can also be solved with (gx 2020 2 (List.ofSeq nums))
let product2 = List.fold (*) 1 answers
printfn $"The three numbers are {answers} and their product is {product2}.\n"
     