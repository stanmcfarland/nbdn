using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.infrastructure
{
    public class PipelineBuilder : Command
    {
        Command command;
        MutableContainer container;

        public PipelineBuilder(Command command, MutableContainer container)
        {
            this.container = container;
            this.command = command;
        }

        public void run_all_steps_in(IEnumerable<Type> startup_steps){


        }
        public PipelineBuilder followed_by<StartupItem>() where StartupItem : ApplicationStartupStep
        {
            var startup_item = (ApplicationStartupStep) Activator.CreateInstance(typeof(StartupItem), container);
            command = new ChainedCommand(command, startup_item);
            return this;
        }

        public void run()
        {
           command.run(); 
        }
    }
}
