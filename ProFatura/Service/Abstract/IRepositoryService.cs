using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProFatura.Service.Abstract
{
    public interface IRepositoryService<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(string name);
        List<T> GetAll();
    }
}
