namespace Bill.Definition
{
    public enum ServiceFee
    {
        zero = 0,
        low = 8,
        medium = 10,
        high = 12
    }

    public enum Currency
    {
        EUR,
        USD,
        HUF
    }

    public class Receipt
    {
        public double Total { get; set; }
        public double TotalWithFee { get; set; }
        public string? Currency { get; set; }

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