using MyFirstApp.Data.Infrastructure;
using MyFirstApp.Model.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyFirstApp.Data
{
    public class MyFirstAppSeedData : DropCreateDatabaseIfModelChanges<MyFirstAppContext>
    {
        protected override void Seed(MyFirstAppContext context)
        {
            GetPersons().ForEach(c => context.Persons.Add(c));

            context.Commit();
        }

        private static List<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person() {  FirstName="Arias", LastName="Balaguera" }
            };
        }
    }
}