using FileDbNs;
using ProjectNE.SQL.Objects;
using System.IO;
using System.Linq;
using System.Windows;

namespace ProjectNE.SQL
{
    /// <summary>
    ///     This will be our FileDBNs manager. Consider it a DBFactory of sorts.
    /// </summary>
    public class FileDBManager
    {
        private FileDb DB;
        private FileDBNames Names;

        public FileDBManager() 
        {
            DB = new FileDb();
            Names = new FileDBNames();
        }

        /// <summary>
        /// Showcase what we can do with FileDBNs [everything not in yet]
        /// </summary>
        public void CreateDBExample()
        {
            if(!Directory.Exists(Directory.GetCurrentDirectory() + "\\DB\\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\DB\\");
            }
            DB.Create(Names.Issue2Test, new [] {
                new Field("TestID", DataTypeEnum.Int32) {AutoIncStart = 1, IsPrimaryKey = true},
                new Field("TestName", DataTypeEnum.String)
            });

            var test = new SQLObject() {Name = Names.Issue2Test};
            test.AddRecord(DB, (new Issue2Test() {TestName = "Taz"}).Value());

            // DEBUG HERE TO SEE THE RETURN.
            var result = DB.SelectRecords<Issue2Test>("TestName = 'Taz'").FirstOrDefault<Issue2Test>();

            DB.Close();

            DB.Create(Names.Issue2Test2, new[] {
                new Field("Test2ID", DataTypeEnum.Int32){AutoIncStart = 1, IsPrimaryKey = true},
                new Field("TestID", DataTypeEnum.Int32),
                new Field("TestProfession", DataTypeEnum.String)
            });

            test = new SQLObject() { Name = Names.Issue2Test2 };
            test.AddRecord(DB, (new Issue2Test2() { TestID = result.TestID, TestProfession = "MY PROFESSION?!?!? Code monkey." }).Value());
            DB.Close();

            // Now lets 'pretend' we need some data on the fly.
            DB.Open(Names.Issue2Test2, true);

            // We stil have Taz (result) from earlier.
            var tazProfession = DB.SelectRecords<Issue2Test2>(string.Format("TestID = {0}", result.TestID))
                                    .FirstOrDefault<Issue2Test2>();

            DB.Close();

            // confirmation
            MessageBox.Show(tazProfession.TestProfession);

            //: Potential of SQLObject
            test = new SQLObject() { Name = Names.Issue2Test };

            //: Get our table
            var table = test.GetInfoByID(DB, tazProfession.TestID);

            //: consider making a wrapper for this, writing this everywhere could get sloppy.
            if(table.Count > 0)
            {
                //: We have rows in JSON format
                foreach (var record in table)
                {
                    //: You can have a foreach ( value in record )
                    MessageBox.Show(record.Data.ToString());
                }
            }
        }
    }
}
