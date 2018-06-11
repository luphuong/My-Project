using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DoAnnn.Coffee
{
    class XuLyNhanVien
    {
        public DataTable LayNhanVien()
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.NhanViens select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("HọvàTên");
            dt.Columns.Add("Tuổi");
            dt.Columns.Add("ĐịaChỉ");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("GiớiTính");
            dt.Columns.Add("Loại");

            dt.Columns.Add("Ca LV");
            dt.Columns.Add("Lương");

            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaNV, p.HoVaTenNV,p.Tuoi, p.DiaChiNV, p.SDT, p.GioiTinh,p.LoaiNV,p.CaLV,p.LuongCB);
            }
            return dt;
        }

        public bool CapNhatNV(string MaNV, string TenNV, string Tuoi, string DiaChi, string SDT, string GioiTinh, string LoaiNV,
                                string Luong, string CaLV, byte[] HinhAnh, ref string err)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tpQuery = (from tp in qlbhEntity.NhanViens where tp.MaNV == MaNV select tp).SingleOrDefault();

            if (tpQuery != null)
            {
                tpQuery.MaNV = MaNV;
                tpQuery.HoVaTenNV = TenNV;
                tpQuery.Tuoi = Tuoi;
                tpQuery.DiaChiNV = DiaChi;
                tpQuery.SDT = SDT;
                tpQuery.GioiTinh = GioiTinh;
                tpQuery.LoaiNV = LoaiNV;
                tpQuery.LuongCB = Luong;
                tpQuery.CaLV = CaLV;
                tpQuery.HinhAnh = HinhAnh;
                qlbhEntity.SaveChanges();
            }

            return true;
        }
        public bool ThemNV(string MaNV, string TenNV, string Tuoi, string DiaChi, string SDT, string GioiTinh, string LoaiNV,
                                string Luong, string CaLV, byte[] HinhAnh, ref string err)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            nv.HoVaTenNV = TenNV;
            nv.Tuoi = Tuoi;
            nv.DiaChiNV = DiaChi;
            nv.SDT = SDT;
            nv.GioiTinh = GioiTinh;
            nv.LoaiNV = LoaiNV;
            nv.LuongCB = Luong;
            nv.CaLV = CaLV;
            nv.HinhAnh = HinhAnh;

            qlbhEntity.NhanViens.Add(nv);
            qlbhEntity.SaveChanges();
            return true;
        }

        public bool XoaMon(ref string err, string MaNV)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            qlbhEntity.NhanViens.Attach(nv);
            qlbhEntity.NhanViens.Remove(nv);
            qlbhEntity.SaveChanges();
            return true;
        }
        public DataTable LayNhanVien1()
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.NhanViens select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("HọvàTên");
            dt.Columns.Add("GiớiTính");
            dt.Columns.Add("Loại");




            foreach (var p in tps)
            {
                dt.Rows.Add(p.MaNV, p.HoVaTenNV, p.GioiTinh, p.LoaiNV);
            }
            return dt;
        }
    }
}
