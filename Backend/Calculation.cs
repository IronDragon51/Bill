using Bill.Definition;
using Bill.FullStack;

namespace Bill.Backend
{
    public class Calculation
    {
        public bool CheckAllCalculated(Receipt receipt, string currency)
        {
            Show.Continue();
            if (Groups.groups.All(g => g.Total > 0))
            {
                Show show = new();
                show.AllGroupsCalculated(currency);
                return true;
            }
            else
            {
                Add.AddLoop(receipt, currency);
                return false;
            }
        }

        public static double SetFeePercent(out bool exit, ServiceFee fee)
        {
            exit = true;
            return (double)fee;
        }

        public static void GetTotalsWithFee(Group group, Receipt receipt, double serviceFeePercent)
        {
            group!.TotalWithFee = group.Total + (group.Total * serviceFeePercent) / 100;
            receipt.TotalWithFee += group.TotalWithFee;
        }
    }
}
