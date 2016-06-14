using RepositoryPatternDemo.Entities;
using RepositoryPatternDemo.Repositories;
using RepositoryPatternDemo.Repositories.Contracts;

namespace RepositoryPatternDemo.Bootstrap
{
    public class Container
    {
        internal Container(ContainerType containerType)
        {
            switch (containerType)
            {
                case ContainerType.MainContainer:
                    _container = new StructureMap.Container(_ =>
                    {
                        _.For<IClientRepository>().Use<ClientRepository>();
                        _.ForConcreteType<ApplicationDbContext>()
                          .Configure
                          .Ctor<string>("connStr").Is("DbConnection");
                    });
                    break;
                case ContainerType.RepositoryTestContainer:
                    _container = new StructureMap.Container(_ =>
                    {
                        _.For<IClientRepository>().Use<ClientRepository>();
                    });
                    break;
            }
        }

        public T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }

        public void Inject<T>(T obj) where T: class
        {
            _container.Inject<T>(obj);
        }

        private StructureMap.Container _container;
    }
}
