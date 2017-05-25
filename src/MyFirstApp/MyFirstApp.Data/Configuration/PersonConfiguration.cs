
using MyFirstApp.Model.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyFirstApp.Data.Configuration.Map
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasKey(x => x.Id)
                .Property(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.FirstName)
                   .HasMaxLength(50)
                   .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            ToTable("Person");
        }
    }
}