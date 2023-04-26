using Bill.Definition;
using Bill.FullStack;
using Bill.Ui;

namespace Bill.Backend
{
    public static class Calculation
    {
        public static bool CheckAllCalculated(Receipt receipt, string currency)
        {
            UiConst._message.ShowMessage(UiMessage.ContinueMessage());

            if (Groups.groups.All(g => g.Total > 0))
            {
                if (!Console.IsOutputRedirected)
                {
                    UiConst._menu.ShowMenu(UiMenu.AllGroupsCalculatedMessage(currency));
                }

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
