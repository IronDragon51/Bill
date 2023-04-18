using Bill.Definition;

namespace Bill.Interfaces
{
    public interface ISelectShow
    {
        void ShowPricesDatas(Group group, string currency, Receipt receipt);

        void ShowCurrencies();

        void ShowSelectableGroups();
    }
}
