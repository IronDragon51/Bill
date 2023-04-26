using Bill.Definition;

namespace Bill.Ui
{
    public static class UiMessage
    {
        public static string AddGroupsMessage()
        {
            StringWriter sw = new();
            sw.Write($"Add groups/people {UiConst.continueReturnMessage} {UiConst.enterMessage}\n");

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

        public static string WelcomeMessage()
        {
            StringWriter sw = new();
            sw.WriteLine("\t\tWelcome to 'Receipt Time' app!\n");
            sw.WriteLine("This program makes your Friday dinners more enjoybale with you friends or family!\n");
            sw.WriteLine("Don't waste your time and energy on calculating how much do you need to pay each");
            sw.WriteLine("This app does it for you! Add people, prices, service fee, and let the program do it's job!");
            return sw.ToString();
        }
    }
}
