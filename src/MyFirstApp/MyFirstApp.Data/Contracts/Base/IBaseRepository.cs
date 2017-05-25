using MyFirstApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyFirstApp.Data.Contracts.Base
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        void Add(Entity p);

        void Edit(Entity p);

        void Remove(long Id);

        IEnumerable<Entity> Get(Expression<Func<Entity, bool>> predicate);

        Entity FindById(long Id);
    }
}