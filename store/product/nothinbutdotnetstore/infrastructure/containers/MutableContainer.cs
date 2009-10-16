using System;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface MutableContainer : Container
    {
        void register<T>(Func<object> item);
        void register<T>(ContainerItemFactory factory);
    }
}