using System;
using System.Collections.Generic;
using System.Linq;
using Insert_DataBase_Example.Models;

namespace Insert_DataBase_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportService.ImportService importService = new ImportService.ImportService();
            Repository.Repository repository = new Repository.Repository();
            var nodes = importService.FindOpenData();
            nodes.ToList()
                 .ForEach(item =>
                 {
                    repository.Insert(item);
                 });
            ShowOpenData(nodes);
            Console.ReadKey();
        }
        public static void ShowOpenData(List<OpenData> nodes)
        {
            Console.WriteLine(string.Format("共收到{0}筆的資料", nodes.Count));
            Console.WriteLine("Master");
            nodes.GroupBy(node => node.資料年度).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var groupDatas = group.ToList();
                    var message = $"資料年度:{key},共有{groupDatas.Count()}筆資料";
                    Console.WriteLine(message);
                });
        }
    }
}
