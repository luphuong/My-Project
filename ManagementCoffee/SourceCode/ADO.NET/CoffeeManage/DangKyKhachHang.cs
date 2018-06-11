using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CoffeeManage.LopXuLyDuLieu;

namespace CoffeeManage
{
    public partial class DangKyKhachHang : Form
    {
        string makh, tenkh, diachikh, sdt;
        string err;
        KhachHang KH;
        public DangKyKhachHang(string MaKH,string TenKH,string DiaChiKH,string SDT)
        {
            InitializeComponent();
            this.makh = MaKH;
            this.tenkh = TenKH;
            this.diachikh = DiaChiKH;
            this.sdt = SDT;
        }


        void LoadData()
        {
            if(BanHang.dem==1 || ThongTinKhachHang.dem==1)
            {
                this.txtMaKH.Text = makh;
                this.txtTenKH.Text = tenkh;
                this.txtDiaChi.Text = diachikh;
                this.txtSDT.Text = sdt;
                btnThem.Enabled = false;
                btnCapNhat.Enabled = true;
                this.txtMaKH.Enabled = false;
            }
            else
            {
                this.btnCapNhat.Enabled = false;
                this.btnThem.Enabled = true;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang KH = new KhachHang();
                KH.CapNhatKhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, ref err);
                MessageBox.Show("Cập Nhật Thành Công");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không Cập Nhật Được");
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void DangKyKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            //this.reportViewer1.RefreshReport();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "")
                {
                    KhachHang KH = new KhachHang();
                    KH.ThemKhachHang(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, ref err);
                    MessageBox.Show("Thêm Thành Công");
                }
                else
                    MessageBox.Show("Thiếu Thông Tin");
            }
            catch(SqlException)
            {
                MessageBox.Show("Không Thêm Được");
            }
        }
    }
}
