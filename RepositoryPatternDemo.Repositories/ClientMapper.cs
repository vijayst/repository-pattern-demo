using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo;

namespace RepositoryPatternDemo.Repositories
{
    enum MapType
    {
        Standard
    }

    class ClientMapper
    {
        internal Entities.Client GetEntity(Models.Client model, MapType mapType=MapType.Standard)
        {
            var entity = new Entities.Client();
            entity.Id = model.Id;
            entity.Name = model.Name;
            return entity;
        }

        internal Models.Client GetModel(Entities.Client entity, MapType mapType=MapType.Standard)
        {
            var model = new Models.Client();
            model.Id = entity.Id;
            model.Name = entity.Name;
            return model;
        }
    }
}
