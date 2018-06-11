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
    class TaiKhoan
    {
        KetNoi k = null;
        public TaiKhoan()
        {
            k = new KetNoi();
        }
        public bool CapNhat(string UserName,string Pass,string Quyen,string Ten,string GioiTinh,ref string err)
        {
            // string sqlString = "Update UserLogin Set(UserName,Password,Quyen,TenNguoiDung,GioiTinh)'" + UserName+"'Password='"+Pass+"'TenNguoiDung='"+Ten+"'GioiTinh='"+GioiTinh+"'where Quyen='"+Quyen+"'";
            string sqlString = "Update UserLogin set UserName=N'" + UserName + "',Password=N'" + Pass +"',Quyen='"+Quyen+"',TenNguoiDung=N'"+Ten+"',GioiTinh=N'"+GioiTinh+ "'where Quyen='" + Quyen + "';";
            return KetNoi.ExecuteNonQuery(sqlString,CommandType.Text,ref err);
        }
        public DataTable LayTaiKhoan(string Quyen, ref string err)
        {
            KetNoi.sqlcnt.Open();
            KetNoi.sqlda = new SqlDataAdapter("select * from UserLogin where Quyen='" + Quyen + "'", KetNoi.sqlcnt);
            DataTable dt = new DataTable();
            KetNoi.sqlda.Fill(dt);
            KetNoi.sqlcnt.Close();
            return dt;
        }
       
      
        public DataTable KiemTraTaiKhoan()
        {
            KetNoi.sqlcnt.Open();
            KetNoi.sqlda = new SqlDataAdapter("select * from UserLogin ", KetNoi.sqlcnt);
            DataTable dt = new DataTable();
            KetNoi.sqlda.Fill(dt);
            KetNoi.sqlcnt.Close();
            return dt;
        }
    }
}
