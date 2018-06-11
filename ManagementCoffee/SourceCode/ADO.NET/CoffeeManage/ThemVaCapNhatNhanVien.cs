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

namespace CoffeeManage
{
    public partial class ThemVaCapNhatNhanVien : Form
    {
        string err;
        public string img = "";

        byte[] bytes = null;
        string manv, tennv, tuoi, diachi, sdt, gioitinh, loainv, luong, calv;


        public ThemVaCapNhatNhanVien(string MaNV,string TenNV,string Tuoi,string DiaChi,string SDT,string GioiTinh,string LoaiNV,string Luong,string CaLV,byte[] HinhAnh)
        {
            InitializeComponent();
            manv = MaNV;
            tennv = TenNV;
            tuoi = Tuoi;
            diachi = DiaChi;
            sdt = SDT;
            gioitinh = GioiTinh;
            loainv = LoaiNV;
            luong = Luong;
            calv = CaLV;
            bytes = HinhAnh;
        }

        public void LoadData()
        {

            if (QuanLyThucDon.dem == 0)
            {
                this.btnCapNhat.Enabled = false;
                this.btnThem.Enabled = true;
            }
            else
            {
                this.txtMaNhanVien.Text = manv;
                this.txtTenNhanVien.Text = tennv;
                this.txtTuoi.Text = tuoi;
                this.txtDiaChi.Text = diachi;
                this.txtSDT.Text = sdt;
                this.cbGioiTinh.Text = gioitinh;
                this.cbLoaiNhanVien.Text = loainv;
                this.txtLuong.Text = luong;
                this.txtCaLV.Text = calv;
                if (QuanLyThucDon.k == 1)
                {
                    MemoryStream ms = new MemoryStream(bytes);
                    this.ptAnh.Image = Image.FromStream(ms);
                }
                this.btnThem.Enabled = false;
                this.btnCapNhat.Enabled = true;
                this.txtMaNhanVien.ReadOnly = true;
            }
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog opd = new OpenFileDialog();
                opd.DefaultExt = ".jpg";
                opd.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|ALL Files (*.*)|*.*";
                opd.Title = "Select ThucDon Piture";
                if (opd.ShowDialog() == DialogResult.OK)
                {
                    img = opd.FileName;
                    bytes = File.ReadAllBytes(img);
                    MemoryStream ms = new MemoryStream(bytes);
                    ptAnh.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThemVaCapNhatNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (img.Length > 1)
                {
                    LopXuLyDuLieu.QuanLyNhanVien x = new LopXuLyDuLieu.QuanLyNhanVien();
                    x.ThemNhanVien(txtMaNhanVien.Text, txtTenNhanVien.Text, txtTuoi.Text, txtDiaChi.Text,txtSDT.Text,cbGioiTinh.Text,cbLoaiNhanVien.Text,txtLuong.Text,txtCaLV.Text,bytes, ref err);
                    MessageBox.Show("Đã Thêm Xong!!!");
                }
                else
                    MessageBox.Show("Thiếu Ảnh");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi !!!");
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                ptAnh.Image.Save(ms, ptAnh.Image.RawFormat);
                byte[] b = ms.GetBuffer();
                ms.Close();
                LopXuLyDuLieu.QuanLyNhanVien x = new LopXuLyDuLieu.QuanLyNhanVien();
                x.CapNhatNhanVien(txtMaNhanVien.Text, txtTenNhanVien.Text, txtTuoi.Text, txtDiaChi.Text,txtSDT.Text,cbGioiTinh.Text,cbLoaiNhanVien.Text,txtLuong.Text,txtCaLV.Text, b, ref err);
                MessageBox.Show("Đã Cập Nhật Xong!!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi Rồi!!!");
            }
        }
    }
}
