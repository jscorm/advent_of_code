namespace Day_4_CS
{
    public class BingoCard
    {
        private readonly CardNumber[,] _numbers = new CardNumber[5,5];

        public BingoCard(string[] numbers)
        {
            for(int i = 0; i < 5; i++)
            {
                var rowNumbers = numbers[i].Split(" ").Where(x => x != "").ToArray();
                for(int j = 0; j < 5; j++)
                {
                    _numbers[i, j] = new CardNumber(int.Parse(rowNumbers[j]));
                }
            }
        }

        public void Mark(int num)
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if(_numbers[i, j].Number == num)
                    {
                        _numbers[i, j].Mark();
                    }
                }
            }
        }

        public bool Winned()
        {
            for(int i = 0; i < 5; i++)
            {
                if (GetRow(i).All(x => x.Marked)) return true;
                if (GetColumn(i).All(x => x.Marked)) return true;
            }

            return false;
        }

        public int SumOfUnmark()
        {
            var sum = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!_numbers[i, j].Marked)
                    {
                        sum += _numbers[i, j].Number;
                    }
                }
            }

            return sum;
        }

        private CardNumber[] GetRow(int rowIndex)
        {
            return Enumerable.Range(0, 5).Select(i => _numbers[i, rowIndex]).ToArray();
        }

        private CardNumber[] GetColumn(int columnIndex)
        {
            return Enumerable.Range(0, 5).Select(i => _numbers[columnIndex, i]).ToArray();
        }
    }
}
