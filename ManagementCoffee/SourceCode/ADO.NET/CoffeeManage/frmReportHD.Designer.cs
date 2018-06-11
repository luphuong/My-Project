namespace CoffeeManage
{
    partial class frmReportHD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ManagementCoffeeDataSet1 = new CoffeeManage.ManagementCoffeeDataSet1();
            this.rpHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportHDTableAdapter = new CoffeeManage.ManagementCoffeeDataSet1TableAdapters.ReportHDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManagementCoffeeDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportHDBindingSource
            // 
            this.ReportHDBindingSource.DataMember = "ReportHD";
            this.ReportHDBindingSource.DataSource = this.ManagementCoffeeDataSet1;
            // 
            // ManagementCoffeeDataSet1
            // 
            this.ManagementCoffeeDataSet1.DataSetName = "ManagementCoffeeDataSet1";
            this.ManagementCoffeeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpHoaDon
            // 
            this.rpHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetHoaDon";
            reportDataSource1.Value = this.ReportHDBindingSource;
            this.rpHoaDon.LocalReport.DataSources.Add(reportDataSource1);
            this.rpHoaDon.LocalReport.ReportEmbeddedResource = "CoffeeManage.rpHoaDon.rdlc";
            this.rpHoaDon.Location = new System.Drawing.Point(0, 0);
            this.rpHoaDon.Name = "rpHoaDon";
            this.rpHoaDon.ServerReport.BearerToken = null;
            this.rpHoaDon.Size = new System.Drawing.Size(800, 617);
            this.rpHoaDon.TabIndex = 0;
            // 
            // ReportHDTableAdapter
            // 
            this.ReportHDTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.ControlBox = false;
            this.Controls.Add(this.rpHoaDon);
            this.Name = "frmReportHD";
            this.Text = "frmReportHD";
            this.Load += new System.EventHandler(this.frmReportHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportHDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManagementCoffeeDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpHoaDon;
        private System.Windows.Forms.BindingSource ReportHDBindingSource;
        private ManagementCoffeeDataSet1 ManagementCoffeeDataSet1;
        private ManagementCoffeeDataSet1TableAdapters.ReportHDTableAdapter ReportHDTableAdapter;
    }
}