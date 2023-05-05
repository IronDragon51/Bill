using Bill.Definition;

namespace Bill.Backend
{
    public class CreateNew
    {
        public static void CreateGroupsAndReceipt(out Groups groups, out Receipt receipt)
        {
            groups = new();
            receipt = new();
        }
    }
}
