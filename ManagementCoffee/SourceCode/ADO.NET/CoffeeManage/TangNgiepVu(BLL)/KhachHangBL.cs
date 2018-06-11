using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CoffeeManage.LopDuLieu;
using System.Data;
namespace CoffeeManage.LopXuLyDuLieu
{
    class KhachHang
    {
        KetNoi k = null;
        public KhachHang()
        {
            k = new KetNoi();
        }

        public DataSet LayKhachHang()
        {
            return k.ExecuteQueryDataSet("select * from KhachHang", CommandType.Text);
        }
        public bool ThemKhachHang(string MaKh, string TenKH, string DiaChi, string SDT, ref string err)
        {
            string sql = "Insert Into KhachHang(MaKH,TenKH,DiaChiKH,SDT)Values(" + MaKh + ",N'" + TenKH + "',N'" + DiaChi + "','" + SDT + "')";
            return KetNoi.ExecuteNonQuery(sql, CommandType.Text, ref err);
        }
        public bool XoaKhachHang(ref string err, string MaKH)
        {
            string sqlString = "Delete From KhachHang where [MaKH] like '" + MaKH + "'";
            return KetNoi.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool CapNhatKhachHang(string MaKH, string TenKH, string DiaChi, string SDT,ref string err)
        { 
            string sqlString = "Update KhachHang set TenKH=N'" + TenKH + "',DiaChiKH=N'" + DiaChi + "',SDT='" + SDT +"'where MaKH='" + MaKH + "';";
            return KetNoi.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
