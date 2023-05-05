using Bill.Backend;
using Bill.Definition;
using Bill.Ui;
using System.Text.RegularExpressions;
using Group = Bill.Definition.Group;

namespace Bill.FullStack
{
    public static class Add
    {
        public static void AddLoop(Groups groups, Receipt receipt)
        {
            Group? group = null;

            while (group == null && (groups.selectedGroupName == null || groups.selectedGroupName == ""))
            {
                groups.selectedGroupName = Select.SelectGroup(groups, receipt);
                if (groups.selectedGroupName == "00")
                {
                    AddGroups(groups, receipt);
                }
                group = AddItemPrices(groups, receipt);
            }

            string choice = Service.ChooseServiceFee(groups, receipt);
            AddServiceFee(group, groups, choice, receipt);
        }


        public static bool AddGroups(Groups groups, Receipt receipt)
        {
            Regex hungarianLettersRegex = new("^[a-zA-ZÁÉÍÓÖŐÚÜŰáéíóöőúüű ]*$");
            UiConst._message.ShowMessage(UiMessage.AddGroupsMessage());
            UiConst._message.ShowMessage(UiMessage.ShowAllGroups());


            while (true)
            {
                string newGroup = Console.ReadLine()!;

                if (newGroup == "0")
                {
                    if (Groups.groups.Count > 0)
                    {

                        while (true)
                        {
                            string currency = Select.SelectCurrency(groups, receipt);
                            AddLoop(groups, receipt);

                            if (currency == "00")
                            {
                                AddGroups(groups, receipt); //meghivja sajat magat ha 00-t irunk a select currencyben
                            }
                            else
                            {
                                currency = Select.SelectCurrency(groups, receipt);
                                AddLoop(groups, receipt);
                            }

                            return false;
                        }

                    }
                    else
                    {
                        UiConst._message.ShowMessage(UiConst.noGroupsMessage);
                        continue;
                    }
                }

                if (newGroup == "00")
                {
                    return true;
                }
                else if (!ValidateHungarianLettersInput(hungarianLettersRegex, newGroup))
                {
                    continue;
                }
                else if (string.IsNullOrWhiteSpace(newGroup))
                {
                    UiConst._message.ShowMessage(UiConst.emptyNameWrongInputMessage);
                }
                else if (Groups.groups.Any(n => n.Name == newGroup))
                {
                    UiConst._message.ShowMessage(UiMessage.GroupExistsWrongInputMessage(newGroup));
                }
                else
                {
                    Groups.AddNewGroup(newGroup);
                }
            }
            return false;
        }

        private static bool ValidateHungarianLettersInput(Regex hungarianLettersRegex, string newGroup)
        {
            if (!hungarianLettersRegex.IsMatch(newGroup))
            {
                Console.WriteLine("Invalid input. Please enter only Hungarian letters!");
                return false;
            }
            return true;
        }


        public static Group AddItemPrices(Groups groups, Receipt receipt)
        {
            UiConst._menu.ShowMenu(UiMenu.GetItemPricesMessage(groups.selectedGroupName));
            Group group = new("");
            double price = 0;
            bool exit = false;

            while (!exit)
            {
                bool success = double.TryParse(Console.ReadLine(), out price);
                group = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName)!;

                if (success && price == 00)
                {
                    return group;
                }
                else if (success && price != 0)
                {
                    group!.Total += price;
                    receipt.Total += price;
                    UiConst._message.ShowMessage(UiMessage.AddedPriceInfoMessage(group, price, receipt));
                }
                else if (success && price == 0)
                {
                    UiConst._message.ShowMessage(UiMessage.TotalPayInfoMessage(group, receipt));
                    exit = true;
                }
                else
                {
                    UiConst._message.ShowMessage(UiConst.nothingAddedWrongInputMessage);
                }
            }

            return group;
        }


        public static void AddServiceFee(Group group, Groups groups, string feeChoosen, Receipt receipt)
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
            UiConst._menu.ShowMenu(UiMenu.ShowPricesDatas(group, receipt));
            Calculation.CheckAllCalculated(groups, receipt);
        }
    }
}