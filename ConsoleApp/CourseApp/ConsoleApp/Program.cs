using ConsoleApp.Controllers;
using ConsoleApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController _groupController = new();
            Helper.PrintConsole(ConsoleColor.Cyan, "Select one option!");
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group, 2 - Update group, 3 - Delete Group, 4 - Get group by id, 5 - Get all groups by teacher, 6 - Get all groups by room, 7 - Get all groups, 8 - Create Student, 9 - Update Student, 10- Get student by id, 11 - Delete student, 12 - Get students by age, 13 - Get all students by group id, 14- Search method for groups by name, 15 - Search method for students by name or surname");

            while (true)
            {
            SelectOption: string selectOption = Console.ReadLine();
                int selectNumberOption;
                bool isSelectOption = int.TryParse(selectOption, out selectNumberOption);

                if (isSelectOption)
                {
                    switch (selectNumberOption)
                    {
                        case 1:
                            _groupController.CreateGroup();
                            break;
                        case 2:
                            _groupController.UpdateGroup();
                            break;
                        case 3:
                            _groupController.DeleteGroup();
                            break;
                        case 4:
                            _groupController.GetGroupById();
                            break;
                        case 7:
                            _groupController.GetAllGroups();
                            break;
                        case 14:
                            _groupController.SearchByGroupName();
                            break;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Please enter correct options type");
                    goto SelectOption;

                }
            }

        }
    }
}
