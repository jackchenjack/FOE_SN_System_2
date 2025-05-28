using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Dapper;
using System.Data.SqlClient;
using YRspace_FOE_SN;
using YRspace_SQL;
using MFG_SN_Mapping;
//using ClassLibraryFOE; //我的類別庫

namespace Table_buyShip_SN2
{
    public partial class Form1 : Form
    {
        string[] arrSN = null;
        string[] arrSN2 = null;
        string connstr_MFG = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";
        string connstr_FORMERICA = "uid=sa;pwd=dsc;database=FORMERICA;server=dataserver";
        List<string> notelist = new List<string>();//後面取流水碼要用
        List<string> substringlist = new List<string>();//後面取流水碼要用
        Run_Mode currentMode = new Run_Mode();

        private enum Run_Mode
        {
            None = 0,
            Production = 1,
            Engineering = 2
        }

        public Form1()
        {
            InitializeComponent();

            Txt_ww.Text = FOE_SN.setWW(dateTimePicker1.Value);//取目前週別
            Txt_yy.Text = dateTimePicker1.Value.Year.ToString().Substring(2);

            currentMode = Run_Mode.None;
        }        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)//變動日期
        {
            Txt_ww.Text = FOE_SN.setWW(dateTimePicker1.Value);//取週數
            Txt_yy.Text = dateTimePicker1.Value.Year.ToString().Substring(2);

            txb_nowR.Text = "";
            txb_R.Text = "";
            txb_startSN.Text = "";
            txb_endSN.Text = "";
        }

        
        private void Cbo_Vendor_SelectedValueChanged(object sender, EventArgs e)//選廠商
        {
            //自動刷條碼時  阻止觸發這個事件
            if (!(txb_Lot.Text == "" || txb_Lot.Text == "5110-yyyymmddxxx"))
            {
                return;
            }
            


            //變更時 清空所有資訊
            Cbo_product_name.Items.Clear();
            Cbo_product_name.Text = "";
            Lbl_script.Text = "";
            txb_select.Text = "";

            Lbl_custmerNo.Text = "";
            txb_nowR.Text = "";
            txb_R.Text = "";
            txb_startSN.Text = "";
            txb_endSN.Text = "";
            txtStartSN2.Text = "";
            txtEndSN2.Text = "";
            lbl_substr.Text = "";

            txb_note1.Text = "";
            txb_note2.Text = "";
            txb_note3.Text = "";
            txb_note4.Text = "";
            //變更時 清空所有資訊

            //有幾個廠商  要客戶直接指定流水碼頭尾
            if (Cbo_Vendor.Text == "T1NEXUS" | Cbo_Vendor.Text == "AXIOM")
            {
                label10.Visible = false;
                txb_quantity.Visible = false;
                btn_nowR.Visible = false;
                txb_nowR.Visible = false;

                label4.Visible = true;
                txb_setRstart.Visible = true;
                txb_setRend.Visible = true;
            }
            else
            {
                label10.Visible = true;
                txb_quantity.Visible = true;
                btn_nowR.Visible = true;
                txb_nowR.Visible = true;

                label4.Visible = false;
                txb_setRstart.Visible = false;
                txb_setRend.Visible = false;
            }

            if (Cbo_Vendor.Text == "LevelOne")
                gbSN2.Visible = true;
            else
                gbSN2.Visible = false;

            //string connstr = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";
            string selectstr = "SELECT DISTINCT [product_name] FROM [MFG_SN].[dbo].[Table_buyShipSN_codingRules] where [Vendor] = '" + Cbo_Vendor.Text + "'";

            List<string> mylist = YRSQL.select_return_list(connstr_MFG, selectstr);

            for (int i = 0; i < mylist.Count; i++)
            {
                Cbo_product_name.Items.Add(mylist[i]);
            }

            selectstr = "SELECT * FROM [MFG_SN].[dbo].[Table_buyShipSN_codingRules] where [Vendor] = '" + Cbo_Vendor.Text + "'";
            DataTable dt = YRSQL.select_return_dt(connstr_MFG, selectstr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                notelist.Add(dt.Rows[i]["note1"].ToString().Split('#')[0]);
                substringlist.Add(dt.Rows[i]["note1"].ToString().Split('#')[1]);
            }

        }

