using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo.Entities;

namespace RepositoryPatternDemo.Repositories
{
    class BaseDbRepository<T, U> where T: class
    {
        protected ApplicationDbContext Context { get; set;  }
        protected DbSet<T> Set { get; set; }
         
        public BaseDbRepository(ApplicationDbContext context) 
        {
            this.Context = context;
            this.Set = Context.Set<T>();
        }

        public T Find(U id)
        {
            return Set.Find(id);
        }

        public void Insert(T entity)
        {
            this.Set.Add(entity);
        }

        public void Update(U id, T entity)
        {
            var existingEntity = Find(id);
            this.Context.Entry<T>(existingEntity).State = EntityState.Detached;
            this.Context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(U id)
        {
            var existingEntity = Find(id);
            this.Context.Entry<T>(existingEntity).State = EntityState.Deleted;
        }
    }
}
