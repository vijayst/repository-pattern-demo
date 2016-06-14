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
        internal ApplicationDbContext Context { get; set; }
        internal ClientDbRepository ClientDbRepo { get; set; }

        public ClientRepository(ApplicationDbContext context) 
        {
            this.Context = context;
            this.ClientDbRepo = new ClientDbRepository(context);
        }


        public Models.Client Find(int id)
        {
            var client = this.ClientDbRepo.Find(id);
            return _mapper.GetModel(client);
        }

        public void Insert(Models.Client c)
        {
            var clientEntity = _mapper.GetEntity(c);
            this.ClientDbRepo.Insert(clientEntity);
        }

        public void Update(Models.Client c)
        {
            var clientEntity = _mapper.GetEntity(c);
            this.ClientDbRepo.Update(clientEntity);
        }

        public void Delete(Models.Client c)
        {
            var clientEntity = _mapper.GetEntity(c);
            this.ClientDbRepo.Delete(clientEntity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        private ClientMapper _mapper = new ClientMapper();
    }
}
