using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;

namespace Bill.FullStack
{
    public static class Add
    {
        private static readonly ISelectMsgShow selectMsgShow = new ConsoleImplementationSelectShow();
        private static readonly IShortMsgShow shortMsgShow = new ConsoleImplementationAddShow();

        public static void AddLoop(Receipt receipt, string currency)
        {
            string selectedGroup = Select.SelectGroup(currency);
            Group group = AddItems(selectedGroup, receipt, currency);
            string feeChoosen = Service.ChooseServiceFee(selectedGroup, currency);
            AddServiceFee(group, feeChoosen, currency, receipt);
        }

        public static void AddGroups(Groups groups)
        {
            shortMsgShow.ShowMessage(UiMessage.GetGroupsMessage());
            {
                //shortMsgShow.ShowMessage("Add groups/people (separated with enter)  -- Press 0 to exit\n");

                while (true)
                {
                    string newGroup = Console.ReadLine()!;

                    if (newGroup == "0")
                    {
                        break;
                    }
                    else if (string.IsNullOrEmpty(newGroup))
                    {
                        shortMsgShow.ShowMessage(UiMessage.emptyNameWrongInputMessage);
                    }
                    else if (int.TryParse(newGroup, out _))
                    {
                        shortMsgShow.ShowMessage(UiMessage.numberWrongInputMessage);
                    }
                    else if (Groups.groups.Any(n => n.Name == newGroup))
                    {
                        shortMsgShow.ShowMessage(UiMessage.GroupExistsWrongInputMessage(newGroup));
                    }
                    else
                    {
                        groups.AddNewGroup(newGroup);
                    }
                }
            }


            public static Group AddItems(string selectedGroupNumber, Receipt receipt, string currency)
            {
                shortMsgShow.ShowMessage(UiMessage.AddItemPricesMessage(selectedGroupNumber));
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
                        shortMsgShow.ShowMessage(UiMessage.AddedPriceInfoMessage(currency, group, price));
                    }
                    else if (success && price == 0)
                    {
                        shortMsgShow.ShowMessage(UiMessage.TotalPayInfoMessage(currency, group));
                        break;
                    }
                    else
                    {
                        shortMsgShow.ShowMessage(UiMessage.nothingAddedWrongInputMessage);
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
                            shortMsgShow.ShowMessage(UiMessage.ChooseAgainWrongInputMessage(1, 4));
                            feeChoosen = Console.ReadLine()!;
                            break;
                    }
                }

                Calculation.GetTotalsWithFee(group, receipt, serviceFeePercent);
                selectMsgShow.ShowMessage(UiMessage.ShowPricesDatas(group, currency, receipt));
                Calculation.CheckAllCalculated(receipt, currency);
            }
        }
    }