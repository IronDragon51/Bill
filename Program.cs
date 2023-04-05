namespace Bill
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add groups/people");

            //bool exit = false;
            string input;
            while (true)
            {
                Console.WriteLine("Press 1 to exit");
                input = Console.ReadLine()!;
                if (input == "1")
                {
                    //exit = true;
                    break;
                }
                else
                {
                    Groups.AddNewGroup(input);
                }

            }

            foreach (var item in Groups.groups)
            {
                Console.WriteLine(item.Name + item.TotalWithFee + item.Total);
            }
        }
    }
}