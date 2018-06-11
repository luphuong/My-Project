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
    public partial class QuanLyNhanVien : Form
    {
        int manv;
        public static int dem;
        public static int k;
        DataTable dtQLNhanVien;
        DataView dv;
        byte[] b;
        string err;
        XuLyNhanVien dsNhanVien = new XuLyNhanVien();
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            try
            {
               
                dtQLNhanVien = dsNhanVien.LayNhanVien();

                dv = new DataView(dtQLNhanVien);

                dgvThongTinNV.DataSource = dv;
                dgvThongTinNV.AutoResizeColumns();


            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong bảng.Lỗi rồi!!!!");
            }

        }


        private void dgvThongTinNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int r = dgvThongTinNV.CurrentCell.RowIndex;
                if (r >= 0)
                {
                    manv = int.Parse(dgvThongTinNV.Rows[r].Cells[0].Value.ToString());

                }
                else
                    MessageBox.Show("Chưa chọn nhân viên");
            }
            switch (manv)
            {
                case 1:
                    ptbAnhNV.Image = Properties.Resources.Vision;
                    break;
                case 2:
                    ptbAnhNV.Image = Properties.Resources.CapWo;
                    break;
                case 3:
                    ptbAnhNV.Image = Properties.Resources.Wol;
                    break;
                case 4:
                    ptbAnhNV.Image = Properties.Resources.Hulk;
                    break;
                case 5:
                    ptbAnhNV.Image = Properties.Resources.Stark;
                    break;
                case 6:
                    ptbAnhNV.Image = Properties.Resources.BlackPan;
                    break;
                case 7:
                    ptbAnhNV.Image = Properties.Resources.BlackWin;
                    break;
                case 8:
                    ptbAnhNV.Image = Properties.Resources.Thanos;
                    break;
                case 9:
                    ptbAnhNV.Image = Properties.Resources.Captain;
                    break;
                default:
                    ptbAnhNV.Image = Properties.Resources.Thor;
                    break;

            }




        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dem = 0;
            ThemVaCapNhatNhanVien t = new ThemVaCapNhatNhanVien(null, null, null, null, null,null,null,null,null,null);
            t.Show();
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien.dem = 1;
            try
            {
                int r;
                r = dgvThongTinNV.CurrentCell.RowIndex;
                if (r >= 0)
                {

                    string MaNV = dgvThongTinNV.Rows[r].Cells[0].Value.ToString();
                    string TenNV = dgvThongTinNV.Rows[r].Cells[1].Value.ToString();
                    string Tuoi = dgvThongTinNV.Rows[r].Cells[2].Value.ToString();
                    string DiaChi = dgvThongTinNV.Rows[r].Cells[3].Value.ToString();
                    string SDT = dgvThongTinNV.Rows[r].Cells[4].Value.ToString();
                    string GioiTinh = dgvThongTinNV.Rows[r].Cells[5].Value.ToString();
                    string LoaiNV = dgvThongTinNV.Rows[r].Cells[6].Value.ToString();
                    string LuongCB = dgvThongTinNV.Rows[r].Cells[7].Value.ToString();
                    string CaLV = dgvThongTinNV.Rows[r].Cells[8].Value.ToString();
                    if (b != null)
                    {
                        
                        QuanLyNhanVien.k = 1;
                    }
                    else
                        QuanLyNhanVien.k = 0;

                    ThemVaCapNhatNhanVien capnhat = new ThemVaCapNhatNhanVien(MaNV, TenNV, Tuoi, DiaChi, SDT, GioiTinh, LoaiNV, LuongCB, CaLV, b);
                    capnhat.Show();
                }
                else
                {
                    MessageBox.Show("Chưa Chọn Món Cần Cập Nhật!!!");
                }
            }
            catch
            { 
                MessageBox.Show("Không Được. Lỗi rồi!!!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            cbGioiTinh.ResetText();
            cbLoaiNV.ResetText();

            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {

                Choose ch = new Choose();
                ch.Show();
                this.Hide();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvThongTinNV.CurrentCell.RowIndex;
                string strThongTin = dgvThongTinNV.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa món này không?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    dsNhanVien.XoaMon(ref err, strThongTin);

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

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtTenNV.Clear();
            this.cbGioiTinh.Text = "";
            this.cbLoaiNV.Text = "";
            if (txtMaNV.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("Mã like '%{0}%'", txtMaNV.Text);
                dv.RowFilter = str;
            }
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMaNV.Clear();
            this.cbLoaiNV.Text = "";
            this.cbGioiTinh.Text = "";
            if (txtTenNV.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("HọvàTên like '%{0}%'", txtTenNV.Text);
                dv.RowFilter = str;
            }
        }

        private void cbGioiTinh_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMaNV.Clear();
            this.txtTenNV.Clear();
            this.cbLoaiNV.Text = "";
            if (cbGioiTinh.Text == "Nam")
            {
                String str = String.Format("GiớiTính like '%{0}%'", cbGioiTinh.Text);
                dv.RowFilter = str;
            }
            if (cbGioiTinh.Text == "Nữ")
            {
                String str = String.Format("GiớiTính like '%{0}%'", cbGioiTinh.Text);
                dv.RowFilter = str;
            }
            
            if (cbGioiTinh.Text == "Tất Cả")
            {
                dgvThongTinNV.DataSource = dtQLNhanVien;
            }
        }

        private void cbLoaiNV_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMaNV.Clear();
            this.txtTenNV.Clear();
            this.cbGioiTinh.Text = "";
            if (cbLoaiNV.Text == "Đầu Bếp")
            {
                String str = String.Format("Loại like '%{0}%'", cbLoaiNV.Text);
                dv.RowFilter = str;
            }
            if (cbLoaiNV.Text == "Phục Vụ")
            {
                String str = String.Format("Loại like '%{0}%'", cbLoaiNV.Text);
                dv.RowFilter = str;
            }
            if (cbLoaiNV.Text == "Thu Ngân")
            {
                String str = String.Format("Loại like '%{0}%'", cbLoaiNV.Text);
                dv.RowFilter = str;
            }
            if (cbLoaiNV.Text == "Giao Hàng")
            {
                String str = String.Format("Loại like '%{0}%'", cbLoaiNV.Text);
                dv.RowFilter = str;
            }
            if (cbLoaiNV.Text == "Quản Lý")
            {
                String str = String.Format("Loại like '%{0}%'", cbLoaiNV.Text);
                dv.RowFilter = str;
            }
            if (cbLoaiNV.Text == "Tạp Vụ")
            {
                String str = String.Format("Loại like '%{0}%'", cbLoaiNV.Text);
                dv.RowFilter = str;
            }
            if (cbLoaiNV.Text == "Tất Cả")
            {
                dgvThongTinNV.DataSource = dtQLNhanVien;
            }
        }
    }
}
