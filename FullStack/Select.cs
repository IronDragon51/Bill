using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;
using Bill.Ui;

namespace Bill.FullStack
{
    public static class Select
    {
        public static string? SelectGroup(Groups groups, Receipt receipt)
        {
            UiConst._menu.ShowMenu(UiMenu.ShowSelectableGroups());
            Group? group = new("");
            string selectedGroup = ConsoleExtraMethods.GetReadLineString();

            if (selectedGroup == "00")
            {
                receipt.Currency = SelectCurrency(groups, receipt);
            }
            else
            {
                group = ErrorHandle.CheckGroupExistence(group, selectedGroup);
            }

            if (group == null)
            {
                UiConst._message.ShowMessage(UiMessage.WaitKeyPressMessage());
                return null;
            }

            if (group!.Total > 0)
            {
                UiConst._menu.ShowMenu(UiMenu.AlreadyCalculatedMessage(groups, receipt));
            }

            return group.Name;
        }


        public static string SelectCurrency(Groups groups, Receipt receipt)
        {
            UiConst._menu.ShowMenu(UiMenu.ShowCurrencies());

            string currency = "";
            string? choice = ConsoleExtraMethods.GetReadLineString();
            bool exit = false;

            while (!exit)
            {
                switch (choice)
                {
                    case "1":
                        return Currency.USD.ToString();

                    case "2":
                        return Currency.EUR.ToString();

                    case "3":
                        return Currency.HUF.ToString();

                    case "00":
                        return "00";
                    //Add.AddGroups(groups, receipt);
                    //SelectCurrency(groups, receipt);

                    default:
                        UiConst._message.ShowMessage(UiMessage.ChooseAgainWrongInputMessage(1, 3));
                        choice = Console.ReadLine();
                        break;
                }
            }

            return currency;
        }
    }
}