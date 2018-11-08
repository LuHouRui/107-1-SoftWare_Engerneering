﻿using Insert_DataBase_Example.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insert_DataBase_Example.DataBase
{
    class OpenDataDbContext:DbContext
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\DcTenXen0621\Data\School\107-1_Software Engineering\1018\Insert_DataBase_Example\Insert_DataBase_Example\App_Data\OpenData.mdf";
            }
        }
        public DbSet<OpenData> OpenData { get; set; }
        public OpenDataDbContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
