using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo.Entities;

namespace RepositoryPatternDemo.Repositories
{
    class ClientDbRepository : BaseDbRepository<Client, int>
    {
        internal ClientDbRepository(ApplicationDbContext context) : base(context) { }

        internal Client FindByName(string name)
        {
            return Context.Clients.FirstOrDefault(c => c.Name.Equals(name));
        }
    }
}
