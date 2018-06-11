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
    class LichSu
    {
        KetNoi k = null;
        public LichSu()
        {
            k = new KetNoi();
        }

        public DataSet LayMonDaChon(string MaHD,ref string err)
        {
            return k.ExecuteQueryDataSet("select * from MonDaChon where [MaHD]='"+MaHD+"'", CommandType.Text);
        }

        public DataSet LayHoaDon()
        {
            return k.ExecuteQueryDataSet("select * from HoaDon", CommandType.Text);
        }
        public bool XoaHoaDon(ref string err, string MaHD)
        {
            string sqlString = "Delete From HoaDon where [MaHD] like '" + MaHD + "'";
            return KetNoi.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public bool XoaMonDaChon(ref string err, string MaHD)
        {
            string sqlString = "Delete From MonDaChon where [MaHD] like '" + MaHD + "'";
            return KetNoi.ExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
