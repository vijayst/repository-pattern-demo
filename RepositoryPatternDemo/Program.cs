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
            Console.WriteLine("Inserted to DbSet.");
            repo.Save();
            Console.WriteLine("Saved to Db.");
            var client = repo.FindByName("Vijay");
            Log(client);

            client.Name = "Vijay T";
            repo.Update(client);
            Console.WriteLine("Updated DbSet.");
            repo.Save();
            Console.WriteLine("Saved to Db.");
            client = repo.FindByName(client.Name);
            Log(client);

            repo.Delete(client);
            Console.WriteLine("Removed from DbSet.");
            repo.Save();

            Console.ReadKey();
        }

        static void Log(Client client)
        {
            Console.WriteLine("{0}: {1}", client.Id, client.Name);
        }
    }
}
