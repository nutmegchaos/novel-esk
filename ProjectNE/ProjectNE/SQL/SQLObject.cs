using FileDbNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNE.SQL.Objects
{
    /// <summary>
    /// Generic SQLObject for use with FileDBNs
    /// </summary>
    public class SQLObject
    {
        public string Name { get; set; }

        public SQLObject() { }

        /// <summary>
        /// Add record to the DB
        /// </summary>
        /// <param name="db">The db to add to</param>
        /// <param name="values">The values to add to the table.</param>
        public void AddRecord(FileDb db, FieldValues values)
        {
            db.Open(Name, false);
            db.AddRecord(values);
        }

        /// <summary>
        /// Return the field definition
        /// </summary>
        /// <param name="db">The DB/Table</param>
        /// <returns></returns>
        public Fields GetFieldDefinition(FileDb db)
        {
            db.Open(Name, true);
            return db.Fields;
        }

        /// <summary>
        /// Pretty much SELECT * FROM [TABLE] WHERE id=id
        /// </summary>
        /// <param name="db">Table to search</param>
        /// <param name="id">id to search for</param>
        /// <returns></returns>
        public Table GetInfoByID(FileDb db, int id)
        {
            db.Open(Name, true);
            return db.SelectRecords(new FilterExpression(db.Fields[0].Name, id, EqualityEnum.Equal));
        }
    }
}
