using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPatternDemo.Entities;
using RepositoryPatternDemo.Repositories;
using RepositoryPatternDemo.Repositories.Contracts;
using StructureMap;

namespace RepositoryPatternDemo.RepositoryTests
{
    [TestClass]
    public class ClientRepositoryTests
    {
        [TestInitialize]
        public void Setup()
        {
            _container = (Container)TestContext.Properties["Container"];
        }

        [TestMethod]
        public void InsertClientWorks()
        {
            var repo = _container.GetInstance<IClientRepository>();
            var client = new Client
            {
                Name = "Vijay"
            };
            repo.Insert(client);
            repo.Save();

            var actualClient = repo.Find(client.Id);
            Assert.AreEqual("Vijay", actualClient.Name);
        }

        public TestContext TestContext { get; set;  }

        private Container _container;
    }
}
