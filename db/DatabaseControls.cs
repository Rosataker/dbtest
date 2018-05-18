using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using dbtest.db;

namespace dbtest.db
{
    class DatabaseControls
    {        
        private string _strConn ;
        private DataSet _DataSet { get; set; }
        private SqlDataAdapter _Adapter { get; set; }
        private SqlConnection _myConn { get; set; }
        public string TableName { get; set; }
        public static DataTable _Table { get; set; }
        public static string MsgShowStr { get; set; }

        public DatabaseControls()
        {
            _strConn = "server=.\\SQLExpress;database=Draginfo;Integrated Security=SSPI;";
            _myConn = new SqlConnection(_strConn);
        }

        /// <summary>
        ///     設定當前的DataTable資料
        /// </summary>
        /// <param name="Sqlstr"></param>
        /// <returns></returns>
        public void Select(string Sqlstr)
        {            
            _Adapter = new SqlDataAdapter(Sqlstr, _myConn);
            _DataSet = new DataSet();
            _Adapter.Fill(_DataSet, TableName);
            _Table = _DataSet.Tables[TableName];            
        }
        


        public int CountUpdate { get; set; }
        /// <summary>
        /// Rows從winform設定，不要找controls
        /// </summary>
        /// <param name="ValueObject"></param>
        public void Update(List<Info> Rows)
        {
            CountUpdate = _Table.Rows.Count;
            DataRow updateRow = _Table.Rows[0];
            
            if (CountUpdate > 0)
            {//update
                updateRow = ForRowSet(updateRow,Rows);

                new SqlCommandBuilder(_Adapter);
                _Adapter.Update(_DataSet, TableName);
            }
        }
 
        
        /// <summary>
        /// Rows從winform設定，不要找controls |
        ///    Controls.Rows.Add(new Info
        ///            {
        ///                Name = value,
        ///                Title = Title,
        ///                Contect = Contect
        ///});
        /// </summary>
        /// <param name="Rows"></param>
        public void Create(List<Info> Rows)
        {
            var updateRow = _Table.NewRow();

            updateRow = ForRowSet(updateRow, Rows);

            _Table.Rows.Add(updateRow);
            new SqlCommandBuilder(_Adapter);
            _Adapter.Update(_DataSet, TableName);
        }

        public void Delete(List<Info> Rows)
        {
            CountUpdate = _Table.Rows.Count;
            DataRow updateRow = _Table.Rows[0];

            if (CountUpdate > 0)
            {
                updateRow.Delete();
                new SqlCommandBuilder(_Adapter);
                _Adapter.Update(_DataSet, TableName);
            }
        }

        private static DataRow ForRowSet(DataRow updateRow, List<Info> Rows)
        {
            foreach (var Row in Rows)
            {
                foreach (var prop in Row.GetType().GetProperties())
                {
                    if (string.IsNullOrEmpty(prop.GetValue(Row, null).ToString())) continue;
                    updateRow[prop.Name] = prop.GetValue(Row, null);
                }
            }
            return updateRow;
        }


        /// <summary>
        ///     Return a string for check table columns.
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        public static string ShowColumns()
        {
            string alltext = null;
            foreach (DataRow myRow in _Table.Rows)
            {
                foreach (DataColumn col in _Table.Columns)
                {
                    alltext += col + " -> " + myRow[col] + "\n";
                }
                alltext += "\n";
            }
            return alltext;
        }
    }

}
