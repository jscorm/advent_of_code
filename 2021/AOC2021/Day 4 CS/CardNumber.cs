namespace Day_4_CS
{
    public class CardNumber
    {
        private readonly int _number;
        private bool _marked;

        public int Number { get { return _number; } }
        public bool Marked { get { return _marked; } }

        public CardNumber(int num)
        {
            _number = num;
            _marked = false;
        }

        public void Mark()
        {
            _marked = true;
        }
    }
}
