using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;
using Bill.Ui;
using Group = Bill.Definition.Group;

namespace Bill.FullStack
{
    public static class Service
    {
        private static readonly IMenu _menu = new ConsoleImplementationMenu();

        public static string ChooseServiceFee(Groups groups, Receipt receipt)
        {
            Group selectedGroup = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName)!;
            _menu.ShowMenu(UiMenu.ChooseServiceFeeMessage(selectedGroup, receipt.Currency!));
            string choice = Console.ReadLine()!;

            return choice;
        }

        public static void ManageServiceFee(Groups groups, Receipt receipt)
        {
            string choice = ChooseServiceFee(groups, receipt);
            double serviceFeePercent = Add.AddServiceFee(groups, choice, receipt);
            Calculation.UpdateTotalsWithFee(groups, receipt, serviceFeePercent);
            UiConst._menu.ShowMenu(UiMenu.ShowPricesDatas(groups, receipt));
            UiConst._message.ShowMessage(UiMessage.ContinueMessage());
            Calculation.CheckAllCalculated(groups, receipt);
            PageManager.currentPage = Page.SelectGroupPage;
        }
    }
}