using System.Data.Entity.ModelConfiguration;
using BookStore.Domain;

namespace BookStore.Data.Mappings
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            ToTable("Author");

            HasKey(x => x.Id);

            Property(x => x.FirstName)
                .HasMaxLength(65)
                .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(65)
                .IsRequired();

            HasMany(x => x.Books)
                .WithMany(x => x.Authors);
        }
    }
}
