using DomainLayer.Entities;
using RepositoryLayer.Repositories.Implementations;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count=1;
        public CourseGroup Create(CourseGroup group)
        {
            group.Id=_count;
            _groupRepository.Create(group);
            _count++;
            return group;

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CourseGroup Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public CourseGroup Update(int id, CourseGroup group)
        {
            throw new NotImplementedException();
        }
    }
}
