using MyFirstApp.Model.Base;

namespace MyFirstApp.Model.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}