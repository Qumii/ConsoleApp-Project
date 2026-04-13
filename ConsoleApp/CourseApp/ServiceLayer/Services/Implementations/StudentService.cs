using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;

namespace ServiceLayer.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private GroupRepository _groupRepository;
        private StudentRepository _studentRepository;
        private int _count = 1;

        public StudentService()
        {
            _groupRepository = new GroupRepository();
            _studentRepository = new StudentRepository();
        }
        public Student Create(int groupId, Student student)
        {
            var group = _groupRepository.Get(g => g.Id == groupId);

            if (group is null) return null;

            student.Id = _count;
            student.Group = group;
            _studentRepository.Create(student);
            
            _count++;
            return student;
        }

        public void Delete(int id)
        {
            Student student = GetById(id);
            if (student!=null)
            {
                _studentRepository.Delete(student);
            }
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public List<Student> GetByAge(int age)
        {
            return _studentRepository.GetAll(s => s.Age == age);
        }

        public List<Student> GetByGroup(string groupName)
        {
            return _studentRepository.GetAll(s => s.Group != null && s.Group.Name.ToLower().Trim() == groupName.ToLower().Trim());
        }

        public List<Student> GetByGroupId(int groupId)
        {
            return _studentRepository.GetAll(s => s.Group != null && s.Group.Id == groupId);
        }

        public Student GetById(int id)
        {
            Student student = _studentRepository.Get(s => s.Id == id);
            if (student is null) return null;

            return student;

        }

        public Student GetByName(string name)
        {
            return _studentRepository.Get(s => s.Name.Trim().ToLower() == name.Trim().ToLower());
        }
        public Student GetBySurname(string surname)
        {
            return _studentRepository.Get(s => s.Surname.Trim().ToLower() == surname.Trim().ToLower());
        }

        public List<Student> Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return new List<Student>();
            }
            return _studentRepository.GetAll().Where(s=> 
            (!string.IsNullOrEmpty(s.Name) && s.Name.Trim().ToLower() == searchText.Trim().ToLower()) ||
            (!string.IsNullOrEmpty(s.Surname) && s.Surname.Trim().ToLower() == searchText.Trim().ToLower()) ||
            (s.Group != null && !string.IsNullOrEmpty(s.Group.Name) && s.Group.Name.Trim().ToLower() == searchText.Trim().ToLower())
            ).ToList();
        }

        public Student Update(int id, Student student)
        {
            Student dbStudent = GetById(id);

            if (dbStudent == null) return null;

            student.Id = id;
            _studentRepository.Update(student);

            return GetById(id);
        }

        
    }
}