        private void Cbo_product_name_SelectedValueChanged(object sender, EventArgs e)//選產品
        {
            //MessageBox.Show("Cbo_product_name_SelectedValueChanged");
            //清空
            Lbl_script.Text = "";
            txb_select.Text = "";
            txb_nowR.Text = "";
            txb_R.Text = "";
            txb_startSN.Text = "";
            txb_endSN.Text = "";
            txtStartSN2.Text = "";
            txtEndSN2.Text = "";
            lbl_substr.Text = "";

            txb_note1.Text = "";
            txb_note2.Text = "";
            txb_note3.Text = "";
            txb_note4.Text = "";
            //清空   

            if (Cbo_product_name.Text == "")
                return;

            //string connstr = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";
            string selectstr = "SELECT * FROM [MFG_SN].[dbo].[Table_buyShipSN_codingRules] where [Vendor] = '" + Cbo_Vendor.Text +
                    "' and [product_name] = '" + Cbo_product_name.Text + "'";

            DataTable dt = YRSQL.select_return_dt(connstr_MFG, selectstr);

            Lbl_custmerNo.Text = dt.Rows[0]["custmerNo"].ToString();
            Lbl_script.Text = dt.Rows[0]["script"].ToString();
            txb_select.Text = dt.Rows[0]["SQLselect"].ToString();

            lbl_substr.Text = dt.Rows[0]["note1"].ToString().Split('#')[1];

            txb_note1.Text = dt.Rows[0]["note1"].ToString();
            txb_note2.Text = dt.Rows[0]["note2"].ToString();
            txb_note3.Text = dt.Rows[0]["note3"].ToString();
            txb_note4.Text = dt.Rows[0]["note4"].ToString();
        }

        

