using ConsoleApp.Controllers;
using ConsoleApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
using System.Runtime.CompilerServices;
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupController _groupController = new();
            StudentController _studentController = new();
            Helper.PrintConsole(ConsoleColor.Cyan, "Select one option!");
            GetMenus();

            while (true)
            {
            SelectOption: string selectOption = Console.ReadLine();
                int selectNumberOption;
                bool isSelectOption = int.TryParse(selectOption, out selectNumberOption);

                if (isSelectOption)
                {
                    switch (selectNumberOption)
                    {
                        case (int)Menus.CreateGroup:
                            _groupController.CreateGroup();
                            break;
                        case (int)Menus.UpdateGroup:
                            _groupController.UpdateGroup();
                            break;
                        case (int)Menus.DeleteGroup:
                            _groupController.DeleteGroup();
                            break;
                        case (int)Menus.GetGroupById:
                            _groupController.GetGroupById();
                            break;
                        case (int)Menus.GetAllGroups:
                            _groupController.GetAllGroups();
                            break;
                        case (int)Menus.CreateStudent:
                            _studentController.CreateStudent();
                            break;
                        case (int)Menus.UpdateStudent:
                            _studentController.UpdateStudent();
                            break;
                        case (int)Menus.GetStudentById:
                            _studentController.GetStudentById();
                            break;
                        case (int)Menus.DeleteStudent:
                            _studentController.DeleteStudent();
                            break;
                        case (int)Menus.GetAllStudentsByGroupId:
                            _studentController.GetAllStudentsByGroupId();
                            break;
                        case (int)Menus.SearchByStudentNameOrSurname:
                            _studentController.Search();
                            break;
                        case (int)Menus.GetStudentByAge:
                            _studentController.GetStudentByAge();
                            break;
                        case (int)Menus.GetAllStudent:
                            _studentController.GetAllStudent();
                            break;
                        case (int)Menus.SearchByGroupName:
                            _groupController.SearchByGroupName();
                            break;
                        case (int)Menus.GetAllGropuByRoom:
                            _groupController.GetByRoom();
                            break;
                        case (int)Menus.GetGroupByTeacher:
                            _groupController.GetByTeacher();
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

        private static void GetMenus()
        {
            Helper.PrintConsole(ConsoleColor.Yellow,
                " 1 - Create group\n" +
                " 2 - Update group\n " +
                "3 - Delete group\n " +
                "4 - Get group by id\n " +
                "5 - Get all groups by teacher\n " +
                "6 - Get all groups by room\n " +
                "7 - Get all groups\n " +
                "8 - Create student\n " +
                "9 - Update student\n " +
                "10 - Get student by id\n " +
                "11 - Delete student\n " +
                "12 - Get students by age\n " +
                "13 - Get all students by group id\n " +
                "14 - Search method for groups by name\n " +
                "15 - Search method for students by name or surname\n" +
                " 16 - Get all student\n" 

                );

        }
    }
}
