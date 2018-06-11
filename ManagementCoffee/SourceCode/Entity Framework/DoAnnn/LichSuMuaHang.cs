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
    public partial class LichSuMuaHang : Form
    {
        string mahd;
        DataTable dtHoaDon = null;
        DataTable dtHoaDon1 = null;
        DataView dv;
        DataView dv1;
        string err;
        XuLyHoaDon dsLichSu = new XuLyHoaDon();
        public LichSuMuaHang()
        {
            InitializeComponent();
        }

        private void LichSuMuaHang_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }
        void LoadData()
        {
            try
            {

                dtHoaDon = dsLichSu.LayHoaDon();

                dv = new DataView(dtHoaDon);

                dgvHoaDon.DataSource = dv;
                dgvHoaDon.AutoResizeColumns();


            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong bảng.Lỗi rồi!!!!");
            }

        }
        void LoadDataChiTiet(string mahd)
        {
            try
            {

                dtHoaDon = dsLichSu.LayMonDaChon(mahd, ref err);

                dv1 = new DataView(dtHoaDon);

                dgvChiTietHoaDon.DataSource = dv1;
                dgvChiTietHoaDon.AutoResizeColumns();


            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong bảng.Lỗi rồi!!!!");
            }

        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtTenThuNgan.Clear();
            this.txtNgay.Clear();
            //LỌC THEO THỂ LOẠI MÓN ĂN
            if (txtMaHD.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("MaHD like '%{0}%'", txtMaHD.Text);
                dv.RowFilter = str;
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
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("TênNV like '%{0}%'", txtTenThuNgan.Text);
                dv.RowFilter = str;
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
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("Ngày like '%{0}%'", txtNgay.Text);
                dv.RowFilter = str;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.txtMaHD.Clear();
            this.txtTenThuNgan.Clear();
            this.txtNgay.Clear();
            LoadData();
        }

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int r = dgvHoaDon.CurrentCell.RowIndex;
        //        string strThongTin = dgvHoaDon.Rows[r].Cells[0].Value.ToString();

        //        DialogResult traloi;
        //        traloi = MessageBox.Show("Chắc xóa Hóa Đơn này không?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //        if (traloi == DialogResult.Yes)
        //        {
        //            dsLichSu.XoaMonDaChon(ref err, strThongTin);
        //            dsLichSu.XoaHoaDon(ref err, strThongTin);
        //            LoadData();
        //            LoadDataChiTiet(null);
        //            MessageBox.Show("Đã xóa xong!!!");
        //        }
        //        else
        //        {
        //            MessageBox.Show("không thực hiện được!!!");
        //        }
        //    }
        //    catch 
        //    {
        //        MessageBox.Show("Không xóa được.Lỗi rồi!!!");
        //    }
        //}

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

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHoaDon.CurrentCell.RowIndex;
            mahd = dgvHoaDon.Rows[r].Cells[0].Value.ToString();
            LoadDataChiTiet(mahd);
        }
    }
}
