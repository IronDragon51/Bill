using Bill.Definition;

namespace Bill
{
    public class Select
    {
        public static string SelectGroup(string currency)
        {
            Show.ShowSelectableGroups();

            Group group = new("")!;
            string selectedGroup = Console.ReadLine()!;
            group = ErrorHandle.CheckGroupExistence(group, selectedGroup);

            if (group.Total > 0)
            {
                Show.AlreadyCalculated(currency);
            }

            return selectedGroup;
        }


        public static string SelectCurrency()
        {
            Show.ShowCurrencies();

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
                        Console.WriteLine("Wrong input, choose from 1,2,3 options");
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
