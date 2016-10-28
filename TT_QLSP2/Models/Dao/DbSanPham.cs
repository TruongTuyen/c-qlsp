using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT_QLSP2.Models.EF;

namespace TT_QLSP2.Models.Dao
{
    public class DbSanPham
    {
        public bool AddNew( SanPham sp )
        {
            DBContext context = new DBContext();
            try
            {
                context.SanPhams.Add(sp);
                context.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }

        public bool Edit(SanPham sp)
        {
            DBContext context = new DBContext();
            try
            {
                var old_data = context.SanPhams.Find(sp.ID);
                old_data.ID = sp.ID;
                old_data.ID_Nhom = sp.ID_Nhom;
                old_data.TenSanPham = sp.TenSanPham;
                old_data.GiaSanPham = sp.GiaSanPham;
                old_data.MoTa = sp.MoTa;
                old_data.AnhSanPham = sp.AnhSanPham;
                context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete( int id)
        {
            try
            {
                DBContext context = new DBContext();
                var row = context.SanPhams.Find(id);
                context.SanPhams.Remove(row);
                context.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }

        public IEnumerable<SanPham> GetAllRow()
        {
            try
            {
                DBContext context = new DBContext();
                return context.SanPhams;
            }catch{
                return null;
            }
        }

        public SanPham GetOneRow( int id)
        {
            try
            {
                DBContext context = new DBContext();
                var data = context.SanPhams.Find(id);
                return data;
            }
            catch
            {
                return null;
            }
        }

    }
}