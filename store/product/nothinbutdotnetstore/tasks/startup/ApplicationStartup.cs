namespace nothinbutdotnetstore.tasks.startup
{
    public class ApplicationStartup
    {
        static public void start()
        {
            new ApplicationStartup().run();
        }

        public void run()
        {
            //Start.by_loading_pipeline_from(new DefaultFileReader(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StartupItems.cfg")));

            //Start.by<ConfigureCoreServices>()
            //    .followed_by<ConfigureServiceLayer>()
            //    .followed_by<ConfigureFrontController>()
            //    .followed_by<ConfigureRouting>()
            //    .followed_by<ConfigureApplicationCommands>()
            //    .run();
        }
    } ;
}