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
        public DataSet LayTenNV()
        {
            string sql = "Select HoVaTenNV from NhanVien";
            return k.ExecuteQueryDataSet(sql, CommandType.Text);

        }
    }
}
