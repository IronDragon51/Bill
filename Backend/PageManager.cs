using Bill.Definition;
using Bill.FullStack;

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

        public static void Run()
        {
            Groups groups = new();
            Receipt receipt = new();

            while (true)
            {
                switch (page)
                {
                    case Welcome:
                        Start.Welcome();
                        break;

                    case AddGroups:
                        Add.AddGroups(groups, receipt);
                        break;

                    case SelectCurrency:
                        Select.SelectCurrency(receipt);
                        break;

                    case SelectGroup:
                        string selectedGroup = Select.SelectGroup(groups, receipt);
                        NullOrEmptyCheck(selectedGroup);
                        break;

                    case AddItemPrices:
                        Add.AddItemPrices(groups, receipt);
                        break;

                    case ChooseServiceFee:
                        Service.ManageServiceFee(groups, receipt);
                        break;
                }
            }
        }

        private static void NullOrEmptyCheck(string selectedGroup)
        {
            if (!string.IsNullOrEmpty(selectedGroup))
            {
                page = AddItemPrices;
            }
        }
    }
}