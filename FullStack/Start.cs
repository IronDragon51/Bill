using Bill.Definition;
using Bill.Ui;

namespace Bill.FullStack
{
    public class Start
    {
        public static void Welcome()
        {
            Groups groups = new();
            Receipt receipt = new();
            UiConst._message.ShowMessage(UiMessage.WelcomeMessage());
            UiConst._message.ShowMessage(UiMessage.ContinueMessage());

            while (true)
            {
                bool goBack = Add.AddGroups(groups, receipt);
                if (goBack == true)
                {
                    Welcome();
                }
                else
                {
                    _ = Add.AddGroups(groups, receipt);
                }
            }
        }
    }
}
