
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
            return new Container(containerType);
        }
    }
}
