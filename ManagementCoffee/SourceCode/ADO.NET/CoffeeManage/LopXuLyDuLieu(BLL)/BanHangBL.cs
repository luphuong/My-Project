using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using CoffeeManage.LopDuLieu;


namespace CoffeeManage.LopXuLyDuLieu
{
    class BanHang
    {
        KetNoi k = null;
        public BanHang()
        {
            k = new KetNoi();
        }
        public DataSet LayKhacHang()
        {
            return k.ExecuteQueryDataSet("select * from KhachHang", CommandType.Text);
        }
      
        public bool GhiBangMonDaChon(string MaHD,string LoaiHD,string MaMon,string MaNV,string MaKH,string TenNV,string TenKH,string TenMon,string Ngay,string GiaMon,string SoLuong,ref string err)
        {
            string sql = "Insert Into MonDaChon(MaHD,LoaiHD,MaMon,MaNV,MaKh,TenNV,TenKH,TenMon,Ngay,GiaMon,SoLuong)Values(" + MaHD + ",N'" + LoaiHD + "',N'" + MaMon + "','" + MaNV + "',N'" + MaKH + "',N'" + TenNV + "',N'" + TenKH + "',N'" + TenMon + "',N'" + Ngay + "',N'" + GiaMon + "',N'" + SoLuong + "')";
            return KetNoi.ExecuteNonQuery(sql, CommandType.Text, ref err);
        }
        public bool GhiBangHoaDon(string MaHD,string LoaiHD,string TenKH,string TenNV,string Ngay,string ThanhTien,ref string err)
        {
            string sql = "Insert Into HoaDon(MaHD,LoaiHD,TenKH,TenNV,Ngay,ThanhTien)Values(" + MaHD + ",N'" + LoaiHD + "',N'" + TenKH + "',N'" + TenNV + "',N'" + Ngay + "',N'" + ThanhTien + "')";
            return KetNoi.ExecuteNonQuery(sql, CommandType.Text, ref err);
        }

       
    }
}
