﻿using Bill.Definition;
using Bill.Interfaces;

namespace Bill.Backend
{
    public class ErrorHandle
    {
        private static readonly IMessage showMessage = new ConsoleImplementationMessage();

        public static Group CheckGroupExistence(Group group, string selectedGroup)
        {
            try
            {
                group = Groups.groups.FirstOrDefault(g => g.Name == Groups.groups[Convert.ToInt32(selectedGroup) - 1].Name)!;

                if (string.IsNullOrEmpty(group.Name))
                {
                    throw new Exception("No group like this!");
                }
            }
            catch (Exception e)
            {
                showMessage.ShowMessage(e.Message);
            }

            return group;
        }
    }
}