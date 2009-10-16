using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ApplicationStartup
    {
        IDictionary<Type, ContainerItemFactory> container;

        static public void start()
        {
            new ApplicationStartup(new Dictionary<Type, ContainerItemFactory>());
        }

        public ApplicationStartup(IDictionary<Type, ContainerItemFactory> container)
        {
            this.container = container;
            run();
        }

        public void run()
        {
//            Start.by<ConfiguringCoreServices>()
//                .followed_by<ConfiguringFrontController>()
//                .followed_by<ConfigureRouting>();

            configure_core_services();
            //configure_service_layer();
            //configure_front_controller();
            //configure_routing();    
            //configure_application_commands();
        }

        void configure_core_services()
        {
            IOC.initialize_with(new DefaultContainer(new DefaultContainerItemFactoryRegistry(container)));
        }        
    } ;
}