using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DoAnnn.Coffee;

namespace DoAnnn.Coffee
{
    class XuLyBanHang
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
                dt.Rows.Add(p.MaKH, p.TenKH, p.DiaChiKH,p.SDT);
            }
            return dt;
        }
        public bool GhiBangMonDaChon(string MaHD, string LoaiHD, string MaMon, string MaNV, string MaKH, string TenNV, string TenKH, string TenMon, string Ngay, string GiaMon, string SoLuong, ref string err)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            MonDaChon mdc = new MonDaChon();
            mdc.MaHD = MaHD;
            mdc.LoaiHD = LoaiHD;
            mdc.MaMon = MaMon;
            mdc.MaNV = MaNV;
            mdc.MaKh = MaKH;
            mdc.TenNV = TenNV;
            mdc.TenKH = TenKH;
            mdc.TenMon = TenMon;
            mdc.Ngay = Ngay;
            mdc.GiaMon = GiaMon;
            mdc.SoLuong = SoLuong;


            qlbhEntity.MonDaChons.Add(mdc);
            qlbhEntity.SaveChanges();
            return true;
        }

        public bool GhiBangHoaDon(string MaHD, string LoaiHD, string TenKH, string TenNV, string Ngay, string ThanhTien, ref string err)
        {
            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();
            HoaDon mdc = new HoaDon();
            mdc.MaHD = MaHD;
            mdc.LoaiHD = LoaiHD;
            mdc.TenKH = TenKH;
            mdc.TenNV = TenNV;
            mdc.Ngay = Ngay;
            mdc.ThanhTien = ThanhTien;


            qlbhEntity.HoaDons.Add(mdc);
            qlbhEntity.SaveChanges();
            return true;
        }

        public DataTable LayTenKH()
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.KhachHangs select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("TenKH");


            foreach (var p in tps)
            {
                dt.Rows.Add(p.TenKH);
            }
            return dt;
        }

        public DataTable LayTenNV()
        {

            ManagementCoffeeEntities qlbhEntity = new ManagementCoffeeEntities();

            var tps = from p in qlbhEntity.NhanViens select p;

            DataTable dt = new DataTable();
            dt.Columns.Add("HoVaTenNV");


            foreach (var p in tps)
            {
                dt.Rows.Add(p.HoVaTenNV);
            }
            return dt;
        }
    }
}
