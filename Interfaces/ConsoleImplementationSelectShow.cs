using Bill.Definition;
using Bill.FullStack;

namespace Bill.Interfaces
{
    public class ConsoleImplementationSelectShow : ISelectMsgShow
    {
        private const string _divLineNBefore = "\n" + _divLine;
        private const string _divLineNAfter = _divLine + "\n";
        private const string _divLine = "--------------------------------";

        public void ShowPricesDatas(Group group, string currency, Receipt receipt)
        {
            Console.Clear();
            string line1 = $"{group.Name}, total price to pay is: {group.ToStringTotal(currency)} ";
            string line2 = $"With service fee included: {group.ToStringTotalWithFee(currency)} \n";
            string line3 = $"For everyone, total price to pay is: {receipt.ToStringTotal(currency)} ";
            string line4 = $"With service fee included: {receipt.ToStringTotalWithFee(currency)}";

            Console.WriteLine(line1);
            Console.WriteLine(line2);
            Console.WriteLine(line3);
            Console.WriteLine(line4);
            Console.WriteLine(_divLineNAfter);

            //File.WriteAllLines(, );
        }

        public void ShowCurrencies()
        {
            Console.Clear();
            Console.WriteLine(_divLine);
            Console.WriteLine("Select a currency!\n");
            Console.WriteLine("Options:");
            Console.WriteLine($"1) {Currency.USD}");
            Console.WriteLine($"2) {Currency.EUR}");
            Console.WriteLine($"3) {Currency.HUF}");
        }

        public void ShowSelectableGroups()
        {
            Console.Clear();
            Console.WriteLine(_divLine);
            Console.WriteLine("Select a group/person to add prices to!\n");
            Console.WriteLine("Options:");

            int num = 0;
            foreach (Group currentGroup in Groups.groups)
            {
                num++;
                Console.WriteLine($"{num}) {currentGroup.Name}");
            }

            Console.WriteLine();
        }

        public void AlreadyCalculatedMessage(string currency)
        {
            Console.WriteLine("Already calculated!");
            Console.WriteLine("Calculate anyway? (y/n)");
            string input = Console.ReadLine()!;

            if (input == "n")
            {
                Select.SelectGroup(currency);
            }
            else if (input != "y")
            {
                Console.WriteLine("Wrong input! Type 'y' or 'n'");
            }
        }

        public void ContinueMessage()
        {
            Console.WriteLine("Press any key to continue\n");
            Console.ReadKey();
        }

        public virtual void AllGroupsCalculatedMessage(string currency)
        {
            Console.WriteLine(_divLineNBefore);
            Console.WriteLine("All groups/person calculated!\n");
            Console.WriteLine("Name \t Total \t\t Total with fee");
            foreach (Group currGroup in Groups.groups)
            {
                Console.WriteLine($"{currGroup.Name} \t {currGroup.ToStringTotal(currency)} \t {currGroup.ToStringTotalWithFee(currency)}");
            }
            Environment.Exit(0);
        }
    }
}
