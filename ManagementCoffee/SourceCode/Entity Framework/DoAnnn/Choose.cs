using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnnn
{
    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void Choose_Load(object sender, EventArgs e)
        {

        }

        private void btnQLThucDon_Click(object sender, EventArgs e)
        {
            QuanLyThucDon qltd = new QuanLyThucDon();
            qltd.Show();
            this.Hide();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlnv = new QuanLyNhanVien();
            qlnv.Show();
            this.Hide();
        }

        private void btnThongTinTaiKhoan_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan t = new ThongTinTaiKhoan();
            this.Hide();
            t.Show();
        }

        private void btnLichSuMuaHang_Click(object sender, EventArgs e)
        {
            LichSuMuaHang l = new LichSuMuaHang();
            this.Hide();
            l.Show();
        }

        private void btnHDBH_Click(object sender, EventArgs e)
        {
            BanHang bh = new BanHang();
            this.Hide();
            bh.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Login l = new Login();
                this.Hide();
                l.Show();
            }
        }

        private void btnThongTinKhachHang_Click(object sender, EventArgs e)
        {
            ThongTinKhachHang ttkh = new ThongTinKhachHang();
            this.Hide();
            ttkh.Show();
        }
    }
}
