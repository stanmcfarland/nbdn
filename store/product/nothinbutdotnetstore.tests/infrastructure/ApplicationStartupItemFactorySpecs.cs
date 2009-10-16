 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class ApplicationStartupItemFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ContainerItemFactory,
                                             ApplicationStartupItemFactory>
         {
        
         }

         [Concern(typeof(ApplicationStartupItemFactory))]
         public class when_creating_an_application_startup_item : concern
         {
             context c = () =>
             {
                 type = "nothinbutdotnetstore.tasks.startup.ConfigureServiceLayer";
                 container = the_dependency<MutableContainer>();
                 provide_a_basic_sut_constructor_argument(type);
             };

             because b = () =>
             {
                 result = sut.create();
             };

        
             it should_return_an_instance_that_matches_the_name_of_the_application_startup_item_type = () =>
             {
                 result.should_be_an_instance_of<ConfigureServiceLayer>();
             };

             static object result;
             static string type;
             static MutableContainer container;
         }
     }
 }
