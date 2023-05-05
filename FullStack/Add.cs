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
            UiConstants._message.ShowMessage(UiMessage.AddGroupsMessage());
            UiConstants._message.ShowMessage(UiMessage.ShowAllGroups());

            while (true)
            {
                string newGroup = Console.ReadLine()!;

                if (newGroup == "0")
                {
                    if (Groups.groups.Count > 0)
                    {
                        PageManager.currentPage = Page.SelectCurrencyPage;

                        return;
                    }
                    else
                    {
                        UiConstants._message.ShowMessage(UiConstants.NoGroupsMessage);

                        continue;
                    }
                }

                if (newGroup == "00")
                {
                    PageManager.currentPage = Page.WelcomePage;
                }
                else if (!ValidateHungarianLettersInput(hungarianLettersRegex, newGroup))
                {
                    continue;
                }
                else if (string.IsNullOrWhiteSpace(newGroup))
                {
                    UiConstants._message.ShowMessage(UiConstants.EmptyNameWrongInputMessage);
                }
                else if (Groups.groups.Any(n => n.Name == newGroup))
                {
                    UiConstants._message.ShowMessage(UiMessage.GroupExistsWrongInputMessage(newGroup));
                }
                else
                {
                    PageManager.currentPage = Page.SelectCurrencyPage;
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
            UiConstants._menu.ShowMenu(UiMenu.GetItemPricesMessage(groups));
            Group group = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName)!;
            double price = 0;
            bool success = false;
            bool goToNextPage = false;

            while (!goToNextPage)
            {
                string input = ConsoleExtraMethods.GetReadLineString();

                if (input == "00")
                {
                    PageManager.currentPage = Page.SelectGroupPage;
                    return;
                }
                else if (input == "0")
                {
                    UiConstants._message.ShowMessage(UiMessage.TotalPayInfoMessage(group, receipt));
                    PageManager.currentPage = Page.ChooseServiceFeePage;
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
                    UiConstants._message.ShowMessage(UiMessage.AddedPriceInfoMessage(group, price, receipt));
                }
                else
                {
                    UiConstants._message.ShowMessage(UiConstants.NothingAddedWrongInputMessage);
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
                        serviceFeePercent = Calculation.SetFeePercent(ServiceFee.zero);
                        exit = true;
                        break;

                    case "2":
                        serviceFeePercent = Calculation.SetFeePercent(ServiceFee.low);
                        exit = true;
                        break;

                    case "3":
                        serviceFeePercent = Calculation.SetFeePercent(ServiceFee.medium);
                        exit = true;
                        break;

                    case "4":
                        serviceFeePercent = Calculation.SetFeePercent(ServiceFee.high);
                        exit = true;
                        break;

                    case "00":
                        PageManager.currentPage = Page.AddItemPricesPage;
                        exit = true;
                        break;

                    default:
                        UiConstants._message.ShowMessage(UiMessage.ChooseAgainWrongInputMessage(1, 4));
                        feeChoosen = Console.ReadLine()!;
                        break;
                }
            }

            return serviceFeePercent;
        }
    }
}