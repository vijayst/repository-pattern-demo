using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPatternDemo.Bootstrap;

namespace RepositoryPatternDemo.RepositoryTests
{
    [TestClass]
    public class SetupAssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            context.Properties["Container"] = ContainerFactory.GetContainer(ContainerType.RepositoryTestContainer);
        }
    }
}
