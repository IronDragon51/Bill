using Bill.Definition;

namespace Bill.Interfaces
{
    public class ConsoleImplementationAddShow : IShortMsgShow
    {
        public void AddGroups_Message()
        {
            Console.Clear();
            Console.Write("Add groups/people (separated with enter)  -- Press 0 to exit\n");
        }

        public void AddItemPrices_Message(string selectedGroupName)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Add item prices (separated with enter) to {selectedGroupName} -- Press 0 to exit");
        }


        public void AddedPrice_InfoMessage(string currency, Group group, double price)
        {
            Console.WriteLine($"Added {price} {currency}. Current total: {group.ToStringTotal(currency)}");
        }
        public void TotalPay_InfoMessage(string currency, Group group)
        {
            Console.WriteLine($"Total price to pay: {group.ToStringTotal(currency)}");
        }


        public void EmptyName_WrongInputMessage()
        {
            Console.WriteLine("Empty name, try again:");
        }

        public void GroupExists_WrongInputMessage(string newGroup)
        {
            Console.WriteLine($"{newGroup} already exists");
        }

        public void Number_WrongInputMessage()
        {
            Console.WriteLine("Number name? Interesting. Try again!");
        }

        public void NothingAdded_WrongInputMessage()
        {
            Console.WriteLine("Wrong input, noting was added");
        }

        public void ChooseAgain4_WrongInputMessage()
        {
            Console.WriteLine("Wrong input, choose from 1,2,3,4 options");
        }

        public void ChooseAgain3_WrongInputMessage()
        {
            Console.WriteLine("Wrong input, choose from 1,2,3 options");
        }

        public void NoGroup_ExceptionInfoMessage(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public void ChooseServiceFee_Message(Group selectedGroup)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Choose service fee: (Current total: {selectedGroup.Total})");
            Console.WriteLine($"1) {(int)ServiceFee.zero}% fee");
            Console.WriteLine($"2) {(int)ServiceFee.low}% fee");
            Console.WriteLine($"3) {(int)ServiceFee.medium}% fee");
            Console.WriteLine($"4) {(int)ServiceFee.high}% fee");
        }
    }
}
