namespace Bill
{
    public class Service
    {
        public static void ChooseServiceFee(string groupName, Groups groups, Receipt receipt)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Choose service fee:");
            Group? group = Groups.groups.FirstOrDefault(g => g.Name == groupName);

            double serviceFeePercent = 0;
            int zero = (int)ServiceFee.zero;
            int low = (int)ServiceFee.low;
            int medium = (int)ServiceFee.medium;
            int high = (int)ServiceFee.high;

            Console.WriteLine($"1) {zero}% fee");
            Console.WriteLine($"2) {low}% fee");
            Console.WriteLine($"3) {medium}% fee");
            Console.WriteLine($"4) {high}% fee");

            string feeChoosen = Console.ReadLine()!;
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