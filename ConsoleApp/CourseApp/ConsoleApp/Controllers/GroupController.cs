using ConsoleApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.Controllers
{
    public class GroupController
    {
        GroupService _groupService = new();
        public void CreateGroup()
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "Add group name!");

            string groupName = Console.ReadLine().ToUpper().Trim();

            Helper.PrintConsole(ConsoleColor.Cyan, "Add group teacher!");

            string groupTeacher = Console.ReadLine();
            groupTeacher = char.ToUpper(groupTeacher[0]) + groupTeacher.Substring(1).ToLower();

        Room: Helper.PrintConsole(ConsoleColor.Cyan, "Add group room!");

            string groupRoom = Console.ReadLine();

            int groupRooms;

            bool isGroupRoom = int.TryParse(groupRoom, out groupRooms);

            if (isGroupRoom)
            {
                CourseGroup group = new CourseGroup { Name = groupName, Teacher = groupTeacher, Room = groupRooms };

                var result = _groupService.Create(group);

                Helper.PrintConsole(ConsoleColor.Green, $"Id: {result.Id}, Name: {result.Name}, Teacher: {result.Teacher}, Room: {result.Room}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct group room type!");
                goto Room;
            }
        }

        public void GetGroupById()
        {
        GroupId: Helper.PrintConsole(ConsoleColor.Cyan, "Add group Id!");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                CourseGroup result = _groupService.GetById(id);
                if (result != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Id: {result.Id}, Name: {result.Name}, Teacher: {result.Teacher}, Room: {result.Room}");

                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct GroupId type!");
                goto GroupId;
            }
        }

        public void GetAllGroups()
        {
            List<CourseGroup> groups = _groupService.GetAll();
            if (groups.Count != 0)
            {
                foreach (var result in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Id: {result.Id}, Name: {result.Name}, Teacher: {result.Teacher}, Room: {result.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please create group!");

            }
        }

        public void DeleteGroup()
        {
        GroupId: Helper.PrintConsole(ConsoleColor.Cyan, "Add group Id!");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                CourseGroup group = _groupService.GetById(id);

                if (group != null)
                {
                    _groupService.Delete(id);
                    Helper.PrintConsole(ConsoleColor.Green, $"'{group.Name}' deleted successfully!");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct GroupId type!");
                goto GroupId;
            }
        }

        public void SearchByGroupName()
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "Add group search text");
            string searchGroupName = Console.ReadLine().ToUpper().Trim();
            List<CourseGroup> groups = _groupService.SearchByGroupName(searchGroupName);

            if (groups.Count != 0)
            {
                foreach (var result in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Id: {result.Id}, Name: {result.Name}, Teacher: {result.Teacher}, Room: {result.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group not found!");

            }
        }

        public void UpdateGroup()
        {

        GroupId: Helper.PrintConsole(ConsoleColor.Cyan, "Add group Id:");

            string groupId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupId))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Updaye operation canceled!");
                goto GroupId;
            }

            int id;
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                var findGroup = _groupService.GetById(id);

                if (findGroup != null)
                {
                    Helper.PrintConsole(ConsoleColor.Cyan, $"Current name: {findGroup.Name}. Add group new name:");

                    string groupNewName = Console.ReadLine().ToUpper();

                    Helper.PrintConsole(ConsoleColor.Cyan, $"Current teacher: {findGroup.Teacher}. Add group new teacher:");
                    string groupNewTeacher = Console.ReadLine();
                    groupNewTeacher = char.ToUpper(groupNewTeacher[0]) + groupNewTeacher.Substring(1).ToLower();

                Room: Helper.PrintConsole(ConsoleColor.Cyan, $"Current room: {findGroup.Room}. Add group new room:");
                    string newRoom = Console.ReadLine();
                    int room = findGroup.Room;

                    if (!string.IsNullOrWhiteSpace(newRoom))
                    {
                        bool isRoom = int.TryParse(newRoom, out room);
                        if (!isRoom)
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Add correct room type!");
                            goto Room;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(groupNewName))
                    {
                        groupNewName = findGroup.Name;
                    }

                    CourseGroup group = new CourseGroup { Name = groupNewName, Teacher = groupNewTeacher, Room = room };

                    var updateGroup = _groupService.Update(id, group);

                    if (updateGroup == null)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Group not updated, please try again!");
                        goto GroupId;
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {updateGroup.Id}, Group Name: {updateGroup.Name}, Group Teacher: {updateGroup.Teacher}, Group Room: {updateGroup.Room}");

                    }


                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                    goto GroupId;
                }


            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type!");
                goto GroupId;
            }


        }

        public void GetByTeacher()
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "Add teacher name:");
            string teacherName = Console.ReadLine();
            teacherName = char.ToUpper(teacherName[0]) + teacherName.Substring(1).ToLower();

            var groups = _groupService.GetByTeacher(teacherName);

            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");

                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not found fot this teacher!");

            }
        }

        public void GetByRoom()
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "Add room number:");

            string roomName = Console.ReadLine();
            int room;
            bool isRoom = int.TryParse(roomName, out room);

            var groups = _groupService.GetByRoom(room);

            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                    return;

                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Groups not found fot this room!");

            }

        }



    }
}
