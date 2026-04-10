using ConsoleApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroupService _groupService = new();
            Helper.PrintConsole(ConsoleColor.Blue, "Select one option!");
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group, 2 - Update group, 3 - Delete Group, 4 - Get group by id, 5 - Get all groups by teacher, 6 - Get all groups by room, 7 - Get all groups, 8 - Create Student, 9 - Update Student, 10- Get student by id, 11 - Delete student, 12 - Get students by age, 13 - Get all students by group id, 14- Search method for groups by name, 15 - Search method for students by name or surname");

            while (true)
            {
                string selectOption = Console.ReadLine();
                int selectNumberOption;
                bool isSelectOption = int.TryParse(selectOption, out selectNumberOption);

                if (isSelectOption)
                {
                    switch (selectNumberOption)
                    {
                        case 1:
                            Helper.PrintConsole(ConsoleColor.Cyan, "Add group name!");

                            string groupName = Console.ReadLine();

                            Helper.PrintConsole(ConsoleColor.Cyan, "Add group teacher!");

                            string groupTeacher = Console.ReadLine();

                            Helper.PrintConsole(ConsoleColor.Cyan, "Add group room!");

                            string groupRoom = Console.ReadLine();

                            int groupRooms;

                            bool isGroupRoom = int.TryParse(groupRoom, out groupRooms);

                            if (isGroupRoom)
                            {
                                CourseGroup group = new CourseGroup { Name = groupName, Room=groupRooms};

                                var result = _groupService.Create(group);

                                Helper.PrintConsole(ConsoleColor.Green, $"Id: {result.Id}, Name: {result.Name}, Room: {result.Room}");
                            }

                            break;
                    }
                }
                //else
                //{
                    
                //}
            }

        }
    }
}
