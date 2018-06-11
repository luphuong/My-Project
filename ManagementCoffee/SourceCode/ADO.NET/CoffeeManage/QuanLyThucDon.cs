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
    public partial class QuanLyThucDon : Form
    {
        public static int dem;
        public static int k;
        DataTable dtQLThucDon = null;
        DataView dv;
        byte[] b;
        string err;
        LopXuLyDuLieu.QuanLyThucDon dsThucDon = new LopXuLyDuLieu.QuanLyThucDon();
        

        public QuanLyThucDon()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dtQLThucDon = new DataTable();
                dtQLThucDon.Clear();

                DataSet ds = dsThucDon.LayThucDon();
                dtQLThucDon = ds.Tables[0];
                dv = new DataView(dtQLThucDon);

                dgvThongTinMon.DataSource = dv;

                dgvThongTinMon.AutoResizeColumns();

                
            }
            catch(SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong bạng.Lỗi rồi!!!!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LoadData();
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

        private void QuanLyThucDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managementCoffeeDataSet.ThucDon' table. You can move, or remove it, as needed.
        //    this.thucDonTableAdapter.Fill(this.managementCoffeeDataSet.ThucDon);
            // TODO: This line of code loads data into the 'managementCoffeeDataSet.HoaDon' table. You can move, or remove it, as needed.
          //  this.hoaDonTableAdapter.Fill(this.managementCoffeeDataSet.HoaDon);
            LoadData();
        }

        
        private void cbTheLoai_TextChanged(object sender, EventArgs e)
        {
            LoadData();
            this.txtMa.Clear();
            this.txtTenMon.Clear();
            //LỌC THEO THỂ LOẠI MÓN ĂN
            if (cbTheLoai.Text == "Bánh")
            {
                String str = String.Format("TheLoai like '%{0}%'", cbTheLoai.Text);
                dv.RowFilter = str;
            }
            else
            {
                if (cbTheLoai.Text == "Cafe")
                {
                    String str = String.Format("TheLoai like '%{0}%'", cbTheLoai.Text);
                    dv.RowFilter = str;
                }
                else
                {
                    if (cbTheLoai.Text == "Khác")
                    {
                        String str = String.Format("TheLoai like '%{0}%'", cbTheLoai.Text);
                        dv.RowFilter = str;
                    }
                    else
                    {
                        if (cbTheLoai.Text == "Tất Cả")
                        {
                            dgvThongTinMon.DataSource = dtQLThucDon;
                        }
                    }
                }
            }
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
                String str = String.Format("MaMon like '%{0}%'", txtMa.Text);
                dv.RowFilter = str;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dem = 0;
            ThemVaCapNhatMon t = new ThemVaCapNhatMon(null,null,null,null,null);
            t.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvThongTinMon.CurrentCell.RowIndex;
                string strThongTin = dgvThongTinMon.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi;
                traloi = MessageBox.Show("Chắc xóa món này không?", "Trả Lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(traloi==DialogResult.Yes)
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
            catch(SqlException)
            {
                MessageBox.Show("Không xóa được.Lỗi rồi!!!");
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
                String str = String.Format("TenMon like '%{0}%'", txtTenMon.Text);
                dv.RowFilter = str;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            dem = 1;
            try
            {
                int r; 
                    r= dgvThongTinMon.CurrentCell.RowIndex;
                if (r >=0)
                {
                //    byte[] HinhAnh = null;
                    string MaMon = dgvThongTinMon.Rows[r].Cells[0].Value.ToString();
                    string TenMon = dgvThongTinMon.Rows[r].Cells[1].Value.ToString();
                    string TheLoai = dgvThongTinMon.Rows[r].Cells[3].Value.ToString();
                    string GiaMon = dgvThongTinMon.Rows[r].Cells[2].Value.ToString();
                    //  string ha = dgvThongTinMon.Rows[r].Cells[4].Value.ToString();
                    if (b!=null)
                    {
                      //  HinhAnh = (byte[])dgvThongTinMon.Rows[r].Cells[4].Value;
                        k = 1;
                    }
                    else
                        k = 0;

                    ThemVaCapNhatMon capnhat = new ThemVaCapNhatMon(MaMon, TenMon, TheLoai, GiaMon, b);
                    capnhat.Show();
                }
                else
                {
                    MessageBox.Show("Chưa Chọn Món Cần Cập Nhật!!!");
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Không Được. Lỗi rồi!!!");
            }
        }

        private void dgvThongTinMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int r= dgvThongTinMon.CurrentCell.RowIndex; 
                if (r>=0)
                {
                    string mamon = dgvThongTinMon.CurrentRow.Cells[0].Value.ToString();
                     b= dsThucDon.LayHinhAnh(mamon,ref err);
                    // byte[] b = (byte[])dgvThongTinMon.Rows[r].Cells[4].Value;
                   MemoryStream ms = new MemoryStream(b);
                    this.ptbAnhMon.Image = Image.FromStream(ms);
                    ms.Close();
                 
                }
                else
                {
                    MessageBox.Show("Không Xem Được!!!");
                }
            }
        }

        private void ptbAnhMon_Click(object sender, EventArgs e)
        {

        }
    }
}
