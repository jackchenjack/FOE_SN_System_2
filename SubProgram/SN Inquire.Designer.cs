
namespace FormSN_System.SubProgram
{
    partial class Form2
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
            this.txtShip_SN_IN = new System.Windows.Forms.TextBox();
            this.txtShip_SN_OUT = new System.Windows.Forms.TextBox();
            this.txtMFG_SN_Out = new System.Windows.Forms.TextBox();
            this.txtMFG_SN_IN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch_ShipSN = new System.Windows.Forms.Button();
            this.btnSearch_MFGsn = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtShip_SN_IN
            // 
            this.txtShip_SN_IN.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShip_SN_IN.Location = new System.Drawing.Point(16, 245);
            this.txtShip_SN_IN.Margin = new System.Windows.Forms.Padding(4);
            this.txtShip_SN_IN.Name = "txtShip_SN_IN";
            this.txtShip_SN_IN.Size = new System.Drawing.Size(224, 52);
            this.txtShip_SN_IN.TabIndex = 0;
            this.txtShip_SN_IN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShip_SN_IN_KeyDown);
            // 
            // txtShip_SN_OUT
            // 
            this.txtShip_SN_OUT.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtShip_SN_OUT.Location = new System.Drawing.Point(469, 75);
            this.txtShip_SN_OUT.Margin = new System.Windows.Forms.Padding(4);
            this.txtShip_SN_OUT.Name = "txtShip_SN_OUT";
            this.txtShip_SN_OUT.Size = new System.Drawing.Size(335, 52);
            this.txtShip_SN_OUT.TabIndex = 1;
            // 
            // txtMFG_SN_Out
            // 
            this.txtMFG_SN_Out.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMFG_SN_Out.Location = new System.Drawing.Point(469, 238);
            this.txtMFG_SN_Out.Margin = new System.Windows.Forms.Padding(4);
            this.txtMFG_SN_Out.Name = "txtMFG_SN_Out";
            this.txtMFG_SN_Out.Size = new System.Drawing.Size(335, 52);
            this.txtMFG_SN_Out.TabIndex = 2;
            // 
            // txtMFG_SN_IN
            // 
            this.txtMFG_SN_IN.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMFG_SN_IN.Location = new System.Drawing.Point(16, 74);
            this.txtMFG_SN_IN.Margin = new System.Windows.Forms.Padding(4);
            this.txtMFG_SN_IN.Name = "txtMFG_SN_IN";
            this.txtMFG_SN_IN.Size = new System.Drawing.Size(224, 52);
            this.txtMFG_SN_IN.TabIndex = 3;
            this.txtMFG_SN_IN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMFG_SN_IN_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(16, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 59);
            this.label1.TabIndex = 4;
            this.label1.Text = "出貨序號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(471, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 59);
            this.label2.TabIndex = 5;
            this.label2.Text = "出貨序號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Blue;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(17, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 59);
            this.label3.TabIndex = 6;
            this.label3.Text = "白牌序號";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Blue;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(469, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 59);
            this.label4.TabIndex = 7;
            this.label4.Text = "白牌序號";
            // 
            // btnSearch_ShipSN
            // 
            this.btnSearch_ShipSN.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearch_ShipSN.Location = new System.Drawing.Point(267, 45);
            this.btnSearch_ShipSN.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch_ShipSN.Name = "btnSearch_ShipSN";
            this.btnSearch_ShipSN.Size = new System.Drawing.Size(180, 56);
            this.btnSearch_ShipSN.TabIndex = 8;
            this.btnSearch_ShipSN.Text = "查詢 →";
            this.btnSearch_ShipSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch_ShipSN.UseVisualStyleBackColor = true;
            this.btnSearch_ShipSN.Click += new System.EventHandler(this.btnSearch_ShipSN_Click);
            // 
            // btnSearch_MFGsn
            // 
            this.btnSearch_MFGsn.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearch_MFGsn.Location = new System.Drawing.Point(267, 211);
            this.btnSearch_MFGsn.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch_MFGsn.Name = "btnSearch_MFGsn";
            this.btnSearch_MFGsn.Size = new System.Drawing.Size(180, 56);
            this.btnSearch_MFGsn.TabIndex = 9;
            this.btnSearch_MFGsn.Text = "查詢 →";
            this.btnSearch_MFGsn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch_MFGsn.UseVisualStyleBackColor = true;
            this.btnSearch_MFGsn.Click += new System.EventHandler(this.btnSearch_MFGsn_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(267, 128);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 56);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "清除資料";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(824, 310);
            this.Controls.Add(this.btnSearch_MFGsn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch_ShipSN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMFG_SN_IN);
            this.Controls.Add(this.txtMFG_SN_Out);
            this.Controls.Add(this.txtShip_SN_OUT);
            this.Controls.Add(this.txtShip_SN_IN);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生產序號查詢";
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShip_SN_IN;
        private System.Windows.Forms.TextBox txtShip_SN_OUT;
        private System.Windows.Forms.TextBox txtMFG_SN_Out;
        private System.Windows.Forms.TextBox txtMFG_SN_IN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch_ShipSN;
        private System.Windows.Forms.Button btnSearch_MFGsn;
        private System.Windows.Forms.Button btnClear;
    }
}