using Bill.Definition;
using Bill.FullStack;

namespace Bill.Backend
{
    public class Calculation
    {
        public static void CheckAllCalculated(Receipt receipt, string currency)
        {
            Console.WriteLine("Press any key to continue\n");
            Console.ReadKey();
            if (Groups.groups.All(g => g.Total > 0))
            {
                Show.AllGroupsCalculated(currency);
            }
            else
            {
                Add.AddLoop(receipt, currency);
            }
        }

        public static double SetFeePercent(out bool exit, ServiceFee fee)
        {
            exit = true;
            return (double)fee;
        }

        public static void GetTotalsWithFee(Group group, Receipt receipt, double serviceFeePercent)
        {
            group!.TotalWithFee = group.Total + group.Total * serviceFeePercent / 100;
            receipt.TotalWithFee += group.TotalWithFee;
        }

    }
}
