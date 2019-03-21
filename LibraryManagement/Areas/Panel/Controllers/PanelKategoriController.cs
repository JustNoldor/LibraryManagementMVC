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

        //KategoriEkle View'ı oluşturmak için.(Eng:Create category view.)
        public ActionResult KategoriEkle()
        {
            return View();
        }

        //Kategori Ekleme ve anasayfaya yönlendir. (Eng: Add new category with HttpPost and return Index.)
        [HttpPost]
        public ActionResult Ekle(Kategori ktg)
        {
            _db.Kategori.Add(ktg);
            _db.SaveChanges();
            return RedirectToAction("Index", "PanelKategori", new { area = "Panel" });
        }

        //Gelen id üzerinden Kategori Silme (Eng: Delete category with getting id)
        public ActionResult Sil(int id)
        {
            var silkategori = _db.Kategori.Find(id);
            if (silkategori==null)
            {
                return HttpNotFound();
            }
                _db.Kategori.Remove(silkategori);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }




    }
}