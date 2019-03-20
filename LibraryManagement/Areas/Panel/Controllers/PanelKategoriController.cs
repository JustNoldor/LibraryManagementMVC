using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Areas.Panel.Controllers
{
    public class PanelKategoriController : Controller
    {

        //Database Bağlantısı (Eng:Database Connection)
        LibraryDBEntities _db = new LibraryDBEntities();

        public ActionResult Index()
        {
            //Kategori Listeleme (Eng: Category Listing)
            var listcategory = _db.Kategori.ToList();
            return View(listcategory);
        }




    }
}