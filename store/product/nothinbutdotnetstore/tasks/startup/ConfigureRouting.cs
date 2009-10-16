using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureRouting : ApplicationStartupItem
    {
        MutableContainer container;

        public ConfigureRouting(MutableContainer container)
        {
            this.container = container;
        }

        public void run()
        {
            container.register<IEnumerable<RequestCommand>>(create_routes);
        }

        private IEnumerable<RequestCommand> create_routes()
        {
            yield return create_command<ViewMainDepartments>();
            yield return create_command<ViewProductsInDepartment>();
            yield return create_command<ViewSubDepartments>();
            yield return create_command<AddProductToCart>();
        }

        private RequestCommand create_command<AppCommand>() where AppCommand : ApplicationWebCommand
        {
            return new DefaultRequestCommand(Url.contains(typeof (AppCommand).Name), container.instance_of<AppCommand>());
        }
    }
}
