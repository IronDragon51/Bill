using Bill.Backend;
using Bill.Ui;

namespace Bill.FullStack
{
    public class Start
    {
        public static void Welcome()
        {
            UiConst._message.ShowMessage(UiMessage.WelcomeMessage());
            UiConst._message.ShowMessage(UiMessage.ContinueMessage());
            PageManager.page = PageManager.AddGroups;

        }
    }
}
