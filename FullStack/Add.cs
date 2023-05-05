using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;
using Bill.Ui;
using System.Text.RegularExpressions;
using Group = Bill.Definition.Group;

namespace Bill.FullStack
{
    public static class Add
    {
        public static void AddGroups(Groups groups, Receipt receipt)
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
                        PageManager.page = PageManager.SelectCurrency;
                    }
                    else
                    {
                        UiConst._message.ShowMessage(UiConst.noGroupsMessage);

                        continue;
                    }
                }

                if (newGroup == "00")
                {
                    PageManager.page = PageManager.Welcome;
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
                    PageManager.page = PageManager.SelectCurrency;
                    Groups.AddNewGroup(newGroup);
                }
            }
        }

        private static bool ValidateHungarianLettersInput(Regex hungarianLettersRegex, string newGroup)
        {
            if (!hungarianLettersRegex.IsMatch(newGroup))
            {
                Console.WriteLine("Invalid userInput. Please enter only Hungarian letters!");
                return false;
            }

            return true;
        }


        public static void AddItemPrices(Groups groups, Receipt receipt)
        {
            UiConst._menu.ShowMenu(UiMenu.GetItemPricesMessage(groups));
            Group group = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName)!;
            double price = 0;
            bool success = false;
            bool goToNextPage = false;

            while (!goToNextPage)
            {
                string input = ConsoleExtraMethods.GetReadLineString();

                if (input == "00")
                {
                    PageManager.page = PageManager.SelectGroup;
                    return;
                }
                else if (input == "0")
                {
                    UiConst._message.ShowMessage(UiMessage.TotalPayInfoMessage(group, receipt));
                    PageManager.page = PageManager.ChooseServiceFee;
                    return;
                }
                else
                {
                    success = double.TryParse(input, out price);
                }

                if (success && price != 0)
                {
                    group!.Total += price;
                    receipt.Total += price;
                    UiConst._message.ShowMessage(UiMessage.AddedPriceInfoMessage(group, price, receipt));
                }
                else
                {
                    UiConst._message.ShowMessage(UiConst.nothingAddedWrongInputMessage);
                }
            }
        }


        public static double AddServiceFee(Groups groups, string feeChoosen, Receipt receipt)
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

                    case "00":
                        PageManager.page = PageManager.AddItemPrices;
                        exit = true;
                        break;

                    default:
                        UiConst._message.ShowMessage(UiMessage.ChooseAgainWrongInputMessage(1, 4));
                        feeChoosen = Console.ReadLine()!;
                        break;
                }
            }

            return serviceFeePercent;
        }
    }
}