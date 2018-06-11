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
    public partial class ThongTinKhachHang : Form
    {

        DataTable dtKhachHang = null;
        DataView dv;
        string err;
        string makh, tenkh, diachi, sdt;
        XuLyDangKyKH dsKhachHang = new XuLyDangKyKH();

        private void ThongTinKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Choose c = new Choose();
                this.Close();
                c.Show();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvThongTinChiTiet.CurrentCell.RowIndex;
                string strThongTin = dgvThongTinChiTiet.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa món này không?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    dsKhachHang.XoaKH(ref err, strThongTin);

                    LoadData();
                    MessageBox.Show("Đã xóa xong!!!");
                }
                else
                {
                    MessageBox.Show("không thực hiện được!!!");
                }
            }
            catch
            {
                MessageBox.Show("Không xóa được.Lỗi rồi!!!");
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            this.txtTenKH.Clear();
            this.txtDiaChi.Clear();
            this.txtSDT.Clear();
            LoadData();
            if (txtMaKH.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("Mã like '%{0}%'", txtMaKH.Text);
                dv.RowFilter = str;
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            this.txtMaKH.Clear();
            this.txtDiaChi.Clear();
            this.txtSDT.Clear();
            LoadData();
            if (txtTenKH.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("Tên like '%{0}%'", txtTenKH.Text);
                dv.RowFilter = str;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            this.txtMaKH.Clear();
            this.txtTenKH.Clear();
            this.txtDiaChi.Clear();
            LoadData();
            if (txtSDT.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("SĐT like '%{0}%'", txtSDT.Text);
                dv.RowFilter = str;
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            this.txtMaKH.Clear();
            this.txtTenKH.Clear();
            this.txtSDT.Clear();
            LoadData();
            if (txtDiaChi.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("ĐịaChỉ like '%{0}%'", txtDiaChi.Text);
                dv.RowFilter = str;
            }
        }

        private void tbnCapNhat_Click(object sender, EventArgs e)
        {
            int r = dgvThongTinChiTiet.CurrentCell.RowIndex;
            makh = dgvThongTinChiTiet.Rows[r].Cells[0].Value.ToString();
            tenkh = dgvThongTinChiTiet.Rows[r].Cells[1].Value.ToString();
            diachi = dgvThongTinChiTiet.Rows[r].Cells[2].Value.ToString();
            sdt = dgvThongTinChiTiet.Rows[r].Cells[3].Value.ToString();
            DangKyKhachHang d = new DangKyKhachHang(makh, tenkh, diachi, sdt);
            d.Show();
        }

        public ThongTinKhachHang()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dtKhachHang = dsKhachHang.LayKhachHang();
                dv = new DataView(dtKhachHang);
                dgvThongTinChiTiet.DataSource = dv;
                dgvThongTinChiTiet.AutoResizeColumns();
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong bảng.Lỗi rồi!!!!");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DangKyKhachHang dk = new DangKyKhachHang(null,null,null,null);
            dk.Show();
        }
    }
}
