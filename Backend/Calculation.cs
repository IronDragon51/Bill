using Bill.Definition;
using Bill.FullStack;
using Bill.Interfaces;

namespace Bill.Backend
{
    public static class Calculation
    {
        private static readonly ISelectMsgShow selectMsgShow = new ConsoleImplementationSelectShow();

        public static bool CheckAllCalculated(Receipt receipt, string currency)
        {
            selectMsgShow.ShowMessage(UiMessage.ContinueMessage());

            if (Groups.groups.All(g => g.Total > 0))
            {
                selectMsgShow.ShowMessage(UiMessage.AllGroupsCalculatedMessage(currency));

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
            group!.TotalWithFee = group.Total + (group.Total * serviceFeePercent / 100);
            receipt.TotalWithFee += group.TotalWithFee;
        }
    }
}
