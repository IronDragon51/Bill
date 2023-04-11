namespace Bill
{
    public class Program
    {
        static void Main(string[] args)
        {
            Groups groups = new();
            Receipt receipt = new();

            Add.AddGroups(groups);
            string currency = Select.SelectCurrency();
            Add.AddLoop(groups, receipt, currency);

        }
    }
}