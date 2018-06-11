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
    class QuanLyThucDon
    {
        KetNoi k = null;
        public  QuanLyThucDon()
        {
           k = new KetNoi();
        }
        public DataSet LayThucDon()
        {
            return k.ExecuteQueryDataSet("select * from ThucDon", CommandType.Text);
        }

        public bool ThemMon(string MaMon, string TenMon, string TheLoai, string GiaMon, byte[] HinhAnh, ref string err)
        {
            //  string sql = "Insert Into ThucDon(MaMon,TenMon,TheLoai,GiaMon,HinhAnh)Values(" + MaMon + ",N'" + TenMon + "','" + TheLoai + "','" + GiaMon + "',@HinhAnh)";
            string sql = "Insert Into ThucDon(MaMon,TenMon,TheLoai,GiaMon,HinhAnh)Values(@MaMon,@TenMon,@TheLoai,@GiaMon,@HinhAnh)";
            if (KetNoi.sqlcnt.State != ConnectionState.Open)
            {
                KetNoi.sqlcnt.Open();
            }
            KetNoi.sqlcmd = new SqlCommand(sql, KetNoi.sqlcnt);
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@HinhAnh", HinhAnh));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@MaMon", MaMon));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@TenMon", TenMon));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@GiaMon", GiaMon));
            KetNoi.sqlcmd.Parameters.Add(new SqlParameter("@TheLoai", TheLoai));
            int x = KetNoi.sqlcmd.ExecuteNonQuery();
            KetNoi.sqlcnt.Close();
            return KetNoi.ExecuteNonQuery(sql, CommandType.Text, ref err);
        }
        public bool XoaMon(ref string err, string MaMon)
        {
            string sqlString = "Delete From ThucDon where [MaMon] like '" + MaMon + "'";
            return KetNoi.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatMon(string MaMon, string TenMon, string TheLoai, string GiaMon, byte[] HinhAnh, ref string err)
        {
            KetNoi.sqlcnt.Open();

            SqlTransaction sqltran = KetNoi.sqlcnt.BeginTransaction();

            KetNoi.sqlcmd = KetNoi.sqlcnt.CreateCommand();
            KetNoi.sqlcmd.Transaction = sqltran;       

            // thực hiện các lệnh riêng biệt
            KetNoi.sqlcmd.Parameters.AddWithValue("@MaMon", MaMon);
            KetNoi.sqlcmd.Parameters.AddWithValue("@TenMon", TenMon);
            KetNoi.sqlcmd.Parameters.AddWithValue("@TheLoai", TheLoai);
            KetNoi.sqlcmd.Parameters.AddWithValue("@GiaMon", GiaMon);
            KetNoi.sqlcmd.Parameters.AddWithValue("@HinhAnh", HinhAnh);

            string sqlString= "Update ThucDon set MaMon = @MaMon,TenMon = @TenMon, TheLoai = @TheLoai, GiaMon = @GiaMon, HinhAnh=@HinhAnh where MaMon = @MaMon";
                KetNoi.sqlcnt.Close();
            return KetNoi.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public byte[] LayHinhAnh(string MaMon, ref string err)
        {        
            string sql = "Select HinhAnh from ThucDon where [MaMon] like '"+MaMon+"'";
            KetNoi.sqlcmd = new SqlCommand(sql,KetNoi.sqlcnt);
        //    KetNoi.sqlcnt.Open();
            byte[] bytes = (byte[])KetNoi.sqlcmd.ExecuteScalar();
         //   MemoryStream ms = new MemoryStream(bytes);

          //  KetNoi.sqlcnt.Close();
            return bytes;
        }
    }
}
