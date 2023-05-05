using Bill.Definition;

namespace Bill.Ui
{
    public static class UiMessage
    {
        public static string WelcomeMessage()
        {
            StringWriter sw = new();
            sw.WriteLine("\t\tWelcome to 'Receipt Time' app!\n");
            sw.WriteLine("This program makes your Friday dinners more enjoybale with you friends or family!\n");
            sw.WriteLine("Don't waste your time and energy on calculating how much do you need to pay each");
            sw.WriteLine("This app does it for you! Add people, prices, service fee, and let the program do it's job!");

            return sw.ToString();
        }

        public static string AddGroupsMessage()
        {
            StringWriter sw = new();
            sw.Write($"Add groups/people {UiConstants.ContinueReturnMessage} {UiConstants.EnterMessage}\n");

            return sw.ToString();
        }

        public static string AddedPriceInfoMessage(Group group, double price, Receipt receipt)
        {
            if (receipt == null)
            {
                throw new ArgumentNullException(nameof(receipt));
            }

            return $"Added {price} {receipt.Currency}. Current total: {group.ToStringTotal(receipt.Currency!)}";
        }


        public static string TotalPayInfoMessage(Group group, Receipt receipt)
        {
            return $"Total price to pay: {group.ToStringTotal(receipt.Currency!)}";
        }

        public static string GroupExistsWrongInputMessage(string newGroup)
        {
            return $"{newGroup} already exists";
        }

        public static string ChooseAgainWrongInputMessage(int start, int end)
        {
            string output = $"Wrong userInput, choose from ";

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

        public static string ContinueMessage()
        {
            StringWriter sw = new();
            sw.WriteLine("\nPress any key to continue");

            return sw.ToString();
        }

        public static string WaitKeyPressMessage()
        {
            StringWriter sw = new();
            sw.WriteLine("Press any key to continue and try again");

            return sw.ToString();
        }

        public static string ShowAllGroups()
        {
            StringWriter sw = new();
            foreach (Group currentGroup in Groups.groups)
            {
                sw.WriteLine($"{currentGroup.Name}");
            }

            return sw.ToString();
        }

        public static string AllGroupsCalculatedMessage(Receipt receipt)
        {
            StringWriter sw = new();
            sw.WriteLine("All groups/persons calculated!\n");
            sw.WriteLine("Name \t Total \t\t Total with fee");

            foreach (Group currGroup in Groups.groups)
            {
                sw.WriteLine($"{currGroup.Name} \t {currGroup.ToStringTotal(receipt.Currency!)} \t\t {currGroup.ToStringTotalWithFee(receipt.Currency!)}");
            }

            return sw.ToString();
        }
    }
}
