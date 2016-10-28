using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TT_QLSP2.Models.Dao;
using TT_QLSP2.Models.EF;

namespace TT_QLSP2.Controllers
{
    public class NhomsanphamController : Controller
    {
        
        // GET: Nhomsanpham
        public ActionResult Index()
        {
            DbNhomSanPham nhom = new DbNhomSanPham();
            var data = nhom.GetAll();
            
            return View(data);
        }

        // GET: Nhomsanpham/Details/5
        public ActionResult Details(int id)
        {
            DbNhomSanPham nhom = new DbNhomSanPham();
            var data = nhom.GetOneRow(id);
            return View(data);
        }

        // GET: Nhomsanpham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nhomsanpham/Create
        [HttpPost]
        public ActionResult Create(NhomSanPham nhomsp )
        {
            if(ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    HttpPostedFileBase File = Request.Files["Anh"];
                    string path = Server.MapPath("~/Images/" + File.FileName);
                    string img_url = "Images/" + File.FileName;
                    File.SaveAs(path);

                    nhomsp.Anh = img_url;

                    DbNhomSanPham nhom = new DbNhomSanPham();
                    nhom.add(nhomsp);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }else
            {
                return View();
            }
            
        }

        // GET: Nhomsanpham/Edit/5
        public ActionResult Edit(int id)
        {
            DbNhomSanPham nhom = new DbNhomSanPham();
            var data = nhom.GetOneRow(id);
            return View(data);
        }

        // POST: Nhomsanpham/Edit/5
        //public ActionResult Edit(int id, FormCollection collection)
        [HttpPost]
        public ActionResult Edit(NhomSanPham nhomsp)
        {
            try
            {
                // TODO: Add update logic here
                DbNhomSanPham nhom = new DbNhomSanPham();

                HttpPostedFileBase File = Request.Files["Anh"];
                if (File.ContentLength >0 )
                {
                    string path = Server.MapPath("~/Images/" + File.FileName);
                    string img_url = "Images/" + File.FileName;
                    File.SaveAs(path);

                    nhomsp.Anh = img_url;
                }
                

                nhom.edit(nhomsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nhomsanpham/Delete/5
        public ActionResult Delete(int id)
        {
            DbNhomSanPham nhom = new DbNhomSanPham();
            var data = nhom.GetOneRow(id);
            return View(data);
        }

        // POST: Nhomsanpham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DbNhomSanPham nhom = new DbNhomSanPham();
                nhom.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        


    }
}
