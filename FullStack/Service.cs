using Bill.Definition;
using Bill.Interfaces;
using Bill.Ui;

namespace Bill.FullStack
{
    public class Service
    {
        private static readonly IMenu _menu = new ConsoleImplementationMenu();

        public static string ChooseServiceFee(string selectedGroupName, string currency)
        {
            Group selectedGroup = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;
            _menu.ShowMenu(UiMenu.ChooseServiceFeeMessage(selectedGroup, currency));

            string feeChoosen = Console.ReadLine()!;
            Group group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;

            return feeChoosen;
        }
    }
}