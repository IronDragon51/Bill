namespace Bill
{
    public class Group
    {
        public string Name { get; init; }
        public double Total { get; set; }
        public double TotalWithFee { get; set; }

        public double AddItem(double price)
        {
            Total += price;
            return Total;
        }

        public Group(string name)
        {
            Name = name;
        }

        public string ToStringTotal(string currency)
        {
            return string.Format("{0} - {1}", Math.Round(Total, 2), currency);
        }

        public string ToStringTotalWithFee(string currency)
        {
            return string.Format("{0} - {1}", Math.Round(TotalWithFee, 2), currency);
        }
    }
}