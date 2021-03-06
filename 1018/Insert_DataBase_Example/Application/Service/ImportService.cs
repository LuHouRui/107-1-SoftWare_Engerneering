﻿using Insert_DataBase_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Insert_DataBase_Example.Repository;
namespace Insert_DataBase_Example.Service
{
    public class ImportService
    {
        public List<OpenData> FindOpenDataFromDb(string name)
        { 
            var repository = new Repository.Repository();
            return repository.SelectAll(name);
        }
        public List<OpenData> FindOpenDataFromXml()
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
            int count = 1;
            result = nodes.ToList()
                .Select(node =>
                {
                    OpenData item = new OpenData();
                    item.Id = count;
                    item.資料年度 =GetValue(node, "資料年度");
                    item.統計項目 = GetValue(node, "統計項目");
                    item.稅目別 = GetValue(node, "稅目別");
                    item.資料單位 = GetValue(node, "資料單位");
                    item.值 = GetValue(node, "值");
                    count++;
                    return item;
                }).ToList();

            return result;
        }
        public string GetValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value?.Trim();
        }
    }
}
