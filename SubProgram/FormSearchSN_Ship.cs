using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MFG_SN_Mapping
{
    public partial class FormSearchSN_Ship : Form
    {
        string strDB_FOE = "uid=sa;pwd=dsc;database=FormericaOE;server=dataserver";   // 資料庫_FormericaOE
        string strDB_MFGSN = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";      // 資料庫_MFG_SN
        string table_ShipSN = "[MFG_SN].[dbo].[Table_Ship_SN]";
        string table_buyShipSN = "[MFG_SN].[dbo].[Table_buyShip_SN]";
        string totalSN = string.Empty;
        int inputQtySN = 0;


        public FormSearchSN_Ship()
        {
            InitializeComponent();

            txtLot.Text = string.Empty;
            txtShipSN.Text = string.Empty;
        }

        private void txtShipSN_KeyDown(object sender, KeyEventArgs e)
        {
            // 判斷是否按下 Enter 鍵
            if (e.KeyCode == Keys.Enter)
            {
                txtShipSN.Text = txtShipSN.Text.ToUpper().Replace(" ", "");
                btnPF.Text = "";
                btnPF.BackColor = Color.White;
                Refresh();

                if (txtLot.Text == "")
                {
                    MessageBox.Show("請輸入 Lot NO. ");
                    return;
                }

                if (txtShipSN.Text == "")
                {
                    MessageBox.Show("請輸入 Ship SN ");
                    return;
                }

                Thread.Sleep(200);

                if (CheckShipSNinLot())
                {
                    if (totalSN.Contains(txtShipSN.Text))
                    {
                        btnPF.Text = "SN 重複";
                        btnPF.BackColor = Color.Yellow;
                    }
                    else
                    {
                        totalSN += txtShipSN.Text + ",";
                        inputQtySN++;
                        txtQty_ShipSN.Text = inputQtySN.ToString();
                        btnPF.Text = "PASS";
                        btnPF.BackColor = Color.Lime;
                    }
                }
                else
                {
                    btnPF.Text = "FAIL";
                    btnPF.BackColor = Color.Red;
                }

                txtShipSN.Focus();
                txtShipSN.SelectAll();
            }

        }

        /// <summary>
        /// 檢查輸入的 Ship SN 是否在指定的 Lot 裡面
        /// </summary>
        private bool CheckShipSNinLot()
        {
            string DB_table;
            if (chbBuyShip.Checked == true)
                DB_table = table_buyShipSN;
            else
                DB_table = table_ShipSN;

            string strComm = $"Select * From {DB_table} where [Ship_SN] = '{txtShipSN.Text}' and [Work_Order] = '{txtLot.Text}'";

            DataTable dt = Jonas_SubFunction.JonasSQL.select_Return_DT(strDB_MFGSN, strComm);

            if (dt.Rows.Count == 0) return false;

            return true;
        }

        private void txtLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                inputQtySN = 0;
                // 在這裡執行你想要的程式碼
                txtLot.Text = txtLot.Text.ToUpper().Replace(" ", "");

                LotSnQty();

                txtShipSN.Focus();
                txtShipSN.SelectAll();
               
                // 防止 Enter 鍵繼續觸發事件
                //e.Handled = true;
            }
        }

        /// <summary>
        /// 指定 Lot 裡面的 SN 數量
        /// </summary>
        private bool LotSnQty()
        {
            string DB_table;
            if (chbBuyShip.Checked == true)
                DB_table = table_buyShipSN;
            else
                DB_table = table_ShipSN;

            string strComm = $"Select DISTINCT [Ship_SN] From {DB_table} where [Work_Order] = '{txtLot.Text}'";

            List<string> _list = Jonas_SubFunction.JonasSQL.select_Return_List(strDB_MFGSN, strComm);

            txtQty_LotSN.Text = _list.Count.ToString();

            return true;
        }

        private void FormSearchSN_Ship_Shown(object sender, EventArgs e)
        {
            txtLot.Focus();
        }
    }
}
