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
using System.IO;
using CoffeeManage.LopXuLyDuLieu;

namespace CoffeeManage
{
    public partial class QuanLyNhanVien : Form
    {
        DataTable dtQLNhanVien = null;
        DataView dv;
        string err;
        byte[] b;
        LopXuLyDuLieu.QuanLyNhanVien QLNhanVien = new LopXuLyDuLieu.QuanLyNhanVien();

        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dtQLNhanVien = new DataTable();
                dtQLNhanVien.Clear();

                DataSet ds = QLNhanVien.LayNhanVien();
                dtQLNhanVien = ds.Tables[0];
                dv = new DataView(dtQLNhanVien);

                dgvThongTinNV.DataSource = dv;

                dgvThongTinNV.AutoResizeColumns();


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bạng.Lỗi rồi!!!!");
            }
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

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managementCoffeeDataSet.NhanVien' table. You can move, or remove it, as needed.
         //   this.nhanVienTableAdapter.Fill(this.managementCoffeeDataSet.NhanVien);
            // TODO: This line of code loads data into the 'managementCoffeeDataSet.NhanVien' table. You can move, or remove it, as needed.
          //  this.nhanVienTableAdapter.Fill(this.managementCoffeeDataSet.NhanVien);
            // TODO: This line of code loads data into the 'managementCoffeeDataSet.HoaDon' table. You can move, or remove it, as needed.
          //  this.hoaDonTableAdapter.Fill(this.managementCoffeeDataSet.HoaDon);
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbLoaiNV_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMaNV.Clear();
            this.txtTenNV.Clear();
            this.cbGioiTinh.Text = "";
            //LỌC THEO THỂ LOẠI MÓN ĂN
            if (cbLoaiNV.Text == "Đầu Bếp")
            {
                String str = String.Format("LoaiNV like '%{0}%'", cbLoaiNV.Text);
                dv.RowFilter = str;
            }
            else
            {
                if (cbLoaiNV.Text == "Thu Ngân")
                {
                    String str = String.Format("LoaiNV like '%{0}%'", cbLoaiNV.Text);
                    dv.RowFilter = str;
                }
                else
                {
                    if (cbLoaiNV.Text == "Giao Hàng")
                    {
                        String str = String.Format("LoaiNV like '%{0}%'", cbLoaiNV.Text);
                        dv.RowFilter = str;
                    }
                    else
                    {
                        if (cbLoaiNV.Text == "Phục Vụ")
                        {
                            String str = String.Format("LoaiNV like '%{0}%'", cbLoaiNV.Text);
                            dv.RowFilter = str;
                        }
                        else
                        {
                            if (cbLoaiNV.Text == "Quản Lý")
                            {
                                String str = String.Format("LoaiNV like '%{0}%'", cbLoaiNV.Text);
                                dv.RowFilter = str;
                            }
                            else
                            {
                                if (cbLoaiNV.Text == "Tạp Vụ")
                                {
                                    String str = String.Format("LoaiNV like '%{0}%'", cbLoaiNV.Text);
                                    dv.RowFilter = str;
                                }
                                else
                                {
                                    if (cbLoaiNV.Text == "Tất Cả")
                                    {
                                        dgvThongTinNV.DataSource = dtQLNhanVien;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }

        private void cbGioiTinh_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMaNV.Clear();
            this.txtTenNV.Clear();
            this.cbLoaiNV.Text = "";
            if(cbGioiTinh.Text=="Nam")
            {
                String str = String.Format("GioiTinh like '%{0}%'", cbGioiTinh.Text);
                dv.RowFilter = str;
            }
            else
            {
                if (cbGioiTinh.Text == "Nữ")
                {
                    String str = String.Format("GioiTinh like '%{0}%'", cbGioiTinh.Text);
                    dv.RowFilter = str;
                }
                else
                {
                    if (cbGioiTinh.Text == "Tất Cả")
                    {
                        dgvThongTinNV.DataSource = dtQLNhanVien;
                    }
                }
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
                String str = String.Format("HoVaTenNV like '%{0}%'", txtTenNV.Text);
                dv.RowFilter = str;
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
                String str = String.Format("MaNV like '%{0}%'", txtMaNV.Text);
                dv.RowFilter = str;
            }
        }

        private void dgvThongTinNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int r = dgvThongTinNV.CurrentCell.RowIndex;
                if (r >= 0)
                {
                    string manv = dgvThongTinNV.CurrentRow.Cells[0].Value.ToString();
                    b = QLNhanVien.LayHinhAnh(manv, ref err);
                    MemoryStream ms = new MemoryStream(b);
                    this.ptbAnhNV.Image = Image.FromStream(ms);
                    ms.Close();

                }
                else
                {
                    MessageBox.Show("Không Xem Được!!!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvThongTinNV.CurrentCell.RowIndex;
                string strThongTin = dgvThongTinNV.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa nhân viên này không?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    QLNhanVien.XoaNhanVien(ref err, strThongTin);

                    LoadData();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            QuanLyThucDon.dem = 0;
            ThemVaCapNhatNhanVien t = new ThemVaCapNhatNhanVien(null,null,null,null,null,null,null,null,null,null);
            t.Show();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            QuanLyThucDon.dem = 1;
            try
            {
                int r;
                r = dgvThongTinNV.CurrentCell.RowIndex;
                if (r >= 0)
                {
                    //    byte[] HinhAnh = null;
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
                        //  HinhAnh = (byte[])dgvThongTinMon.Rows[r].Cells[4].Value;
                        QuanLyThucDon.k = 1;
                    }
                    else
                       QuanLyThucDon.k = 0;

                    ThemVaCapNhatNhanVien capnhat = new ThemVaCapNhatNhanVien(MaNV, TenNV, Tuoi, DiaChi,SDT,GioiTinh,LoaiNV,LuongCB,CaLV,b);
                    capnhat.Show();
                }
                else
                {
                    MessageBox.Show("Chưa Chọn Món Cần Cập Nhật!!!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không Được. Lỗi rồi!!!");
            }
        }
    }
}
