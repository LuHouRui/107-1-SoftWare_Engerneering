using Insert_DataBase_Example.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Insert_DataBase_Example.Repository
{
    class Repository
    {
        //資料庫連線來源
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename = 
D:\DcTenXen0621\Data\School\107-1_Software Engineering\1018\Insert_DataBase_Example\Insert_DataBase_Example\App_Data\OpenData.mdf";
            }
        }
        //使用C#執行資料庫指令INSERT
        public void Insert(OpenData item)
        {
            //宣告 newItem內裝有OpenData型態的item
            var newItem = item;
            //宣告 connection物件為 SqlConnection型態
            var connection = new SqlConnection(ConnectionString);
            //開啟對資料庫的連線
            connection.Open();
            //宣告 SqlCommand型態的物件command，其指令輸出到connection的來源處
            var command = new SqlCommand("", connection);
            //設定command的指令內容
            command.CommandText = string.Format(@"
INSERT INTO OpenData (資料年度,統計項目,稅目別,資料單位,值)
VALUES                  (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')"
    ,newItem.資料年度, newItem.統計項目, newItem.稅目別, newItem.資料單位, newItem.值);
            //使用C#執行SQL語言的指令時所用的方法
            command.ExecuteNonQuery();
            //關閉對資料庫的連線
            connection.Close();
        }
    }
}
