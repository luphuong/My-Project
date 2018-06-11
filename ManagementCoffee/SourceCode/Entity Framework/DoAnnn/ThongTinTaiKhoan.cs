using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnnn.Coffee;

namespace DoAnnn
{
    public partial class ThongTinTaiKhoan : Form
    {
        DataTable dtTaiKhoan = null;
        string err;
        XuLyTaiKhoan TaiKhoan = new XuLyTaiKhoan();
        void LoadData()
        {
            try
            {
                // Tài Khoản ADMIN
                dtTaiKhoan = TaiKhoan.LayTaiKhoan(txtQuyenAD.Text, ref err);
                txtTaiKhoanAD.Text = dtTaiKhoan.Rows[0][0].ToString();
                txtMatKhauAD.Text = dtTaiKhoan.Rows[0][1].ToString();
                txtTenNguoiDungAD.Text = dtTaiKhoan.Rows[0][3].ToString();
                txtGioiTinh.Text = dtTaiKhoan.Rows[0][4].ToString();

                //TÀI KHOẢN SERVE
                dtTaiKhoan = TaiKhoan.LayTaiKhoan(txtQuyenNV.Text, ref err);
                txtTaiKhoanNV.Text = dtTaiKhoan.Rows[0][0].ToString();
                txtMatKhauNV.Text = dtTaiKhoan.Rows[0][1].ToString();
                txttenNguoiDungNV.Text = dtTaiKhoan.Rows[0][3].ToString();

            }
            catch 
            {
                MessageBox.Show("Không lấy được nội dung trong bạng.Lỗi rồi!!!!");
            }
        }
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void ptbAnhQuanLy_Click(object sender, EventArgs e)
        {

        }

        

        private void btnCapNhatAD_Click(object sender, EventArgs e)
        {
            try
            {
                XuLyTaiKhoan x = new XuLyTaiKhoan();
                x.CapNhat(txtTaiKhoanAD.Text, txtMatKhauAD.Text, txtQuyenAD.Text, txtTenNguoiDungAD.Text, txtGioiTinh.Text, ref err);
                LoadData();
                MessageBox.Show("Cập Nhật Thành Công");
            }
            catch
            {
                MessageBox.Show("Lỗi Rồi!!!");
            }
        }

        private void btnCapNhatNV_Click(object sender, EventArgs e)
        {
            try
            {
                XuLyTaiKhoan x = new XuLyTaiKhoan();
                x.CapNhat(txtTaiKhoanAD.Text, txtMatKhauAD.Text, txtQuyenAD.Text, txtTenNguoiDungAD.Text, null, ref err);
                LoadData();
                MessageBox.Show("Cập Nhật Thành Công");
            }
            catch
            {
                MessageBox.Show("Lỗi Rồi!!!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Choose c = new Choose();
                this.Hide();
                c.Show();
            }
        }

        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
