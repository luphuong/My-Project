using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeManage.LopDuLieu;

namespace CoffeeManage
{
    public partial class InHoaDon : Form
    {
        public InHoaDon()
        {
            InitializeComponent();
        }
        KetNoi db = new KetNoi();
        ManagementCoffeeDataSet1 dts = new ManagementCoffeeDataSet1();
        private void InHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ManagementCoffeeDataSet1.InHoaDon' table. You can move, or remove it, as needed.
            this.inHoaDonTableAdapter.Fill(this.ManagementCoffeeDataSet1.InHoaDon);

            this.reportViewer1.RefreshReport();
          //  this.reportViewer2.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn thực sự muốn thoát?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
