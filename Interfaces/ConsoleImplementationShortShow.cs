namespace Bill.Interfaces
{
    public class ConsoleImplementationAddShow : IShortMsgShow
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}