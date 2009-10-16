using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureApplicationCommands : ApplicationStartupStep
    {
        MutableContainer container;

        public ConfigureApplicationCommands(MutableContainer container)
        {
            this.container = container;
        }

        public void run()
        {
            container.register<ViewMainDepartments>(() => new ViewMainDepartments(container.instance_of<CatalogBrowsingTasks>(), container.instance_of<ResponseEngine>()));
            container.register<ViewSubDepartments>(() => new ViewSubDepartments(container.instance_of<ResponseEngine>(), container.instance_of<CatalogBrowsingTasks>()));
            container.register<ViewProductsInDepartment>(() => new ViewProductsInDepartment(container.instance_of<ResponseEngine>(), container.instance_of<CatalogBrowsingTasks>()));
            container.register<AddProductToCart>(() => new AddProductToCart(container.instance_of<ShoppingTasks>()));
        }
    }
}