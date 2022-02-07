using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFest.BL.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
