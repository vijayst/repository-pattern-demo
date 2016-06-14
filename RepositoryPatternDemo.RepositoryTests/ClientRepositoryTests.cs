using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryPatternDemo.Bootstrap;
using RepositoryPatternDemo.Entities;
using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Repositories;
using RepositoryPatternDemo.Repositories.Contracts;

namespace RepositoryPatternDemo.RepositoryTests
{
    [TestClass]
    public class ClientRepositoryTests
    {
        [TestInitialize]
        public void Setup()
        {
            _container = (Container)TestContext.Properties["Container"];
            _mockContext = new Mock<ApplicationDbContext>();
            _mockSet = new Mock<DbSet<RepositoryPatternDemo.Entities.Client>>();
            _mockContext.Setup(m => m.Clients).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Set<Entities.Client>()).Returns(_mockSet.Object);
            _container.Inject<ApplicationDbContext>(_mockContext.Object);
        }

        [TestMethod]
        public void InsertClientWorks()
        {
            var repo = _container.GetInstance<IClientRepository>();
            var client = new Models.Client
            {
                Name = "Vijay"
            };
            
            repo.Insert(client);
            repo.Save();

            _mockSet.Verify(m => m.Add(It.Is<Entities.Client>((c) =>
                c.Name.Equals("Vijay"))), Times.Once);

            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        public TestContext TestContext { get; set;  }

        private Container _container;
        private Mock<ApplicationDbContext> _mockContext;
        private Mock<DbSet<Entities.Client>> _mockSet;
    }
}
