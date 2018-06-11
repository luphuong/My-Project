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
using System.Data;
using CoffeeManage.LopXuLyDuLieu;

namespace CoffeeManage
{
    public partial class ThongTinKhachHang : Form
    {
        public static int dem;
        DataTable dtKhachHang = null;
        DataView dv;
        string err;
        KhachHang dsKhachHang = new KhachHang();
        string makh, tenkh, diachi, sdt;
        public ThongTinKhachHang()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();

                DataSet ds = dsKhachHang.LayKhachHang();
                dtKhachHang = ds.Tables[0];
                dv = new DataView(dtKhachHang);

                dgvThongTinChiTiet.DataSource = dv;

                dgvThongTinChiTiet.AutoResizeColumns();


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bạng.Lỗi rồi!!!!");
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
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
                sdt = dgvThongTinChiTiet.Rows[r].Cells[0].Value.ToString();
                KhachHang k = new KhachHang();
                k.XoaKhachHang(ref err, sdt);
                MessageBox.Show("Xóa Thành Công");
                LoadData();
            }
            catch(SqlException)
            {
                MessageBox.Show("Không Xóa Được");
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
                String str = String.Format("MaKH like '%{0}%'", txtMaKH.Text);
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
                String str = String.Format("TenKH like '%{0}%'", txtTenKH.Text);
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
                String str = String.Format("SDT like '%{0}%'", txtSDT.Text);
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
                String str = String.Format("DiaChiKH like '%{0}%'", txtDiaChi.Text);
                dv.RowFilter = str;
            }
        }

        private void ThongTinKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managementCoffeeDataSet.KhachHang' table. You can move, or remove it, as needed.
            //  this.khachHangTableAdapter.Fill(this.managementCoffeeDataSet.KhachHang);
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dem = 0;
            DangKyKhachHang d = new DangKyKhachHang(null,null,null,null);
            d.Show();
        }

        private void tbnCapNhat_Click(object sender, EventArgs e)
        {
            dem = 1;
            int r = dgvThongTinChiTiet.CurrentCell.RowIndex;
            makh = dgvThongTinChiTiet.Rows[r].Cells[0].Value.ToString();
            tenkh = dgvThongTinChiTiet.Rows[r].Cells[1].Value.ToString();
            diachi = dgvThongTinChiTiet.Rows[r].Cells[2].Value.ToString();
            sdt = dgvThongTinChiTiet.Rows[r].Cells[3].Value.ToString();
            DangKyKhachHang d = new DangKyKhachHang(makh,tenkh,diachi,sdt);
            d.Show();
        }
    }
}
