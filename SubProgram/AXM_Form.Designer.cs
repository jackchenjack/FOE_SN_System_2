
namespace FormSN_System.SubProgram
{
    partial class AXM_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AXM_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_quantity = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.Label();
            this.Output_btn = new System.Windows.Forms.Button();
            this.Inquire_btn = new System.Windows.Forms.Button();
            this.txt_LotNo = new System.Windows.Forms.TextBox();
            this.LN_AXM = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.chbBuy = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.chbBuy);
            this.groupBox1.Controls.Add(this.txt_quantity);
            this.groupBox1.Controls.Add(this.quantity);
            this.groupBox1.Controls.Add(this.Output_btn);
            this.groupBox1.Controls.Add(this.Inquire_btn);
            this.groupBox1.Controls.Add(this.txt_LotNo);
            this.groupBox1.Controls.Add(this.LN_AXM);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1033, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inquire 💫 Output";
            // 
            // txt_quantity
            // 
            this.txt_quantity.BackColor = System.Drawing.Color.PeachPuff;
            this.txt_quantity.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_quantity.Location = new System.Drawing.Point(426, 75);
            this.txt_quantity.Margin = new System.Windows.Forms.Padding(4);
            this.txt_quantity.Multiline = true;
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.ReadOnly = true;
            this.txt_quantity.Size = new System.Drawing.Size(116, 42);
            this.txt_quantity.TabIndex = 5;
            // 
            // quantity
            // 
            this.quantity.AutoSize = true;
            this.quantity.BackColor = System.Drawing.Color.LemonChiffon;
            this.quantity.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.quantity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.quantity.Location = new System.Drawing.Point(429, 39);
            this.quantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(115, 30);
            this.quantity.TabIndex = 4;
            this.quantity.Text = "數量 👇";
            // 
            // Output_btn
            // 
            this.Output_btn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Output_btn.Image = ((System.Drawing.Image)(resources.GetObject("Output_btn.Image")));
            this.Output_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Output_btn.Location = new System.Drawing.Point(806, 42);
            this.Output_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Output_btn.Name = "Output_btn";
            this.Output_btn.Size = new System.Drawing.Size(167, 65);
            this.Output_btn.TabIndex = 3;
            this.Output_btn.Text = "      匯出";
            this.Output_btn.UseVisualStyleBackColor = true;
            this.Output_btn.Click += new System.EventHandler(this.Export_file_Click);
            // 
            // Inquire_btn
            // 
            this.Inquire_btn.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Inquire_btn.Image = ((System.Drawing.Image)(resources.GetObject("Inquire_btn.Image")));
            this.Inquire_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Inquire_btn.Location = new System.Drawing.Point(598, 41);
            this.Inquire_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Inquire_btn.Name = "Inquire_btn";
            this.Inquire_btn.Size = new System.Drawing.Size(167, 66);
            this.Inquire_btn.TabIndex = 2;
            this.Inquire_btn.Text = "     查詢";
            this.Inquire_btn.UseVisualStyleBackColor = true;
            this.Inquire_btn.Click += new System.EventHandler(this.Check_btn_Click);
            // 
            // txt_LotNo
            // 
            this.txt_LotNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_LotNo.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LotNo.Location = new System.Drawing.Point(115, 76);
            this.txt_LotNo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_LotNo.Multiline = true;
            this.txt_LotNo.Name = "txt_LotNo";
            this.txt_LotNo.Size = new System.Drawing.Size(267, 42);
            this.txt_LotNo.TabIndex = 1;
            this.txt_LotNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // LN_AXM
            // 
            this.LN_AXM.AutoSize = true;
            this.LN_AXM.BackColor = System.Drawing.Color.LemonChiffon;
            this.LN_AXM.Font = new System.Drawing.Font("新細明體", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LN_AXM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LN_AXM.Location = new System.Drawing.Point(117, 39);
            this.LN_AXM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LN_AXM.Name = "LN_AXM";
            this.LN_AXM.Size = new System.Drawing.Size(258, 32);
            this.LN_AXM.TabIndex = 0;
            this.LN_AXM.Text = "請輸入 Lot No 👇";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 172);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(651, 375);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Pink;
            this.label1.Font = new System.Drawing.Font("新細明體", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(753, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "👉 點擊匯出❤";
            // 
            // chbBuy
            // 
            this.chbBuy.AutoSize = true;
            this.chbBuy.Checked = true;
            this.chbBuy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbBuy.Location = new System.Drawing.Point(14, 80);
            this.chbBuy.Name = "chbBuy";
            this.chbBuy.Size = new System.Drawing.Size(85, 33);
            this.chbBuy.TabIndex = 6;
            this.chbBuy.Text = "外購";
            this.chbBuy.UseVisualStyleBackColor = true;
            // 
            // AXM_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1071, 566);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AXM_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "(外購) 序號查詢匯出系統💫";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_LotNo;
        private System.Windows.Forms.Label LN_AXM;
        private System.Windows.Forms.Button Inquire_btn;
        private System.Windows.Forms.TextBox txt_quantity;
        private System.Windows.Forms.Label quantity;
        private System.Windows.Forms.Button Output_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbBuy;
    }
}