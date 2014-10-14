using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNE.SQL
{
    /// <summary>
    ///     Host the names of our DataBases
    /// </summary>
    public class FileDBNames
    {
        public readonly string Issue2Test;
        public readonly string Issue2Test2;

        public FileDBNames()
        {
            Issue2Test = Directory.GetCurrentDirectory() + "\\DB\\Issue2-Test.db";
            Issue2Test2 = Directory.GetCurrentDirectory() + "\\DB\\Issue2-Test2.db";
        }
    }
}
