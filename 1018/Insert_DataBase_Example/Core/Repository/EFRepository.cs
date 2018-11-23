using Insert_DataBase_Example.DataBase;
using Insert_DataBase_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insert_DataBase_Example.Repository
{
    public class EFRepository
    {
        private OpenDataDbContext openDataDbContext { get; set; }

        public EFRepository()
        {
            openDataDbContext = new OpenDataDbContext();
        }
        public List<OpenData> SelectAll(string name)
        {
            var result = new List<OpenData>();
            var query = openDataDbContext.OpenData.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x=>x.資料年度 == name);
            }
            
            return query.ToList();
        }
        private void Orderby(IQueryable<OpenData>query)
        {
            query.OrderBy(x=>x.稅目別);
        }
        public void Insert(OpenData item)
        {
            openDataDbContext.OpenData.Add(item);
            openDataDbContext.SaveChanges();
        }
        private void Update(OpenData item)
        {
            var exsit = openDataDbContext.OpenData.Where(x => x.資料年度 == item.資料年度).SingleOrDefault();
            if(exsit == null)
            {
                return;
            }
            exsit.資料年度 = item.資料年度;
            exsit.統計項目 = item.統計項目;
            exsit.稅目別 = item.稅目別;
            exsit.資料單位 = item.資料單位;
            exsit.值 = item.值;
            openDataDbContext.SaveChanges();
        }
        private void Delete(string In)
        {
            var exsit = openDataDbContext.OpenData.Where(x => x.資料年度 == In).SingleOrDefault();
            if (exsit == null)
            {
                return;
            }
            openDataDbContext.Remove(exsit);
            openDataDbContext.SaveChanges();
        }
    }
}
