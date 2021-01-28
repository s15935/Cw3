using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DAL
{
    public interface IDbService<T>
    {
        public IEnumerable<T> GetStudents();
        public T GetStudents(int id);
        public int NextId();
        public void AddStudent(T entryToAdd);
        public void RemoveStudent(T entryToRemove);
    }
}
