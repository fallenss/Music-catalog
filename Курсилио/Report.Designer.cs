
namespace Курсилио
{
    partial class Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.View_1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Клубная_музыкаDataSet = new Курсилио.Клубная_музыкаDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.View_1TableAdapter = new Курсилио.Клубная_музыкаDataSetTableAdapters.View_1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Клубная_музыкаDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // View_1BindingSource
            // 
            this.View_1BindingSource.DataMember = "View_1";
            this.View_1BindingSource.DataSource = this.Клубная_музыкаDataSet;
            // 
            // Клубная_музыкаDataSet
            // 
            this.Клубная_музыкаDataSet.DataSetName = "Клубная_музыкаDataSet";
            this.Клубная_музыкаDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.View_1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Курсилио.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1108, 554);
            this.reportViewer1.TabIndex = 0;
            // 
            // View_1TableAdapter
            // 
            this.View_1TableAdapter.ClearBeforeFill = true;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 554);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Report";
            this.Text = "Отчёт по жанрам";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Клубная_музыкаDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource View_1BindingSource;
        private Клубная_музыкаDataSet Клубная_музыкаDataSet;
        private Клубная_музыкаDataSetTableAdapters.View_1TableAdapter View_1TableAdapter;
    }
}