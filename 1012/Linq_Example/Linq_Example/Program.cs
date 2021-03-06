﻿using System;
using Linq_Example;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
//HI
namespace _1005
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = findOpenData();
            ShowOpenData(nodes);
            Console.ReadKey();
        }
        static List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();
            var Xml = XElement.Load(@"https://data.kcg.gov.tw/dataset/a1f496df-8fc1-424f-83c3-6c76b0c14496/resource/e4c6fda4-b261-4d70-af9f-f92c9390e75c/download/xml75.xml");
            var nodes = Xml.Descendants("各項稅捐徵課費用").ToList();

            //for (var i = 0; i < nodes.Count; i++)
            //{
            //    var node = nodes[i];
            //    OpenData item = new OpenData();

            //    item.資料年度 = getValue(node, "資料年度");
            //    item.統計項目 = getValue(node, "統計項目");
            //    item.稅目別 = getValue(node, "稅目別");
            //    item.資料單位 = getValue(node, "資料單位");
            //    item.值 = getValue(node, "值");
            //    result.Add(item);
            //}

            //nodes.ToList()
            //    .Where(x=>getValue(x,"")=="")
            //    .ToList()
            //    .ForEach(node =>
            //    {
            //        OpenData item = new OpenData();
            //        item.資料年度 = getValue(node, "資料年度");
            //        item.統計項目 = getValue(node, "統計項目");
            //        item.稅目別 = getValue(node, "稅目別");
            //        item.資料單位 = getValue(node, "資料單位");
            //        item.值 = getValue(node, "值");
            //        result.Add(item);
            //    });

            result = nodes.ToList()
                .Select(node =>
                {
                    OpenData item = new OpenData();
                    item.資料年度 = getValue(node, "資料年度");
                    item.統計項目 = getValue(node, "統計項目");
                    item.稅目別 = getValue(node, "稅目別");
                    item.資料單位 = getValue(node, "資料單位");
                    item.值 = getValue(node, "值");
                    return item;
                }).ToList();

            return result;
        }
        private static string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();
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
