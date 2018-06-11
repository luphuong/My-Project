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
using System.IO;
using CoffeeManage.LopDuLieu;


namespace CoffeeManage
{
    public partial class BanHang : Form
    {
        public static int dem;
        public static int co;
        int dongnv;
        int dongkh;
        string mamon, tenmon, giamon, soluong, manv,makh;
        DataTable dtQLThucDon = null;
        DataTable dtKhacHang=null;
       
        DataView dv;
        DataView dvKH;
        string err;
        byte[] b;
        int r, k = 0;
        int sodong = 0;
        float tien;
        LopXuLyDuLieu.QuanLyThucDon dsThucDon = new LopXuLyDuLieu.QuanLyThucDon();
        LopXuLyDuLieu.BanHang dsBanHang = new LopXuLyDuLieu.BanHang();

        public BanHang()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                // show thông tin bảng thực đơn lên datagridview
                dtQLThucDon = new DataTable();
                dtQLThucDon.Clear();
                DataSet ds = dsThucDon.LayThucDon();
                dtQLThucDon = ds.Tables[0];
                dv = new DataView(dtQLThucDon);
                dgvThongTinMon.DataSource = dv;
                dgvThongTinMon.AutoResizeColumns();

                // show thông tin khách hàng
                dtKhacHang = new DataTable();
                dtKhacHang.Clear();
                DataSet dsKH = dsBanHang.LayKhacHang();
                dtKhacHang = dsKH.Tables[0];
                dvKH = new DataView(dtKhacHang);
                dgvThongTinKhachHang.DataSource = dvKH;
                dgvThongTinKhachHang.AutoResizeColumns();

               

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bạng.Lỗi rồi!!!!");
            }
        }
       


        private void BanHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managementCoffeeDataSet1.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.managementCoffeeDataSet1.NhanVien);
            // TODO: This line of code loads data into the 'managementCoffeeDataSet.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.managementCoffeeDataSet.KhachHang);

            LoadData();
        }

        private void dgvThongTinMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int r = dgvThongTinMon.CurrentCell.RowIndex;
                if (r >= 0)
                {
                    string mamon = dgvThongTinMon.CurrentRow.Cells[0].Value.ToString();
                    b = dsThucDon.LayHinhAnh(mamon, ref err);
                    // byte[] b = (byte[])dgvThongTinMon.Rows[r].Cells[4].Value;
                    MemoryStream ms = new MemoryStream(b);
                    this.ptAnh.Image = Image.FromStream(ms);
                    ms.Close();

                }
                else
                {
                    MessageBox.Show("Không Xem Được!!!");
                }
            }
        }

        private void cbLoaiMon_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtTimKiem.Clear();
            //LỌC THEO THỂ LOẠI MÓN ĂN
            if (cbLoaiMon.Text == "Cafe")
            {
                String str = String.Format("TheLoai like '%{0}%'", cbLoaiMon.Text);
                dv.RowFilter = str;
            }
            if (cbLoaiMon.Text == "Bánh")
            {
                String str = String.Format("TheLoai like '%{0}%'", cbLoaiMon.Text);
                dv.RowFilter = str;
            }

            if (cbLoaiMon.Text == "Khác")
            {
                String str = String.Format("TheLoai like '%{0}%'", cbLoaiMon.Text);
                dv.RowFilter = str;
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
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("TenMon like '%{0}%'", txtTimKiem.Text);
                dv.RowFilter = str;
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
           
                float tongtien ;
            float thanhtien = 0;

            for (int j = 0; j < dgvMonDaChon.Rows.Count-1; j++)
            {
                tongtien = float.Parse(dgvMonDaChon.Rows[j].Cells[3].Value.ToString()) * (int)dgvMonDaChon.Rows[j].Cells[4].Value;
                thanhtien += tongtien;
            }
            tien = thanhtien;
            txtTongTien.Text = tien.ToString();
            txtThanhTien.Text = (tien+(tien*10/100)).ToString();
                       
        }

        private void btnBot_Click(object sender, EventArgs e)
        {
            int i;
            string row = "";
            r = dgvMonDaChon.CurrentCell.RowIndex;
            if ((string)dgvMonDaChon.Rows[r].Cells[1].Value!=null)
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

       

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                if (BanHang.co == 1)
                {
                    Choose c = new Choose();
                    this.Close();
                    c.Show();
                }
                else
                {
                    Login l = new Login();
                    this.Close();
                    l.Show();
                }
            }
           
        }

        private void btnChonKH_Click(object sender, EventArgs e)
        {
            
            r = dgvThongTinKhachHang.CurrentCell.RowIndex;
            if (dgvThongTinKhachHang.Rows[r].Cells[1].Value.ToString() != null)
            {
                txtKH.Text = dgvThongTinKhachHang.Rows[r].Cells[1].Value.ToString();
            }
            else
                MessageBox.Show("Mời Chọn Lại");
        }

        private void dgvThongTinKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dongkh = dgvThongTinKhachHang.CurrentCell.RowIndex;
            string ten = dgvThongTinKhachHang.Rows[dongkh].Cells[1].Value.ToString();
            txtKH.Text = ten;
        }

       

        private void dgvThongTinNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dongnv = dgvThongTinNhanVien.CurrentCell.RowIndex;
            string ten = dgvThongTinNhanVien.Rows[dongnv].Cells[1].Value.ToString();
            txtNhanVien.Text = ten;
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
                String str = String.Format("TenKH like '%{0}%'", txtTimKiemKH.Text);
                dvKH.RowFilter = str;
            }
        }

        private void btnDKKH_Click(object sender, EventArgs e)
        {
            dem = 0;
            DangKyKhachHang d = new DangKyKhachHang(null, null, null,null);
            d.Show();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtMaHD.Text!="" && cbLoaiHd.Text!="" && txtNhanVien.Text!="" && txtKH.Text!="" && txtThanhTien.Text!="0")
                {
                    LopXuLyDuLieu.BanHang bh = new LopXuLyDuLieu.BanHang();
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
               //     KetNoi.sqlcnt.Open();
                }
                
            }
            catch(SqlException)
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
