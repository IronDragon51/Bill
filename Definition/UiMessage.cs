using Bill.FullStack;

namespace Bill.Definition
{
    public static class UiMessage
    {
        public const string _divLineNBefore = "\n" + _divLine;
        public const string _divLineNAfter = _divLine + "\n";
        public const string _divLine = "--------------------------------";
        public const string numberWrongInputMessage = "Number name? Interesting. Try again!";
        public const string emptyNameWrongInputMessage = "Empty name, try again:";
        public const string nothingAddedWrongInputMessage = "Wrong input, noting was added";

        public static string AddGroupsMessage()
        {
            StringWriter sw = new();
            Console.SetOut(sw);
            Console.Clear();
            Console.SetError(sw);
            Console.Write("Add groups/people (separated with enter)  -- Press 0 to exit\n");
            string output = sw.ToString()!;
            return output;
        }

        public static string AddItemPricesMessage(string selectedGroupName)
        {
            string output = "";
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                Console.Clear();
                Console.WriteLine(_divLine);
                Console.WriteLine($"Add item prices (separated with enter) to {selectedGroupName} -- Press 0 to exit");
                output = sw.ToString()!;
            }

            return output;
        }

        public static string ChooseServiceFeeMessage(Group selectedGroup, string currency)
        {
            string output = string.Empty;
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                Console.Clear();
                Console.WriteLine(_divLine);
                Console.WriteLine($"Choose service fee: (Current total: {selectedGroup.Total} {currency})");
                Console.WriteLine($"1) {(int)ServiceFee.zero}% fee");
                Console.WriteLine($"2) {(int)ServiceFee.low}% fee");
                Console.WriteLine($"3) {(int)ServiceFee.medium}% fee");
                Console.WriteLine($"4) {(int)ServiceFee.high}% fee");
                output = sw.ToString()!;
            }

            return output;
        }


        public static string AddedPriceInfoMessage(string currency, Group group, double price)
        {
            return $"Added {price} {currency}. Current total: {group.ToStringTotal(currency)}";
        }

        public static string TotalPayInfoMessage(string currency, Group group)
        {
            return $"Total price to pay: {group.ToStringTotal(currency)}";
        }

        public static string GroupExistsWrongInputMessage(string newGroup)
        {
            return $"{newGroup} already exists";
        }

        public static string ChooseAgainWrongInputMessage(int start, int end)
        {
            string output = $"Wrong input, choose from ";

            for (int i = start; i <= end; i++)
            {
                output += i.ToString();
                if (i != end)
                {
                    output += ", ";
                }
            }
            output += " options";

            return output;
        }

        public static string NoGroupExceptionInfoMessage(string exception)
        {
            return exception;
        }

        public static string ShowPricesDatas(Group group, string currency, Receipt receipt)
        {
            string output = "";
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                Console.Clear();
                Console.WriteLine($"{group.Name}, total price to pay is: {group.ToStringTotal(currency)} ");
                Console.WriteLine($"With service fee included: {group.ToStringTotalWithFee(currency)} \n");
                Console.WriteLine($"For everyone, total price to pay is: {receipt.ToStringTotal(currency)} ");
                Console.WriteLine($"With service fee included: {receipt.ToStringTotalWithFee(currency)}");
                Console.WriteLine(_divLineNAfter);
                output = sw.ToString();
            }

            return output;
        }

        public static string ShowCurrencies()
        {
            string output = "";
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                Console.Clear();
                Console.WriteLine(_divLine);
                Console.WriteLine("Select a currency!\n");
                Console.WriteLine("Options:");
                Console.WriteLine($"1) {Currency.USD}");
                Console.WriteLine($"2) {Currency.EUR}");
                Console.WriteLine($"3) {Currency.HUF}");
                output = sw.ToString();
            }

            return output;
        }

        public static string ShowSelectableGroups()
        {
            string output = "";
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                Console.Clear();
                Console.WriteLine(_divLine);
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

            return output;
        }

        public static string AlreadyCalculatedMessage(string currency)
        {
            string output = "";
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
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
                output = sw.ToString();
            }

            return output;
        }

        public static string ContinueMessage()
        {
            string output = "";
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();
                output = sw.ToString();
            }

            return output;
        }

        public static string AllGroupsCalculatedMessage(string currency)
        {
            string output = "";
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                Console.WriteLine(UiMessage._divLineNBefore);
                Console.WriteLine("All groups/person calculated!\n");
                Console.WriteLine("Name \t Total \t\t Total with fee");
                foreach (Group currGroup in Groups.groups)
                {
                    Console.WriteLine($"{currGroup.Name} \t {currGroup.ToStringTotal(currency)} \t {currGroup.ToStringTotalWithFee(currency)}");
                }
                Environment.Exit(0);
                output = sw.ToString()!;
            }

            return output;
        }
    }
}
