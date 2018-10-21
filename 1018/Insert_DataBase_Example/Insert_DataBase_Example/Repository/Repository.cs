using Insert_DataBase_Example.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Insert_DataBase_Example.Repository
{
    class Repository
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename = 
D:\DcTenXen0621\Data\School\107-1_Software Engineering\1018\Insert_DataBase_Example\Insert_DataBase_Example\App_Data\OpenData.mdf";
            }
        }
        public void Insert(OpenData item)
        {
            var newItem = item;
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT INTO OpenData (資料年度,統計項目,稅目別,資料單位,值)
VALUES                  (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')"
    ,newItem.資料年度, newItem.統計項目, newItem.稅目別, newItem.資料單位, newItem.值);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
