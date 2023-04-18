using Bill.Definition;

namespace Bill.Interfaces
{
    public interface IShow
    {
        void ShowPricesDatas(Group group, string currency, Receipt receipt);

        void ShowCurrencies();

        void ShowSelectableGroups();

        void AlreadyCalculated(string currency);

        void Continue();

        void AllGroupsCalculated(string currency);
    }
}
