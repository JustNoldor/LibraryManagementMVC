using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Areas.Panel.Controllers
{
    public class PanelUyeController : Controller
    {
        //Database Bağlantısı (Eng:Database Connection)
        LibraryDBEntities _db = new LibraryDBEntities();

        //Kitap Listeleme (Eng: Listing books)
        public ActionResult Index()
        {
            var member = _db.Uye.ToList();
            return View(member);
        }

        //Uye Eklemek için View oluşturur.(Eng:Create view for adding users)
        public ActionResult UyeEkle()
        {
            return View();
        }

        //Yeni Üye Ekleme (Eng: Add new user)
        public ActionResult Ekle(Uye members)
        {

            //Eklenme Tarihi (Eng:Upload Date)
            members.EklenmeTarihi = DateTime.Now;

            //members.UyeNo = "10KTPH" + members.UyeID;
            _db.Uye.Add(members);
            _db.SaveChanges();
            
            //Özel bir Üye Numarası oluşturur.(Eng:Create special member number)
            var eklenenuye = _db.Uye.Find(members.UyeID);
            eklenenuye.UyeNo = "10KTPH" + eklenenuye.UyeID;
            _db.SaveChanges();

            return RedirectToAction("Index", "PanelUye", new { area = "Panel" });
        }
    }
}