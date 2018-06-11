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
using System.IO;


namespace DoAnnn
{
    public partial class ThemVaCapNhapMon : Form
    {
        string err;
        public string img = "";
        string ma, ten, loai, gia;
        byte[] bytes = null;
        public ThemVaCapNhapMon(string MaMon, string TenMon, string Loai, string Gia, byte[] Anh)
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

                //if (QuanLyThucDon.k == 1)
                //{
                //    MemoryStream ms = new MemoryStream(bytes);
                //    this.ptbAnh.Image = Image.FromStream(ms);
                //}
                int mmm = int.Parse(ma);

                switch (mmm)
                {
                    case 4:
                        ptbAnh.Image = Properties.Resources.CafeSuaDa;
                        break;
                    case 9:
                        ptbAnh.Image = Properties.Resources.SinhToDau;
                        break;
                    case 1:
                        ptbAnh.Image = Properties.Resources.PhoMaiQue;
                        break;
                    case 2:
                        ptbAnh.Image = Properties.Resources.Pudding;
                        break;
                    case 3:
                        ptbAnh.Image = Properties.Resources.BongLan;
                        break;
                    case 5:
                        ptbAnh.Image = Properties.Resources.CafeDen;
                        break;
                    case 6:
                        ptbAnh.Image = Properties.Resources.CaCao;
                        break;
                    case 7:
                        ptbAnh.Image = Properties.Resources.CafeKem;
                        break;
                    case 8:
                        ptbAnh.Image = Properties.Resources.NuocCam;
                        break;
                    default:
                        ptbAnh.Image = Properties.Resources.BanhCrepe_;
                        break;

                }
                this.btnThem.Enabled = false;
                this.btnCapNhat.Enabled = true;
            }
            //    string sss = ma.ToString();
        }
        private void ThemVaCapNhapMon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (img.Length > 1)
                {
                    Coffee.XuLyThucDon x = new Coffee.XuLyThucDon();
                    x.ThemMon(txtMaMon.Text, txtTenMon.Text, txtGia.Text, cbLoai.Text, bytes, ref err);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                ptbAnh.Image.Save(ms, ptbAnh.Image.RawFormat);
                byte[] b = ms.GetBuffer();
                ms.Close();
                Coffee.XuLyThucDon x = new Coffee.XuLyThucDon();
                x.CapNhatMon(txtMaMon.Text, txtTenMon.Text, cbLoai.Text, txtGia.Text, b, ref err);
                MessageBox.Show("Đã Cập Nhật Xong!!!");
            }
            catch
            {
                MessageBox.Show("Lỗi Rồi!!!");
            }
        }

        private void btnAnh_Click_1(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuayLai_Click_1(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }

        

        

        
    }
}
