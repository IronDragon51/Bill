namespace Bill
{
    public class Service
    {
        public static double serviceFeePercent = 0;
        readonly static int zero = (int)ServiceFee.zero;
        readonly static int low = (int)ServiceFee.low;
        readonly static int medium = (int)ServiceFee.medium;
        readonly static int high = (int)ServiceFee.high;

        public static void ChooseServiceFee(string groupName, Groups groups, Receipt receipt)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Choose service fee:");
            Group? group = Groups.groups.FirstOrDefault(g => g.Name == groupName);


            Console.WriteLine($"1) {zero}% fee");
            Console.WriteLine($"2) {low}% fee");
            Console.WriteLine($"3) {medium}% fee");
            Console.WriteLine($"4) {high}% fee");

            string feeChoosen = Console.ReadLine()!;
            AddServiceFee(group, feeChoosen);
        }

        private static void AddServiceFee(Group? group, string feeChoosen)
        {
            bool exit = false;
            while (!exit)
            {
                switch (feeChoosen)
                {
                    case "1":
                        serviceFeePercent = zero;
                        exit = true;
                        break;

                    case "2":
                        serviceFeePercent = low;
                        exit = true;
                        break;

                    case "3":
                        serviceFeePercent = medium;
                        exit = true;
                        break;

                    case "4":
                        serviceFeePercent = high;
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong input, choose from 1,2,3,4 options");
                        break;
                }
            }

            group!.TotalWithFee = group.Total + (group.Total * serviceFeePercent) / 100;
            Console.WriteLine($"Total price to pay (with service fee included): {group.TotalWithFee}");
            Console.WriteLine("--------------------------------");
        }
    }
}