using InventoryManager.Data;
using InventoryManager.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManager.Client.MVC.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryManagerDbContext, Configuration>());
            InventoryManagerDbContext.Create().Database.Initialize(true);
        }
    }
}