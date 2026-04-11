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
        public void Create()
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "Add group name!");

            string groupName = Console.ReadLine().ToUpper();

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

        public void GetById()
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

        public void GetAll()
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

        public void Delete()
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

        public void Search()
        {

        }
        public void Update()
        {

        }
    }
}
