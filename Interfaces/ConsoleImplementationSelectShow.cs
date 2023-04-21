namespace Bill.Interfaces
{
    public class ConsoleImplementationSelectShow : ISelectMsgShow
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
