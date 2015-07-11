﻿using System.Data.Entity;
using BookStore.Data.Mappings;
using BookStore.Domain;

namespace BookStore.Data.DataContexts
{
    public class BookStoreDataContext : DbContext
    {
        public BookStoreDataContext()
            :base("BookStoreConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new AuthorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
