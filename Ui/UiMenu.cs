using Bill.Definition;
using Bill.FullStack;

namespace Bill.Ui
{
    public class UiMenu
    {
        public static string GetItemPricesMessage(string selectedGroupName)
        {
            StringWriter sw = new();
            sw.WriteLine($"Add item prices (separated with enter) to {selectedGroupName} {UiConst.continueReturnMessage} {UiConst.enterMessage}");

            return sw.ToString();
        }

        public static string ShowPricesDatas(Group group, Receipt receipt)
        {
            StringWriter sw = new();
            sw.WriteLine($"{group.Name}, total price to pay is: {group.ToStringTotal(receipt.Currency!)} ");
            sw.WriteLine($"With service fee included: {group.ToStringTotalWithFee(receipt.Currency!)} \n");
            sw.WriteLine($"For everyone, total price to pay is: {receipt.ToStringTotal(receipt.Currency!)} ");
            sw.WriteLine($"With service fee included: {receipt.ToStringTotalWithFee(receipt.Currency!)}");
            sw.WriteLine(UiConst._divLineNAfter);

            return sw.ToString();
        }

        public static string AllGroupsCalculatedMessage(Receipt receipt)
        {
            StringWriter sw = new();
            sw.WriteLine("All groups/person calculated!\n");
            sw.WriteLine("Name \t Total \t\t Total with fee");

            foreach (Group currGroup in Groups.groups)
            {
                sw.WriteLine($"{currGroup.Name} \t {currGroup.ToStringTotal(receipt.Currency!)} \t\t {currGroup.ToStringTotalWithFee(receipt.Currency!)}");
            }

            return sw.ToString();
        }


        public static string ShowSelectableGroups()
        {
            StringWriter sw = new();
            sw.WriteLine($"Select a group/person to add prices to! {UiConst.continueReturnMessage} {UiConst.enterMessage}\n");
            sw.WriteLine("Options:");
            int num = 0;

            foreach (Group currentGroup in Groups.groups)
            {
                num++;
                sw.WriteLine($"{num}) {currentGroup.Name}");
            }

            sw.WriteLine();

            return sw.ToString();
        }

        public static string ChooseServiceFeeMessage(Group selectedGroup, string currency)
        {
            StringWriter sw = new();
            sw.WriteLine($"Choose service fee: (Current total: {selectedGroup.Total} {currency}) {UiConst.continueReturnMessage} {UiConst.enterMessage}");
            sw.WriteLine($"1) {(int)ServiceFee.zero}% fee");
            sw.WriteLine($"2) {(int)ServiceFee.low}% fee");
            sw.WriteLine($"3) {(int)ServiceFee.medium}% fee");
            sw.WriteLine($"4) {(int)ServiceFee.high}% fee");

            return sw.ToString();
        }

        public static string AlreadyCalculatedMessage(Groups groups, Receipt receipt)
        {
            StringWriter sw = new();
            sw.WriteLine("Already calculated!");
            sw.WriteLine($"Calculate anyway? (y/n) {UiConst.enterMessage}");
            string? input = Console.ReadLine();

            if (input == "n")
            {
                Select.SelectGroup(groups, receipt);
            }
            else if (input != "y")
            {
                sw.WriteLine($"Wrong input! Type 'y' or 'n'! {UiConst.enterMessage}");
            }

            return sw.ToString();
        }

        public static string ShowCurrencies()
        {
            StringWriter sw = new();
            sw.WriteLine($"Select a currency! {UiConst.returnMessage} {UiConst.enterMessage}\n");
            sw.WriteLine("Options:");
            sw.WriteLine($"1) {Currency.USD}");
            sw.WriteLine($"2) {Currency.EUR}");
            sw.WriteLine($"3) {Currency.HUF}");

            return sw.ToString();
        }
    }
}
