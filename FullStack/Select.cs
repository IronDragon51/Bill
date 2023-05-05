using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;
using Bill.Ui;

namespace Bill.FullStack
{
    public static class Select
    {
        public static string SelectGroup(Groups groups, Receipt receipt)
        {
            UiConst._menu.ShowMenu(UiMenu.ShowSelectableGroups());
            Group? group = new("");

            groups.selectedGroupName = ConsoleExtraMethods.GetReadLineString();

            if (groups.selectedGroupName == "00")
            {
                return "00";
            }
            else
            {
                group = ErrorHandle.CheckGroupExistence(group, groups.selectedGroupName);
            }

            if (group == null)
            {
                UiConst._message.ShowMessage(UiMessage.WaitKeyPressMessage());
                return "";
            }

            groups.selectedGroupName = group.Name;

            if (group!.Total > 0)
            {
                UiConst._menu.ShowMenu(UiMenu.AlreadyCalculatedMessage(groups, receipt));
            }

            return group.Name;
        }


        public static void SelectCurrency(Receipt receipt)
        {
            UiConst._menu.ShowMenu(UiMenu.ShowCurrencies());

            string? choice = ConsoleExtraMethods.GetReadLineString();
            bool exit = false;

            while (!exit)
            {
                switch (choice)
                {
                    case "1":
                        receipt.Currency = Currency.USD.ToString();
                        exit = true;
                        break;

                    case "2":
                        receipt.Currency = Currency.EUR.ToString();
                        exit = true;
                        break;

                    case "3":
                        receipt.Currency = Currency.HUF.ToString();
                        exit = true;
                        break;

                    case "00":
                        PageManager.page = PageManager.AddGroups;
                        exit = true;
                        break;

                    default:
                        UiConst._message.ShowMessage(UiMessage.ChooseAgainWrongInputMessage(1, 3));
                        choice = Console.ReadLine();
                        break;
                }
            }

            PageManager.page = PageManager.SelectGroup;
        }
    }
}