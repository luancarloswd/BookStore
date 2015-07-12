using System.Data.Entity;
using BookStore.Data.Mappings;
using BookStore.Domain;


namespace BookStore.Data.DataContexts
{
    public class BookStoreDataContext : DbContext
    {
        public BookStoreDataContext()
            :base("BookStoreConnectionString")
        {
            Database.SetInitializer(new MySqlInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new BookMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
