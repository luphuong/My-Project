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
    public partial class ThemVaCapNhatMon : Form
    {
        string err;
        public string img = "";
        string ma, ten, loai, gia;
        byte[] bytes = null;
        public ThemVaCapNhatMon(string MaMon,string TenMon,string Loai,string Gia,byte[] Anh)
        {
            InitializeComponent();
            ma = MaMon;
            ten = TenMon;
            loai = Loai;
            gia = Gia;
            bytes = Anh;
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
                this.txtMaMon.Text = ma;
                this.txtTenMon.Text = ten;
                this.txtGia.Text = gia;
                this.cbLoai.Text = loai;

                if (QuanLyThucDon.k == 1)
                {
                    MemoryStream ms = new MemoryStream(bytes);
                    this.ptbAnh.Image = Image.FromStream(ms);
                }
                this.btnThem.Enabled = false;
                this.btnCapNhat.Enabled = true;
                this.txtMaMon.ReadOnly = true;
            }
        }
        private void ThemMon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                ptbAnh.Image.Save(ms, ptbAnh.Image.RawFormat);
                byte[] b = ms.GetBuffer();
                ms.Close();
                LopXuLyDuLieu.QuanLyThucDon x = new LopXuLyDuLieu.QuanLyThucDon();
                x.CapNhatMon(txtMaMon.Text, txtTenMon.Text, cbLoai.Text, txtGia.Text, b, ref err);
                MessageBox.Show("Đã Cập Nhật Xong!!!");
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi Rồi!!!");
            }
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
                if (img.Length>1)
                {
                    LopXuLyDuLieu.QuanLyThucDon x = new LopXuLyDuLieu.QuanLyThucDon();
                    x.ThemMon(txtMaMon.Text, txtTenMon.Text, cbLoai.Text, txtGia.Text, bytes, ref err);
                    MessageBox.Show("Đã Thêm Xong!!!");
                }
                else
                    MessageBox.Show("Thiếu Ảnh");
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi rồi !!!");
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
                    ptbAnh.Image = Image.FromStream(ms);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

       
    }
}
