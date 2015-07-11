using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Contracts
{
    public interface IRepository<T> : IDisposable
    {
        List<T> Get(int skip = 0, int take = 25);
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
