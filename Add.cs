namespace Bill
{
    public class Add
    {
        public static void AddLoop(Groups groups, Receipt receipt, string currency)
        {
            string selectedGroup = Select.SelectGroup(currency);
            Group group = AddItems(selectedGroup, receipt, currency);
            string feeChoosen = Service.ChooseServiceFee(selectedGroup, groups, group, receipt, currency);
            AddServiceFee(group, feeChoosen, currency, receipt);
        }


        public static void AddGroups(Groups groups)
        {
            Console.Clear();
            Console.Write("Add groups/people (separated with enter)");
            Console.WriteLine(" -- Press 0 to exit");

            string newGroup;
            while (true)
            {
                newGroup = Console.ReadLine()!;

                if (newGroup == "0")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(newGroup))
                {
                    Console.WriteLine("Empty name, try again:");
                }
                else if (Groups.groups.All(n => n.Name != newGroup))
                {
                    groups.AddNewGroup(newGroup);
                }
                else
                {
                    Console.WriteLine($"{newGroup} already exists");
                }
            }
        }


        public static Group AddItems(string selectedGroup, Receipt receipt, string currency)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Add item prices (separated with enter) to {selectedGroup} -- Press 0 to exit");

            Group group = new("");
            double price = 0;
            while (true)
            {
                bool success = double.TryParse(Console.ReadLine(), out price);
                group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroup)!;

                if (success && price != 0)
                {
                    group!.Total += price;
                    receipt.Total += price;
                    Console.WriteLine($"Added {price} {currency}. Current total: {group.ToStringTotal(currency)}");
                }
                else if (success && price == 0)
                {
                    Console.WriteLine($"Total price to pay: {group.ToStringTotal(currency)}");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input, noting was added");
                }
            }

            return group;
        }


        public static void AddServiceFee(Group group, string feeChoosen, string currency, Receipt receipt)
        {
            double serviceFeePercent = 0;
            bool exit = false;
            while (!exit)
            {
                switch (feeChoosen)
                {
                    case "1":
                        serviceFeePercent = (double)ServiceFee.zero;
                        exit = true;
                        break;

                    case "2":
                        serviceFeePercent = (double)ServiceFee.low;
                        exit = true;
                        break;

                    case "3":
                        serviceFeePercent = (double)ServiceFee.medium;
                        exit = true;
                        break;

                    case "4":
                        serviceFeePercent = (double)ServiceFee.high;
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong input, choose from 1,2,3,4 options");
                        break;
                }
            }

            group!.TotalWithFee = group.Total + (group.Total * serviceFeePercent) / 100;
            receipt.TotalWithFee += group.TotalWithFee;

            ShowPricesDatas(group, currency, receipt);
            CheckAllCalculated(currency);
        }


        private static void ShowPricesDatas(Group group, string currency, Receipt receipt)
        {
            Console.Clear();
            Console.WriteLine($"{group.Name}, total price to pay is: {group.ToStringTotal(currency)} ");
            Console.WriteLine($"With service fee included: {group.ToStringTotalWithFee(currency)} \n");
            Console.WriteLine($"For everyone, total price to pay is: {receipt.ToStringTotal(currency)} ");
            Console.WriteLine($"With service fee included: {receipt.ToStringTotalWithFee(currency)}");
            Console.WriteLine("--------------------------------\n");
        }


        private static void CheckAllCalculated(string currency)
        {
            if (Groups.groups.All(g => g.Total > 0))
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
}