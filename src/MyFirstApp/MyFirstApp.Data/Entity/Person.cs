using MyFirstApp.Data.Entity.Base;

namespace MyFirstApp.Data.Entity
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}