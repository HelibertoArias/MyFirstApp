using MyFirstApp.Data.Contracts.Base;
using MyFirstApp.Data.Infrastructure;
using MyFirstApp.Model.Models;

namespace MyFirstApp.Repository.Repositories.Contracts
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public override void Edit(Person entity)
        {
            entity.FirstName = entity.FirstName + " modificado";
            base.Edit(entity);
        }
    }
}