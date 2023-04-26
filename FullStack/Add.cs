using Bill.Backend;
using Bill.Definition;
using Bill.Ui;

namespace Bill.FullStack
{
    public static class Add
    {
        public static void AddLoop(Receipt receipt, string currency)
        {
            string? selectedGroup = null;
            while (selectedGroup == null)
            {
                selectedGroup = Select.SelectGroup(currency);
            }
            Group group = AddItems(selectedGroup, receipt, currency);
            string feeChoosen = Service.ChooseServiceFee(selectedGroup, currency);
            AddServiceFee(group, feeChoosen, currency, receipt);
        }

        public static void AddGroups(Groups groups)
        {
            UiConst._message.ShowMessage(UiMessage.AddGroupsMessage());

            while (true)
            {
                string newGroup = Console.ReadLine()!;

                if (newGroup == "0" && Groups.groups.Count > 0)
                {
                    break;
                }
                else if (newGroup == "0" && Groups.groups.Count <= 0)
                {
                    UiConst._message.ShowMessage(UiConst.noGroupsMessage);
                }
                else if (string.IsNullOrWhiteSpace(newGroup))
                {
                    UiConst._message.ShowMessage(UiConst.emptyNameWrongInputMessage);
                }
                else if (int.TryParse(newGroup, out _))
                {
                    UiConst._message.ShowMessage(UiConst.numberWrongInputMessage);
                }
                else if (Groups.groups.Any(n => n.Name == newGroup))
                {
                    UiConst._message.ShowMessage(UiMessage.GroupExistsWrongInputMessage(newGroup));
                }
                else
                {
                    groups.AddNewGroup(newGroup);
                }
            }
        }


        public static Group AddItems(string selectedGroupNumber, Receipt receipt, string currency)
        {
            UiConst._menu.ShowMenu(UiMenu.GetItemPricesMessage(selectedGroupNumber));
            Group group = new("");
            double price = 0;

            while (true)
            {
                bool success = double.TryParse(Console.ReadLine(), out price);
                group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupNumber)!;

                if (success && price != 0)
                {
                    group!.Total += price;
                    receipt.Total += price;
                    UiConst._message.ShowMessage(UiMessage.AddedPriceInfoMessage(currency, group, price));
                }
                else if (success && price == 0)
                {
                    UiConst._message.ShowMessage(UiMessage.TotalPayInfoMessage(currency, group));
                    break;
                }
                else
                {
                    UiConst._message.ShowMessage(UiConst.nothingAddedWrongInputMessage);
                }
            }

            return group;
        }


        public static void AddServiceFee(Group group, string feeChoosen, string currency, Receipt receipt)
        {
            double serviceFeePercent = 0;
            bool exit = false;

            while (!exit)
            {
                switch (feeChoosen)
                {
                    case "1":
                        serviceFeePercent = Calculation.SetFeePercent(out exit, ServiceFee.zero);
                        break;

                    case "2":
                        serviceFeePercent = Calculation.SetFeePercent(out exit, ServiceFee.low);
                        break;

                    case "3":
                        serviceFeePercent = Calculation.SetFeePercent(out exit, ServiceFee.medium);
                        break;

                    case "4":
                        serviceFeePercent = Calculation.SetFeePercent(out exit, ServiceFee.high);
                        break;

                    default:
                        UiConst._message.ShowMessage(UiMessage.ChooseAgainWrongInputMessage(1, 4));
                        feeChoosen = Console.ReadLine()!;
                        break;
                }
            }

            Calculation.GetTotalsWithFee(group, receipt, serviceFeePercent);
            UiConst._menu.ShowMenu(UiMenu.ShowPricesDatas(group, currency, receipt));
            Calculation.CheckAllCalculated(receipt, currency);
        }
    }
}