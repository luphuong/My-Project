using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CoffeeManage.LopDuLieu
{
    class KetNoi
    {
        //CHUỖI KẾT NỐI
        public static string SKetNoi = @"Data Source=LUPHUONG_LAPTOP\SQLEXPRESS;Initial Catalog=ManagementCoffee;Integrated Security=True";
        // Tạo đối tượng kết nối
       public static SqlConnection sqlcnt = null;
       public static SqlCommand sqlcmd = null;
       public static SqlDataAdapter sqlda = null;

        public KetNoi()
        {
            sqlcnt = new SqlConnection(SKetNoi);
            sqlcmd = sqlcnt.CreateCommand();
        }

        public DataSet ExecuteQueryDataSet(string strsql, CommandType ct)
        {
            if (sqlcnt.State == ConnectionState.Open)
                sqlcnt.Close();
            sqlcnt.Open();
            sqlcmd.CommandText = strsql;
            sqlcmd.CommandType = ct;
            sqlda = new SqlDataAdapter(sqlcmd);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            return ds;
        }
        // thêm, Xóa , Sửa , Cập Nhật
        public static bool ExecuteNonQuery(string strsql, CommandType ct, ref string error)
        {
            bool f = false;
            if (sqlcnt.State == ConnectionState.Open)
            {
                sqlcnt.Close();
            }
            sqlcnt.Open();
            sqlcmd.CommandText = strsql;
            sqlcmd.CommandType = ct;
            try
            {
                sqlcmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                sqlcnt.Close();
            }
            return f;
        }


    }
}
