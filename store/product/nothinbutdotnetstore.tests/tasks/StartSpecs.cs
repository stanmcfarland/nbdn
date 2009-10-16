 
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.startup;
using nothinbutdotnetstore.tasks.stubs;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartSpecs
    {
        public abstract class concern : observations_for_a_static_sut
        {

        }

        [Concern(typeof (Start))]
        public class when_loading_pipeline_from_file : concern
        {
            context c = () =>
            {
                file_reader = an<FileReader>();
                types = new List<string>() { "nothinbutdotnetstore.tasks.startup.ConfigureCoreServices" };

                file_reader.Stub(x => x.get_lines()).Return(types);
            };

            because b = () =>
            {
                Start.load_pipeline_from(file_reader);
            };

            it should_create_the_types_in_the_file = () =>
            {
                IOC.resolve.should_not_be_null();
            };

            static FileReader file_reader;
            static List<string> types;
        }
    }
}
