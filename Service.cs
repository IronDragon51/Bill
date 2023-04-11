namespace Bill
{
    public class Service
    {
        public static string ChooseServiceFee(string selectedGroupName, Groups groups, Group groupInput, Receipt receipt, string currency)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Group selectedGroup = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;
            Console.WriteLine($"Choose service fee: (Current total: {selectedGroup.Total})");
            Console.WriteLine($"1) {(int)ServiceFee.zero}% fee");
            Console.WriteLine($"2) {(int)ServiceFee.low}% fee");
            Console.WriteLine($"3) {(int)ServiceFee.medium}% fee");
            Console.WriteLine($"4) {(int)ServiceFee.high}% fee");

            string feeChoosen = Console.ReadLine()!;
            Group group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;

            return feeChoosen;
        }
    }
}