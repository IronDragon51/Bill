using Bill.Backend;
using Bill.Ui;

namespace Bill.FullStack
{
    public class Start
    {
        public static void Welcome()
        {
            UiConstants._message.ShowMessage(UiMessage.WelcomeMessage());
            UiConstants._message.ShowMessage(UiMessage.ContinueMessage());
            PageManager.currentPage = Page.AddGroupsPage;
        }
    }
}
