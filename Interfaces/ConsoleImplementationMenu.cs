namespace Bill.Interfaces
{
    public class ConsoleImplementationMenu : IMenu
    {
        public void ShowMenu(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            if (message.Contains("Press any key"))
            {
                Console.ReadKey();
            }
        }
    }
}
