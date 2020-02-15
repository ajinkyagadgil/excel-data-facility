namespace ExcelImport
{
    partial class ExcelFacilityForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.errorProviderValue = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderFile = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFile)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(572, 82);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(126, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnImportExcelFile_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(122, 82);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(422, 22);
            this.tbFileName.TabIndex = 1;
            this.tbFileName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFileName_Validating);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(122, 126);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(202, 23);
            this.btnImportExcel.TabIndex = 2;
            this.btnImportExcel.Text = "Import";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(34, 46);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(69, 17);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "Set Value";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(122, 43);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(117, 22);
            this.tbValue.TabIndex = 4;
            this.tbValue.Text = "72";
            this.tbValue.Validating += new System.ComponentModel.CancelEventHandler(this.tbValue_Validating);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(30, 88);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(73, 17);
            this.lblFile.TabIndex = 5;
            this.lblFile.Text = "Select File";
            // 
            // errorProviderValue
            // 
            this.errorProviderValue.ContainerControl = this;
            // 
            // errorProviderFile
            // 
            this.errorProviderFile.ContainerControl = this;
            // 
            // ExcelFacilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.btnBrowse);
            this.Name = "ExcelFacilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel Data Facility";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.ErrorProvider errorProviderValue;
        private System.Windows.Forms.ErrorProvider errorProviderFile;
    }
}

