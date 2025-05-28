
namespace FormSN_System.SubProgram
{
    partial class FormFoeSN_Gen
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
            this.txt_WO_No = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.cb_ProductType = new System.Windows.Forms.ComboBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txt_LastSN = new System.Windows.Forms.TextBox();
            this.txt_StartSN = new System.Windows.Forms.TextBox();
            this.txt_EndSN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_YYWW = new System.Windows.Forms.TextBox();
            this.btn_SN_Gen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_WO_No
            // 
            this.txt_WO_No.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_WO_No.Location = new System.Drawing.Point(201, 114);
            this.txt_WO_No.Name = "txt_WO_No";
            this.txt_WO_No.Size = new System.Drawing.Size(355, 40);
            this.txt_WO_No.TabIndex = 0;
            this.txt_WO_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_WO_No.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_WO_No_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Font = new System.Drawing.Font("標楷體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(308, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "查詢";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(52, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(134, 40);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "製令單號";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox3.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(51, 228);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(134, 40);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "產品類別";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox4.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(52, 285);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(134, 40);
            this.textBox4.TabIndex = 0;
            this.textBox4.Text = "上次序號";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox5.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(52, 342);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(134, 40);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "開始序號";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox6.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(52, 399);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(134, 40);
            this.textBox6.TabIndex = 0;
            this.textBox6.Text = "結束序號";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Qty
            // 
            this.txt_Qty.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Qty.Location = new System.Drawing.Point(437, 227);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Size = new System.Drawing.Size(118, 40);
            this.txt_Qty.TabIndex = 0;
            this.txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Qty_KeyDown);
            // 
            // cb_ProductType
            // 
            this.cb_ProductType.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_ProductType.FormattingEnabled = true;
            this.cb_ProductType.Items.AddRange(new object[] {
            "TRX",
            "OBM",
            "POBM",
            "COB"});
            this.cb_ProductType.Location = new System.Drawing.Point(200, 227);
            this.cb_ProductType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_ProductType.Name = "cb_ProductType";
            this.cb_ProductType.Size = new System.Drawing.Size(125, 40);
            this.cb_ProductType.TabIndex = 2;
            this.cb_ProductType.SelectedValueChanged += new System.EventHandler(this.cb_ProductType_SelectedValueChanged);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox8.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(344, 227);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(80, 40);
            this.textBox8.TabIndex = 0;
            this.textBox8.Text = "數量";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_LastSN
            // 
            this.txt_LastSN.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LastSN.Location = new System.Drawing.Point(201, 284);
            this.txt_LastSN.Name = "txt_LastSN";
            this.txt_LastSN.ReadOnly = true;
            this.txt_LastSN.Size = new System.Drawing.Size(355, 40);
            this.txt_LastSN.TabIndex = 0;
            this.txt_LastSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_StartSN
            // 
            this.txt_StartSN.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StartSN.ForeColor = System.Drawing.Color.Blue;
            this.txt_StartSN.Location = new System.Drawing.Point(201, 341);
            this.txt_StartSN.Name = "txt_StartSN";
            this.txt_StartSN.ReadOnly = true;
            this.txt_StartSN.Size = new System.Drawing.Size(355, 40);
            this.txt_StartSN.TabIndex = 0;
            this.txt_StartSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_EndSN
            // 
            this.txt_EndSN.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_EndSN.ForeColor = System.Drawing.Color.Blue;
            this.txt_EndSN.Location = new System.Drawing.Point(201, 398);
            this.txt_EndSN.Name = "txt_EndSN";
            this.txt_EndSN.ReadOnly = true;
            this.txt_EndSN.Size = new System.Drawing.Size(355, 40);
            this.txt_EndSN.TabIndex = 0;
            this.txt_EndSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(158, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "FOE 白牌序號產生器";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox12.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(52, 171);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(134, 40);
            this.textBox12.TabIndex = 0;
            this.textBox12.Text = "年週選擇";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("標楷體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker1.Location = new System.Drawing.Point(201, 171);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(223, 39);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txt_YYWW
            // 
            this.txt_YYWW.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_YYWW.Location = new System.Drawing.Point(437, 171);
            this.txt_YYWW.Name = "txt_YYWW";
            this.txt_YYWW.ReadOnly = true;
            this.txt_YYWW.Size = new System.Drawing.Size(118, 40);
            this.txt_YYWW.TabIndex = 0;
            this.txt_YYWW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_SN_Gen
            // 
            this.btn_SN_Gen.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_SN_Gen.Enabled = false;
            this.btn_SN_Gen.Font = new System.Drawing.Font("標楷體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SN_Gen.Location = new System.Drawing.Point(52, 476);
            this.btn_SN_Gen.Name = "btn_SN_Gen";
            this.btn_SN_Gen.Size = new System.Drawing.Size(503, 60);
            this.btn_SN_Gen.TabIndex = 1;
            this.btn_SN_Gen.Text = "產生序號";
            this.btn_SN_Gen.UseVisualStyleBackColor = false;
            this.btn_SN_Gen.Click += new System.EventHandler(this.btn_SN_Gen_Click);
            // 
            // FormFoeSN_Gen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(608, 570);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_ProductType);
            this.Controls.Add(this.btn_SN_Gen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txt_YYWW);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.txt_EndSN);
            this.Controls.Add(this.txt_StartSN);
            this.Controls.Add(this.txt_LastSN);
            this.Controls.Add(this.txt_WO_No);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormFoeSN_Gen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFoeSN_Gen";
            this.Shown += new System.EventHandler(this.FormFoeSN_Gen_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_WO_No;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txt_Qty;
        private System.Windows.Forms.ComboBox cb_ProductType;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox txt_LastSN;
        private System.Windows.Forms.TextBox txt_StartSN;
        private System.Windows.Forms.TextBox txt_EndSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_YYWW;
        private System.Windows.Forms.Button btn_SN_Gen;
    }
}