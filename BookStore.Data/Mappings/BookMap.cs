using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BookStore.Domain;

namespace BookStore.Data.Mappings
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Book");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

           Property(x => x.Title)
                .HasMaxLength(225)
                .IsRequired();

            Property(x => x.Price)
                .IsRequired();

            Property(x => x.ReleaseDate)
                .IsRequired();

            HasMany(x => x.Authors)
                .WithMany(x => x.Books);
        }
    }
}
