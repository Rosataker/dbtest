using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dbtest.db;


namespace dbtest.controls
{
    class InfoControls
    {        

        private static DatabaseControls DatabaseControls = new DatabaseControls();
        public static Info NowClass = new Info();
        public static string TableId;
        public static List<Info> Rows = new List<Info>();
        

        public InfoControls()
        {

            DatabaseControls.TableName = "Info";
            TableId = "InfoId";            
            Rows.Clear();
        }

        public static void Select(string Sqlwhere = "1=1")
        {
            string Sqlstr = "select * from " + DatabaseControls.TableName + " where "+ Sqlwhere;
            DatabaseControls.Select(Sqlstr);
        }

        

        public static bool Create()
        {
            Select("0=1");
            try
            {
                DatabaseControls.Create(Rows);
            }
            catch (Exception)
            {
                return false;
            }            
            return true;
        }


        public static bool Update(int Id)
        {
            string Sqlstr = TableId + "=" + Id;
            Select(Sqlstr);
            try
            {
                DatabaseControls.Update(Rows);
            }
            catch (Exception)
            {
                return false;
            }
            return true;      
        }

        public static bool Delete(int Id)
        {
            string Sqlstr = TableId + "=" + Id;
            Select(Sqlstr);
            try
            {
                DatabaseControls.Delete(Rows);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }



        public static string ShowColumns()
        { 
            return DatabaseControls.ShowColumns();
        }


        public static Dictionary<string, string> ShowColVar = new Dictionary<string, string>();
        /// <summary>
        /// save select data for ShowColVar Dictionary
        /// </summary>
        /// <param name="_table"></param>
        public static void SetColVar(DataTable _table)
        {
            ShowColVar.Clear();
            DataTable table = _table;            
            foreach (DataRow myRow in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    ShowColVar.Add(col.ToString(), myRow[col].ToString());                    
                }
            }
        }


        public class CboDataList
        {
            public string Cbo_Name { get; set; }
            public int Cbo_Value { get; set; }
        }
        public static List<CboDataList> ComboboxProduce()
        {
            Select();
            DataTable _Table = DatabaseControls._Table;
            List<CboDataList> lis_DataList = new List<CboDataList>();

            lis_DataList.Add(
                new CboDataList
                {
                    Cbo_Name = "",
                    Cbo_Value = 0
                }
            );

            foreach (DataRow myRow in _Table.Rows)
            {
                foreach (DataColumn col in _Table.Columns)
                {
                    switch (col.ToString())
                    {
                        case "Title":
                            NowClass.Title = myRow[col].ToString();
                            break;
                        case "InfoId":
                            NowClass.InfoId = Convert.ToInt32(myRow[col].ToString());
                            break;
                        default:
                            break;
                    }



                }
                lis_DataList.Add(
                    new CboDataList
                    {
                        Cbo_Name = NowClass.Title,
                        Cbo_Value = NowClass.InfoId
                    }
                );
            }

            return lis_DataList;
        }
    }
}
