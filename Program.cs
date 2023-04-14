using Bill.Definition;
using Bill.FullStack;

namespace Bill
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Groups groups = new();
            Receipt receipt = new();

            Add.AddGroups(groups);
            string currency = Select.SelectCurrency();
            Add.AddLoop(receipt, currency);
        }
    }
}