using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo.Entities;
using RepositoryPatternDemo.Repositories.Contracts;

namespace RepositoryPatternDemo.Repositories
{
    public class ClientRepository : IClientRepository
    {
        internal ApplicationDbContext Context { get; set;  }
        internal DbSet<Client> Set { get; set; }

        public ClientRepository(ApplicationDbContext context) 
        {
            this.Context = context;
            this.Set = Context.Set<Client>();
        }

        public Client Find(int id)
        {
            return Set.Find(id);
        }

        public void Insert(Client c)
        {
            this.Set.Add(c);
        }

        public void Update(Client c)
        {
            if (this.Context.Entry<Client>(c).State == EntityState.Detached)
            {
                this.Set.Attach(c);
            }
            this.Context.Entry<Client>(c).State = EntityState.Modified;
        }

        public void Delete(Client c)
        {
            if (this.Context.Entry<Client>(c).State == EntityState.Detached)
            {
                this.Set.Attach(c);
            }
            this.Context.Entry<Client>(c).State = EntityState.Deleted;
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
