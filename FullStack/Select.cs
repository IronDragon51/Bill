using Bill.Backend;
using Bill.Definition;
using Bill.Interfaces;

namespace Bill.FullStack
{
    public static class Select
    {
        private static readonly ISelectMsgShow selectMsgShow = new ConsoleImplementationSelectShow();
        private static readonly IShortMsgShow shortMsgShow = new ConsoleImplementationAddShow();

        public static string SelectGroup(string currency)
        {
            selectMsgShow.ShowSelectableGroups();

            Group group = new("");
            string selectedGroup = Console.ReadLine()!;
            group = ErrorHandle.CheckGroupExistence(group, selectedGroup);

            if (group.Total > 0)
            {
                selectMsgShow.AlreadyCalculatedMessage(currency);
            }

            return group.Name;
        }


        public static string SelectCurrency()
        {
            selectMsgShow.ShowCurrencies();

            string currency = "";
            string choice = Console.ReadLine()!;
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
                        shortMsgShow.ChooseAgain3_WrongInputMessage();
                        choice = Console.ReadLine()!;
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