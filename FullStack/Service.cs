using Bill.Definition;
using Bill.Interfaces;
using Bill.Ui;
using Group = Bill.Definition.Group;

namespace Bill.FullStack
{
    public class Service
    {
        private static readonly IMenu _menu = new ConsoleImplementationMenu();

        public static string ChooseServiceFee(Groups groups, Receipt receipt)
        {
            Group selectedGroup = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName)!;
            _menu.ShowMenu(UiMenu.ChooseServiceFeeMessage(selectedGroup, receipt.Currency!));

            string choice = Console.ReadLine()!;
            Group group = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName)!;

            return choice;
        }
    }
}