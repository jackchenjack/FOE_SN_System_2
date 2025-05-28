
namespace MFG_SN_Mapping
{
    partial class FormSearchSN_Ship
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShipSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPF = new System.Windows.Forms.Button();
            this.chbBuyShip = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQty_LotSN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQty_ShipSN = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(47, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lot NO";
            // 
            // txtLot
            // 
            this.txtLot.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLot.Location = new System.Drawing.Point(116, 88);
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(207, 33);
            this.txtLot.TabIndex = 1;
            this.txtLot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLot_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(47, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ship SN";
            // 
            // txtShipSN
            // 
            this.txtShipSN.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtShipSN.Location = new System.Drawing.Point(116, 158);
            this.txtShipSN.Name = "txtShipSN";
            this.txtShipSN.Size = new System.Drawing.Size(207, 33);
            this.txtShipSN.TabIndex = 1;
            this.txtShipSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShipSN_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(194, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ship SN 查詢";
            // 
            // btnPF
            // 
            this.btnPF.Enabled = false;
            this.btnPF.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPF.Location = new System.Drawing.Point(116, 268);
            this.btnPF.Name = "btnPF";
            this.btnPF.Size = new System.Drawing.Size(372, 77);
            this.btnPF.TabIndex = 3;
            this.btnPF.UseVisualStyleBackColor = true;
            // 
            // chbBuyShip
            // 
            this.chbBuyShip.AutoSize = true;
            this.chbBuyShip.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chbBuyShip.Location = new System.Drawing.Point(116, 214);
            this.chbBuyShip.Name = "chbBuyShip";
            this.chbBuyShip.Size = new System.Drawing.Size(73, 31);
            this.chbBuyShip.TabIndex = 4;
            this.chbBuyShip.Text = "外購";
            this.chbBuyShip.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(359, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "數量";
            // 
            // txtQty_LotSN
            // 
            this.txtQty_LotSN.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQty_LotSN.Location = new System.Drawing.Point(406, 88);
            this.txtQty_LotSN.Name = "txtQty_LotSN";
            this.txtQty_LotSN.ReadOnly = true;
            this.txtQty_LotSN.Size = new System.Drawing.Size(82, 33);
            this.txtQty_LotSN.TabIndex = 1;
            this.txtQty_LotSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(359, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "數量";
            // 
            // txtQty_ShipSN
            // 
            this.txtQty_ShipSN.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQty_ShipSN.Location = new System.Drawing.Point(406, 158);
            this.txtQty_ShipSN.Name = "txtQty_ShipSN";
            this.txtQty_ShipSN.ReadOnly = true;
            this.txtQty_ShipSN.Size = new System.Drawing.Size(82, 33);
            this.txtQty_ShipSN.TabIndex = 1;
            this.txtQty_ShipSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormSearchSN_Ship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(572, 380);
            this.Controls.Add(this.chbBuyShip);
            this.Controls.Add(this.btnPF);
            this.Controls.Add(this.txtShipSN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQty_ShipSN);
            this.Controls.Add(this.txtQty_LotSN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSearchSN_Ship";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSearchSN_Ship";
            this.Shown += new System.EventHandler(this.FormSearchSN_Ship_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShipSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPF;
        private System.Windows.Forms.CheckBox chbBuyShip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQty_LotSN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQty_ShipSN;
    }
}