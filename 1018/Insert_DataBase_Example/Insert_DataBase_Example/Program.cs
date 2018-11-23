using System;
using System.Collections.Generic;
using System.Linq;
using Insert_DataBase_Example.Models;
using Insert_DataBase_Example.Service;

namespace Insert_DataBase_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //宣告 ImportService型態的物件importService 

            ImportService importService = new ImportService();
            EFImportService EFImportService = new EFImportService();
            //使用物件importService的方法FindOpenData來讀取資料
            var nodes =EFImportService.FindOpenDataFromDb("");
            //使用ForEach展開所有資料並使用INSERT(SQL語言)插入資料至資料庫
            //nodes.ToList()
            //     .ForEach(item =>
            //     {
            //         repository.Insert(item);
            //     });

            //print以資料年度篩選的結果
            ShowOpenData(nodes);
            Console.ReadKey();
        }
        //將nodes的資料以GroupBy分組在展開統計每組的數量
        public static void ShowOpenData(List<OpenData> nodes)
        {
            Console.WriteLine(string.Format("共收到{0}筆的資料", nodes.Count));
            nodes.ToList().ForEach(x=>
            {
                var message = $"資料年度:{x.資料年度},統計項目:{x.統計項目},稅目別:{x.稅目別}" +
                $",資料單位:{x.資料單位},值:{x.值}";
                Console.WriteLine(message);
            });
            //nodes.GroupBy(node => node.資料年度).ToList() //GroupBy 以"資料年度"分組
            //    .ForEach(group =>                         //ForEach 各組展開統計
            //    {
            //        var key = group.Key;
            //        var groupDatas = group.ToList();
            //        var message = $"資料年度:{key},共有{groupDatas.Count()}筆資料";
            //        Console.WriteLine(message);
            //    });
        }
    }
}