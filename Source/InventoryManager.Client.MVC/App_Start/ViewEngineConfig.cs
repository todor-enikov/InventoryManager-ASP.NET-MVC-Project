using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.Client.MVC.App_Start
{
    public class ViewEngineConfig
    {
        public static void RegisterViewEngine(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}