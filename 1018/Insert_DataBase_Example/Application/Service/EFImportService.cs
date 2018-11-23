using Insert_DataBase_Example.Models;
using Insert_DataBase_Example.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insert_DataBase_Example.Service
{
    public class EFImportService
    { public List<OpenData> FindOpenDataFromDb(string name)
        {
            var EFrepository = new EFRepository();
            return EFrepository.SelectAll(name);
        }
    }
}
