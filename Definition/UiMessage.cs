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
            sw.Write("Add groups/people (separated with enter)  -- Press 0 to exit\n");

            return sw.ToString();
        }

        public static string AddItemPricesMessage(string selectedGroupName)
        {
            StringWriter sw = new();
            sw.WriteLine(_divLine);
            sw.WriteLine($"Add item prices (separated with enter) to {selectedGroupName} -- Press 0 to exit");

            return sw.ToString();
        }

        public static string ChooseServiceFeeMessage(Group selectedGroup, string currency)
        {
            StringWriter sw = new();
            sw.WriteLine(_divLine);
            sw.WriteLine($"Choose service fee: (Current total: {selectedGroup.Total} {currency})");
            sw.WriteLine($"1) {(int)ServiceFee.zero}% fee");
            sw.WriteLine($"2) {(int)ServiceFee.low}% fee");
            sw.WriteLine($"3) {(int)ServiceFee.medium}% fee");
            sw.WriteLine($"4) {(int)ServiceFee.high}% fee");

            return sw.ToString();
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
            StringWriter sw = new();
            sw.WriteLine($"{group.Name}, total price to pay is: {group.ToStringTotal(currency)} ");
            sw.WriteLine($"With service fee included: {group.ToStringTotalWithFee(currency)} \n");
            sw.WriteLine($"For everyone, total price to pay is: {receipt.ToStringTotal(currency)} ");
            sw.WriteLine($"With service fee included: {receipt.ToStringTotalWithFee(currency)}");
            sw.WriteLine(_divLineNAfter);

            return sw.ToString();
        }

        public static string ShowCurrencies()
        {
            StringWriter sw = new();
            sw.WriteLine(_divLine);
            sw.WriteLine("Select a currency!\n");
            sw.WriteLine("Options:");
            sw.WriteLine($"1) {Currency.USD}");
            sw.WriteLine($"2) {Currency.EUR}");
            sw.WriteLine($"3) {Currency.HUF}");

            return sw.ToString();
        }

        public static string ShowSelectableGroups()
        {
            StringWriter sw = new();
            sw.WriteLine(_divLine);
            sw.WriteLine("Select a group/person to add prices to!\n");
            sw.WriteLine("Options:");

            int num = 0;
            foreach (Group currentGroup in Groups.groups)
            {
                num++;
                sw.WriteLine($"{num}) {currentGroup.Name}");
            }

            sw.WriteLine();

            return sw.ToString();
        }

        public static string AlreadyCalculatedMessage(string currency)
        {
            StringWriter sw = new();
            sw.WriteLine("Already calculated!");
            sw.WriteLine("Calculate anyway? (y/n)");
            string input = Console.ReadLine()!;

            if (input == "n")
            {
                Select.SelectGroup(currency);
            }
            else if (input != "y")
            {
                sw.WriteLine("Wrong input! Type 'y' or 'n'");
            }

            return sw.ToString();
        }

        public static string ContinueMessage()
        {
            StringWriter sw = new();
            sw.WriteLine("Press any key to continue\n");
            return sw.ToString();
        }

        public static string AllGroupsCalculatedMessage(string currency)
        {
            StringWriter sw = new();
            sw.WriteLine("All groups/person calculated!\n");
            sw.WriteLine("Name \t Total \t\t Total with fee");

            foreach (Group currGroup in Groups.groups)
            {
                sw.WriteLine($"{currGroup.Name} \t {currGroup.ToStringTotal(currency)} \t\t {currGroup.ToStringTotalWithFee(currency)}");
            }
            //Environment.Exit(0);

            return sw.ToString();
        }
    }
}
