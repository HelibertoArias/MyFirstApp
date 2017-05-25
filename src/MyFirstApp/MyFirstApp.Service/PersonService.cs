using MyFirstApp.Data.Infrastructure;
using MyFirstApp.Model.Models;
using MyFirstApp.Repository.Repositories.Contracts;
using System;

namespace MyFirstApp.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IUnitOfWork unitOfWork;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository)
        {
            this.unitOfWork = unitOfWork;
            this.personRepository = personRepository;
        }

        public void SaveData()
        {
            unitOfWork.Commit();
        }


        public bool AddPerson(Person entity)
        {
            try
            {
                personRepository.Add(entity);
                return true;
            }
            catch (Exception w)
            {

                return false;
            }
        }
    }
}