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

namespace CoffeeManage
{
    public partial class LichSuMuaHang : Form
    {
        string mahd;
        DataTable dtHoaDon = null;
        DataTable dtHoaDon1 = null;
        DataView dv;
        DataView dv1;
        string err;
        LopXuLyDuLieu.LichSu dsLichSu = new LopXuLyDuLieu.LichSu();
        public LichSuMuaHang()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dtHoaDon1 = new DataTable();
                dtHoaDon1.Clear();
                DataSet ds1 = dsLichSu.LayHoaDon();
                dtHoaDon1 = ds1.Tables[0];
                dv1 = new DataView(dtHoaDon1);
                dgvHoaDon.DataSource = dv1;
                dgvHoaDon.AutoResizeColumns();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bạng.Lỗi rồi!!!!");
            }
        }

        void LoadDataChiTiet(string mahd)
        {
            try
            {
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                DataSet ds = dsLichSu.LayMonDaChon(mahd, ref err);
                dtHoaDon = ds.Tables[0];
                dv = new DataView(dtHoaDon);
                dgvChiTietHoaDon.DataSource = dv;
                dgvChiTietHoaDon.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bạng!!!!");
            }
        }

        private void txtTenThuNgan_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMaHD.Clear();
            this.txtNgay.Clear();
            //LỌC THEO THỂ LOẠI MÓN ĂN
            if (txtTenThuNgan.Text == "")
            {
                dv1.RowFilter = "";
            }
            else
            {
                String str = String.Format("TenNV like '%{0}%'", txtTenThuNgan.Text);
                dv1.RowFilter = str;
            }
        }


        private void LichSuMuaHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managementCoffeeDataSet1.HoaDon' table. You can move, or remove it, as needed.
            this.hoaDonTableAdapter.Fill(this.managementCoffeeDataSet1.HoaDon);
            // TODO: This line of code loads data into the 'managementCoffeeDataSet1.MonDaChon' table. You can move, or remove it, as needed.
            this.monDaChonTableAdapter.Fill(this.managementCoffeeDataSet1.MonDaChon);
            // TODO: This line of code loads data into the 'managementCoffeeDataSet.HoaDon' table. You can move, or remove it, as needed.
            //  this.hoaDonTableAdapter.Fill(this.managementCoffeeDataSet.HoaDon);
            LoadData();
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtTenThuNgan.Clear();
            this.txtNgay.Clear();
            //LỌC THEO THỂ LOẠI MÓN ĂN
            if (txtMaHD.Text == "")
            {
                dv1.RowFilter = "";
            }
            else
            {
                String str = String.Format("MaHD like '%{0}%'", txtMaHD.Text);
                dv1.RowFilter = str;
            }
        }

        private void txtNgay_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtTenThuNgan.Clear();
            this.txtMaHD.Clear();
            //LỌC THEO THỂ LOẠI MÓN ĂN
            if (txtNgay.Text == "")
            {
                dv1.RowFilter = "";
            }
            else
            {
                String str = String.Format("Ngay like '%{0}%'", txtNgay.Text);
                dv1.RowFilter = str;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.txtMaHD.Clear();
            this.txtTenThuNgan.Clear();
            this.txtNgay.Clear();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvHoaDon.CurrentCell.RowIndex;
                string strThongTin = dgvHoaDon.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa Hóa Đơn này không?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    dsLichSu.XoaMonDaChon(ref err, strThongTin);
                    dsLichSu.XoaHoaDon(ref err, strThongTin);       
                    LoadData();
                    LoadDataChiTiet(null);
                    MessageBox.Show("Đã xóa xong!!!");
                }
                else
                {
                    MessageBox.Show("không thực hiện được!!!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được.Lỗi rồi!!!");
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

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHoaDon.CurrentCell.RowIndex;
            mahd = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            LoadDataChiTiet(mahd);
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            InHoaDon i = new InHoaDon();
            i.Show();
        }
    }
}
