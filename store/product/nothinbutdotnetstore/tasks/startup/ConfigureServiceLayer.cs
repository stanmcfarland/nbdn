using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureServiceLayer : ApplicationStartupItem
    {
        MutableContainer container;

        public ConfigureServiceLayer(MutableContainer container)
        {
            this.container = container;
        }

        public void run()
        {
            container.register<CatalogBrowsingTasks>(() => new StubCatalogBrowsingTasks());
        }
    }
}