        private void btn_nowR_Click(object sender, EventArgs e)
        {
            //清空
            txb_nowR.Text = "";
            txb_R.Text = "";
            txb_startSN.Text = "";
            txb_endSN.Text = "";
            txtStartSN2.Text = string.Empty;
            txtEndSN2.Text = string.Empty;
            //清空

            //if (Cbo_tablename.Text == "" || Cbo_Vendor.Text == "" || Cbo_product_name.Text == "")
            if (Cbo_Vendor.Text == "" || Cbo_product_name.Text == "")
            {
                MessageBox.Show("下拉選單不能空白");
            }
            else
            {
                string addyyww = "";//是否加入年週select where
                if (chk_addyyww.Checked)//是否加入年週select where
                {
                    if (Cbo_Vendor.Text == "NETGEAR"| Cbo_Vendor.Text == "WAVESPLITTER")
                    {
                        //addyyww = " and  [Ship_SN] like '_____" + dateTimePicker1.Value.Month.ToString("X1") + "%'";
                        addyyww = " and  [YearWeek] like '"+ Txt_yy.Text + dateTimePicker1.Value.ToString("MM") + "'";
                    }
                    else if (Cbo_Vendor.Text == "SolidOptics"| Cbo_Vendor.Text == "ReadyLinkss")
                    {
                        addyyww = "";                        
                    }

                    // 20230705 Jonas 修改
                    // 加入 ReadyLinks 每日更新(00001)
                    else if (Cbo_Vendor.Text == "ReadyLinks")
                    {
                        addyyww = " and [Ship_SN] like '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "%'";
                    }
                    else if (Cbo_Vendor.Text == "LevelOne")
                    {
                        addyyww = $" and [YearWeek] = '{Txt_yy.Text}{Txt_ww.Text}' and [Note] = '{txb_note1.Text}'";
                    }
                    else
                    {
                        addyyww = " and [YearWeek] like '" + Txt_yy.Text + Txt_ww.Text + "'";
                    }
                }



                //以下 查詢目前流水號到多少
                //string connstr = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";
                string selectstr = "SELECT * FROM [MFG_SN].[dbo].[Table_buyShipSN_codingRules] where [Vendor] = '" + Cbo_Vendor.Text + "'";
                DataTable dt = YRSQL.select_return_dt(connstr_MFG, selectstr);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    notelist.Add(dt.Rows[i]["note1"].ToString().Split('#')[0]);
                    substringlist.Add(dt.Rows[i]["note1"].ToString().Split('#')[1]);
                }

                
                selectstr = "SELECT * FROM [MFG_SN].[dbo].[Table_buyShip_SN] " + txb_select.Text + addyyww + " order by [Ship_SN] desc";

                dt = YRSQL.select_return_dt(connstr_MFG, selectstr);

                if (dt.Rows.Count == 0)
                {
                    //MessageBox.Show("查無資料");
                    txb_nowR.Text = "查無資料";
                    //沒資料時要編一個 第一碼  還沒寫
                    txb_R.Text = "0";
                }
                else
                {
                    //List<string> nowxxxx = getxxxx(dt);
                    List<string> nowxxxx = FOE_SN.getxxxx(dt, notelist, substringlist, Lbl_script.Text);

                    txb_nowR.Text = nowxxxx[0];
                    txb_R.Text = nowxxxx[1];
                }
            }


        }               
        
        
        private void btn_setSN_Click(object sender, EventArgs e)
        {
            int num_var;
            if (Cbo_Vendor.Text == "T1NEXUS" | Cbo_Vendor.Text == "AXIOM")
            {
                int setRstart, setRend;
                if (int.TryParse(txb_setRstart.Text, out setRstart) & int.TryParse(txb_setRend.Text, out setRend))
                {
                    arrSN = new string[setRend - setRstart + 1];
                    arrSN = FOE_SN.setSN2(Lbl_script.Text, (setRstart-1).ToString(), (setRend - setRstart + 1), Txt_yy.Text, Txt_ww.Text, dateTimePicker1.Value);                    

                    txb_startSN.Text = arrSN[0];
                    txb_endSN.Text = arrSN[arrSN.Length - 1];
                }
                else
                {
                    MessageBox.Show("客戶直接指定流水號 請填入 頭尾碼 不用補碼");
                    txb_state.Text = "客戶直接指定流水號 請填入 頭尾碼 不用補碼";
                }                
            }            
            else if (txb_quantity.Text == "0")
            {
                MessageBox.Show("請填 大於0 的數字");
            }
            else if (txb_quantity.Text != "0" && int.TryParse(txb_quantity.Text, out num_var))
            {
                ////////////////////////////////////Jonas_20230607 編號超過 32767 出現異常////////////////////////////////////////
                // Int16 : -32768 ~ 32767
                // Int32 : -2147483648 ~ 2147483647
                // 以下2行原程式 Int16.Parse 改為 Int32.Parse 
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                arrSN = new string[Int32.Parse(txb_quantity.Text)];
                arrSN = FOE_SN.setSN2(Lbl_script.Text, txb_R.Text, Int32.Parse(txb_quantity.Text), Txt_yy.Text, Txt_ww.Text, dateTimePicker1.Value);

                for (int i=0; i< arrSN.Length; i++) // 檢查產出序號是否存在
                {
                    string sn_new = arrSN[i];
                    string sn_SQL = $"SELECT * FROM [MFG_SN].[dbo].[Table_buyShip_SN] WHERE [Ship_SN]='{sn_new}'";

                    DataTable dt = Jonas_SubFunction.JonasSQL.select_Return_DT(connstr_MFG, sn_SQL);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show($"Ship SN {sn_new} 已存在, 請檢查");
                        return;
                    }
                }

                txb_startSN.Text = arrSN[0];
                txb_endSN.Text = arrSN[arrSN.Length - 1];

                // LevelOne 需同時產生相同流水號的 label SN (目前選項規則只產生A0A2的SN)
                if (gbSN2.Visible == true)
                {
                    string L1_sn = LevelOne_SnRule(txt93sn.Text);

                    if (L1_sn == "")
                    {
                        MessageBox.Show("LevelOne 此料號沒有要建立出貨序號, 如有問題請通知軟體工程師");
                        return;
                    }
                    arrSN2 = new string[Int32.Parse(txb_quantity.Text)];
                    arrSN2 = FOE_SN.setSN2(L1_sn, txb_R.Text, Int32.Parse(txb_quantity.Text), Txt_yy.Text, Txt_ww.Text, dateTimePicker1.Value);

                    for (int i = 0; i < arrSN2.Length; i++) // 檢查產出序號是否存在
                    {
                        string sn_new = arrSN2[i];
                        string sn_SQL = $"SELECT * FROM [MFG_SN].[dbo].[Table_buyShip_SN] WHERE [Ship_SN]='{sn_new}'";

                        DataTable dt = Jonas_SubFunction.JonasSQL.select_Return_DT(connstr_MFG, sn_SQL);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show($"Ship SN {sn_new} 已存在, 請檢查");
                            return;
                        }
                    }

                    txtStartSN2.Text = arrSN2[0];
                    txtEndSN2.Text = arrSN2[arrSN2.Length - 1];
                }
            }
            else
            {
                MessageBox.Show("請填數字");
            }
        }        

        private void btn_build_Click(object sender, EventArgs e)
        {
            if (txb_startSN.Text=="" || txb_endSN.Text == "")
            {
                MessageBox.Show("要先產出 頭尾碼");
                return;
            }
            
            
            DialogResult MsgBoxResult = MessageBox.Show("確定要新增", "確定要新增",
            MessageBoxButtons.YesNo,//定義對話方塊的按鈕，這裡定義了YSE和NO兩個按鈕 
            MessageBoxIcon.Exclamation,//定義對話方塊內的圖表式樣，這裡是一個黃色三角型內加一個感嘆號 
            MessageBoxDefaultButton.Button2);//定義對話方塊的按鈕式樣

            if (MsgBoxResult == DialogResult.No)
            {
                return;
            }


            string connstr = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";
            string selectstr = "INSERT INTO [MFG_SN].[dbo].[Table_buyShip_SN] " +
                    "(Work_Order, Product, YearWeek, Buy, Ship_SN, Date, Note, Operator) VALUES " +
                    "(@Work_Order, @Product, @YearWeek, @Buy, @Ship_SN, @Date, @Note, @Operator)";

            using (SqlConnection openCon = new SqlConnection(connstr))
            using (SqlCommand cmd = new SqlCommand(selectstr, openCon))
            {
                cmd.Parameters.Add("@Work_Order", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Product", SqlDbType.NVarChar);
                cmd.Parameters.Add("@YearWeek", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Buy", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Ship_SN", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime);
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Operator", SqlDbType.NVarChar);

                openCon.Open();

                for (int i = 0; i < arrSN.Length; i++)
                {
                    cmd.Parameters["@Work_Order"].Value = txb_Lot.Text;
                    cmd.Parameters["@Product"].Value = "1";

                    //有些沒用週別
                    if (Cbo_Vendor.Text == "NETGEAR" | Cbo_Vendor.Text == "WAVESPLITTER")
                    {
                        cmd.Parameters["@YearWeek"].Value = Txt_yy.Text + dateTimePicker1.Value.ToString("MM");
                    }
                    else if (Cbo_Vendor.Text == "SolidOptics" | Cbo_Vendor.Text == "ReadyLinks")
                    {
                        cmd.Parameters["@YearWeek"].Value = Txt_yy.Text + dateTimePicker1.Value.ToString("MM")+ dateTimePicker1.Value.ToString("dd");
                    }
                    else
                    {
                        cmd.Parameters["@YearWeek"].Value = Txt_yy.Text + Txt_ww.Text;
                    }                   

                    cmd.Parameters["@Buy"].Value = Cbo_Vendor.Text.Split(':')[0];
                    cmd.Parameters["@Ship_SN"].Value = arrSN[i];
                    cmd.Parameters["@Date"].Value = System.DateTime.Now;
                    cmd.Parameters["@Note"].Value = txb_note1.Text;
                    cmd.Parameters["@Operator"].Value = Input_ID.opid; // 建立出貨序號的OP

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("序號1已新增到資料庫");
                txb_state.Text = "序號1已新增到資料庫";

                // 以下針對有 2 組 SN 的作業 (客戶:LevelOne)
                // A0A2_SN 和 出貨SN 的流水號必須一致
                if (txtStartSN2.Text == "" || txtEndSN2.Text == "")
                {
                    return;
                }

                if (arrSN.Length != arrSN2.Length) // 序號1&2數量必須一致
                {
                    MessageBox.Show("SN和SN2資料的長度不一致");
                    return;
                }

                for (int i = 0; i < arrSN2.Length; i++)
                {
                    cmd.Parameters["@Work_Order"].Value = txb_Lot.Text;
                    cmd.Parameters["@Product"].Value = "1";

                    //有些沒用週別
                    if (Cbo_Vendor.Text == "NETGEAR" | Cbo_Vendor.Text == "WAVESPLITTER")
                    {
                        cmd.Parameters["@YearWeek"].Value = Txt_yy.Text + dateTimePicker1.Value.ToString("MM");
                    }
                    else if (Cbo_Vendor.Text == "SolidOptics" | Cbo_Vendor.Text == "ReadyLinks")
                    {
                        cmd.Parameters["@YearWeek"].Value = Txt_yy.Text + dateTimePicker1.Value.ToString("MM") + dateTimePicker1.Value.ToString("dd");
                    }
                    else
                    {
                        cmd.Parameters["@YearWeek"].Value = Txt_yy.Text + Txt_ww.Text;
                    }

                    cmd.Parameters["@Buy"].Value = Cbo_Vendor.Text.Split(':')[0];
                    cmd.Parameters["@Ship_SN"].Value = arrSN2[i];
                    cmd.Parameters["@Date"].Value = System.DateTime.Now;
                    //cmd.Parameters["@Note"].Value = txb_note1.Text;
                    cmd.Parameters["@Note"].Value = "";
                    cmd.Parameters["@Operator"].Value = Input_ID.opid; // 建立出貨序號的OP

                    cmd.ExecuteNonQuery();
                }

                openCon.Close();

                MessageBox.Show("序號2已新增到資料庫");
                txb_state.Text = "序號2已新增到資料庫";
            }

            
            //MessageBox.Show("已新增到資料庫");
            //txb_state.Text = "已新增到資料庫";
        }


        private void txt93sn_KeyDown(object sender, KeyEventArgs e)
        {
            // 判斷是否按下 Enter 鍵
            if (e.KeyCode == Keys.Enter)
            {

                txt93sn_Search();

                // 防止 Enter 鍵繼續觸發事件
                //e.Handled = true;
            }

        }

        /// <summary>
        /// 檢查93料號格式是否正確
        /// 依照93料號找出廠商[Vendor] 和 產品名稱[product_name]
        /// </summary>
        private void txt93sn_Search()
        {
            txt93sn.Text = txt93sn.Text.Replace(" ", "");

            if (txt93sn.Text.Length != 12)
            {
                MessageBox.Show("93料號長度必須是12字元");
                currentMode = Run_Mode.None;
                return;
            }

            if (txt93sn.Text.Substring(0, 1) != "9")
            {
                MessageBox.Show("93料號錯誤!");
                currentMode = Run_Mode.None;
                return;
            }
            
            string selectstr = $"SELECT [Vendor],[product_name] FROM [MFG_SN].[dbo].[Table_buyShipSN_codingRules] WHERE [93SN] like '%{txt93sn.Text}%'";

            DataTable dt = Jonas_SubFunction.JonasSQL.select_Return_DT(connstr_MFG, selectstr);


            if (dt.Rows.Count == 0)
            {
                //MessageBox.Show("93SN not found !");
                MessageBox.Show("沒有找到此93料號對應的產品,請自行選擇廠商及產品型號");
                currentMode = Run_Mode.Engineering;
                return;
            }
            else
            {
                Cbo_Vendor.Items.Clear();
                Cbo_Vendor.Items.Add(dt.Rows[0]["Vendor"].ToString().Trim());

                Cbo_product_name.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    currentMode = Run_Mode.Production;
                    
                    Cbo_product_name.Items.Add(dt.Rows[i]["product_name"].ToString().Trim());
                }
            }

            

            Cbo_Vendor.SelectedIndex = 0;
            Cbo_product_name.SelectedIndex = 0;
        }

        private void Cbo_tablename_SelectedValueChanged_1(object sender, EventArgs e)
        {
            AllVendor_Import();          

        }

        private void AllVendor_Import()
        {
            //清空
            Cbo_product_name.Items.Clear();
            Cbo_Vendor.Items.Clear();
            Cbo_Vendor.Text = "請選擇.....";
            Cbo_product_name.Text = "";
            txb_quantity.Text = "0";

            //清空   

            string selectstr = $"SELECT DISTINCT [Vendor] FROM [MFG_SN].[dbo].[Table_buyShipSN_codingRules]";

            List<string> mylist = YRSQL.select_return_list(connstr_MFG, selectstr);

            for (int i = 0; i < mylist.Count; i++)
            {
                Cbo_Vendor.Items.Add(mylist[i]);
            }
        }


        private void txb_Lot_KeyDown(object sender, KeyEventArgs e)
        {
            // 判斷是否按下 Enter 鍵
            if (e.KeyCode == Keys.Enter)
            {
                
                //清空
                Lbl_script.Text = "";
                txb_select.Text = "";
                txb_nowR.Text = "";
                txb_R.Text = "";
                txb_startSN.Text = "";
                txb_endSN.Text = "";
                lbl_substr.Text = "";

                txb_note1.Text = "";
                txb_note2.Text = "";
                txb_note3.Text = "";
                txb_note4.Text = "";
                txb_quantity.Text = "0";

                Cbo_Vendor.Items.Clear();
                Cbo_product_name.Items.Clear();
                //清空   

                if (txb_Lot.Text == "" || txb_Lot.Text == "5110-yyyymmddxxx")
                {
                    txb_Lot.Text = "5110-yyyymmddxxx";
                    currentMode = Run_Mode.Engineering;
                }

                WO_Check();

                if (currentMode == Run_Mode.None) return;

                if (currentMode == Run_Mode.Production)
                {
                    // 檢查料號對應的產品資訊
                    txt93sn_Search();
                }

                if (currentMode == Run_Mode.Engineering)
                {
                    // 匯入所有客戶名稱
                    AllVendor_Import();
                }

                // 防止 Enter 鍵繼續觸發事件
                e.Handled = true;
            }

        }

        /// <summary>
        /// 檢查輸入的工單號碼格式是否正確
        /// 依照工單號碼查詢93料號及出貨日期(目前以預計完工日期作為出貨日期)
        /// 工單資訊資訊資料庫及資料表 [FORMERICA].[dbo].[MOCTA]
        /// [TA001]-[TA002] : 工單號
        /// [TA006] : 料號
        /// [TA010] : 出貨日(以這個預計完工日期做為出貨日)
        /// </summary>
        private void WO_Check()
        {
            currentMode = Run_Mode.Engineering;
            txb_Lot.Text = txb_Lot.Text.Replace(" ", "");
            txt93sn.Text = string.Empty;
            Application.DoEvents();

            string[] x = txb_Lot.Text.Split('-');

            if (x[0].Length != 4 || x[1].Length != 11)
            {
                MessageBox.Show("工單號碼長度錯誤");
                currentMode = Run_Mode.None;
                return;
            }

            // 依照工單查詢93料號及出貨日
            string selectstr = $"SELECT [TA006],[TA010] FROM [FORMERICA].[dbo].[MOCTA] WHERE [TA001] = '{x[0]}' and [TA002] = '{x[1]}' ";

            DataTable dt = Jonas_SubFunction.JonasSQL.select_Return_DT(connstr_FORMERICA, selectstr);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show($"無此工單, 請人工選擇");
                currentMode = Run_Mode.Engineering;
                return;
            }

            if (dt.Rows.Count != 1)
            {
                MessageBox.Show($"此工單找到 {dt.Rows.Count} 筆, 請確認");
                currentMode = Run_Mode.None;
                return;
            }

            currentMode = Run_Mode.Production;

            txt93sn.Text = dt.Rows[0]["TA006"].ToString().Trim();

            string shipDate = dt.Rows[0]["TA010"].ToString().Trim();

            if (shipDate == "")
            {
                MessageBox.Show("工單出貨日異常");
                currentMode = Run_Mode.Engineering;
                return;
            }

            dateTimePicker1.Value = DateTime.ParseExact(dt.Rows[0]["TA010"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture);

        }

        /// <summary>
        /// 依據
        /// 文件名稱:levelone(B0138)客制標籤列印圖
        /// 文件編號:B0138-200401
        /// Sheet 5~7
        /// </summary>
        private string LevelOne_SnRule(string _93sn)
        {
            if (_93sn == "9306J0A00559" || _93sn == "9307J0A00459") // DAC-0101
                return "'55114107'+yy+ww+R5";

            else if (_93sn == "9306J0A00659" || _93sn == "9307J0A00559") // DAC-0103
                return "'55114207'+yy+ww+R5";

            else if (_93sn == "9306J0A00759" || _93sn == "9307J0A00659") // DAC-0105
                return "'55114307'+yy+ww+R5";

            else if (_93sn == "9307J0A00759") // DAC-0102
                return "'55114407101'+yy+ww+R5";

            else if (_93sn == "9301S0603301") // AOC-0301
                return "'55115207101'+yy+ww+R5";

            else if (_93sn == "9301S0603401") // AOC-0302
                return "'55115307101'+yy+ww+R5";

            else if (_93sn == "9301S0603501") // AOC-0303
                return "'55115407101'+yy+ww+R5";

            else if (_93sn == "9301T0616701") // AOC-0501
                return "'55115507101'+yy+ww+R5";

            else if (_93sn == "9301T0616801") // AOC-0502
                return "'55115607101'+yy+ww+R5";

            else if (_93sn == "9301T0617001") // AOC-0503
                return "'55115707101'+yy+ww+R5";
            else return "";
        }


        private void Form1_Activated(object sender, EventArgs e)
        {
            txb_Lot.SelectAll();
            txb_Lot.Focus();
        }
    }
}
