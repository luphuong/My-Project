using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using CoffeeManage.LopDuLieu;

namespace CoffeeManage.LopXuLyDuLieu
{
    class QuanLyNhanVien
    {
        KetNoi k = null;
        public QuanLyNhanVien()
        {
            k = new KetNoi();
        }
        public DataSet LayNhanVien()
        {
            return k.ExecuteQueryDataSet("select * from NhanVien", CommandType.Text);
        }
        public bool XoaNhanVien(ref string err, string MaNV)
        {
            string sqlString = "Delete From NhanVien where [MaNV] like '" + MaNV + "'";
            return KetNoi.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool ThemNhanVien(string MaNV, string TenNV, string Tuoi, string DiaChi,string SDT,string GioiTinh,string LoaiNV, string Luong,string CaLV,byte[] HinhAnh, ref string err)
        {
            //  string sql = "Insert Into ThucDon(MaMon,TenMon,TheLoai,GiaMon,HinhAnh)Values(" + MaMon + ",N'" + TenMon + "','" + TheLoai + "','" + GiaMon + "',@HinhAnh)";
            string sql = "Insert Into NhanVien(MaNV,HoVaTenNV,Tuoi,DiaChiNV,SDT,GioiTinh,LoaiNV,LuongCB,CaLV,HinhAnh)Values(@MaNV,@TenNV,@Tuoi,@DiaChi,@SDT,@GioiTinh,@LoaiNV,@Luong,@CaLV,@HinhAnh)";
            if (KetNoi.sqlcnt.State != ConnectionState.Open)
            {
                KetNoi.sqlcnt.Open();
            }
            KetNoi.sqlcmd = new SqlCommand(sql, KetNoi.sqlcnt);
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@MaNV", MaNV));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@TenNV", TenNV));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@Tuoi", Tuoi));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@DiaChi", DiaChi));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@SDT", SDT));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@GioiTinh", GioiTinh));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@LoaiNV", LoaiNV));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@Luong", Luong));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@CaLV", CaLV));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@HinhAnh", HinhAnh));
            int x = KetNoi.sqlcmd.ExecuteNonQuery();
            KetNoi.sqlcnt.Close();
            return KetNoi.ExecuteNonQuery(sql, CommandType.Text, ref err);
        }
        public byte[] LayHinhAnh(string MaNV, ref string err)
        {
            string sql = "Select HinhAnh from NhanVien where [MaNV] like '" + MaNV + "'";
            KetNoi.sqlcmd = new SqlCommand(sql, KetNoi.sqlcnt);
            //  KetNoi.sqlcnt.Open();
            byte[] bytes = (byte[])KetNoi.sqlcmd.ExecuteScalar();
            //   MemoryStream ms = new MemoryStream(bytes);

             // KetNoi.sqlcnt.Close();
            return bytes;
        }

        public bool CapNhatNhanVien(string MaNV, string TenNV, string Tuoi, string DiaChi, string SDT, string GioiTinh, string LoaiNV, string Luong, string CaLV, byte[] HinhAnh, ref string err)
        {
            KetNoi.sqlcnt.Open();

            SqlTransaction sqltran = KetNoi.sqlcnt.BeginTransaction();

            KetNoi.sqlcmd = KetNoi.sqlcnt.CreateCommand();
            KetNoi.sqlcmd.Transaction = sqltran;

            // thực hiện các lệnh riêng biệt
            KetNoi.sqlcmd.Parameters.AddWithValue("@MaNV", MaNV);
            KetNoi.sqlcmd.Parameters.AddWithValue("@TenNV", TenNV);
            KetNoi.sqlcmd.Parameters.AddWithValue("@Tuoi", Tuoi);
            KetNoi.sqlcmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            KetNoi.sqlcmd.Parameters.AddWithValue("@SDT", SDT);
            KetNoi.sqlcmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
            KetNoi.sqlcmd.Parameters.AddWithValue("@LoaiNV", LoaiNV);
            KetNoi.sqlcmd.Parameters.AddWithValue("@Luong", Luong);
            KetNoi.sqlcmd.Parameters.AddWithValue("@CaLV", CaLV);
            KetNoi.sqlcmd.Parameters.AddWithValue("@HinhAnh", HinhAnh);

            string sqlString = "Update NhanVien set MaNV = @MaNV,HoVaTenNV = @TenNV, Tuoi = @Tuoi, DiaChiNV = @DiaChi, SDT=@SDT,GioiTinh=@GioiTinh,LoaiNV=@LoaiNV,LuongCB=@Luong,CaLV=@CaLV,HinhAnh=@HinhAnh where MaNV = @MaNV";
            KetNoi.sqlcnt.Close();
            return KetNoi.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
