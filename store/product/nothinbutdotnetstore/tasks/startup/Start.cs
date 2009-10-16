using System;
using System.Collections.Generic;
using developwithpassion.bdd.core.extensions;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        static public CommandBuilder by<StartupItem>() where StartupItem : ApplicationStartupItem
        {
            var container = new DefaultContainer(new DefaultContainerItemFactoryRegistry(new Dictionary<Type, ContainerItemFactory>()));
            var startup_item = (ApplicationStartupItem)Activator.CreateInstance(typeof(StartupItem), container);
            return new CommandBuilder(startup_item, container);
        }

        static public void load_pipeline_from(FileReader file_reader)
        {
            var container = new DefaultContainer(new DefaultContainerItemFactoryRegistry(new Dictionary<Type, ContainerItemFactory>()));
            
            Action<object> startup_adapter = (startup_item) => ((ApplicationStartupItem)startup_item).run();
            
            file_reader.get_lines().each(type => startup_adapter(new ApplicationStartupItemFactory(type, container).create()));
        }
    }
}