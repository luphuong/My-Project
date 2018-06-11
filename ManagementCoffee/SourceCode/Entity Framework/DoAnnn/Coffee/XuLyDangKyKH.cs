using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnnn.Coffee
{
    class XuLyDangKyKH
    {
        public DataTable LayKhachHang()
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.KhachHangs select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Tên");
            dt.Columns.Add("ĐịaChỉ");
            dt.Columns.Add("SĐT");

            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaKH, p.TenKH, p.DiaChiKH, p.SDT);
            }
            return dt;
        }

        public bool CapNhatKH(string MaKH, string TenKH, string DiaChi, string SDT, ref string err)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tpQuery = (from tp in qlbhEntity.KhachHangs where tp.MaKH == MaKH select tp).SingleOrDefault();

            if (tpQuery != null)
            {
                tpQuery.MaKH = MaKH;
                tpQuery.TenKH= TenKH;
                tpQuery.DiaChiKH = DiaChi;
                tpQuery.SDT = SDT;
                qlbhEntity.SaveChanges();
            }

            return true;
        }
        public bool ThemKH(string MaKH, string TenKH, string DiaChi, string SDT, ref string err)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            KhachHang kh = new KhachHang();
            kh.MaKH = MaKH;
            kh.TenKH = TenKH;
            kh.DiaChiKH = DiaChi;
            kh.SDT = SDT;

            qlbhEntity.KhachHangs.Add(kh);
            qlbhEntity.SaveChanges();
            return true;
        }

        public bool XoaKH(ref string err, string MaKH)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            KhachHang kh = new KhachHang();
            kh.MaKH = MaKH;
            qlbhEntity.KhachHangs.Attach(kh);
            qlbhEntity.KhachHangs.Remove(kh);
            qlbhEntity.SaveChanges();
            return true;
        }
    }
}
