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
        T GetById(string id);
        ICollection<T> GetByName(string name);
        T Add(T item);
        void Remove(string id);
        bool Update(T item);
    }
}
