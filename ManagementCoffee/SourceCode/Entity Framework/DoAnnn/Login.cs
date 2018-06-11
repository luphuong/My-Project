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
    public partial class Login : Form
    {
        DataTable dtLogin = null;
        XuLyTaiKhoan tk = new XuLyTaiKhoan();
        DataView dv;
        string err;
        public Login()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dtLogin = tk.KiemTraTaiKhoan();
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("Tài Khoản không được bỏ trống!!!");
                }
                else
                {
                    if (txtPassWord.Text == "")
                    {
                        MessageBox.Show("Mật Khẩu không được bỏ trống !!!!");
                    }
                    else
                    {
                        bool co = false;
                        for (int i = 0; i < dtLogin.Rows.Count; i++)
                        {
                            if (txtUserName.Text == dtLogin.Rows[i][0].ToString() && txtPassWord.Text == dtLogin.Rows[i][1].ToString())
                            {
                                if (i == 0)
                                {
                                    Choose c = new Choose();
                                    c.Show();
                                    co = true;
                                }
                                else
                                {
                                    BanHang b = new BanHang();
                                    b.Show();
                                    co = true;
                                }
                                this.Hide();
                            }
                        }
                        if (co == false)
                        {
                            MessageBox.Show("Tài Khoản hoặc Mật Khẩu Không Đúng!!!");
                        }
                    }
                }

            }
            catch 
            {
                MessageBox.Show("Không lấy được nội dung trong bảng.Lỗi rồi!!!!");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.label9.Text = DateTime.Now.ToLongDateString();
            this.label10.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            this.label10.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
