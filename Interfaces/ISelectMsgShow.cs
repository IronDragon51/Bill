using Bill.Definition;

namespace Bill.Interfaces
{
    public interface ISelectMsgShow
    {
        void ShowPricesDatas(Group group, string currency, Receipt receipt);

        void ShowCurrencies();

        void ShowSelectableGroups();

        void AlreadyCalculatedMessage(string currency);

        void ContinueMessage();

        void AllGroupsCalculatedMessage(string currency);
    }
}