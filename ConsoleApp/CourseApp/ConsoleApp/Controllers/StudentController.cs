using ConsoleApp.Helpers;
using DomainLayer.Entities;
using ServiceLayer.Services.Implementations;


namespace ConsoleApp.Controllers
{
    public class StudentController
    {
        StudentService _studentService = new();
        GroupService _groupService = new();
        public void CreateStudent()
        {
        GroupId: Helper.PrintConsole(ConsoleColor.Cyan, "Add group Id:");
            string groupId = Console.ReadLine();
            int id;
            bool isGroupId = int.TryParse(groupId, out id);

            var findGroup = _groupService.GetById(id);
            if (findGroup is null)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group not found!");
                goto GroupId;
            }

            if (isGroupId)
            {
                Helper.PrintConsole(ConsoleColor.Cyan, "Add student name:");
                string studentName = Console.ReadLine();
                studentName = char.ToUpper(studentName[0]) + studentName.Substring(1).ToLower();


                Helper.PrintConsole(ConsoleColor.Cyan, "Add student surname");

                string studentSurname = Console.ReadLine();
                studentSurname = char.ToUpper(studentSurname[0]) + studentSurname.Substring(1).ToLower();

            Age: Helper.PrintConsole(ConsoleColor.Cyan, "Add student age:");

                string studentAge = Console.ReadLine();

                int age;

                bool isStudentAge = int.TryParse(studentAge, out age);

                if (isStudentAge)
                {
                    Student student = new Student { Name = studentName, Surname = studentSurname, Age = age, Group = findGroup };

                    var result = _studentService.Create(id, student);

                    if (result != null)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Id: {result.Id}, Name: {result.Name}, Surname: {result.Surname}, Age: {result.Age}, Group: {result.Group.Name}");

                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Student not created!");

                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Please enter correct student age type!");
                    goto Age;
                }

            }
        }

        public void UpdateStudent()
        {
        StudentId: Helper.PrintConsole(ConsoleColor.Cyan, "Enter Student Id:");

            string idSt = Console.ReadLine();
            int id;

            bool isIdSt = int.TryParse(idSt, out id);
            if (isIdSt)
            {
                var findStudent = _studentService.GetById(id);

                if (findStudent != null)
                {
                    Helper.PrintConsole(ConsoleColor.Cyan, $"Current name: {findStudent.Name}. Add student new name:");

                    string studemtNewName = Console.ReadLine();
                    studemtNewName = char.ToUpper(studemtNewName[0]) + studemtNewName.Substring(1).ToLower();

                    Helper.PrintConsole(ConsoleColor.Cyan, $"Current surname: {findStudent.Surname}. Add student new surname:");
                    string studentNewSurname = Console.ReadLine();
                    studentNewSurname = char.ToUpper(studentNewSurname[0]) + studentNewSurname.Substring(1).ToLower();

                Age: Helper.PrintConsole(ConsoleColor.Cyan, $"Current age: {findStudent.Age}. Add student new age:");
                    string newAge = Console.ReadLine();
                    int age = findStudent.Age;

                    if (!string.IsNullOrWhiteSpace(newAge))
                    {
                        bool isAge = int.TryParse(newAge, out age);
                        if (!isAge)
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Add correct age type!");
                            goto Age;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(studemtNewName))
                    {
                        studemtNewName = findStudent.Name;
                    }
                    if (string.IsNullOrWhiteSpace(studentNewSurname))
                    {
                        studentNewSurname = findStudent.Surname;
                    }

                    Student student = new Student { Name = studemtNewName, Surname = studentNewSurname, Age = age };

                    var updateStudent = _studentService.Update(id, student);

                    if (updateStudent == null)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Student not updated, please try again!");
                        goto StudentId;
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Student Id: {updateStudent.Id}, Student Name: {updateStudent.Name}, Student surname: {updateStudent.Surname}, Student age: {updateStudent.Age}");

                    }


                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found!");
                    goto StudentId;
                }


            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct StudentId type!");
                goto StudentId;
            }
        }

        public void GetStudentById()
        {
        StudentId: Helper.PrintConsole(ConsoleColor.Cyan, "Add student Id:");
            string studentId = Console.ReadLine();
            int id;
            bool isStudentId = int.TryParse(studentId, out id);
            if (isStudentId)
            {
                Student result = _studentService.GetById(id);
                if (result != null)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Id: {result.Id}, Name: {result.Name}, Surname: {result.Surname}, Age: {result.Age}, Group: {result.Group.Name}");

                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found!");
                    goto StudentId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct StudentId type!");
                goto StudentId;
            }
        }

        public void GetStudentByAge()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Add age:");
            string ageSt = Console.ReadLine();

            if (!int.TryParse(ageSt, out int age))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid age!");
                return;
            }

            var students = _studentService.GetByAge(age);

            if (students.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkYellow, "Students not found with this age!");
                return;
            }

            foreach (var student in students)
            {
                Helper.PrintConsole(ConsoleColor.Green,
                    $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Group: {student.Group?.Name}");
            }
        }

        public void DeleteStudent()
        {
        StudentId: Helper.PrintConsole(ConsoleColor.Cyan, "Add group Id!");
            string studentId = Console.ReadLine();
            int id;
            bool isStudentId = int.TryParse(studentId, out id);
            if (isStudentId)
            {
                Student student = _studentService.GetById(id);

                if (student != null)
                {
                    _studentService.Delete(id);
                    Helper.PrintConsole(ConsoleColor.Green, $"'{student.Name}' deleted successfully!");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found!");
                    goto StudentId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please enter correct StudentId type!");
                goto StudentId;
            }
        }

        public void GetAllStudent()
        {
            var students = _studentService.GetAll();
            if (students == null || students.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Student not found!");
                return;
            }
            else
            {

                foreach (var s in students)
                {
                    Helper.PrintConsole(ConsoleColor.Green,
                        $"Id: {s.Id}, Name: {s.Name} {s.Surname}, Age: {s.Age}, Group: {s.Group?.Name}");
                }

            }

            
        }

        public void GetAllStudentsByGroupId()
        {
        GroupId: Helper.PrintConsole(ConsoleColor.Cyan, "Add group Id:");
            string groupId = Console.ReadLine();

            if (!int.TryParse(groupId, out int id))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Invalid group id!");
                goto GroupId;
            }
            var students = _studentService.GetByGroupId(id);

            if (students.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Students not found!");
                return;

            }
            foreach (var student in students)
            {
                Helper.PrintConsole(ConsoleColor.Green, $"Id: {student.Id}, Group: {student.Group.Name}");

            }
        }

        public void Search()
        {
            Helper.PrintConsole(ConsoleColor.Cyan, "Enter name or surname:");
            string searchText = Console.ReadLine();

            var result = _studentService.Search(searchText);

            if (result.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.DarkYellow, "Students not found!");
                return;

            }

            foreach (var student in result)
            {
                Helper.PrintConsole(ConsoleColor.Green, $"Id: {student.Id}, Group: {student.Group?.Name}");

            }

        }
    }

}




