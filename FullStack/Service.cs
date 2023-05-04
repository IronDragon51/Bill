using Bill.Definition;
using Bill.Interfaces;
using Bill.Ui;

namespace Bill.FullStack
{
    public class Service
    {
        private static readonly IMenu _menu = new ConsoleImplementationMenu();

        public static string ChooseServiceFee(string selectedGroupName, Receipt receipt)
        {
            Group selectedGroup = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;
            _menu.ShowMenu(UiMenu.ChooseServiceFeeMessage(selectedGroup, receipt.Currency));

            string choice = Console.ReadLine()!;
            Group group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;

            return choice;
        }
    }
}