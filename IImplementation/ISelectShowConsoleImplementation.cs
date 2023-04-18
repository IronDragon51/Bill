using Bill.Definition;

namespace Bill.Interfaces
{
    public class ConsoleImplementationSelectShow : ISelectShow
    {
        public void ShowPricesDatas(Group group, string currency, Receipt receipt)
        {
            Console.Clear();
            Console.WriteLine($"{group.Name}, total price to pay is: {group.ToStringTotal(currency)} ");
            Console.WriteLine($"With service fee included: {group.ToStringTotalWithFee(currency)} \n");
            Console.WriteLine($"For everyone, total price to pay is: {receipt.ToStringTotal(currency)} ");
            Console.WriteLine($"With service fee included: {receipt.ToStringTotalWithFee(currency)}");
            Console.WriteLine("--------------------------------\n");
        }

        public void ShowCurrencies()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Select a currency!\n");
            Console.WriteLine("Options:");
            Console.WriteLine($"1) {Currency.USD}");
            Console.WriteLine($"2) {Currency.EUR}");
            Console.WriteLine($"3) {Currency.HUF}");
        }

        public void ShowSelectableGroups()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Select a group/person to add prices to!\n");
            Console.WriteLine("Options:");

            int num = 0;
            foreach (Group currentGroup in Groups.groups)
            {
                num++;
                Console.WriteLine($"{num}) {currentGroup.Name}");
            }
            Console.WriteLine();
        }
    }
}
