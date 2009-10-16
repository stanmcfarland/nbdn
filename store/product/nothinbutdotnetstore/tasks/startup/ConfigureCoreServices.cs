using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureCoreServices : ApplicationStartupItem
    {
        MutableContainer container;

        public ConfigureCoreServices(MutableContainer container)
        {
            this.container = container;
        }

        public void run()
        {
            IOC.initialize_with(container);
        }
    }
}
