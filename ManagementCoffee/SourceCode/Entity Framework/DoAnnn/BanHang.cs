using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DoAnnn.Coffee;

namespace DoAnnn
{
    public partial class BanHang : Form
    {
        int mm;
        string mamon, tenmon, giamon, manv, makh, soluong;
        DataTable dtQLThucDon = null;
        DataTable dtKhachHang = null;
        DataTable dtNhanVien = null;
        DataView dv;
        DataView dvMon;
        DataView dvKH;
        int dongnv;
        int dongkh;
        string err;
        byte[] b;
        int r, k = 0;
        int sodong = 0;
        float tien;
        XuLyThucDon dsThucDon = new XuLyThucDon();
        XuLyBanHang dsBanHang = new XuLyBanHang();
        XuLyNhanVien dsNhanVien = new XuLyNhanVien();
        public BanHang()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
               
                dtQLThucDon = dsThucDon.LayThucDon();
                dvMon = new DataView(dtQLThucDon);
                dgvThongTinMon.DataSource = dvMon;
                dgvThongTinMon.AutoResizeColumns();

                dtKhachHang = dsBanHang.LayKhachHang();
                dvKH = new DataView(dtKhachHang);
                dgvThongTinKhachHang.DataSource = dvKH;
                dgvThongTinKhachHang.AutoResizeColumns();

