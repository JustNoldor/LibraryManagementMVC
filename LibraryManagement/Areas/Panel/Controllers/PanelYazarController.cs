using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Areas.Panel.Controllers
{
    public class PanelYazarController : Controller
    {
        //Database Bağlantısı (Eng:Database Connection)
        LibraryDBEntities _db = new LibraryDBEntities();

        //Yazar Listeleme(Eng: Listing Authors)
        public ActionResult Index()
        {
            var listauthor = _db.Yazarlar.ToList();
            return View(listauthor);
        }


        //Yazar View'ı oluşturur.(Eng:Create Author View for Users)
        public ActionResult YazarEkle()
        {
            return View();
        }

        //Yazar Ekleme ve anasayfaya yönlendirme. (Eng: Add new author with HttpPost and return Index.)
        [HttpPost]
        public ActionResult Ekle(Yazarlar author)
        {
            _db.Yazarlar.Add(author);
            _db.SaveChanges();
            return RedirectToAction("Index", "PanelYazar", new { area = "Panel" });

        }

        public ActionResult Sil(int id)
        {
            var silyazar = _db.Yazarlar.Find(id);
            if (silyazar==null)
            {
                return HttpNotFound();
            }
            _db.Yazarlar.Remove(silyazar);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}