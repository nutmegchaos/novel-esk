using FileDbNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNE.SQL.Objects
{
    /// <summary>
    ///     Example 2 of a FileDBNs object that we can use.
    /// </summary>
    public class Issue2Test2
    {
        public int Test2ID { get; set; }
        public int TestID { get; set; }
        public string TestProfession { get; set; }

        private string[] ColumnNames = new[] {
            "Test2ID",
            "TestID",
            "TestProfession"
        };

        public FieldValues Value(bool GetID = false)
        {
            var values = new FieldValues();
            if (GetID)
                values.Add(ColumnNames[0], TestID);

            values.Add(ColumnNames[1], TestID);
            values.Add(ColumnNames[2], TestProfession);
            return values;
        }
    }
}
