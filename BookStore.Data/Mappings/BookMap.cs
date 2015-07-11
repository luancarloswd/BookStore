using System.Data.Entity.ModelConfiguration;
using BookStore.Domain;

namespace BookStore.Data.Mappings
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Book");

            HasKey(x => x.Id);
            Property(x => x.Title)
                .HasMaxLength(225)
                .IsRequired();

            Property(x => x.Price)
                .HasColumnType("Money")
                .IsRequired();

            Property(x => x.ReleaseDate)
                .IsRequired();

            HasMany(x => x.Authors)
                .WithMany(x => x.Books);
        }
    }
}
