using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MFG_SN_Mapping;
using FormSN_System.SubProgram;
using Table_buyShip_SN2;
using System.Reflection;

/// <summary>
/// 1.0.0.0     Jonas   2023/10/30  初版
/// 1.0.0.1     Jonas   2023/11/06
/// 1.0.0.2     Jonas   2023/11/15
/// 1.0.0.3     Jonas   2023/11/17  新增外購產品對應
/// 1.0.0.4     Jonas   2023/11/27  修改白牌和成品序號不存在時需卡關
/// 1.0.0.5     Jonas   2023/12/6   新增外購序號查詢及可匯出 Excel
/// 1.0.0.6     Jonas   2023/12/7   對應模式增加(Extreme A/B面 + DAC 白牌2 對 出貨1)
/// 1.0.0.7     Jonas   2024/1/9    新增終測查詢 QSFP_FinalTest 資料表,查詢方式by Channel/Voltage/Temperature
/// 1.0.0.8     Jonas   2024/1/12   新增 COB 白牌產生器
/// 1.0.0.9     Jonas   2024/1/22   修正 ATS_FinalTestData/TRx_FinalTest/QSFP_FinalTest 終測查詢方式by Channel/Voltage/Temperature
/// 1.0.0.10    Jonas   2024/1/26   對應刪除 by SN
/// 1.0.0.11    Jonas   2024/1/30   外購序號查詢修正
/// 1.0.0.12    Jonas   2024/2/29   白牌出貨對應修改外購400G/800G搜尋終測資料PAM4資料庫
/// 1.0.13.0    Jonas   2024/3/8    Extreme序號產生的產品名稱改由93料號輸入後自動選擇
/// 1.0.14.0    Jonas   2024/3/11   出貨序號查詢:輸入批號 輸入出貨序號 告知是否在該批號內 // 品保權限只能做出貨序號查詢/檢查
/// 1.0.15.0    Jonas   2024/3/27   (琹君)客戶序號產生器新增Lot防呆(字數必須等於16)
/// 1.0.15.1    Jonas   2024/3/29   Excel會一直跳出的問題
/// 1.0.16.0    Jonas   2024/4/23   工單輸入帶出資訊,取代OP手選
/// </summary>

namespace MFG_SN_Mapping
{
    public partial class Main_menu : Form
    {
        public bool Result;
        //string str_Path_exe = @"D:\SVN\SN_System_20230814\FormSN_MFGShip_Mapping\bin\Debug\";
        //string str_Path_exe = @"\\egoserver\技術中心\FOE_Program\EXE\"; // 執行檔放置路徑
        public Main_menu()
        {
            InitializeComponent();

            Input_OPID();

            QCID_Check();
        }

        private bool Input_OPID()
        {
            Input_ID vForm = new Input_ID();
            vForm.ShowDialog();

            //if (vForm.)
            return true;
        }

        private void QCID_Check()
        {
            if (Jonas_SubFunction.JonasSQL.Program_Permissions("SN System_QC", Input_ID.opid))
            {
                btn_FoeSN_Gen.Enabled = false;
                btn_FoeProductSN_Gen.Enabled = false;
                btnCustom_SN_Gen.Enabled = false;
                btn_93Ship_Mapping.Enabled = false;
                btnSN_Search.Enabled = false;
                btnOutSn_Search.Enabled = true;
                btnSearchSN_Ship.Enabled = true;
            }

        }

        private void btn_93Ship_Mapping_Click(object sender, EventArgs e)
        {

            this.Hide();

            Sn_Mapping vForm = new Sn_Mapping();
            vForm.ShowDialog();

            this.Show();
        }

        private void btn_FoeSN_Gen_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormFoeSN_Gen vForm = new FormFoeSN_Gen();
            vForm.ShowDialog();

            this.Show();
        }

        private void Main_menu_Load(object sender, EventArgs e)
        {
            this.Text = "Ver：" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();
            BackColor = Color.MediumSeaGreen;
        }

        private void btn_FoeProductSN_Gen_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormFoeProductSN_Gen vForm = new FormFoeProductSN_Gen();
            vForm.ShowDialog();

            this.Show();
        }

        private void btnCustom_SN_Gen_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 vForm = new Form1();
            vForm.ShowDialog();

            this.Show();
        }

        private void btnOutsource_FT_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormOutsourcing_FT_Import vForm = new FormOutsourcing_FT_Import();
            vForm.ShowDialog();

            this.Show();
        }

        private void btnSN_Search_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form2 vForm = new Form2();
            vForm.ShowDialog();

            this.Show();
        }

        private void btnOutSn_Search_Click(object sender, EventArgs e)
        {
            this.Hide();

            AXM_Form vForm = new AXM_Form();
            vForm.ShowDialog();

            this.Show();
        }

        private void btnMaintain_SN_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchSN_Ship_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormSearchSN_Ship vForm = new FormSearchSN_Ship();
            vForm.ShowDialog();

            this.Show();
        }
    }
}
