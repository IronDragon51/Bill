using Bill.Definition;
using Bill.Interfaces;

namespace Bill.Backend
{
    public class ErrorHandle
    {
        private static readonly IMessage showMessage = new ConsoleImplementationMessage();

        public static Group? CheckGroupExistence(Group group, string selectedGroupNumber)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(selectedGroupNumber) - 1;
                if (selectedIndex < 0 || selectedIndex >= Groups.groups.Count)
                {
                    throw new ArgumentOutOfRangeException(selectedGroupNumber + ": Invalid group index.");
                }

                group = Groups.groups.FirstOrDefault(g => g.Name == Groups.groups[Convert.ToInt32(selectedGroupNumber) - 1].Name)!;

                if (string.IsNullOrEmpty(group.Name) || group == null)
                {
                    throw new Exception("No group like this!");
                }
            }
            catch (Exception e)
            {
                showMessage.ShowMessage(e.Message);
                return null;
            }

            return group;
        }
    }
}