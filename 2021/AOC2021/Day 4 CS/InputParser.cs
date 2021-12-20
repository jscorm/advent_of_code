namespace Day_4_CS
{
    public class InputParser
    {
        private readonly string[] _input;

        public InputParser(string filepath)
        {
            _input = File.ReadAllLines(filepath);
        }

        public int[] GetDrawnNumbers()
        {
            return _input[0].Split(",")
                .Select(int.Parse)
                .ToArray();
        }

        public BingoCard[] GetBingoCards()
        {
            return _input.Skip(1)
                .Where(x => x != "")
                .Chunk(5)
                .Select(x => new BingoCard(x))
                .ToArray();
        }
    }
}
