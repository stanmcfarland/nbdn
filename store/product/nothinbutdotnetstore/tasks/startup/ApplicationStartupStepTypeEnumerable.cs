using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ApplicationStartupStepTypeEnumerable : IEnumerable<Type>
    {
        FileReader reader;

        public ApplicationStartupStepTypeEnumerable(FileReader reader)
        {
            this.reader = reader;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Type> GetEnumerator()
        {
            return reader.get_lines().Select(s => transform_to_type(s)).GetEnumerator();
        }

        Type transform_to_type(string type_name)
        {
            return typeof (int);
        }
    }
}