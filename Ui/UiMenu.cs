using Bill.Definition;
using Bill.FullStack;
using Group = Bill.Definition.Group;

namespace Bill.Ui
{
    public class UiMenu
    {
        public static string GetItemPricesMessage(Groups groups)
        {
            StringWriter sw = new();
            sw.WriteLine($"Add item prices (separated with enter) to {groups.selectedGroupName} {UiConstants.ContinueReturnMessage} {UiConstants.EnterMessage}");

            return sw.ToString();
        }

        public static string ShowPricesDatas(Groups groups, Receipt receipt)
        {
            Group selectedGroup = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName)!;
            StringWriter sw = new();
            sw.WriteLine($"{selectedGroup.Name}, total price to pay is: {selectedGroup.ToStringTotal(receipt.Currency!)} ");
            sw.WriteLine($"With service fee included: {selectedGroup.ToStringTotalWithFee(receipt.Currency!)} \n");
            sw.WriteLine($"For everyone, total price to pay is: {receipt.ToStringTotal(receipt.Currency!)} ");
            sw.WriteLine($"With service fee included: {receipt.ToStringTotalWithFee(receipt.Currency!)}");
            sw.WriteLine(UiConstants.DivLineNAfter);

            return sw.ToString();
        }

        public static string ShowSelectableGroups()
        {
            StringWriter sw = new();
            sw.WriteLine($"Select a group/person to add prices to! {UiConstants.ContinueReturnMessage} {UiConstants.EnterMessage}\n");
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
            sw.WriteLine($"Choose service fee: (Current total: {selectedGroup.Total} {currency}) {UiConstants.ContinueReturnMessage} {UiConstants.EnterMessage}");
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
            sw.WriteLine($"Calculate anyway? (y/n) {UiConstants.EnterMessage}");
            string? input = Console.ReadLine();

            if (input == "n")
            {
                Select.SelectGroup(groups, receipt);
            }
            else if (input != "y")
            {
                sw.WriteLine($"Wrong userInput! Type 'y' or 'n'! {UiConstants.EnterMessage}");
            }

            return sw.ToString();
        }

        public static string ShowCurrencies()
        {
            StringWriter sw = new();
            sw.WriteLine($"Select a currency! {UiConstants.ReturnMessage} {UiConstants.EnterMessage}\n");
            sw.WriteLine("Options:");
            sw.WriteLine($"1) {Currency.USD}");
            sw.WriteLine($"2) {Currency.EUR}");
            sw.WriteLine($"3) {Currency.HUF}");

            return sw.ToString();
        }
    }
}