                dtNhanVien = dsNhanVien.LayNhanVien1();
                dv = new DataView(dtNhanVien);
                dgvThongTinNhanVien.DataSource = dv;
                dgvThongTinNhanVien.AutoResizeColumns();


            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong bảng.Lỗi rồi!!!!");
            }
        }

        private void dgvThongTinMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int r = dgvThongTinMon.CurrentCell.RowIndex;
                if (r >= 0)
                {
                    mm= int.Parse(dgvThongTinMon.Rows[r].Cells[0].Value.ToString());

                }
                else
                    MessageBox.Show("Chua Chon mon");
            }
            switch (mm)
            {
                case 4:
                    ptAnh.Image = Properties.Resources.CafeSuaDa;
                    break;
                case 9:
                    ptAnh.Image = Properties.Resources.SinhToDau;
                    break;
                case 1:
                    ptAnh.Image = Properties.Resources.PhoMaiQue;
                    break;
                case 2:
                    ptAnh.Image = Properties.Resources.Pudding;
                    break;
                case 3:
                    ptAnh.Image = Properties.Resources.BongLan;
                    break;
                case 5:
                    ptAnh.Image = Properties.Resources.CafeDen;
                    break;
                case 6:
                    ptAnh.Image = Properties.Resources.CaCao;
                    break;
                case 7:
                    ptAnh.Image = Properties.Resources.CafeKem;
                    break;
                case 8:
                    ptAnh.Image = Properties.Resources.NuocCam;
                    break;
                default:
                    ptAnh.Image = Properties.Resources.BanhCrepe_;
                    break;

            }
        }

        private void cbLoaiMon_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtTimKiem.Clear();
 
            if (cbLoaiMon.Text == "Cafe")
            {
                String str = String.Format("ThểLoại like '%{0}%'", cbLoaiMon.Text);
                dvMon.RowFilter = str;
            }
            if (cbLoaiMon.Text == "Bánh")
            {
                String str = String.Format("ThểLoại like '%{0}%'", cbLoaiMon.Text);
                dvMon.RowFilter = str;
            }

            if (cbLoaiMon.Text == "Khác")
            {
                String str = String.Format("ThểLoại like '%{0}%'", cbLoaiMon.Text);
                dvMon.RowFilter = str;
            }

            if (cbLoaiMon.Text == "Tất Cả")
            {
                dgvThongTinMon.DataSource = dtQLThucDon;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.cbLoaiMon.Text = "";
            if (txtTimKiem.Text == "")
            {
                dvMon.RowFilter = "";
            }
            else
            {
                String str = String.Format("TênMón like '%{0}%'", txtTimKiem.Text);
                dvMon.RowFilter = str;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int i;
            string row = "";
            r = dgvThongTinMon.CurrentCell.RowIndex;
            if ((string)dgvThongTinMon.Rows[r].Cells[1].Value != null)
            {
                for (i = 0; i <= dgvThongTinMon.SelectedRows.Count; i++)
                {
                    row = dgvThongTinMon.Rows[r].Cells[0].Value.ToString();
                }
                int chiso = TimTenTrung(row);
                if (chiso == -1)
                {
                    DataGridViewRow n = (DataGridViewRow)dgvMonDaChon.Rows[sodong].Clone();
                    dgvMonDaChon.Rows.Add(n);
                    dgvMonDaChon.Rows[sodong].Cells[0].Value = dgvThongTinMon.Rows[r].Cells[0].Value.ToString();
                    dgvMonDaChon.Rows[sodong].Cells[1].Value = dgvThongTinMon.Rows[r].Cells[1].Value.ToString();
                    dgvMonDaChon.Rows[sodong].Cells[2].Value = dgvThongTinMon.Rows[r].Cells[2].Value.ToString();
                    dgvMonDaChon.Rows[sodong].Cells[3].Value = dgvThongTinMon.Rows[r].Cells[3].Value.ToString();
                    dgvMonDaChon.Rows[sodong].Cells[4].Value = 1;
                    sodong++;
                }
                else
                {
                    dgvMonDaChon.Rows[chiso].Cells[4].Value = (int)dgvMonDaChon.Rows[chiso].Cells[4].Value + 1;
                }
            }
            else
                MessageBox.Show("Chưa chọn món");

            float tongtien;
            float thanhtien = 0;

            for (int j = 0; j < dgvMonDaChon.Rows.Count - 1; j++)
            {
                tongtien = float.Parse(dgvMonDaChon.Rows[j].Cells[3].Value.ToString()) * (int)dgvMonDaChon.Rows[j].Cells[4].Value;
                thanhtien += tongtien;
            }
            tien = thanhtien;
            txtTongTien.Text = tien.ToString();
            txtThanhTien.Text = (tien + (tien * 10 / 100)).ToString();
        }

        private void btnBot_Click(object sender, EventArgs e)
        {
            int i;
            string row = "";
            r = dgvMonDaChon.CurrentCell.RowIndex;
            if ((string)dgvMonDaChon.Rows[r].Cells[1].Value != null)
            {
                for (i = 0; i <= dgvMonDaChon.SelectedRows.Count; i++)
                {
                    row = dgvMonDaChon.Rows[r].Cells[0].Value.ToString();
                }
            }
            else
                MessageBox.Show("Chưa Chọn Món");
            int chiso = TimTenTrung(row);
            if (chiso == -1)
            {
                MessageBox.Show("Không xóa được");
            }
            else
            {
                if ((int)dgvMonDaChon.Rows[chiso].Cells[4].Value > 1)
                {
                    dgvMonDaChon.Rows[chiso].Cells[4].Value = (int)dgvMonDaChon.Rows[chiso].Cells[4].Value - 1;
                    tien = tien - float.Parse(dgvMonDaChon.Rows[chiso].Cells[3].Value.ToString());
                }
                else
                {
                    tien = tien - float.Parse(dgvMonDaChon.Rows[chiso].Cells[3].Value.ToString());
                    dgvMonDaChon.Rows.Remove(dgvMonDaChon.Rows[chiso]);
                    sodong--;
                }
            }

            txtTongTien.Text = tien.ToString();
            txtThanhTien.Text = (tien + (tien * 10 / 100)).ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            r = dgvMonDaChon.CurrentCell.RowIndex;
            if ((string)dgvMonDaChon.Rows[r].Cells[1].Value != null)
            {
                tien = tien - (float.Parse(dgvMonDaChon.Rows[r].Cells[3].Value.ToString()) * (int)dgvMonDaChon.Rows[r].Cells[4].Value);
                dgvMonDaChon.Rows.Remove(dgvMonDaChon.Rows[r]);
                MessageBox.Show("Xóa Thành Công");
                sodong--;
            }
            else
                MessageBox.Show("Chưa Chọn Món");

            txtTongTien.Text = tien.ToString();
            txtThanhTien.Text = (tien + (tien * 10 / 100)).ToString();
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvThongTinKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtKH.DataBindings.Clear();
            //txtKH.DataBindings.Add("text", dgvThongTinKhachHang.DataSource, "Tên");
            dongkh = dgvThongTinKhachHang.CurrentCell.RowIndex;
            string ten = dgvThongTinKhachHang.Rows[dongkh].Cells[1].Value.ToString();
            txtKH.Text = ten;
        }

        private void txtTimKiemKH_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            if (txtTimKiemKH.Text == "")
            {
                dvKH.RowFilter = "";
            }
            else
            {
                String str = String.Format("Tên like '%{0}%'", txtTimKiemKH.Text);
                dvKH.RowFilter = str;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDKKH_Click(object sender, EventArgs e)
        {
            DangKyKhachHang d = new DangKyKhachHang(null, null, null, null);
            d.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvThongTinNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dongnv = dgvThongTinNhanVien.CurrentCell.RowIndex;
            string ten = dgvThongTinNhanVien.Rows[dongnv].Cells[1].Value.ToString();
            txtNhanVien.Text = ten;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                XuLyBanHang bh = new XuLyBanHang();
                if (txtMaHD.Text != "" && cbLoaiHd.Text != "" && txtNhanVien.Text != "" && txtKH.Text != "" && txtThanhTien.Text != "0")
                {
                    bh.GhiBangHoaDon(txtMaHD.Text, cbLoaiHd.Text, txtKH.Text, txtNhanVien.Text, dtpNgayLap.Text, txtThanhTien.Text, ref err);
                    for (int i = 0; i < dgvMonDaChon.Rows.Count - 1; i++)
                    {
                        mamon = dgvMonDaChon.Rows[i].Cells[0].Value.ToString();
                        tenmon = dgvMonDaChon.Rows[i].Cells[1].Value.ToString();
                        giamon = dgvMonDaChon.Rows[i].Cells[3].Value.ToString();
                        soluong = dgvMonDaChon.Rows[i].Cells[4].Value.ToString();
                        manv = dgvThongTinNhanVien.Rows[dongnv].Cells[0].Value.ToString();
                        makh = dgvThongTinKhachHang.Rows[dongkh].Cells[0].Value.ToString();
                        bh.GhiBangMonDaChon(txtMaHD.Text, cbLoaiHd.Text, mamon, manv, makh, txtNhanVien.Text, txtKH.Text, tenmon, dtpNgayLap.Text, giamon, soluong, ref err);
                    }

                    MessageBox.Show("Thanh Toán Thành Công!!", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Thiếu Thông Tin");
                }

            }
            catch 
            {
                MessageBox.Show("Lỗi Rồi @@@");
            }
        }

        int TimTenTrung(string ma)
        {
            int kq = -1;

            for (int i = 0; i < dgvMonDaChon.Rows.Count; i++)
            {
                string a = (string)dgvMonDaChon.Rows[i].Cells[0].Value;
                if (a == ma)
                {
                    return i;
                }
            }
            return kq;
        }
    }
}
