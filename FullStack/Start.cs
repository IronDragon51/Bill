using Bill.Definition;
using Bill.Ui;

namespace Bill.FullStack
{
    public class Start
    {
        public static void Welcome(Groups groups, Receipt receipt)
        {
            UiConst._message.ShowMessage(UiMessage.WelcomeMessage());
            UiConst._message.ShowMessage(UiMessage.ContinueMessage());

        }
    }
}
