using System;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.infrastructure
{
    public class CommandBuilder : Command
    {
        Command command;
        MutableContainer container;

        public CommandBuilder(Command command, MutableContainer container)
        {
            this.container = container;
            this.command = command;
        }

        public CommandBuilder followed_by<StartupItem>() where StartupItem : ApplicationStartupItem
        {
            var startup_item = (ApplicationStartupItem) Activator.CreateInstance(typeof(StartupItem), container);
            command = new ChainedCommand(command, startup_item);
            return this;
        }

        public void run()
        {
           command.run(); 
        }
    }
}
