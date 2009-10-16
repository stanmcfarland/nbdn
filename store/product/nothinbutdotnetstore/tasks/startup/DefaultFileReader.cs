using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tasks.startup
{
    public class DefaultFileReader : FileReader
    {
        string path;

        public DefaultFileReader(string path)
        {
            this.path = path;
        }

        public IEnumerable<string> get_lines()
        {
            return System.IO.File.ReadAllLines(path).Select(x => x);
        }
    }
}
