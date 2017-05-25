using MyFirstApp.Data.Infrastructure;
using MyFirstApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MyFirstApp.Data.Contracts.Base
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        private MyFirstAppContext dataContext;
        private readonly IDbSet<Entity> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected MyFirstAppContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
 

        protected BaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<Entity>();
        }

        public virtual void Add(Entity p)
        {
            throw new NotImplementedException();
        }

        public virtual void Edit(Entity p)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(long Id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Entity> Get(Expression<Func<Entity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Entity FindById(long Id)
        {
            throw new NotImplementedException();
        }
    }
}