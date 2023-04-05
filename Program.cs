
namespace Bill
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add groups/people");

            string input;
            while (true)
            {
                Console.WriteLine("Press 1 to exit");
                input = Console.ReadLine()!;
                if (input == "1")
                {
                    break;
                }
                else
                {
                    Groups.AddNewGroup(input);
                }

            }

            Console.WriteLine("Select a group/person to add prices to");

            input = Console.ReadLine()!;
            foreach (Group group in groups)
            {
                foreach (var item in collection)
                {

                }
            }

            Console.WriteLine("Add item price");
            while (true)
            {
                Console.WriteLine("Press 1 to exit");
                double price = Convert.ToDouble(Console.ReadLine());
                if (input == "1")
                {
                    break;
                }
                else
                {
                    matchingName.AddItem
                }

            }

        }
    }
}