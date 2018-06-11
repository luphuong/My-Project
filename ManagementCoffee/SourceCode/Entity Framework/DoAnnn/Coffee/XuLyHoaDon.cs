using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnnn.Coffee
{
    class XuLyHoaDon
    {
        public DataTable LayHoaDon()
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.HoaDons select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("MaHD");
            dt.Columns.Add("LoạiHD");
            dt.Columns.Add("TênKH");
            dt.Columns.Add("TênNV");
            dt.Columns.Add("Ngày");
            dt.Columns.Add("ThànhTiền");

            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaHD, p.LoaiHD, p.TenKH, p.TenNV, p.Ngay, p.ThanhTien);
            }
            return dt;
        }


        public bool XoaHoaDon(ref string err, string MaHD)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            HoaDon hd = new HoaDon();
            hd.MaHD = MaHD;
            qlbhEntity.HoaDons.Attach(hd);
            qlbhEntity.HoaDons.Remove(hd);
            qlbhEntity.SaveChanges();
            return true;
        }

        public DataTable LayMonDaChon(string MaHD, ref string err)
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.MonDaChons where p.MaHD == MaHD select p;
            //List<MonDaChon> tps = (from p in qlbhEntity.MonDaChons where p.MaHD == MaHD select p).ToList<MonDaChon>();
            //List<object> list = qlbhEntity.MonDaChons.Where(p => p.MaHD == ma).Select(p => new {
            //                        MaMon=p.MaMon,
            //                        TenMon=p.TenMon,
            //                        SoLuong=p.SoLuong.ToString(),
            //                        GiaTien=p.GiaMon
            //                    }).ToList<object>();

            DataTable dt = new DataTable();
            dt.Columns.Add("MaMon");
            dt.Columns.Add("TenMon");
            dt.Columns.Add("GiaMon");
            dt.Columns.Add("SoLuong");

            foreach (var p in tps)
            {
                dt.Rows.Add( p.MaMon,  p.TenMon, p.GiaMon, p.SoLuong);
            }
            return dt;
        }
        public bool XoaMonDaChon(ref string err, string MaHD)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            MonDaChon hd = new MonDaChon();
            hd.MaHD = MaHD;
            qlbhEntity.MonDaChons.Attach(hd);
            qlbhEntity.MonDaChons.Remove(hd);
            qlbhEntity.SaveChanges();
            return true;
        }
    }
}
