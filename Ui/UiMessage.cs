using Bill.Definition;

namespace Bill.Ui
{
    public static class UiMessage
    {
        public static string AddGroupsMessage()
        {
            StringWriter sw = new();
            sw.Write("Add groups/people (separated with enter)  -- Press 0 to exit\n");

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


        public static string ContinueMessage()
        {
            StringWriter sw = new();
            sw.WriteLine("Press any key to continue\n");
            return sw.ToString();
        }
    }
}
