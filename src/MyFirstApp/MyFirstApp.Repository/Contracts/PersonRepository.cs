using MyFirstApp.Data.Contracts;
using MyFirstApp.Data.Contracts.Base;
using MyFirstApp.Data.Infrastructure;
using MyFirstApp.Model.Models;

namespace MyFirstApp.Repository.Contracts
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}