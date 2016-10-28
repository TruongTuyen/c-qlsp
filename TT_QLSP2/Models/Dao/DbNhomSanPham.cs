using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT_QLSP2.Models.EF;

namespace TT_QLSP2.Models.Dao
{
    public class DbNhomSanPham
    {
        DBContext db;
        private object viewBag;

        public DbNhomSanPham()
        {
            db = new DBContext();
        }
        public bool add(NhomSanPham nhomsp)
        {
            DBContext context = new DBContext();
            try
            {
                context.NhomSanPhams.Add(nhomsp);
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public IEnumerable<NhomSanPham> GetAll()
        {
            DBContext context = new DBContext();
            return context.NhomSanPhams;
        }

        public NhomSanPham GetOneRow(int id)
        {
            try
            {
                DBContext context = new DBContext();
                return context.NhomSanPhams.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool edit(NhomSanPham nhomsp)
        {
            DBContext context = new DBContext();
            try
            {
                
                var data = context.NhomSanPhams.Find(nhomsp.ID);

                data.TenNhom = nhomsp.TenNhom;
                data.MoTa = nhomsp.MoTa;
                
                if(nhomsp.Anh.Length > 0){
                    data.Anh = nhomsp.Anh;
                }else
                {
                    data.Anh = data.Anh;
                }
                
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int id)
        {
            try
            {
                DBContext context = new DBContext();
                var row = context.NhomSanPhams.Find(id);
                context.NhomSanPhams.Remove(row);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}