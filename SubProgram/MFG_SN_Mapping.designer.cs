
namespace MFG_SN_Mapping
{
    partial class Sn_Mapping
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txt_MFG_SN1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txt_Ship_SN = new System.Windows.Forms.TextBox();
            this.LMessage = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cb_DB = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.btnLot_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Mode = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete_Enable = new System.Windows.Forms.Button();
            this.btnSorting = new System.Windows.Forms.Button();
            this.cb_SortBy = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.chbOutsource = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txt_MFG_SN2 = new System.Windows.Forms.TextBox();
            this.txtOP = new System.Windows.Forms.TextBox();
            this.btnSN_Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Blue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(29, 276);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(122, 39);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "白牌序號 1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_MFG_SN1
            // 
            this.txt_MFG_SN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MFG_SN1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MFG_SN1.Location = new System.Drawing.Point(158, 276);
            this.txt_MFG_SN1.Name = "txt_MFG_SN1";
            this.txt_MFG_SN1.Size = new System.Drawing.Size(226, 37);
            this.txt_MFG_SN1.TabIndex = 0;
            this.txt_MFG_SN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_MFG_SN1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_MFG_SN1_KeyDown);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Blue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox3.Location = new System.Drawing.Point(29, 367);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(354, 39);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "成品序號";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Ship_SN
            // 
            this.txt_Ship_SN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Ship_SN.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ship_SN.Location = new System.Drawing.Point(29, 416);
            this.txt_Ship_SN.Name = "txt_Ship_SN";
            this.txt_Ship_SN.Size = new System.Drawing.Size(354, 37);
            this.txt_Ship_SN.TabIndex = 1;
            this.txt_Ship_SN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Ship_SN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Ship_SN_KeyDown);
            // 
            // LMessage
            // 
            this.LMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LMessage.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LMessage.Location = new System.Drawing.Point(29, 478);
            this.LMessage.Multiline = true;
            this.LMessage.Name = "LMessage";
            this.LMessage.Size = new System.Drawing.Size(354, 184);
            this.LMessage.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(400, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(565, 524);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView1_SortCompare);
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No.";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 30;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "白牌序號";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "出貨序號";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(867, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 39);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cb_DB
            // 
            this.cb_DB.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_DB.FormattingEnabled = true;
            this.cb_DB.Location = new System.Drawing.Point(158, 104);
            this.cb_DB.Name = "cb_DB";
            this.cb_DB.Size = new System.Drawing.Size(226, 37);
            this.cb_DB.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Blue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox2.Location = new System.Drawing.Point(29, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(122, 39);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "資料庫";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Blue;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox4.Location = new System.Drawing.Point(29, 188);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(122, 39);
            this.textBox4.TabIndex = 0;
            this.textBox4.Text = "Lot No";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLot
            // 
            this.txtLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLot.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLot.Location = new System.Drawing.Point(158, 188);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(226, 37);
            this.txtLot.TabIndex = 0;
            this.txtLot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLot_KeyDown);
            // 
            // btnLot_Search
            // 
            this.btnLot_Search.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnLot_Search.Location = new System.Drawing.Point(400, 101);
            this.btnLot_Search.Name = "btnLot_Search";
            this.btnLot_Search.Size = new System.Drawing.Size(149, 38);
            this.btnLot_Search.TabIndex = 5;
            this.btnLot_Search.Text = "by Lot 搜尋";
            this.btnLot_Search.UseVisualStyleBackColor = true;
            this.btnLot_Search.Click += new System.EventHandler(this.btnLot_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(235, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "FOE(外購) 白牌/出貨序號對應系統";
            // 
            // cb_Mode
            // 
            this.cb_Mode.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Mode.FormattingEnabled = true;
            this.cb_Mode.Items.AddRange(new object[] {
            "1 對 1",
            "2 對 1",
            "2 對 A/B 面",
            "SN搜尋模式"});
            this.cb_Mode.Location = new System.Drawing.Point(158, 233);
            this.cb_Mode.Name = "cb_Mode";
            this.cb_Mode.Size = new System.Drawing.Size(226, 37);
            this.cb_Mode.TabIndex = 4;
            this.cb_Mode.SelectedValueChanged += new System.EventHandler(this.cb_Mode_SelectedIndexChanged);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Blue;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox6.Location = new System.Drawing.Point(29, 233);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(122, 39);
            this.textBox6.TabIndex = 0;
            this.textBox6.Text = "對應模式";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(760, 145);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 39);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete_Enable
            // 
            this.btnDelete_Enable.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete_Enable.Location = new System.Drawing.Point(251, 673);
            this.btnDelete_Enable.Name = "btnDelete_Enable";
            this.btnDelete_Enable.Size = new System.Drawing.Size(132, 39);
            this.btnDelete_Enable.TabIndex = 3;
            this.btnDelete_Enable.Text = "刪除解鎖";
            this.btnDelete_Enable.UseVisualStyleBackColor = true;
            this.btnDelete_Enable.Click += new System.EventHandler(this.btnDelete_Enable_Click);
            // 
            // btnSorting
            // 
            this.btnSorting.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSorting.Location = new System.Drawing.Point(867, 145);
            this.btnSorting.Name = "btnSorting";
            this.btnSorting.Size = new System.Drawing.Size(98, 39);
            this.btnSorting.TabIndex = 3;
            this.btnSorting.Text = "重新排序";
            this.btnSorting.UseVisualStyleBackColor = true;
            this.btnSorting.Click += new System.EventHandler(this.btnSorting_Click);
            // 
            // cb_SortBy
            // 
            this.cb_SortBy.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_SortBy.FormattingEnabled = true;
            this.cb_SortBy.Items.AddRange(new object[] {
            "by 日期",
            "by 出貨序號"});
            this.cb_SortBy.Location = new System.Drawing.Point(400, 146);
            this.cb_SortBy.Name = "cb_SortBy";
            this.cb_SortBy.Size = new System.Drawing.Size(148, 37);
            this.cb_SortBy.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("微軟正黑體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker1.Location = new System.Drawing.Point(555, 146);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 36);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // chbOutsource
            // 
            this.chbOutsource.AutoSize = true;
            this.chbOutsource.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chbOutsource.Location = new System.Drawing.Point(59, 673);
            this.chbOutsource.Name = "chbOutsource";
            this.chbOutsource.Size = new System.Drawing.Size(73, 30);
            this.chbOutsource.TabIndex = 8;
            this.chbOutsource.Text = "外購";
            this.chbOutsource.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Blue;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox5.Location = new System.Drawing.Point(29, 319);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(122, 39);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "白牌序號 2";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_MFG_SN2
            // 
            this.txt_MFG_SN2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MFG_SN2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MFG_SN2.Location = new System.Drawing.Point(158, 319);
            this.txt_MFG_SN2.Name = "txt_MFG_SN2";
            this.txt_MFG_SN2.Size = new System.Drawing.Size(226, 37);
            this.txt_MFG_SN2.TabIndex = 0;
            this.txt_MFG_SN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_MFG_SN2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_MFG_SN2_KeyDown);
            // 
            // txtOP
            // 
            this.txtOP.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOP.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOP.Location = new System.Drawing.Point(4, 29);
            this.txtOP.Name = "txtOP";
            this.txtOP.ReadOnly = true;
            this.txtOP.Size = new System.Drawing.Size(226, 37);
            this.txtOP.TabIndex = 0;
            this.txtOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSN_Search
            // 
            this.btnSN_Search.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSN_Search.Location = new System.Drawing.Point(555, 101);
            this.btnSN_Search.Name = "btnSN_Search";
            this.btnSN_Search.Size = new System.Drawing.Size(149, 38);
            this.btnSN_Search.TabIndex = 5;
            this.btnSN_Search.Text = "by SN 搜尋";
            this.btnSN_Search.UseVisualStyleBackColor = true;
            this.btnSN_Search.Click += new System.EventHandler(this.btnSN_Search_Click);
            // 
            // Sn_Mapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 747);
            this.Controls.Add(this.chbOutsource);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSN_Search);
            this.Controls.Add(this.btnLot_Search);
            this.Controls.Add(this.cb_Mode);
            this.Controls.Add(this.cb_SortBy);
            this.Controls.Add(this.cb_DB);
            this.Controls.Add(this.btnSorting);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete_Enable);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LMessage);
            this.Controls.Add(this.txt_Ship_SN);
            this.Controls.Add(this.txtOP);
            this.Controls.Add(this.txtLot);
            this.Controls.Add(this.txt_MFG_SN2);
            this.Controls.Add(this.txt_MFG_SN1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sn_Mapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "白牌及出貨序號對應";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txt_MFG_SN1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txt_Ship_SN;
        private System.Windows.Forms.TextBox LMessage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cb_DB;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Button btnLot_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Mode;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete_Enable;
        private System.Windows.Forms.Button btnSorting;
        private System.Windows.Forms.ComboBox cb_SortBy;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox chbOutsource;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txt_MFG_SN2;
        private System.Windows.Forms.TextBox txtOP;
        private System.Windows.Forms.Button btnSN_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

