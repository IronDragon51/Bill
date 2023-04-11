namespace Bill
{
    public class Select
    {
        public static string SelectGroup(string currency)
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

            Group group = new("")!;
            string selectedGroup = Console.ReadLine()!;
            try
            {
                group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroup)!;
                if (string.IsNullOrEmpty(group.Name))
                {
                    throw new Exception("No group like this!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (Groups.groups.All(g => g.Total > 0))
            {
                Console.WriteLine("All groups/person calculated!");
                Console.WriteLine("Name: Total");
                foreach (Group currGroup in Groups.groups)
                {
                    Console.WriteLine($"{currGroup.Name} - {currGroup.ToStringTotal(currency)} - {currGroup.ToStringTotalWithFee(currency)}");
                }
            }

            if (group.Total > 0)
            {
                Console.WriteLine("Already calculated!");
                Console.WriteLine("Calculate anyway? (y/n)");
                string input = Console.ReadLine()!;
                if (input == "n")
                {
                    SelectGroup(currency);
                }
                else if (input != "y")
                {
                    Console.WriteLine("Wrong input! Type 'y' or 'n'");
                }
            }


            return selectedGroup;
        }


        public static string SelectCurrency()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Select a currency!\n");
            Console.WriteLine("Options:");
            Console.WriteLine($"1) {Currency.USD}");
            Console.WriteLine($"2) {Currency.EUR}");
            Console.WriteLine($"3) {Currency.HUF}");

            string currency = "";
            string choice = Console.ReadLine()!;
            bool exit = false;
            while (!exit)
            {
                switch (choice)
                {
                    case "1":
                        currency = Currency.USD.ToString();
                        exit = true;
                        break;

                    case "2":
                        currency = Currency.EUR.ToString();
                        exit = true;
                        break;

                    case "3":
                        currency = Currency.HUF.ToString();
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong input, choose from 1,2,3 options");
                        break;
                }
            }

            return currency;
        }
    }
}
