using DomainLayer.Entities;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;


namespace RepositoryLayer.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data is null)
                {
                    throw new NotFoundException("Student not found");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Student data)
        {
            throw new NotImplementedException();
        }

        public Student Get(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
