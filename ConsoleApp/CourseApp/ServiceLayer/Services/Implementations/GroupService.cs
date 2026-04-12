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
        private GroupRepository _groupRepository = new();
        private int _count = 1;
        public CourseGroup Create(CourseGroup group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;

        }

        public void Delete(int id)
        {
            CourseGroup group = GetById(id);
            _groupRepository.Delete(group);
        }

        public CourseGroup GetById(int id)
        {
            CourseGroup group = _groupRepository.Get(g => g.Id == id);
            if (group is null) return null;

            return group;

        }

        public List<CourseGroup> GetAll()
        {
            return _groupRepository.GetAll();
        }



        public CourseGroup Update(int id, CourseGroup group)
        {
            CourseGroup dbGroup = GetById(id);
            if (dbGroup is null) return null;

            group.Id = id;

            _groupRepository.Update(group);
            return GetById(id);
        }





        public CourseGroup Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseGroup> SearchByGroupName(string name )
        {
            return _groupRepository.GetAll(g => g.Name == name);
        }
    }
}
