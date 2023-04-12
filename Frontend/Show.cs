using Bill.Definition;

namespace Bill
{
    public class Show
    {
        public static void ShowPricesDatas(Group group, string currency, Receipt receipt)
        {
            Console.Clear();
            Console.WriteLine($"{group.Name}, total price to pay is: {group.ToStringTotal(currency)} ");
            Console.WriteLine($"With service fee included: {group.ToStringTotalWithFee(currency)} \n");
            Console.WriteLine($"For everyone, total price to pay is: {receipt.ToStringTotal(currency)} ");
            Console.WriteLine($"With service fee included: {receipt.ToStringTotalWithFee(currency)}");
            Console.WriteLine("--------------------------------\n");
        }

        public static void ShowCurrencies()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Select a currency!\n");
            Console.WriteLine("Options:");
            Console.WriteLine($"1) {Currency.USD}");
            Console.WriteLine($"2) {Currency.EUR}");
            Console.WriteLine($"3) {Currency.HUF}");
        }

        public static void ShowSelectableGroups()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Select a group/person to add prices to!\n");
            Console.WriteLine("Options:");

            foreach (Group currentGroup in Groups.groups)
            {
                Console.WriteLine(currentGroup.Name);
            }
            Console.WriteLine();
        }

        public static void AlreadyCalculated(string currency)
        {
            Console.WriteLine("Already calculated!");
            Console.WriteLine("Calculate anyway? (y/n)");
            string input = Console.ReadLine()!;
            if (input == "n")
            {
                Select.SelectGroup(currency);
            }
            else if (input != "y")
            {
                Console.WriteLine("Wrong input! Type 'y' or 'n'");
            }
        }

        public static void AllGroupsCalculated(string currency)
        {
            Console.WriteLine("All groups/person calculated!");
            Console.WriteLine("Name: Total");
            foreach (Group currGroup in Groups.groups)
            {
                Console.WriteLine($"{currGroup.Name} - {currGroup.ToStringTotal(currency)} - {currGroup.ToStringTotalWithFee(currency)}");
            }
            Environment.Exit(0);
        }
    }
}
