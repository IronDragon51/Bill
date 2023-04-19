using Bill.Definition;

namespace Bill.Interfaces
{
    public interface IShortMsgShow
    {
        void AddGroupsMessage();
        void AddItemPricesMessage(string selectedGroupName);
        void AddedPriceInfoMessage(string currency, Group group, double price);
        void EmptyNameWrongInputMessage();
        void GroupExistsWrongInputMessage(string newGroup);
        void NumberWrongInputMessage(); //Number_?  ... _Number?

    }
}
