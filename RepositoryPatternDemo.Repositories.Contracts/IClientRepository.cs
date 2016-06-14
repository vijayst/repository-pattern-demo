using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo.Entities;

namespace RepositoryPatternDemo.Repositories.Contracts
{
    public interface IClientRepository
    {
        Client Find(int id);
        void Insert(Client c);
        void Update(Client c);
        void Delete(Client c);
        void Save();
    }
}
