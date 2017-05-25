using MyFirstApp.Data.Contracts.Base;
using MyFirstApp.Model.Models;

namespace MyFirstApp.Repository.Repositories.Contracts
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
    }
}