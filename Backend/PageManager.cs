using Bill.Definition;
using Bill.FullStack;
using Bill.Ui;

namespace Bill.Backend
{
    public static class PageManager
    {
        public const string Welcome = "Welcome";
        public const string AddGroups = "AddGroups";
        public const string SelectCurrency = "SelectCurrency";
        public const string SelectGroup = "SelectGroup";
        public const string AddItemPrices = "AddItemPrices";
        public const string ChooseServiceFee = "ChooseServiceFee";
        public static string? page = Welcome;
        public static string userInput;

        public static void Run()
        {
            Groups groups = new();
            Receipt receipt = new();

            while (true)
            {
                if (page == Welcome)
                {
                    Start.Welcome(groups, receipt);
                    page = AddGroups;
                }
                else if (page == AddGroups)
                {
                    Add.AddGroups(groups, receipt);
                }
                else if (page == SelectCurrency)
                {
                    Select.SelectCurrency(receipt);
                }
                else if (page == SelectGroup)
                {
                    string selectedGroup = "";

                    while (string.IsNullOrEmpty(selectedGroup))
                    {
                        selectedGroup = Select.SelectGroup(groups, receipt);
                    }

                    page = AddItemPrices;
                }
                else if (page == AddItemPrices)
                {
                    Add.AddItemPrices(groups, receipt);
                }
                else if (page == ChooseServiceFee)
                {
                    string choice = Service.ChooseServiceFee(groups, receipt);
                    double serviceFeePercent = Add.AddServiceFee(groups, choice, receipt);
                    Calculation.GetTotalsWithFee(groups, receipt, serviceFeePercent);
                    UiConst._menu.ShowMenu(UiMenu.ShowPricesDatas(groups, receipt));
                    Calculation.CheckAllCalculated(groups, receipt);
                    page = SelectGroup;
                }
            }
        }
    }
}