using Bill.Definition;

namespace Bill.Backend
{
    public class ErrorHandle
    {
        public static Group CheckGroupExistence(Group group, string selectedGroup)
        {
            try
            {
                group = Groups.groups.FirstOrDefault(g => g.Name == selectedGroup)!;

                if (string.IsNullOrEmpty(group.Name))
                {
                    throw new Exception("No group like this!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return group;
        }
    }
}