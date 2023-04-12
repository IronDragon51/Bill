using Bill.Definition;

namespace Bill
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

        public static void SetFeePercent(out double serviceFeePercent, out bool exit, ServiceFee fee)
        {
            serviceFeePercent = (double)fee;
            exit = true;
        }

        public static void GetTotalsWithFee(Group group, Receipt receipt, double serviceFeePercent)
        {
            group!.TotalWithFee = group.Total + (group.Total * serviceFeePercent) / 100;
            receipt.TotalWithFee += group.TotalWithFee;
        }

    }
}
