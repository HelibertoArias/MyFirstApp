using MyFirstApp.Data.Configuration.Map;
using MyFirstApp.Model.Models;
using System.Data.Entity;

namespace MyFirstApp.Data.Infrastructure
{
    public class MyFirstAppContext : DbContext
    {
        public MyFirstAppContext() : base("name = MyFirstAppConnectionString")
        {
        }

        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //                        .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //                        .Where(type => type.BaseType != null && type.BaseType.IsGenericType
            //                            && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}

            modelBuilder.Configurations.Add(new PersonConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}