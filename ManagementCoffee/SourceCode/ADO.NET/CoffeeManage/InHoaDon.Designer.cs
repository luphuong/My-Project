namespace CoffeeManage
{
    partial class InHoaDon
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
            this.inHoaDonBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.ManagementCoffeeDataSet1 = new CoffeeManage.ManagementCoffeeDataSet1();
            this.inHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportHDTableAdapter = new CoffeeManage.ManagementCoffeeDataSet1TableAdapters.ReportHDTableAdapter();
            this.inHoaDonTableAdapter = new CoffeeManage.ManagementCoffeeDataSet1TableAdapters.InHoaDonTableAdapter();
            this.inHoaDonBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inHoaDonBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManagementCoffeeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inHoaDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inHoaDonBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // inHoaDonBindingSource2
            // 
            this.inHoaDonBindingSource2.DataMember = "InHoaDon";
            this.inHoaDonBindingSource2.DataSource = this.ManagementCoffeeDataSet1;
            // 
            // ManagementCoffeeDataSet1
            // 
            this.ManagementCoffeeDataSet1.DataSetName = "ManagementCoffeeDataSet1";
            this.ManagementCoffeeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inHoaDonBindingSource
            // 
            this.inHoaDonBindingSource.DataMember = "InHoaDon";
            this.inHoaDonBindingSource.DataSource = this.ManagementCoffeeDataSet1;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "InHoaDon";
            reportDataSource1.Value = this.inHoaDonBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CoffeeManage.rpInHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1441, 670);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReportHDBindingSource
            // 
            this.ReportHDBindingSource.DataMember = "ReportHD";
            this.ReportHDBindingSource.DataSource = this.ManagementCoffeeDataSet1;
            // 
            // ReportHDTableAdapter
            // 
            this.ReportHDTableAdapter.ClearBeforeFill = true;
            // 
            // inHoaDonTableAdapter
            // 
            this.inHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // inHoaDonBindingSource1
            // 
            this.inHoaDonBindingSource1.DataMember = "InHoaDon";
            this.inHoaDonBindingSource1.DataSource = this.ManagementCoffeeDataSet1;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(12, 134);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(132, 51);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // InHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 684);
            this.ControlBox = false;
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.reportViewer1);
            this.Name = "InHoaDon";
            this.Text = "InHoaDon";
            this.Load += new System.EventHandler(this.InHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inHoaDonBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManagementCoffeeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inHoaDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inHoaDonBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReportHDBindingSource;
        private ManagementCoffeeDataSet1 ManagementCoffeeDataSet1;
        private ManagementCoffeeDataSet1TableAdapters.ReportHDTableAdapter ReportHDTableAdapter;
        private System.Windows.Forms.BindingSource inHoaDonBindingSource;
        private ManagementCoffeeDataSet1TableAdapters.InHoaDonTableAdapter inHoaDonTableAdapter;
        private System.Windows.Forms.BindingSource inHoaDonBindingSource1;
        private System.Windows.Forms.BindingSource inHoaDonBindingSource2;
        private System.Windows.Forms.Button btnThoat;
    }
}