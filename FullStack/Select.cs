using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;
using Bill.Ui;

namespace Bill.FullStack
{
    public static class Select
    {
        public static string? SelectGroup(string currency, Groups groups)
        {
            UiConst._menu.ShowMenu(UiMenu.ShowSelectableGroups());
            Group? group = new("");
            string selectedGroup = ConsoleExtraMethods.GetReadLineString();

            if (selectedGroup == "00")
            {
                currency = SelectCurrency(groups);
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
                UiConst._menu.ShowMenu(UiMenu.AlreadyCalculatedMessage(currency, groups));
            }

            return group.Name;
        }


        public static string SelectCurrency(Groups groups)
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
                        currency = SetCurrency(out exit, Currency.USD);
                        break;

                    case "2":
                        currency = SetCurrency(out exit, Currency.EUR);
                        break;

                    case "3":
                        currency = SetCurrency(out exit, Currency.HUF);
                        break;

                    case "00":
                        Add.AddGroups(groups);
                        break;

                    default:
                        UiConst._message.ShowMessage(UiMessage.ChooseAgainWrongInputMessage(1, 3));
                        choice = Console.ReadLine();
                        break;
                }
            }

            return currency;
        }

        public static string SetCurrency(out bool exit, Currency enumCurrency)
        {
            exit = true;

            return enumCurrency.ToString();
        }
    }
}