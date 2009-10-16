using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Start
    {
        static public PipelineBuilder by<StartupItem>() where StartupItem : ApplicationStartupStep
        {
            var container = create_container();
            var startup_item = (ApplicationStartupStep) Activator.CreateInstance(typeof (StartupItem), container);
            return create_builder(container, startup_item);
        }

        static PipelineBuilder create_builder(MutableContainer container, ApplicationStartupStep startup_item)
        {
            return new PipelineBuilder(startup_item, container);
        }

        static DefaultContainer create_container()
        {
            return new DefaultContainer(new DefaultContainerItemFactoryRegistry(new Dictionary<Type, ContainerItemFactory>()));
        }

        static public void by_loading_pipeline_from(string file_name)
        {
            create_builder(create_container(),new NonApplicationStep()).run_all_steps_in(null);
        }
    }
}