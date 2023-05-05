using Bill.Definition;
using Bill.Ui;

namespace Bill.Backend
{
    public static class Calculation
    {
        public static void CheckAllCalculated(Groups groups, Receipt receipt)
        {
            UiConst._message.ShowMessage(UiMessage.ContinueMessage());

            if (Groups.groups.All(g => g.Total > 0))
            {
                //if (!Console.IsOutputRedirected)
                //{
                UiConst._message.ShowMessage(UiMessage.AllGroupsCalculatedMessage(receipt));
                //}
            }
        }

        public static double SetFeePercent(out bool exit, ServiceFee fee)
        {
            exit = true;
            return (double)fee;
        }

        public static void GetTotalsWithFee(Groups groups, Receipt receipt, double serviceFeePercent)
        {
            Group group = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName)!;
            group!.TotalWithFee = group.Total + (group.Total * serviceFeePercent / 100);
            receipt.TotalWithFee += group.TotalWithFee;
        }
    }
}
