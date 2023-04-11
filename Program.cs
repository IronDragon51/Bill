namespace Bill
{
    public class Program
    {
        //public const char ESC = '\x1B';
        static void Main()
        {
            Groups groups = new();
            Receipt receipt = new();

            Add.AddGroups(groups);
            string currency = Select.SelectCurrency();
            Add.AddLoop(groups, receipt, currency);
        }
    }
}