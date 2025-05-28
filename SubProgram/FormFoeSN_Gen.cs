using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSN_System.SubProgram
{
    public partial class FormFoeSN_Gen : Form
    {
        string connstr = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";
        string productType, strSN;
        string strLastSN1 = "";
        string strLastSN2 = "";
        string strNextSN2 = "";
        int Qty;
        int LastSN2;
        int StartSN, EndSN, NextSN;
        //int StartSN_COB, EndSN_COB;

        public FormFoeSN_Gen()
        {
            InitializeComponent();
            //dateTimePicker1.Value = DateTime.Now;
            txt_WO_No.Focus();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //string ww = FOE_SN.setWW(dateTimePicker1.Value);//取週數
            string yy = dateTimePicker1.Value.Year.ToString().Substring(2);

            DateTime dt = dateTimePicker1.Value;
            Calendar cal = new CultureInfo("en-US").Calendar;
            string ww = (cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday)).ToString("D2");

            txt_YYWW.Text = yy + ww;

            if (cb_ProductType.Text != "") dataUpdated();

        }

        private void txt_WO_No_KeyDown(object sender, KeyEventArgs e)
        {
            // 判斷是否按下 Enter 鍵
            if (e.KeyCode == Keys.Enter)
            {
                // 在這裡執行你想要的程式碼
                //string userInput = txt_WO_No.Text;
                //MessageBox.Show($"You entered: {userInput}");
                cb_ProductType.Enabled = true;
                txt_Qty.Enabled = false;
                txt_Qty.Text = "";
                txt_LastSN.Text = "";
                txt_StartSN.Text = "";
                txt_EndSN.Text = "";
                //btn_SN_Gen.Text = "請選擇產品類別";

                //cb_ProductType.Focus();
                //cb_ProductType.DroppedDown = true;
                cb_ProductType.Focus();

                // 防止 Enter 鍵繼續觸發事件
                e.Handled = true;
            }
        }

        private void FormFoeSN_Gen_Shown(object sender, EventArgs e)
        {
            txt_WO_No.Enabled = true;
            dateTimePicker1.Value = DateTime.Now;
            cb_ProductType.Enabled = false;
            txt_Qty.Enabled = false;

            btn_SN_Gen.BackColor = Color.RoyalBlue;
            //btn_SN_Gen.Text = "請輸入製令單號";

            txt_WO_No.Text = "";
            txt_LastSN.Text = "";
            txt_StartSN.Text = "";
            txt_EndSN.Text = "";
            txt_WO_No.Focus();
        }

        private void txt_Qty_KeyDown(object sender, KeyEventArgs e)
        {
            // 判斷是否按下 Enter 鍵
            if (e.KeyCode == Keys.Enter)
            {
                // 在這裡執行你想要的程式碼
                try
                {
                    Qty = Convert.ToInt16(txt_Qty.Text);
                }
                catch
                {
                    MessageBox.Show("數量輸入異常");
                    return;
                }

                if (cb_ProductType.Text == "COB")
                {
                    EndSN = LastSN2 + Qty;

                    if (EndSN > 9999) MessageBox.Show("結束 SN > 9999");
                    else txt_EndSN.Text = strLastSN1 + EndSN.ToString("D4");
                }
                else
                {
                    EndSN = LastSN2 + Qty;

                    if (EndSN > 9999) MessageBox.Show("結束 SN > 9999");
                    else txt_EndSN.Text = strLastSN1 + "A" + EndSN.ToString("D4");
                }
                

                btn_SN_Gen.Enabled = true;
                btn_SN_Gen.Focus();

                // 防止 Enter 鍵繼續觸發事件
                e.Handled = true;
            }
        }

        private void btn_SN_Gen_Click(object sender, EventArgs e)
        {
            btn_SN_Gen.BackColor = Color.Yellow;
            Refresh();
            Thread.Sleep(1000);
            try
            {
                using (SqlConnection openCon = new SqlConnection(connstr))
                {
                    openCon.Open();

                    if (cb_ProductType.Text == "COB")
                    {
                        for (int i = StartSN; i <= EndSN; i++)
                        {
                            strSN = strLastSN1 + i.ToString("D4");
                            string strCommand = "INSERT INTO [dbo].[Table_MFG_SN] ([Work_Order],[Product],[YearWeek],[MFG_SN],[Date],[Note]) " +
                                                $"VALUES('{txt_WO_No.Text}', '{productType}', '{txt_YYWW.Text}', '{strSN}', GETDATE(), '')";

                            using (SqlCommand cmd = new SqlCommand(strCommand, openCon))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        for (int i = StartSN; i <= EndSN; i++)
                        {
                            strSN = productType + txt_YYWW.Text + "A" + i.ToString("D4");
                            string strCommand = "INSERT INTO [dbo].[Table_MFG_SN] ([Work_Order],[Product],[YearWeek],[MFG_SN],[Date],[Note]) " +
                                                $"VALUES('{txt_WO_No.Text}', '{productType}', '{txt_YYWW.Text}', '{strSN}', GETDATE(), '')";

                            using (SqlCommand cmd = new SqlCommand(strCommand, openCon))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    

                    openCon.Close();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                MessageBox.Show("資料庫發生異常");

                btn_SN_Gen.BackColor = Color.Red;
                return;
            }

            btn_SN_Gen.BackColor = Color.RoyalBlue;
            cb_ProductType_SelectedValueChanged(sender, e);
            btn_SN_Gen.Enabled = false;
        }

        private void cb_ProductType_SelectedValueChanged(object sender, EventArgs e)
        {
            //string productType, SN = "";
            switch (cb_ProductType.Text)
            {
                case "TRX":
                    productType = "T";
                    break;
                case "OBM":
                    productType = "O";
                    break;
                case "POBM":
                    productType = "P";
                    break;
                case "COB":
                    productType = "B";
                    break;
                default:
                    productType = "";
                    txt_LastSN.Text = "";
                    txt_StartSN.Text = "";
                    txt_EndSN.Text = "";
                    return;
            }

            dataUpdated();
            txt_Qty.Enabled = true;
            txt_Qty.Text = "";
            txt_Qty.Focus();
        }

        private void dataUpdated()
        {
            string Y = string.Empty, W = string.Empty;
            string numTable_yyww = "0123456789ABCDEFGHJKLMNPQRS";   // 年&週查詢表
            //string numTable_sn4 = "0123456789ABCDEFGHJKLMNPQRS";    // 序號第4碼查詢表 ex: 0001 ~ A999 , 1~3碼 : 001~999
            if (cb_ProductType.Text == "COB")
            {
                int y1 = Convert.ToInt16(txt_YYWW.Text.Substring(0, 1));
                int y2 = Convert.ToInt16(txt_YYWW.Text.Substring(1, 1));
                int ww = Convert.ToInt16(txt_YYWW.Text.Substring(2, 2));

                int yy = y1 * y2;

                if (ww > 27)
                {
                    ww = ww - 27;
                    yy++;
                }

                Y = numTable_yyww.Substring(yy, 1);
                W = numTable_yyww.Substring(ww-1, 1);

                strSN =  $"{Y}{W}%";
                
                //MessageBox.Show($"strSN = {strSN}");
                //return;
            }
            else
                strSN = productType + txt_YYWW.Text + "A%";

            string str_SQL = $"select top 1 MFG_SN from MFG_SN.dbo.Table_MFG_SN where MFG_SN like '{strSN}' and [Product]='{productType}' order by MFG_SN desc";
            List<string> mylist = Jonas_SubFunction.JonasSQL.select_Return_List(connstr, str_SQL);

            if (mylist.Count > 0)
            {
                if (cb_ProductType.Text == "COB")
                {
                    txt_LastSN.Text = mylist[0];
                    strLastSN1 = mylist[0].Substring(0,2);
                    //char[] sn4 = mylist[0].Substring(2, 1).ToCharArray();
                    //int index_sn4 = numTable_sn4.IndexOf(sn4[0]);
                    LastSN2= Convert.ToInt16(mylist[0].Substring(2, 4));
                    NextSN = LastSN2 + 1;
                    if (NextSN >= 10000)
                    {
                        MessageBox.Show("當週序號已滿,請通知軟體工程師");
                        return;
                        //index_sn4++;
                        //sn4[0] = 
                    }

                    txt_StartSN.Text = strLastSN1 + NextSN.ToString("D4");
                    //strSN = mylist[0].Substring
                    //txt_StartSN.Text = Convert.ToInt16(txt_LastSN.Text).ToString("D4");
                }
                else
                {
                    txt_LastSN.Text = mylist[0];
                    string[] x = mylist[0].Split('A');
                    strLastSN1 = x[0];
                    LastSN2 = Convert.ToInt16(x[1]);

                    txt_StartSN.Text = strLastSN1 + "A" + (Convert.ToInt16(LastSN2) + 1).ToString("D4");
                }
                
                txt_EndSN.Text = "";
                txt_Qty.Text = "";
            }
            else
            {
                if (cb_ProductType.Text == "COB")
                {
                    txt_LastSN.Text = "查無序號";
                    txt_StartSN.Text = $"{Y}{W}" + "0001";
                    txt_EndSN.Text = "";
                    txt_Qty.Text = "";

                    strLastSN1 = $"{Y}{W}";
                    LastSN2 = 0;
                }
                else
                {
                    txt_LastSN.Text = "查無序號";
                    txt_StartSN.Text = productType + txt_YYWW.Text + "A0001";
                    txt_EndSN.Text = "";
                    txt_Qty.Text = "";

                    strLastSN1 = productType + txt_YYWW.Text;
                    LastSN2 = 0;
                }
                
                
            }

            StartSN = LastSN2 + 1;

        }
    }
}
