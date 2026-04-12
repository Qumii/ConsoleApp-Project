using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Exceptions;
using RepositoryLayer.Repositories.Interfaces;

namespace RepositoryLayer.Repositories.Implementations
{
    public class GroupRepository : IRepository<CourseGroup>
    {
        public void Create(CourseGroup data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Data not found!");
                AppDbContext<CourseGroup>.datas.Add(data);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); 
            }
        }

        public void Delete(CourseGroup data)
        {
            AppDbContext<CourseGroup>.datas.Remove(data);

        }

        public CourseGroup Get(Predicate<CourseGroup> predicate)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.Find(predicate) : null;
        }

        public List<CourseGroup> GetAll(Predicate<CourseGroup> predicate = null)
        {
            return predicate != null ? AppDbContext<CourseGroup>.datas.FindAll(predicate) : AppDbContext<CourseGroup>.datas;

        }



        public void Update(CourseGroup data)
        {
            CourseGroup dbGroup = Get(g  => g.Id == data.Id);

            if (dbGroup==null) return;

            if (!string.IsNullOrEmpty(data.Name))
            {
                dbGroup.Name = data.Name;
            }
            if (!string.IsNullOrEmpty(data.Teacher))
            {
                dbGroup.Teacher = data.Teacher;
            }

            if (data.Room > 0)
            {
                dbGroup.Room = data.Room; 
            }
            
        }



    }
}
