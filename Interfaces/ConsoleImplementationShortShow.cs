using Bill.Definition;

namespace Bill.Interfaces
{
    public class ConsoleImplementationAddShow : IShortMsgShow
    {
        public void AddGroupsMessage()
        {
            Console.Clear();
            Console.Write("Add groups/people (separated with enter)  -- Press 0 to exit\n");
        }

        public void AddItemPricesMessage(string selectedGroupName)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Add item prices (separated with enter) to {selectedGroupName} -- Press 0 to exit");
        }

        public void AddedPriceInfoMessage(string currency, Group group, double price)
        {
            Console.WriteLine($"Added {price} {currency}. Current total: {group.ToStringTotal(currency)}");
        }

        public void EmptyNameWrongInputMessage()
        {
            Console.WriteLine("Empty name, try again:");
        }

        public void GroupExistsWrongInputMessage(string newGroup)
        {
            Console.WriteLine($"{newGroup} already exists");
        }

        public void NumberWrongInputMessage()
        {
            Console.WriteLine("Number name? Interesting. Try again!");
        }

    }
}
