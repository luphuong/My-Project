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
    public partial class ThemVaCapNhatNhanVien : Form
    {
        string err;
        public string img = "";

        byte[] bytes = null;
        string manv, tennv, tuoi, diachi, sdt, gioitinh, loainv, luong, calv;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                this.Close();
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
                Coffee.XuLyNhanVien x = new Coffee.XuLyNhanVien();
                x.CapNhatNV(txtMaNhanVien.Text, txtTenNhanVien.Text, txtTuoi.Text, txtDiaChi.Text, txtSDT.Text, cbGioiTinh.Text, cbLoaiNhanVien.Text, txtLuong.Text, txtCaLV.Text, b, ref err);
                MessageBox.Show("Đã Cập Nhật Xong!!!");
            }
            catch 
            {
                MessageBox.Show("Lỗi Rồi!!!");
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (img.Length > 1)
                {
                    XuLyNhanVien x = new XuLyNhanVien();
                    x.ThemNV(txtMaNhanVien.Text, txtTenNhanVien.Text, txtTuoi.Text, txtDiaChi.Text, txtSDT.Text, cbGioiTinh.Text, cbLoaiNhanVien.Text, txtLuong.Text, txtCaLV.Text, bytes, ref err);
                    MessageBox.Show("Đã Thêm Xong!!!");
                }
                else
                    MessageBox.Show("Thiếu Ảnh");
            }
            catch 
            {
                MessageBox.Show("Lỗi rồi !!!");
            }
        }
    

        public ThemVaCapNhatNhanVien(string MaNV, string TenNV, string Tuoi, string DiaChi, string SDT, string GioiTinh, string LoaiNV, string Luong, string CaLV, byte[] HinhAnh)
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

            if (QuanLyNhanVien.dem == 0)
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
                if (QuanLyNhanVien.k == 1)
                {
                    MemoryStream ms = new MemoryStream(bytes);
                    this.ptAnh.Image = Image.FromStream(ms);
                }
                txtMaNhanVien.Text = manv;
                int mm = int.Parse(manv);
                switch (mm)
                {
                    case 1:
                        ptAnh.Image = Properties.Resources.Vision;
                        break;
                    case 2:
                        ptAnh.Image = Properties.Resources.CapWo;
                        break;
                    case 3:
                        ptAnh.Image = Properties.Resources.Wol;
                        break;
                    case 4:
                        ptAnh.Image = Properties.Resources.Hulk;
                        break;
                    case 5:
                        ptAnh.Image = Properties.Resources.Stark;
                        break;
                    case 6:
                        ptAnh.Image = Properties.Resources.BlackPan;
                        break;
                    case 7:
                        ptAnh.Image = Properties.Resources.BlackWin;
                        break;
                    case 8:
                        ptAnh.Image = Properties.Resources.Thanos;
                        break;
                    case 9:
                        ptAnh.Image = Properties.Resources.Captain;
                        break;
                    default:
                        ptAnh.Image = Properties.Resources.Thor;
                        break;

                }
                this.btnThem.Enabled = false;
                this.btnCapNhat.Enabled = true;
            }
        }
        private void ThemVaCapNhatNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
