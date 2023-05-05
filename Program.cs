using Bill.Definition;
using Bill.FullStack;

namespace Bill
{
    public class Program
    {
        private static string? _page;

        public static void Main()
        {
            Groups groups = new();
            Receipt receipt = new();
            Group? group = null;
            _page = "Welcome";
            string input = "";

            while (input != "00")
            {
                if (_page == "Welcome")
                {
                    Start.Welcome(groups, receipt);
                    _page = "AddGroups";
                }
                else if (_page == "AddGroups")
                {
                    Add.AddGroups(groups, receipt);
                    _page = "SelectCurrency";
                }
                else if (_page == "SelectCurrency")
                {
                    Select.SelectCurrency(groups, receipt);
                    _page = "SelectGroup";
                }
                else if (_page == "SelectGroup")
                {
                    Select.SelectGroup(groups, receipt);
                    _page = "AddItemPrices";
                }
                else if (_page == "AddItemPrices")
                {
                    Add.AddItemPrices(null, receipt);
                    _page = "ChooseServiceFee";
                }
                else if (_page == "ChooseServiceFee")
                {
                    string choice = Service.ChooseServiceFee(groups, receipt);
                    Add.AddServiceFee(group, groups, choice, receipt);
                    _page = "ShowReceipt";
                }
                else if (_page == "ShowReceipt")
                {

                    _page = "ChooseAnotherGroup";
                }
            }
        }
    }
}