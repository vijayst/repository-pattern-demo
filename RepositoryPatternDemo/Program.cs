using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPatternDemo.Bootstrap;
using RepositoryPatternDemo.Models;
using RepositoryPatternDemo.Repositories.Contracts;

namespace RepositoryPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerFactory.GetContainer(ContainerType.MainContainer);
            var repo = container.GetInstance<IClientRepository>();
            repo.Insert(new Client
            {
                Name = "Vijay"
            });
            Console.WriteLine("Inserted to in-memory cache");
            repo.Save();
            Console.WriteLine("Saved to Db");
            var client = repo.Find(1);
            Console.WriteLine("{0}: {1}", client.Id, client.Name);
            Console.ReadKey();
        }
    }
}
