using Bill.Definition;

namespace Bill.Interfaces
{
    public interface IShortMsgShow
    {
        void AddGroups_Message();
        void AddItemPrices_Message(string selectedGroupName);
        void ChooseServiceFee_Message(Group selectedGroup);

        void AddedPrice_InfoMessage(string currency, Group group, double price);
        void TotalPay_InfoMessage(string currency, Group group);

        void Number_WrongInputMessage(); //Number_?  ... _Number?
        void EmptyName_WrongInputMessage();
        void GroupExists_WrongInputMessage(string newGroup);
        void NothingAdded_WrongInputMessage();
        void ChooseAgain4_WrongInputMessage();
        void ChooseAgain3_WrongInputMessage();

        void NoGroup_ExceptionInfoMessage(Exception e);
    }
}
