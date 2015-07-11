using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BookStore.Data.DataContexts;
using BookStore.Domain;
using BookStore.Domain.Contracts;
using System.Data.Entity;

namespace BookStore.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreDataContext _db;

        public BookRepository()
        {
                _db = new BookStoreDataContext();
        }
        public List<Book> Get(int skip = 0, int take = 25)
        {
            return _db.Books.OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }
        public List<Book> GetWithAuthors(int skip = 0, int take = 25)
        {
            return _db.Books.Include(x => x.Authors).OrderBy(x => x.Title).Skip(skip).Take(take).ToList();
        }

        public Book GeWithAuthors(int id)
        {
            return _db.Books.Include(x => x.Authors).FirstOrDefault(x => x.Id == id);
        }

        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        public void Create(Book entity)
        {
            _db.Books.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Book entity)
        {
            _db.Entry<Book>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Books.Remove(_db.Books.Find(id));
        }

        
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
