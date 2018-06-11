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
using Microsoft.Reporting.WinForms;


namespace CoffeeManage
{
    public partial class frmReportHD : Form
    {
        public frmReportHD()
        {
            InitializeComponent();
        }

        KetNoi db = new KetNoi();
        ManagementCoffeeDataSet1 dts = new ManagementCoffeeDataSet1();

        private void frmReportHD_Load(object sender, EventArgs e)
        {

          //  TODO: This line of code loads data into the 'ManagementCoffeeDataSet1.ReportHD' table.You can move, or remove it, as needed.
          //rpHoaDon.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
          //  rpHoaDon.LocalReport.ReportPath = "rpHoaDon.rdlc";

          //  string sql = "SELECT HoaDon.MaHD, HoaDon.LoaiHD, HoaDon.TenNV, HoaDon.TenKH, HoaDon.Ngay, HoaDon.ThanhTien, MonDaChon.MaMon, MonDaChon.TenMon, MonDaChon.GiaMon FROM HoaDon INNER JOIN MonDaChon ON HoaDon.MaHD = MonDaChon.MaHD INNER JOIN ThucDon ON MonDaChon.MaMon = ThucDon.MaMon Where HoaDon.MaHD=5";
          //  db.ExecuteQueryDataSet(sql, CommandType.Text) as DataSet;

          //  ReportDataSource rds = new ReportDataSource();
          //  rds.Name = "DataSetHoaDon";
          //  rds.Value = dts.Tables[0];
          //  rpHoaDon.LocalReport.DataSources.Add(rds);
          //  //Refresh lại báo cáo
          //  rpHoaDon.RefreshReport();

            this.ReportHDTableAdapter.Fill(this.ManagementCoffeeDataSet1.ReportHD);

            this.rpHoaDon.RefreshReport();
        }
    }
}
