using Bill.Definition;
using Bill.Interfaces;

namespace Bill.FullStack
{
    public class Service
    {
        private static readonly IShortMsgShow shortMsgShow = new ConsoleImplementationAddShow();

        public static string ChooseServiceFee(string selectedGroupName, string currency)
        {
            Group selectedGroup = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;
            shortMsgShow.ChooseServiceFee_Message(selectedGroup, currency);

            string feeChoosen = Console.ReadLine()!;
            Group group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroupName)!;

            return feeChoosen;
        }
    }
}