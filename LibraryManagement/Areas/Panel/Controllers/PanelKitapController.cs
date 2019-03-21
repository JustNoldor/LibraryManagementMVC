using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Areas.Panel.Controllers
{
    public class PanelKitapController : Controller
    {
        //Database Bağlantısı (Eng:Database Connection)
        LibraryDBEntities _db = new LibraryDBEntities();


        //Kitap Listele (Listing Books)
        public ActionResult Index()
        {
            var booklist = _db.Kitaplar.ToList();
            return View(booklist);
        }

        //Kitap Listeleme View'ı oluşturur.(Eng:Add Book List View)
        public ActionResult KitapEkle()
        {
            ViewBag.Kategoriler = _db.Kategori.ToList();
            return View();
        }

        //Kitap Ekleme(Eng:Add new book)
        [HttpPost]
        public ActionResult Ekle(Kitaplar book)
        {
            _db.Kitaplar.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index", "PanelKitap", new { area = "Panel" });
        }
    }
}