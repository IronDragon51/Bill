using Bill.Definition;
using Bill.Interfaces;

namespace Bill.Backend
{
    public class ErrorHandle
    {
        private static readonly IShortMsgShow shortMsgShow = new ConsoleImplementationAddShow();

        public static Group CheckGroupExistence(Group group, int selectedGroup)
        {
            try
            {
                group = Groups.groups.FirstOrDefault(g => g.Name == Groups.groups[selectedGroup].Name)!;

                if (string.IsNullOrEmpty(group.Name))
                {
                    throw new Exception("No group like this!");
                }
            }
            catch (Exception e)
            {
                shortMsgShow.NoGroup_ExceptionInfoMessage(e);
            }

            return group;
        }
    }
}