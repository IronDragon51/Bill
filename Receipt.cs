
namespace Bill
{
    enum ServiceFee
    {
        zero = 0,
        low = 8,
        normal = 10,
        high = 12
    }

    public class Receipt
    {
        public double Total { get; set; }
        private double _totalDivided;
        public double TotalDevided
        {
            get
            {
                return _totalDivided;
            }
            set
            {
                foreach (Group currentGroup in Groups.groups)
                {
                    _totalDivided += currentGroup.Total;
                }
            }

        }

        public double TotalWithFee { get; init; }
    }
}
