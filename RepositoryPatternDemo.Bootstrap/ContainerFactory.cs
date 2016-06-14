using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo.Entities;
using RepositoryPatternDemo.Repositories;
using RepositoryPatternDemo.Repositories.Contracts;
using StructureMap;

namespace RepositoryPatternDemo.Bootstrap
{
    public enum ContainerType
    {
        MainContainer,
        RepositoryTestContainer
    }

    public class ContainerFactory
    {
        public static Container GetContainer(ContainerType containerType)
        {
            switch (containerType)
            {
                case ContainerType.MainContainer:
                    return new Container(_ =>
                    {
                         _.For<IClientRepository>().Use<ClientRepository>();
                         _.ForConcreteType<ApplicationDbContext>()
                           .Configure
                           .Ctor<string>("connStr").Is("DbConnection");
                    });
                case ContainerType.RepositoryTestContainer:
                    return new Container(_ =>
                    {
                        _.For<IClientRepository>().Use<ClientRepository>();
                    });
            }
            throw new ArgumentException("Won't reach here!");
        }
    }
}
