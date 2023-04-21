using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;

namespace Bill.FullStack
{
    public static class Add
    {
        private static readonly IMenu _menu = new ConsoleImplementationMenu();
        private static readonly IMessage _message = new ConsoleImplementationMessage();

        public static void AddLoop(Receipt receipt, string currency)
        {
            string selectedGroup = Select.SelectGroup(currency);
            Group group = AddItems(selectedGroup, receipt, currency);
            string feeChoosen = Service.ChooseServiceFee(selectedGroup, currency);
            AddServiceFee(group, feeChoosen, currency, receipt);
        }

        public static void AddGroups(Groups groups)
        {
            _message.ShowMessage(UiMessage.AddGroupsMessage());

            while (true)
            {
                string newGroup = Console.ReadLine()!;

                if (newGroup == "0")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(newGroup))
                {
                    _message.ShowMessage(UiMessage.emptyNameWrongInputMessage);
                }
                else if (int.TryParse(newGroup, out _))
                {
                    _message.ShowMessage(UiMessage.numberWrongInputMessage);
                }
                else if (Groups.groups.Any(n => n.Name == newGroup))
                {
                    _message.ShowMessage(UiMessage.GroupExistsWrongInputMessage(newGroup));
                }
                else
                {
                    groups.AddNewGroup(newGroup);
                }
            }
        }


        public static Group AddItems(string selectedGroupNumber, Receipt receipt, string currency)
        {
            _menu.ShowMenu(UiMessage.AddItemPricesMessage(selectedGroupNumber));
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
                    _message.ShowMessage(UiMessage.AddedPriceInfoMessage(currency, group, price));
                }
                else if (success && price == 0)
                {
                    _message.ShowMessage(UiMessage.TotalPayInfoMessage(currency, group));
                    break;
                }
                else
                {
                    _message.ShowMessage(UiMessage.nothingAddedWrongInputMessage);
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
                        _message.ShowMessage(UiMessage.ChooseAgainWrongInputMessage(1, 4));
                        feeChoosen = Console.ReadLine()!;
                        break;
                }
            }

            Calculation.GetTotalsWithFee(group, receipt, serviceFeePercent);
            _menu.ShowMenu(UiMessage.ShowPricesDatas(group, currency, receipt));
            Calculation.CheckAllCalculated(receipt, currency);
        }
    }
}