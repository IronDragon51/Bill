namespace Bill
{
    public class Group
    {
        public string Name { get; set; }
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

    }
}
