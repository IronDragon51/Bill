using Bill.Definition;
using Bill.FullStack;

namespace Bill.Backend
{
    public enum Page
    {
        WelcomePage,
        AddGroupsPage,
        SelectCurrencyPage,
        SelectGroupPage,
        AddItemPricesPage,
        ChooseServiceFeePage
    }

    public static class PageManager
    {
        public static Page currentPage = Page.WelcomePage;

        public static void ManagePages()
        {
            CreateNew.CreateGroupsAndReceipt(out Groups groups, out Receipt receipt);

            while (true)
            {
                switch (currentPage)
                {
                    case Page.WelcomePage:
                        Start.Welcome();
                        break;

                    case Page.AddGroupsPage:
                        Add.AddGroups(groups, receipt);
                        break;

                    case Page.SelectCurrencyPage:
                        Select.SelectCurrency(receipt);
                        break;

                    case Page.SelectGroupPage:
                        string selectedGroup = Select.SelectGroup(groups, receipt);
                        NullOrEmptyCheck(selectedGroup);
                        break;

                    case Page.AddItemPricesPage:
                        Add.AddItemPrices(groups, receipt);
                        break;

                    case Page.ChooseServiceFeePage:
                        Service.ManageServiceFee(groups, receipt);
                        break;
                }
            }
        }

        private static void NullOrEmptyCheck(string selectedGroup)
        {
            if (!string.IsNullOrEmpty(selectedGroup))
            {
                currentPage = Page.AddItemPricesPage;
            }
        }
    }
}