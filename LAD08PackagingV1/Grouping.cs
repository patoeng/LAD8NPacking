
namespace LAD08PackagingV1
{
    public delegate void GroupingAchieved();
    public delegate void GroupingValue(int data);
    public class Grouping
    {
        public event GroupingAchieved GroupingIsAchievedTarget;
        public event GroupingValue RemainingValueChanged ;
        public Grouping(int size)
        {
            Size = size;
        }
        public Grouping(int size, int initialPacked)
        {
            Size = size;
            _packed = initialPacked;
            Remaining = Size -(_packed % Size);
        }
        public int Size { get; protected set; }
        private int _remaining;
        public int Remaining
        {
            get { return _remaining; }
            protected set
            {
                if (_remaining == value) return;
                _remaining = value;
                RemainingValueChanged?.Invoke(_remaining);
            }
        }

        private int _packed;
        public int PrintPending { get; protected set; }

        public bool PendingDoPrint()
        {
            if (PrintPending > 0)
            {
                PrintPending -= 1;
                return true;
            }
            return false;
        }
        public int Packed
        {
            get { return _packed; }
            set
            {
                if (_packed == value) return;
                _packed = value;
                Remaining =Size -( _packed % Size);
                if (Remaining == 0)
                {
                    PrintPending += 1;
                    GroupingIsAchievedTarget?.Invoke();
                }
            }
        }
    }
}