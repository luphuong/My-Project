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
    public partial class DangKyKhachHang : Form
    {
        string makh, tenkh, diachi, sdt;
        string err;

        void LoadData()
        {
            this.txtMaKH.Text = makh;
            this.txtTenKH.Text = tenkh;
            this.txtDiaChi.Text = diachi;
            this.txtSDT.Text = sdt;
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
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                XuLyDangKyKH x = new XuLyDangKyKH();
                x.ThemKH(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, ref err);
                MessageBox.Show("Thêm Thành Công");
            }
            catch
            { 
                MessageBox.Show("Không Thêm Được");
            }
        }


        public DangKyKhachHang(string MaKH, string TenKH, string DiaChiKH, string SDT)
        {
            InitializeComponent();
            this.makh = MaKH;
            this.tenkh = TenKH;
            this.diachi = DiaChiKH;
            this.sdt = SDT;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            { 
                XuLyDangKyKH x = new XuLyDangKyKH();
                x.CapNhatKH(txtMaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, ref err);
                MessageBox.Show("Cập Nhật Thành Công");
            }
            catch
            {
                MessageBox.Show("Không Cập Nhật Được");
            }

        }

    }
}
