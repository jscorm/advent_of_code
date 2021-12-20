using Day_4_CS;

var inputParser = new InputParser("../../../input.txt");
var drawnNumbers = inputParser.GetDrawnNumbers();

Console.WriteLine("Advent of Code 2021 - Day 4");

//Part 1
Console.WriteLine("\nPart 1");
var bingoCards = inputParser.GetBingoCards();
BingoCard? winningCard = null;
int? lastDrawn = null;
bool gameOver = false;

foreach(int number in drawnNumbers)
{
    foreach(var card in bingoCards)
    {
        card.Mark(number);
        if(card.Winned())
        {
            winningCard = card;
            lastDrawn = number;
            gameOver = true;
            break;
        }
    }

    if (gameOver) break;
}

if (winningCard != null && lastDrawn != null)
{
    Console.WriteLine($"LastDrawn: {lastDrawn} | SumOfUnmark: {winningCard.SumOfUnmark()} | Answer: {winningCard.SumOfUnmark() * lastDrawn}");
}
else
{
    Console.WriteLine("No winning card found.");
}

//Part 2
bingoCards = inputParser.GetBingoCards();
Console.WriteLine("\nPart 2");
winningCard = null;
lastDrawn = null;

foreach (int number in drawnNumbers)
{
    foreach (var card in bingoCards)
    {
        card.Mark(number);
        if (card.Winned())
        {
            winningCard = card;
            lastDrawn = number;
            if (bingoCards.All(card => card.Winned())) break;
        }
    }

    if (bingoCards.All(card => card.Winned())) break;
}

if (winningCard != null && lastDrawn != null)
{
    Console.WriteLine($"LastDrawn: {lastDrawn} | SumOfUnmark: {winningCard.SumOfUnmark()} | Answer: {winningCard.SumOfUnmark() * lastDrawn}");
}
else
{
    Console.WriteLine("No winning card found.");
}


