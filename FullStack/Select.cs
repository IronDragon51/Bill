using Bill.Backend;
using Bill.Definition;
using Bill.Ui;

namespace Bill.FullStack
{
    public static class Select
    {
        public static string SelectGroup(string currency)
        {
            UiConst._menu.ShowMenu(UiMenu.ShowSelectableGroups());
            Group? group = new("");
            string selectedGroup = Console.ReadLine()!;
            group = ErrorHandle.CheckGroupExistence(group, selectedGroup);

            if (group == null)
            {
                UiConst._message.ShowMessage(UiMessage.WaitKeyPressMessage());
                return null;
            }

            if (group!.Total > 0)
            {
                UiConst._menu.ShowMenu(UiMenu.AlreadyCalculatedMessage(currency));
            }

            return group.Name;
        }


        public static string SelectCurrency()
        {
            UiConst._menu.ShowMenu(UiMenu.ShowCurrencies());

            string currency = "";
            string? choice = Console.ReadLine();
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