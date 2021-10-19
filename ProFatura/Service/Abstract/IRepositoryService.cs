using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProFatura.Service.Abstract
{
    public interface IRepositoryService<T>
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        List<T> Get(string name);
        List<T> Get(int id);
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
    }
}
