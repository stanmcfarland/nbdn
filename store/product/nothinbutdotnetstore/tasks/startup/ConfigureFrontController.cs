using System.Collections.Generic;
using System.Web.Compilation;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureFrontController : ApplicationStartupStep
    {
        MutableContainer container;

        public ConfigureFrontController(MutableContainer container)
        {
            this.container = container;
        }

        public void run()
        {
            container.register<FrontController>(() => new DefaultFrontController(container.instance_of<CommandRegistry>()));
            container.register<CommandRegistry>(() => new DefaultCommandRegistry(container.instance_of<IEnumerable<RequestCommand>>()));
            container.register<RequestFactory>(() => new StubRequestFactory());
            container.register<ResponseEngine>(() => new DefaultResponseEngine(container.instance_of<ViewFactory>()));
            container.register<ViewRegistry>(() => new StubViewRegistry());
            container.register<ViewFactory>(() => new DefaultViewFactory(container.instance_of<ViewRegistry>(), (path, type) => BuildManager.CreateInstanceFromVirtualPath(path, type)));
            ;
        }
    }
}
