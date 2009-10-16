using System.Collections.Generic;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface FileReader
    {
        IEnumerable<string> get_lines();
    }
}
