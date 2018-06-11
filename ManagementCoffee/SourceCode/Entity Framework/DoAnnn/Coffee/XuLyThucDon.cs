using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnnn.Coffee
{
    class XuLyThucDon
    {
        public DataTable LayThucDon()
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.ThucDons select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("MãMón");
            dt.Columns.Add("TênMón");
            dt.Columns.Add("ThểLoại");
            dt.Columns.Add("GiáMón");
            //dt.Columns.Add("Hình Ảnh");

            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaMon, p.TenMon, p.TheLoai, p.GiaMon);
            }
            return dt;
        }

        public bool CapNhatMon(string MaMon, string TenMon, string TheLoai, string GiaMon, byte[] HinhAnh, ref string err)
        {
                ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

                var tpQuery = (from tp in qlbhEntity.ThucDons where tp.MaMon == MaMon select tp).SingleOrDefault();

                if (tpQuery != null)
                {
                    tpQuery.MaMon = MaMon;
                    tpQuery.TenMon = TenMon;
                    tpQuery.TheLoai = TheLoai;
                    tpQuery.GiaMon = GiaMon;
                    qlbhEntity.SaveChanges();
                }

                return true;
        }
        public bool ThemMon(string MaMon, string TenMon, string GiaMon, string TheLoai, byte[] HinhAnh, ref string err)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            ThucDon td = new ThucDon();
            td.MaMon = MaMon;
            td.TenMon = TenMon;
            td.GiaMon = GiaMon;
            td.TheLoai = TheLoai;
            td.HinhAnh = HinhAnh;

            qlbhEntity.ThucDons.Add(td);
            qlbhEntity.SaveChanges();
            return true;
        }

        public bool XoaMon(ref string err, string MaMon)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            ThucDon td = new ThucDon();
            td.MaMon = MaMon;
            qlbhEntity.ThucDons.Attach(td);
            qlbhEntity.ThucDons.Remove(td);
            qlbhEntity.SaveChanges();
            return true;
        }
    }
}
