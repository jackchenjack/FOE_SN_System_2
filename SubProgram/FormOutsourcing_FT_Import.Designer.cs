
namespace FormSN_System.SubProgram
{
    partial class FormOutsourcing_FT_Import
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgView1 = new System.Windows.Forms.DataGridView();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRead_File = new System.Windows.Forms.Button();
            this.btnDataPaste = new System.Windows.Forms.Button();
            this.btnFT_Import = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.txtVolt = new System.Windows.Forms.TextBox();
            this.txtCH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.chbQSFP = new System.Windows.Forms.CheckBox();
            this.btn_ClearData = new System.Windows.Forms.Button();
            this.chbOverWrite_DB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgView1.Location = new System.Drawing.Point(43, 258);
            this.dgView1.Name = "dgView1";
            this.dgView1.RowHeadersWidth = 51;
            this.dgView1.RowTemplate.Height = 24;
            this.dgView1.Size = new System.Drawing.Size(907, 377);
            this.dgView1.TabIndex = 0;
            // 
            // cbCustomer
            // 
            this.cbCustomer.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Items.AddRange(new object[] {
            "Model1",
            "Model2"});
            this.cbCustomer.Location = new System.Drawing.Point(154, 117);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(175, 35);
            this.cbCustomer.TabIndex = 1;
            this.cbCustomer.SelectedValueChanged += new System.EventHandler(this.cbCustomer_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(310, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "外購終測資料匯入系統";
            // 
            // btnRead_File
            // 
            this.btnRead_File.Enabled = false;
            this.btnRead_File.Font = new System.Drawing.Font("新細明體", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRead_File.Location = new System.Drawing.Point(789, 179);
            this.btnRead_File.Name = "btnRead_File";
            this.btnRead_File.Size = new System.Drawing.Size(161, 53);
            this.btnRead_File.TabIndex = 3;
            this.btnRead_File.Text = "讀取檔案";
            this.btnRead_File.UseVisualStyleBackColor = true;
            this.btnRead_File.Visible = false;
            this.btnRead_File.Click += new System.EventHandler(this.btnRead_File_Click);
            // 
            // btnDataPaste
            // 
            this.btnDataPaste.Enabled = false;
            this.btnDataPaste.Font = new System.Drawing.Font("新細明體", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDataPaste.Location = new System.Drawing.Point(589, 117);
            this.btnDataPaste.Name = "btnDataPaste";
            this.btnDataPaste.Size = new System.Drawing.Size(175, 53);
            this.btnDataPaste.TabIndex = 3;
            this.btnDataPaste.Text = "貼上資料";
            this.btnDataPaste.UseVisualStyleBackColor = true;
            this.btnDataPaste.Click += new System.EventHandler(this.btnDataPaste_Click);
            // 
            // btnFT_Import
            // 
            this.btnFT_Import.Enabled = false;
            this.btnFT_Import.Font = new System.Drawing.Font("新細明體", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnFT_Import.Location = new System.Drawing.Point(789, 117);
            this.btnFT_Import.Name = "btnFT_Import";
            this.btnFT_Import.Size = new System.Drawing.Size(161, 52);
            this.btnFT_Import.TabIndex = 3;
            this.btnFT_Import.Text = "匯入資料庫";
            this.btnFT_Import.UseVisualStyleBackColor = true;
            this.btnFT_Import.Click += new System.EventHandler(this.btnFT_Import_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(68, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lot No.";
            // 
            // txtLotNo
            // 
            this.txtLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLotNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLotNo.Location = new System.Drawing.Point(154, 164);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(175, 29);
            this.txtLotNo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(38, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Model No.";
            // 
            // txtModelNo
            // 
            this.txtModelNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtModelNo.Location = new System.Drawing.Point(154, 204);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(175, 29);
            this.txtModelNo.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(56, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "資料格式";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(384, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 27);
            this.label5.TabIndex = 4;
            this.label5.Text = "溫度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(383, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 27);
            this.label6.TabIndex = 4;
            this.label6.Text = "電壓";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(1164, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 27);
            this.label7.TabIndex = 4;
            this.label7.Text = "CH";
            // 
            // txtTemp
            // 
            this.txtTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTemp.Location = new System.Drawing.Point(440, 117);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(125, 29);
            this.txtTemp.TabIndex = 5;
            this.txtTemp.Text = "25";
            // 
            // txtVolt
            // 
            this.txtVolt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVolt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVolt.Location = new System.Drawing.Point(440, 162);
            this.txtVolt.Name = "txtVolt";
            this.txtVolt.Size = new System.Drawing.Size(125, 29);
            this.txtVolt.TabIndex = 5;
            this.txtVolt.Text = "3.3";
            // 
            // txtCH
            // 
            this.txtCH.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCH.Location = new System.Drawing.Point(1212, 140);
            this.txtCH.Name = "txtCH";
            this.txtCH.Size = new System.Drawing.Size(88, 29);
            this.txtCH.TabIndex = 5;
            this.txtCH.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(342, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 27);
            this.label8.TabIndex = 4;
            this.label8.Text = "外購廠商";
            // 
            // txtCustomer
            // 
            this.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(440, 203);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(125, 29);
            this.txtCustomer.TabIndex = 5;
            // 
            // chbQSFP
            // 
            this.chbQSFP.AutoSize = true;
            this.chbQSFP.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chbQSFP.Location = new System.Drawing.Point(1169, 199);
            this.chbQSFP.Margin = new System.Windows.Forms.Padding(2);
            this.chbQSFP.Name = "chbQSFP";
            this.chbQSFP.Size = new System.Drawing.Size(87, 32);
            this.chbQSFP.TabIndex = 6;
            this.chbQSFP.Text = "QSFP";
            this.chbQSFP.UseVisualStyleBackColor = true;
            // 
            // btn_ClearData
            // 
            this.btn_ClearData.Enabled = false;
            this.btn_ClearData.Font = new System.Drawing.Font("新細明體", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_ClearData.Location = new System.Drawing.Point(589, 180);
            this.btn_ClearData.Name = "btn_ClearData";
            this.btn_ClearData.Size = new System.Drawing.Size(175, 53);
            this.btn_ClearData.TabIndex = 3;
            this.btn_ClearData.Text = "清除資料";
            this.btn_ClearData.UseVisualStyleBackColor = true;
            this.btn_ClearData.Click += new System.EventHandler(this.btn_ClearData_Click);
            // 
            // chbOverWrite_DB
            // 
            this.chbOverWrite_DB.AutoSize = true;
            this.chbOverWrite_DB.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chbOverWrite_DB.Location = new System.Drawing.Point(826, 78);
            this.chbOverWrite_DB.Name = "chbOverWrite_DB";
            this.chbOverWrite_DB.Size = new System.Drawing.Size(124, 24);
            this.chbOverWrite_DB.TabIndex = 7;
            this.chbOverWrite_DB.Text = "相同資料覆蓋";
            this.chbOverWrite_DB.UseVisualStyleBackColor = true;
            // 
            // FormOutsourcing_FT_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 662);
            this.Controls.Add(this.chbOverWrite_DB);
            this.Controls.Add(this.chbQSFP);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.txtCH);
            this.Controls.Add(this.txtVolt);
            this.Controls.Add(this.txtTemp);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFT_Import);
            this.Controls.Add(this.btn_ClearData);
            this.Controls.Add(this.btnDataPaste);
            this.Controls.Add(this.btnRead_File);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.dgView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormOutsourcing_FT_Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOutsourcing_FT_Import";
            this.Load += new System.EventHandler(this.FormOutsourcing_FT_Import_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgView1;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRead_File;
        private System.Windows.Forms.Button btnDataPaste;
        private System.Windows.Forms.Button btnFT_Import;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.TextBox txtVolt;
        private System.Windows.Forms.TextBox txtCH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.CheckBox chbQSFP;
        private System.Windows.Forms.Button btn_ClearData;
        private System.Windows.Forms.CheckBox chbOverWrite_DB;
    }
}