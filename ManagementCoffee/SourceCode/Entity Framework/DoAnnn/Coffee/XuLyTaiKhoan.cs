using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnnn.Coffee;

namespace DoAnnn.Coffee
{
    class XuLyTaiKhoan
    {
        public DataTable LayTaiKhoan(string Quyen, ref string err)
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.UserLogins where p.Quyen == Quyen select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("User");
            dt.Columns.Add("Password");
            dt.Columns.Add("Quyen");
            dt.Columns.Add("TenNguoiDung");
            dt.Columns.Add("GioiTinh");

            foreach (var p in tps)
            {
                dt.Rows.Add(p.UserName,p.Password,p.Quyen,p.TenNguoiDung,p.GioiTinh);
            }
            return dt;
        }

        public DataTable KiemTraTaiKhoan()
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.UserLogins select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("User");
            dt.Columns.Add("Password");


            foreach (var p in tps)
            {
                dt.Rows.Add(p.UserName, p.Password);
            }
            return dt;
        }
        public bool CapNhat(string User, string Pass, string Quyen, string Ten, string GioiTinh, ref string err)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tpQuery = (from tp in qlbhEntity.UserLogins where tp.UserName == User select tp).SingleOrDefault();

            if (tpQuery != null)
            {
                tpQuery.UserName = User;
                tpQuery.Password = Pass;
                tpQuery.Quyen = Quyen;
                tpQuery.TenNguoiDung = Ten;
                tpQuery.GioiTinh = GioiTinh;
                qlbhEntity.SaveChanges();
            }

            return true;
        }
    }
}
