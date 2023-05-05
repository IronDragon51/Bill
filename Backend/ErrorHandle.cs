using Bill.Definition;
using Bill.Interfaces;

namespace Bill.Backend
{
    public static class ErrorHandle
    {
        private static readonly IMessage _showMessage = new ConsoleImplementationMessage();

        public static Group? CheckGroupExistence(Group group, string selectedGroupNumber)
        {
            try
            {
                int selectedIndex = Convert.ToInt32(selectedGroupNumber) - 1;
                if (selectedIndex < 0 || selectedIndex >= Groups.groups.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(selectedGroupNumber), "Invalid group index.");
                }

                group = Groups.groups[selectedIndex];
                if (group == null || string.IsNullOrEmpty(group.Name))
                {
                    throw new ArgumentException("No group like this!", nameof(selectedGroupNumber));
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                _showMessage.ShowMessage(e.Message);
                return null;
            }
            catch (ArgumentException e)
            {
                _showMessage.ShowMessage(e.Message);
                return null;
            }
            catch (FormatException e)
            {
                _showMessage.ShowMessage("Invalid input format: " + e.Message);
                return null;
            }

            return group;
        }
    }
}
