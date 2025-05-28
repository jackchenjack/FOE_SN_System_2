
namespace MFG_SN_Mapping
{
    partial class Main_menu
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
            this.btn_93Ship_Mapping = new System.Windows.Forms.Button();
            this.btn_FoeSN_Gen = new System.Windows.Forms.Button();
            this.btnCustom_SN_Gen = new System.Windows.Forms.Button();
            this.btn_FoeProductSN_Gen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSN_Search = new System.Windows.Forms.Button();
            this.btnOutSn_Search = new System.Windows.Forms.Button();
            this.btnMaintain_SN = new System.Windows.Forms.Button();
            this.btnSearchSN_Ship = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_93Ship_Mapping
            // 
            this.btn_93Ship_Mapping.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_93Ship_Mapping.Location = new System.Drawing.Point(57, 400);
            this.btn_93Ship_Mapping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_93Ship_Mapping.Name = "btn_93Ship_Mapping";
            this.btn_93Ship_Mapping.Size = new System.Drawing.Size(299, 75);
            this.btn_93Ship_Mapping.TabIndex = 0;
            this.btn_93Ship_Mapping.Text = "白牌出貨對應";
            this.btn_93Ship_Mapping.UseVisualStyleBackColor = true;
            this.btn_93Ship_Mapping.Click += new System.EventHandler(this.btn_93Ship_Mapping_Click);
            // 
            // btn_FoeSN_Gen
            // 
            this.btn_FoeSN_Gen.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_FoeSN_Gen.Location = new System.Drawing.Point(57, 134);
            this.btn_FoeSN_Gen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_FoeSN_Gen.Name = "btn_FoeSN_Gen";
            this.btn_FoeSN_Gen.Size = new System.Drawing.Size(299, 75);
            this.btn_FoeSN_Gen.TabIndex = 0;
            this.btn_FoeSN_Gen.Text = "FOE 白牌序號產生器";
            this.btn_FoeSN_Gen.UseVisualStyleBackColor = true;
            this.btn_FoeSN_Gen.Click += new System.EventHandler(this.btn_FoeSN_Gen_Click);
            // 
            // btnCustom_SN_Gen
            // 
            this.btnCustom_SN_Gen.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCustom_SN_Gen.Location = new System.Drawing.Point(57, 311);
            this.btnCustom_SN_Gen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCustom_SN_Gen.Name = "btnCustom_SN_Gen";
            this.btnCustom_SN_Gen.Size = new System.Drawing.Size(299, 75);
            this.btnCustom_SN_Gen.TabIndex = 0;
            this.btnCustom_SN_Gen.Text = "客戶成品序號產生器";
            this.btnCustom_SN_Gen.UseVisualStyleBackColor = true;
            this.btnCustom_SN_Gen.Click += new System.EventHandler(this.btnCustom_SN_Gen_Click);
            // 
            // btn_FoeProductSN_Gen
            // 
            this.btn_FoeProductSN_Gen.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_FoeProductSN_Gen.Location = new System.Drawing.Point(57, 222);
            this.btn_FoeProductSN_Gen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_FoeProductSN_Gen.Name = "btn_FoeProductSN_Gen";
            this.btn_FoeProductSN_Gen.Size = new System.Drawing.Size(299, 75);
            this.btn_FoeProductSN_Gen.TabIndex = 0;
            this.btn_FoeProductSN_Gen.Text = "FOE 成品序號產生器";
            this.btn_FoeProductSN_Gen.UseVisualStyleBackColor = true;
            this.btn_FoeProductSN_Gen.Click += new System.EventHandler(this.btn_FoeProductSN_Gen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(237, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "FOE 序號系統";
            // 
            // btnSN_Search
            // 
            this.btnSN_Search.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSN_Search.Location = new System.Drawing.Point(404, 134);
            this.btnSN_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSN_Search.Name = "btnSN_Search";
            this.btnSN_Search.Size = new System.Drawing.Size(381, 75);
            this.btnSN_Search.TabIndex = 0;
            this.btnSN_Search.Text = "對應序號查詢";
            this.btnSN_Search.UseVisualStyleBackColor = true;
            this.btnSN_Search.Click += new System.EventHandler(this.btnSN_Search_Click);
            // 
            // btnOutSn_Search
            // 
            this.btnOutSn_Search.BackColor = System.Drawing.SystemColors.Control;
            this.btnOutSn_Search.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOutSn_Search.Location = new System.Drawing.Point(404, 222);
            this.btnOutSn_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOutSn_Search.Name = "btnOutSn_Search";
            this.btnOutSn_Search.Size = new System.Drawing.Size(381, 75);
            this.btnOutSn_Search.TabIndex = 0;
            this.btnOutSn_Search.Text = "出貨序號查詢 (含外購)";
            this.btnOutSn_Search.UseVisualStyleBackColor = true;
            this.btnOutSn_Search.Click += new System.EventHandler(this.btnOutSn_Search_Click);
            // 
            // btnMaintain_SN
            // 
            this.btnMaintain_SN.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMaintain_SN.Location = new System.Drawing.Point(245, 535);
            this.btnMaintain_SN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMaintain_SN.Name = "btnMaintain_SN";
            this.btnMaintain_SN.Size = new System.Drawing.Size(299, 75);
            this.btnMaintain_SN.TabIndex = 0;
            this.btnMaintain_SN.Text = "序號維護";
            this.btnMaintain_SN.UseVisualStyleBackColor = true;
            this.btnMaintain_SN.Click += new System.EventHandler(this.btnMaintain_SN_Click);
            // 
            // btnSearchSN_Ship
            // 
            this.btnSearchSN_Ship.Font = new System.Drawing.Font("標楷體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearchSN_Ship.Location = new System.Drawing.Point(404, 311);
            this.btnSearchSN_Ship.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchSN_Ship.Name = "btnSearchSN_Ship";
            this.btnSearchSN_Ship.Size = new System.Drawing.Size(381, 75);
            this.btnSearchSN_Ship.TabIndex = 0;
            this.btnSearchSN_Ship.Text = "出貨序號檢查 (含外購)";
            this.btnSearchSN_Ship.UseVisualStyleBackColor = true;
            this.btnSearchSN_Ship.Click += new System.EventHandler(this.btnSearchSN_Ship_Click);
            // 
            // Main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 521);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCustom_SN_Gen);
            this.Controls.Add(this.btn_FoeProductSN_Gen);
            this.Controls.Add(this.btn_FoeSN_Gen);
            this.Controls.Add(this.btnOutSn_Search);
            this.Controls.Add(this.btnMaintain_SN);
            this.Controls.Add(this.btnSearchSN_Ship);
            this.Controls.Add(this.btnSN_Search);
            this.Controls.Add(this.btn_93Ship_Mapping);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main_menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_menu";
            this.Load += new System.EventHandler(this.Main_menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_93Ship_Mapping;
        private System.Windows.Forms.Button btn_FoeSN_Gen;
        private System.Windows.Forms.Button btnCustom_SN_Gen;
        private System.Windows.Forms.Button btn_FoeProductSN_Gen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSN_Search;
        private System.Windows.Forms.Button btnOutSn_Search;
        private System.Windows.Forms.Button btnMaintain_SN;
        private System.Windows.Forms.Button btnSearchSN_Ship;
    }
}

