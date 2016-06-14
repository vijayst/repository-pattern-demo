using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo.Models;

namespace RepositoryPatternDemo.Repositories.Contracts
{
    public interface IClientRepository
    {
        Client Find(int id);
        Client FindByName(string name);
        void Insert(Client c);
        void Update(Client c);
        void Delete(Client c);
        void Save();
    }
}
