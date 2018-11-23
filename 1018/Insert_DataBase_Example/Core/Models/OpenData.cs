using System;
using System.Collections.Generic;
using System.Text;

namespace Insert_DataBase_Example.Models
{
    public class OpenData //資料屬性類別
    {
        public int Id { set; get; }
        public string 資料年度 { set; get; }
        public string 統計項目 { set; get; }
        public string 稅目別 { set; get; }
        public string 資料單位 { set; get; }
        public string 值 { set; get; }
    }
}
