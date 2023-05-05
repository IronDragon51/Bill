using Bill.Definition;
using Bill.Ui;

namespace Bill.Backend
{
    public static class Calculation
    {
        public static void CheckAllCalculated(Groups groups, Receipt receipt)
        {
            if (Groups.groups.All(g => g.Total > 0))
            {
                UiConst._message.ShowMessage(UiMessage.AllGroupsCalculatedMessage(receipt));
            }
        }

        public static double SetFeePercent(ServiceFee serviceFee)
        {
            return (double)serviceFee;
        }

        public static void UpdateTotalsWithFee(Groups groups, Receipt receipt, double serviceFeePercent)
        {
            Group? selectedGroup = Groups.groups.FirstOrDefault(g => g.Name == groups.selectedGroupName);
            if (selectedGroup != null)
            {
                selectedGroup.TotalWithFee = selectedGroup.Total + (selectedGroup.Total * serviceFeePercent / 100);
                receipt.TotalWithFee += selectedGroup.TotalWithFee;
            }
        }
    }
}
