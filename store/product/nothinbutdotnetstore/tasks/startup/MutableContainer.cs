using System;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface MutableContainer : Container
    {
        void register<Dependency>(Func<object> factory);
        void register<Dependency>(Dependency item);
    }
}