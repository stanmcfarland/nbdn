using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class ApplicationStartupItemFactory : ContainerItemFactory
    {
        readonly string type;
        readonly MutableContainer container;

        public ApplicationStartupItemFactory(string type, MutableContainer container)
        {
            this.type = type;
            this.container = container;
        }

        public object create()
        {
            return Activator.CreateInstance(Type.GetType(type), container);
        }
    }
}