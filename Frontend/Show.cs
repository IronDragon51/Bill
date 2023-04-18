using Bill.Definition;
using Bill.FullStack;

namespace Bill
{
    public class Show : WriteImplementation
    {
        IShow show = new WriteImplementation();

        //public static void ShowPricesDatas(Group group, string currency, Receipt receipt)
        //{
        //    Console.Clear();
        //    Console.WriteLine($"{group.Name}, total price to pay is: {group.ToStringTotal(currency)} ");
        //    Console.WriteLine($"With service fee included: {group.ToStringTotalWithFee(currency)} \n");
        //    Console.WriteLine($"For everyone, total price to pay is: {receipt.ToStringTotal(currency)} ");
        //    Console.WriteLine($"With service fee included: {receipt.ToStringTotalWithFee(currency)}");
        //    Console.WriteLine("--------------------------------\n");
        //}

        //public static void ShowCurrencies()
        //{

        //    Console.Clear();
        //    Console.WriteLine("--------------------------------");
        //    Console.WriteLine("Select a currency!\n");
        //    Console.WriteLine("Options:");
        //    Console.WriteLine($"1) {Currency.USD}");
        //    Console.WriteLine($"2) {Currency.EUR}");
        //    Console.WriteLine($"3) {Currency.HUF}");
        //}

        //public static void ShowSelectableGroups()
        //{
        //    Console.Clear();
        //    Console.WriteLine("--------------------------------");
        //    Console.WriteLine("Select a group/person to add prices to!\n");
        //    Console.WriteLine("Options:");

        //    int num = 0;
        //    foreach (Group currentGroup in Groups.groups)
        //    {
        //        num++;
        //        Console.WriteLine($"{num}) {currentGroup.Name}");
        //    }
        //    Console.WriteLine();
        //}

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

        public virtual void AllGroupsCalculated(string currency)
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("All groups/person calculated!\n");
            Console.WriteLine("Name \t Total \t Total with fee");
            foreach (Group currGroup in Groups.groups)
            {
                Console.WriteLine($"{currGroup.Name} \t {currGroup.ToStringTotal(currency)} \t {currGroup.ToStringTotalWithFee(currency)}");
            }
            Environment.Exit(0);
        }

        public static void Continue()
        {
            Console.WriteLine("Press any key to continue\n");
            Console.ReadKey();
        }
    }
}