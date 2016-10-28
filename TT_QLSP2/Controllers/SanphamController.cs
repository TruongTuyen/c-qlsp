using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TT_QLSP2.Models.Dao;
using TT_QLSP2.Models.EF;

namespace TT_QLSP2.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Sanpham
        public ActionResult Index()
        {
            DbSanPham dbsp = new DbSanPham();
            var data = dbsp.GetAllRow();

            return View(data);
        }

        // GET: Sanpham/Details/5
        public ActionResult Details(int id)
        {
            DbSanPham dbsp = new DbSanPham();
            var data = dbsp.GetOneRow(id);
            return View(data);
        }

        public void set_select_nhom( int? selectedID = null)
        {
            var context = new DbNhomSanPham();
            ViewBag.ID_Nhom = new SelectList(context.GetAll(), "ID", "TenNhom", selectedID);
        }

        // GET: Sanpham/Create
        public ActionResult Create()
        {
            //var nhomsp = new DbNhomSanPham();
            //int selectedValue = null;
            //ViewBag.ID_Nhom = new SelectList(nhomsp.GetAll(), "ID", "TenNhom", selectedValue );
            //ViewData["ID_Nhom"] = new SelectList(nhomsp.GetAll(), "ID", "TenNhom", selectedValue);
            set_select_nhom();
            return View();
        }

        // POST: Sanpham/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            if (ModelState.IsValid) { 
                try
                {
                    // TODO: Add insert logic here
                    HttpPostedFileBase File = Request.Files["AnhSanPham"];
                
                    string path = Server.MapPath("~/Images/Sanpham/" + File.FileName);
                    string img_url = "Images/Sanpham/" + File.FileName;
                    File.SaveAs(path);

                    sp.AnhSanPham = img_url;

                    DbSanPham db = new DbSanPham();
                    db.AddNew(sp);
                
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

        // GET: Sanpham/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sanpham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sanpham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sanpham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
