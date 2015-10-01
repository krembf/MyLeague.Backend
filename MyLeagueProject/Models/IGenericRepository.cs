using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITemplateProject.Models
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        ICollection<T> Get(string name);
        T Add(T item);
        void Remove(int id);
        bool Update(T item);
    }
}
