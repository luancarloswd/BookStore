using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.DataContexts;
using BookStore.Domain;
using BookStore.Domain.Contracts;

namespace BookStore.Data.Repositories
{
    class AuthorRepository : IAuthorRepository
    {
         private BookStoreDataContext _db;

        public AuthorRepository()
        {
                _db = new BookStoreDataContext();
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public List<Author> Get(int skip = 0, int take = 25)
        {
            return _db.Authors.Skip(skip).Take(take).ToList();
        }

        public Author Get(int id)
        {
            return _db.Authors.Find(id);
        }

        public void Create(Author entity)
        {
            _db.Authors.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Author entity)
        {
            _db.Entry<Author>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Authors.Remove(_db.Authors.Find(id));
        }
    }
}
