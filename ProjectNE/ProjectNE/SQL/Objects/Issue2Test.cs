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
    public class Issue2Test
    {
        public int TestID { get; set; }
        public string TestName { get; set; }

        private string[] ColumnNames = new [] {
            "TestID",
            "TestName"
        };

        /// <summary>
        /// REALLY useful for adding records / updating records 
        /// </summary>
        /// <param name="GetID">Do you want the Primary key [ID] for this?</param>
        /// <returns></returns>
        public FieldValues Value(bool GetID = false)
        {
            var values = new FieldValues();
            if(GetID)
                values.Add(ColumnNames[0], TestID);

            values.Add(ColumnNames[1], TestName);
            return values;
        }
    }
}
