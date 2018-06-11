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
    public partial class QuanLyThucDon : Form
    {
        int mamon;
        public static int dem;
        public static int k;
        DataTable dtQLThucDon;
        DataView dv;
        byte[] b;
        string err;
        XuLyThucDon dsThucDon = new XuLyThucDon();
        public QuanLyThucDon()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                
                dtQLThucDon = dsThucDon.LayThucDon();

                dv = new DataView(dtQLThucDon);

                dgvThongTinMon.DataSource = dv;
                dgvThongTinMon.AutoResizeColumns();
                

            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong bảng.Lỗi rồi!!!!");
            }
            
        }

        private void QuanLyThucDon_Load(object sender, EventArgs e)
        {
            
            LoadData();
        }

        private void dgvThongTinMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.RowIndex>=0)
            {
                int r = dgvThongTinMon.CurrentCell.RowIndex;
                if (r >= 0)
                {
                    mamon = int.Parse(dgvThongTinMon.Rows[r].Cells[0].Value.ToString());
  
                    //textBox1.Text = mamon;
                }
                else
                    MessageBox.Show("Chua Chon mon");
            }
            switch (mamon)
            {
                case 4:
                    ptbAnhMon.Image = Properties.Resources.CafeSuaDa;
                    break;
                case 9:
                    ptbAnhMon.Image = Properties.Resources.SinhToDau;
                    break;
                case 1:
                    ptbAnhMon.Image = Properties.Resources.PhoMaiQue;
                    break;
                case 2:
                    ptbAnhMon.Image = Properties.Resources.Pudding;
                    break;
                case 3:
                    ptbAnhMon.Image = Properties.Resources.BongLan;
                    break;
                case 5:
                    ptbAnhMon.Image = Properties.Resources.CafeDen;
                    break;
                case 6:
                    ptbAnhMon.Image = Properties.Resources.CaCao;
                    break;
                case 7:
                    ptbAnhMon.Image = Properties.Resources.CafeKem;
                    break;
                case 8:
                    ptbAnhMon.Image = Properties.Resources.NuocCam;
                    break;
                default:
                    ptbAnhMon.Image = Properties.Resources.BanhCrepe_;
                    break;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dem = 0;
            ThemVaCapNhapMon t = new ThemVaCapNhapMon(null, null, null, null, null);
            t.Show();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            dem = 1;
            try
            {
                int r;
                r = dgvThongTinMon.CurrentCell.RowIndex;
                if (r >= 0)
                {
                    string MaMon = dgvThongTinMon.Rows[r].Cells[0].Value.ToString();
                    string TenMon = dgvThongTinMon.Rows[r].Cells[1].Value.ToString();
                    string TheLoai = dgvThongTinMon.Rows[r].Cells[3].Value.ToString();
                    string GiaMon = dgvThongTinMon.Rows[r].Cells[2].Value.ToString();
                    if (b != null)
                    {
                        k = 1;
                    }
                    else
                        k = 0;

                    ThemVaCapNhapMon capnhat = new ThemVaCapNhapMon(MaMon, TenMon, TheLoai, GiaMon, b);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvThongTinMon.CurrentCell.RowIndex;
                string strThongTin = dgvThongTinMon.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa món này không?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    dsThucDon.XoaMon(ref err, strThongTin);

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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMa.ResetText();
            txtTenMon.ResetText();
            cbTheLoai.ResetText();

            LoadData();
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtTenMon.Clear();
            this.cbTheLoai.Text = "";
            if (txtMa.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("MãMón like '%{0}%'", txtMa.Text);
               dv.RowFilter = str;
            }
        }

        private void txtTenMon_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMa.Clear();
            this.cbTheLoai.Text = "";
            if (txtTenMon.Text == "")
            {
                dv.RowFilter = "";
            }
            else
            {
                String str = String.Format("TênMón like '%{0}%'", txtTenMon.Text);
                dv.RowFilter = str;
            }
        }

        private void dgvThongTinMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void cbTheLoai_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMa.Clear();
            this.txtTenMon.Clear();
            if (cbTheLoai.Text == "Bánh")
            {
                String str = String.Format("ThểLoại like '%{0}%'", cbTheLoai.Text);
                dv.RowFilter = str;
            }
            if (cbTheLoai.Text == "Cafe")
            {
                String str = String.Format("ThểLoại like '%{0}%'", cbTheLoai.Text);
                dv.RowFilter = str;
            }
            if (cbTheLoai.Text == "Khác")
            {
                String str = String.Format("ThểLoại like '%{0}%'", cbTheLoai.Text);
                dv.RowFilter = str;
            }
            if (cbTheLoai.Text == "Tất Cả")
            {
                dgvThongTinMon.DataSource = dtQLThucDon;
            }
                    
                
            
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
    }
}
