using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Jonas_SubFunction;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace MFG_SN_Mapping
{
    public partial class Sn_Mapping : Form
    {
        int row_number = 0;
        private bool suspendSelectionChanged = false;
        string strConn_FOE = "uid=sa;pwd=dsc;database=FormericaOE;server=dataserver";   // 資料庫_FormericaOE
        string strConn_MFGSN = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";      // 資料庫_MFG_SN
        string mfgsn1 = string.Empty;
        string mfgsn2 = string.Empty;
        string shipsn = string.Empty;
        string Mode1 = "1 對 1";
        string Mode2 = "2 對 1";
        string Mode3 = "2 對 A/B 面";
        string SMode = "SN搜尋模式";


        public Sn_Mapping()
        {
            InitializeComponent();

            Init_Dgv();
            Init_Start();
        }

        /// <summary>
        /// 初始值設定
        /// </summary>
        private void Init_Start()
        {
            string[] DB_options = { "自動", "PAM4", "高速", "低速(外購低速)", "外購_QSFP" };

            foreach (string option in DB_options)
            {
                cb_DB.Items.Add(option);
            }
            Application.DoEvents();

            cb_DB.SelectedIndex = 0;
            //cb_Mode.SelectedIndex = 0;
            cb_SortBy.SelectedIndex = 0;
            txtLot.Visible = true;
            /*
            txt_MFG_SN1.Visible = false;
            txt_MFG_SN2.Visible = false;
            txt_Ship_SN.Visible = false;
            */
            cb_Mode.Enabled = true;
            txt_MFG_SN1.Enabled = false;
            txt_MFG_SN2.Enabled = false;
            txt_Ship_SN.Enabled = false;
            txt_MFG_SN1.BackColor = Color.Gray;
            txt_MFG_SN2.BackColor = Color.Gray;
            txt_Ship_SN.BackColor = Color.Gray;
            txtOP.Text = Input_ID.opid;
            LMessage.Text = "請輸入 Lot No ";
        }

        private void Init_Dgv()
        {
            dataGridView1.Rows.Clear(); // 清除所有行
            dataGridView1.Columns.Clear(); // 清除所有列
            row_number = 0;

            dataGridView1.ColumnCount = 4; // 設定 3 個欄位

            dataGridView1.Columns[0].HeaderText = "";
            dataGridView1.Columns[1].HeaderText = "白牌序號";
            dataGridView1.Columns[2].HeaderText = "成品序號";
            dataGridView1.Columns[3].HeaderText = "工號";

            dataGridView1.Columns[0].Width = 50; dataGridView1.Columns[1].Width = 190; dataGridView1.Columns[2].Width = 190; dataGridView1.Columns[3].Width = 135;
            //dataGridView1.Width = 453;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14); // 使用 Arial 字型，大小為 12
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // 設定列標題的字型、大小與粗體
            dataGridView1.ScrollBars = ScrollBars.Vertical;

            // 設定選取模式為整行選取
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        /// <summary>
        /// 白牌序號1 輸入
        /// </summary>
        private void txt_MFG_SN1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                mfgsn1 = txt_MFG_SN1.Text.Replace(" ","").ToUpper();
                txt_MFG_SN1.Text = mfgsn1;
                Refresh();

                // 行前檢查                
                if (mfgsn1 == "")
                {
                    LMessage.Text = "序號不能空白";
                    return;
                }

                LMessage.Text = "";

                if (!MfgSN_Checker(mfgsn1))
                {

                    //LMessage.Text = $"白牌序號{mfgsn1}沒有測試資料";
                    return;
                }
                    
                    


                if (txt_MFG_SN2.Visible == true)
                {
                    txt_MFG_SN2.BackColor = Color.White;
                    Refresh();

                    // 防止 Enter 鍵繼續觸發事件
                    e.Handled = true;

                    txt_MFG_SN2.Text = "";
                    txt_MFG_SN2.BackColor = Color.Yellow;
                    txt_MFG_SN2.Focus();
                    LMessage.Text += "請輸入白牌序號2";

                }
                else
                {
                    txt_Ship_SN.BackColor = Color.White;
                    Refresh();

                    // 防止 Enter 鍵繼續觸發事件
                    e.Handled = true;

                    txt_Ship_SN.Text = "";
                    txt_Ship_SN.BackColor = Color.Yellow;
                    txt_Ship_SN.Focus();
                    LMessage.Text += "請輸入成品序號";
                    //keydown = false;
                }
                txt_MFG_SN1.BackColor = Color.Gray;
            }
        }

        /// <summary>
        /// 白牌序號2 輸入
        /// </summary>
        private void txt_MFG_SN2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mfgsn2 = txt_MFG_SN2.Text.Replace(" ", "").ToUpper();
                txt_MFG_SN2.Text = mfgsn2;
                Refresh();

                // 行前檢查                
                if (mfgsn2 == "")
                {
                    LMessage.Text = "白牌序號 2 不能空白";
                    return;
                }

                if (mfgsn1 == mfgsn2)
                {
                    LMessage.Text = "白牌序號 1/2 重複";
                    return;
                }

                LMessage.Text = "";

                if (!MfgSN_Checker(mfgsn2)) return;

                if (txt_MFG_SN2.Visible == false) txt_MFG_SN1.BackColor = Color.Gray;
                else txt_MFG_SN2.BackColor = Color.Gray;

                txt_Ship_SN.Text = "";
                txt_Ship_SN.BackColor = Color.Yellow;
                txt_Ship_SN.Focus();
                LMessage.Text += "請輸入成品序號\r\n";
            }
        }

        private bool MfgSN_Checker(string sn)
        {
            string strComm = string.Empty;
            List<string> mfgSN;

            LMessage.Text = "";
            
            
            // 如果不是外購則執行
            if (chbOutsource.Checked == false)
            {
                // 查詢資料庫(MFG_SN)/資料表(Table_MFG_SN) 是否有 SN 資料
                strComm = $"select [MFG_SN] from [MFG_SN].[dbo].[Table_MFG_SN] where [MFG_SN] like '{sn}'";
                mfgSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

                if (mfgSN.Count == 0)   // 沒找到 SN
                {
                    LMessage.Text += $"白牌序號 {sn} \r\n不存在,請重新輸入\r\n";
                    return false;
                }
            }

            // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有 SN 資料
            strComm = $"select [MFG_SN] from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [MFG_SN] like '{sn}'";
            mfgSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

            if (mfgSN.Count != 0)   // 有找到 SN
            {
                LMessage.Text += $"白牌序號 {sn} \r\n已對應過,請重新輸入\r\n";
                return false;
            }

            //LMessage.Text += $"白牌序號 {sn} 正常\r\n";


            var PAM4_result = New_FTCheck_PAM4_FinalTest(sn);
            var ATS_FinalTestData = New_FTCheck_ATS_FinalTestData(sn);
            var TRx_FinalTest = New_FTCheck_TRx_FinalTest(sn);
            var QSFP_FinalTest = New_FTCheck_QSFP_FinalTest(sn);
            var OBM_TEST_Data = OBM_TEST(sn);
            var POBM_TEST_Data = POBM_TEST(sn);

            var FastPhotonics_L19_Data = FastPhotonics_L19_TEST(sn);


            if (PAM4_result.Item1 == true && PAM4_result.Item2 == true)
            {
                return true;
            }
            else if (ATS_FinalTestData.Item1 == true && ATS_FinalTestData.Item2 == true)
            {
                return true;
            }

            else if (TRx_FinalTest.Item1 == true && TRx_FinalTest.Item2 == true)
            {
                return true;   
            }

            else if (QSFP_FinalTest.Item1 == true && QSFP_FinalTest.Item2 == true)
            {
                return true;
            }
            else if (OBM_TEST_Data.Item1 == true && OBM_TEST_Data.Item2 == true)
            {
                return true;
            }
            else if (POBM_TEST_Data.Item1 == true && POBM_TEST_Data.Item2 == true)
            {
                return true;
            }
            else if (FastPhotonics_L19_Data.Item1 == true && FastPhotonics_L19_Data.Item2 == true)
            {
                return true;
            }
            else 
            {
                LMessage.Text += $"白牌序號 {sn} 測試異常\r\n請確認資料庫測報\r\n";
                txt_Ship_SN.BackColor = Color.Gray;

                return false;
            }




            //bool find = false;

            ///// 到資料表[PAM4_FinalTest]找測試資料
            ///// 廠內(800G/400G)測試站測試資料
            ////if (find == false && chbOutsource.Checked == false)
            //if (find == false)
            //{
            //    if (FTCheck_PAM4_FinalTest(sn, ref find) == false) // 測試結果 FAIL or 沒有找到測試資料
            //    {
            //        if (find) // 有找到測試資料
            //        {
            //            return false;
            //        }
            //        else // 沒有找到測試資料 : 結束 或是 繼續("自動")
            //        {
            //            if (cb_DB.Text == "PAM4") // 如果選擇的是 PAM4 資料表,則作業結束,不需繼續尋找其他的資料表
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //    else // 測試結果 PASS , 結束搜尋
            //    {
            //        return true;
            //    }
            //}

            ///// 到資料表[ATS_FinalTestData]找測試資料
            ///// 廠內(100G/40G/25G)測試站測試資料
            //if (!find && chbOutsource.Checked == false)
            //{

            //    if (FTCheck_ATS_FinalTestData(sn, ref find) == false) // 測試結果 FAIL or 沒有找到測試資料
            //    {
            //        if (find) // 有找到測試資料
            //        {
            //            return false;
            //        }
            //        else // 沒有找到測試資料 : 結束 或是 繼續("自動")
            //        {
            //            if (cb_DB.Text == "高速") // 如果選擇的是 高速 資料表,則作業結束,不需繼續尋找其他的資料表
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //    else // 測試結果 PASS , 結束搜尋
            //    {
            //        return true;
            //    }
            //}

            ///// 到資料表[TRx_FinalTest]找測試資料
            ///// 和廠內低速和外購nonQSFP(匯入)共用測試資料表
            //if (!find)
            //{

            //    if (FTCheck_TRx_FinalTest(sn, ref find) == false) // 測試結果 FAIL or 沒有找到測試資料
            //    {
            //        if (find) // 有找到測試資料
            //        {
            //            return false;
            //        }
            //        else // 沒有找到測試資料 : 結束 或是 繼續("自動")
            //        {
            //            if (cb_DB.Text == "低速(外購低速)") // 如果選擇的是 低速(外購低速) 資料表,則作業結束,不需繼續尋找其他的資料表
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //    else // 測試結果 PASS , 結束搜尋
            //    {
            //        return true;
            //    }
            //}

            ///// 到資料表[QSFP_FinalTest]找測試資料
            ///// 外購QSFP(匯入)測試資料表
            //if (!find && chbOutsource.Checked == true)
            //{

            //    if (FTCheck_QSFP_FinalTest(sn, ref find) == false) // 測試結果 FAIL or 沒有找到測試資料
            //    {
            //        if (find) // 有找到測試資料
            //        {
            //            return false;
            //        }
            //        else // 沒有找到測試資料 : 結束 或是 繼續("自動")
            //        {
            //            if (cb_DB.Text == "外購_QSFP") // 如果選擇的是 PAM4 資料表,則作業結束,不需繼續尋找其他的資料表
            //            {
            //                return false;
            //            }
            //        }
            //        return false;
            //    }
            //    else // 測試結果 PASS , 結束搜尋
            //    {
            //        return true;
            //    }
            //}

            //LMessage.Text = $"白牌序號 {sn} 測試異常,請確認\r\n";
            //return false;
        }

        private Tuple<bool, bool> New_FTCheck_PAM4_FinalTest(string sn)
        {

            // 取該 sn 的測試溫度有哪些
            string strCom = $"select DISTINCT [Test_Temp] from [FormericaOE].[dbo].[PAM4_FinalTest] where [SN] like '{sn}'";
            List<string> Temperatures = ToolSQL.select_Return_List(strConn_FOE, strCom);

            // 取該 sn 的測試電壓有哪些
            strCom = $"select DISTINCT [Test_Voltage] from [FormericaOE].[dbo].[PAM4_FinalTest] where [SN] like '{sn}'";
            List<string> Voltages = ToolSQL.select_Return_List(strConn_FOE, strCom);

            // 取該 sn 的測試Channel有哪些
            strCom = $"select DISTINCT [Channel] from [FormericaOE].[dbo].[PAM4_FinalTest] where [SN] like '{sn}'";
            List<string> Channels = ToolSQL.select_Return_List(strConn_FOE, strCom);

            if (Temperatures.Count == 0 || Voltages.Count == 0 || Channels.Count == 0)
            {

                return new Tuple<bool, bool>(false, false);
            }

            foreach (var Channel in Channels)
            {
                foreach (var Voltage in Voltages)
                {
                    foreach (var Temperature in Temperatures)
                    {
                        strCom = $"select top(1) [PassFail] from [FormericaOE].[dbo].[PAM4_FinalTest] where [SN] like '{sn}' and [Channel] = '{Channel}' and [Test_Voltage] = '{Voltage}' and [Test_Temp] = '{Temperature}' order by [TestTime] desc";
                        List<string> PassFail = ToolSQL.select_Return_List(strConn_FOE, strCom);

                        if (PassFail[0].ToUpper().Replace(" ", "") != "PASS")
                        {
                            LMessage.Text += $"PAM4_FinalTest\r\nChannel={Channel}  ,Volt={Voltage}  ,Temperature={Temperature}  測試資料 FAIL\r\n";
                            Refresh();
                            return new Tuple<bool, bool>(true, false);
                        }
                    }
                }
            }
            LMessage.Text += $"測試資料 PASS\r\nPAM4_FinalTest\r\n";
            Refresh();
            return new Tuple<bool, bool>(true, true);
        }
        /// <summary>
        /// PAM4_FinalTest 資料表
        /// 400G/800G FT Data
        /// 結果 1(Find=true ,Result=true)   ==> 有找到測試資料,測試PASS
        /// 結果 2(Find=true ,Result=false)  ==> 有找到測試資料,測試FAIL
        /// 結果 3(Find=false,Result=false)  ==> 沒找到測試資料
        /// </summary>
        /// 

        //private bool FTCheck_PAM4_FinalTest(string sn, ref bool find)
        //{
        //    //bool result = true;

        //    if (cb_DB.Text == "自動" || cb_DB.Text == "PAM4")
        //    {
        //        // 取該 sn 的測試溫度有哪些
        //        string strCom = $"select DISTINCT [Test_Temp] from [FormericaOE].[dbo].[PAM4_FinalTest] where [SN] like '{sn}'";
        //        List<string> Temperatures = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        // 取該 sn 的測試電壓有哪些
        //        strCom = $"select DISTINCT [Test_Voltage] from [FormericaOE].[dbo].[PAM4_FinalTest] where [SN] like '{sn}'";
        //        List<string> Voltages = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        // 取該 sn 的測試Channel有哪些
        //        strCom = $"select DISTINCT [Channel] from [FormericaOE].[dbo].[PAM4_FinalTest] where [SN] like '{sn}'";
        //        List<string> Channels = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        if (Temperatures.Count == 0 || Voltages.Count == 0 || Channels.Count == 0)
        //        {
        //            if (cb_DB.Text != "自動")
        //            {
        //                LMessage.Text += $"白牌序號 {sn} 測試異常,請確認\r\n";
        //            }
        //            return false;
        //        }

        //        find = true;
        //        LMessage.Text += "PAM4\r\n";

        //        foreach (var Channel in Channels)
        //        {
        //            foreach (var Voltage in Voltages)
        //            {
        //                foreach (var Temperature in Temperatures)
        //                {
        //                    strCom = $"select top(1) [PassFail] from [FormericaOE].[dbo].[PAM4_FinalTest] where [SN] like '{sn}' and [Channel] = '{Channel}' and [Test_Voltage] = '{Voltage}' and [Test_Temp] = '{Temperature}' order by [TestTime] desc";
        //                    List<string> PassFail = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //                    if (PassFail[0].ToUpper().Replace(" ","") != "PASS")
        //                    {
        //                        LMessage.Text += $"Channel={Channel}  ,Volt={Voltage}  ,Temperature={Temperature}  測試資料 FAIL\r\n";
        //                        Refresh();
        //                        return false;
        //                    }
        //                }
        //            }
        //        }
        //        LMessage.Text += $"測試資料 PASS\r\n";
        //        Refresh();
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// ATS_FinalTestData 資料表
        /// 100G/40G/25G FT Data
        /// </summary>
        //private bool FTCheck_ATS_FinalTestData(string sn,ref bool find)
        //{
        //    //bool result = true;

        //    if (cb_DB.Text == "自動" || cb_DB.Text == "高速")   // 廠內高速
        //    {
        //        // 取該 sn 的測試溫度有哪些
        //        string strCom = $"select DISTINCT [Test_Temp] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Test_Temp] != '' and [Test_Voltage] !='' and [Channel] != ''";
        //        List<string> Temperatures = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        // 取該 sn 的測試電壓有哪些
        //        strCom = $"select DISTINCT [Test_Voltage] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Test_Temp] != '' and [Test_Voltage] !='' and [Channel] != ''";
        //        List<string> Voltages = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        // 取該 sn 的測試Channel有哪些
        //        strCom = $"select DISTINCT [Channel] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Test_Temp] != '' and [Test_Voltage] !='' and [Channel] != ''";
        //        List<string> Channels = ToolSQL.select_Return_List(strConn_FOE, strCom);
        //        /*
        //        if ((Temperatures.Count == 0 || Voltages.Count ==0) && cb_DB.Text != "自動")
        //        {
        //            LMessage.Text = $"白牌序號 {sn} \r\n無測試資料,請重新輸入\r\n";
        //            return false;
        //        }*/

        //        if (Temperatures.Count == 0 || Voltages.Count == 0 || Channels.Count == 0)
        //        {
        //            if (cb_DB.Text != "自動")
        //            {
        //                LMessage.Text += $"白牌序號 {sn} 測試異常,請確認\r\n";
        //            }
        //            return false;
        //        }

        //        find = true;

        //        foreach (var Channel in Channels)
        //        {
        //            foreach (var Voltage in Voltages)
        //            {
        //                foreach (var Temperature in Temperatures)
        //                {
        //                    strCom = $"select top(1) [Total_Pass] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Channel] = '{Channel}' and [Test_Voltage] = '{Voltage}' and [Test_Temp] = '{Temperature}' order by [Test_time] desc";
        //                    List<string> PassFail = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //                    if (PassFail.Count != 0)
        //                    {
        //                        if (PassFail[0].ToUpper().Replace(" ", "") != "PASS")
        //                        {
        //                            LMessage.Text = $"Channel={Channel}  ,Volt={Voltage}  ,Temperature={Temperature}  測試資料 Fail ";
        //                            Refresh();
        //                            return false;
        //                        }
        //                    }
                            
        //                }
        //            }
        //        }
        //        LMessage.Text += $"測試資料 PASS\r\n";
        //        Refresh();
        //        return true;

        //    }
        //    return false;
        //}
        private Tuple<bool, bool> New_FTCheck_ATS_FinalTestData(string sn)
        {

            {
                // 取該 sn 的測試溫度有哪些
                string strCom = $"select DISTINCT [Test_Temp] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Test_Temp] != '' and [Test_Voltage] !='' and [Channel] != ''";
                List<string> Temperatures = ToolSQL.select_Return_List(strConn_FOE, strCom);

                // 取該 sn 的測試電壓有哪些
                strCom = $"select DISTINCT [Test_Voltage] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Test_Temp] != '' and [Test_Voltage] !='' and [Channel] != ''";
                List<string> Voltages = ToolSQL.select_Return_List(strConn_FOE, strCom);

                // 取該 sn 的測試Channel有哪些
                strCom = $"select DISTINCT [Channel] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Test_Temp] != '' and [Test_Voltage] !='' and [Channel] != ''";
                List<string> Channels = ToolSQL.select_Return_List(strConn_FOE, strCom);
                

                if (Temperatures.Count == 0 || Voltages.Count == 0 || Channels.Count == 0)
                {
                    //if (cb_DB.Text != "自動")
                    //{
                        //LMessage.Text += $"白牌序號 {sn} 測試異常,請確認ATS\r\nATS_FinalTestData";
                    //}
                        return new Tuple<bool, bool>(false, false);
                }


                foreach (var Channel in Channels)
                {
                    foreach (var Voltage in Voltages)
                    {
                        foreach (var Temperature in Temperatures)
                        {
                            strCom = $"select top(1) [Total_Pass] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Channel] = '{Channel}' and [Test_Voltage] = '{Voltage}' and [Test_Temp] = '{Temperature}' order by [Test_time] desc";
                            List<string> PassFail = ToolSQL.select_Return_List(strConn_FOE, strCom);

                            if (PassFail.Count != 0)
                            {
                                if (PassFail[0].ToUpper().Replace(" ", "") != "PASS")
                                {
                                    LMessage.Text += $"ATS_FinalTestData\r\nChannel={Channel}  ,Volt={Voltage}  ,Temperature={Temperature}  測試資料 Fail \r\n";
                                    Refresh();
                                    return new Tuple<bool, bool>(true, false);
                                }
                            }

                        }
                    }
                }
                LMessage.Text += $"測試資料 PASS\r\nATS_FinalTestData\r\n";
                Refresh();
                return new Tuple<bool, bool>(true, true);

            }
        }
        //private bool FTCheck_ATS_FinalTestData_OLD(string sn, ref bool find)
        //{
        //    bool result = true;

        //    if (cb_DB.Text == "自動" || cb_DB.Text == "高速")   // 廠內高速
        //    {
        //        string strCom = $"select [Total_Pass] from [FormericaOE].[dbo].[ATS_FinalTestData] where [SN] like '{sn}' and [Test_Temp] != ''";
        //        List<string> total_Pass = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        if (total_Pass.Count == 0 && cb_DB.Text != "自動")
        //        {
        //            LMessage.Text = $"白牌序號 {sn} \r\n無高速測試資料,請重新輸入\r\n";
        //            return false;
        //        }

        //        if (total_Pass.Count != 0)  // 在高速站終測找到資料
        //        {
        //            find = true;
        //            foreach (var x in total_Pass)
        //            {
        //                if (x.Trim().ToUpper() != "PASS") result = false;
        //                //MessageBox.Show(x);
        //            }

        //            if (result == false)
        //            {
        //                LMessage.Text = LMessage.Text + $"高速測試結果 Fail\r\n";
        //                txt_MFG_SN1.Text = "";
        //                return false;
        //            }
        //            else
        //            {
        //                LMessage.Text = LMessage.Text + $"高速測試結果 Pass\r\n";
        //                //return;
        //            }
        //        }

        //    }
        //    return true;
        //}

        /// <summary>
        /// TRx_FinalTest 資料表
        /// 10G/1G FT Data
        /// 外購產品資料匯入
        /// </summary>
        //private bool FTCheck_TRx_FinalTest(string sn, ref bool find)
        //{
        //    //bool result = true;

        //    if (cb_DB.Text == "自動" || cb_DB.Text == "低速(外購低速)")   // 廠內高速
        //    {
        //        // 取該 sn 的測試溫度有哪些
        //        string strCom = $"select DISTINCT [Temperature] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}'";
        //        List<string> Temperatures = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        // 取該 sn 的測試電壓有哪些
        //        strCom = $"select DISTINCT [Volt] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}'";
        //        List<string> Voltages = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        if (Temperatures.Count == 0 || Voltages.Count == 0)
        //        {
        //            if (cb_DB.Text != "自動")
        //                LMessage.Text = $"白牌序號 {sn} 測試異常,請確認\r\n";
        //            return false;
        //        }

        //        find = true;

        //        foreach (var Voltage in Voltages)
        //        {
        //            foreach (var Temperature in Temperatures)
        //            {
        //                strCom = $"select top(1) [Tx_PF] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}' and [Volt] = '{Voltage}' and [Temperature] = '{Temperature}' order by [Test_Date] desc,[Test_time] desc";
        //                List<string> Tx_PF = ToolSQL.select_Return_List(strConn_FOE, strCom);
        //                strCom = $"select top(1) [Rx_PF] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}' and [Volt] = '{Voltage}' and [Temperature] = '{Temperature}' order by [Test_Date] desc,[Test_time] desc";
        //                List<string> Rx_PF = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //                if (Tx_PF[0].ToUpper().Replace(" ","") != "PASS" || Rx_PF[0].ToUpper().Replace(" ","") != "PASS")
        //                {
        //                    LMessage.Text = $"Volt={Voltage}  Temperature={Temperature}  測試資料 Fail ";
        //                    Refresh();
        //                    return false;
        //                }
        //            }
        //        }
        //        LMessage.Text += $"測試資料 PASS\r\n";
        //        Refresh();
        //        return true;
        //    }
        //    return false;
        //}

        private Tuple<bool, bool> New_FTCheck_TRx_FinalTest(string sn)
        {

            //if (cb_DB.Text == "自動" || cb_DB.Text == "低速(外購低速)")   // 廠內高速
            {
                // 取該 sn 的測試溫度有哪些
                string strCom = $"select DISTINCT [Temperature] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}'";
                List<string> Temperatures = ToolSQL.select_Return_List(strConn_FOE, strCom);

                // 取該 sn 的測試電壓有哪些
                strCom = $"select DISTINCT [Volt] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}'";
                List<string> Voltages = ToolSQL.select_Return_List(strConn_FOE, strCom);


                if (Temperatures.Count == 0 || Voltages.Count == 0)
                {
                    //LMessage.Text = $"白牌序號 {sn} 測試異常,請確認\r\nTemperatures.Count == 0 || Voltages.Count == 0\r\nTRx_FinalTest";
                    return new Tuple<bool, bool>(false, false);
                }


                foreach (var Voltage in Voltages)
                {
                    foreach (var Temperature in Temperatures)
                    {
                        strCom = $"select top(1) [Tx_PF] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}' and [Volt] = '{Voltage}' and [Temperature] = '{Temperature}' order by [Test_Date] desc,[Test_time] desc";
                        List<string> Tx_PF = ToolSQL.select_Return_List(strConn_FOE, strCom);
                        strCom = $"select top(1) [Rx_PF] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}' and [Volt] = '{Voltage}' and [Temperature] = '{Temperature}' order by [Test_Date] desc,[Test_time] desc";
                        List<string> Rx_PF = ToolSQL.select_Return_List(strConn_FOE, strCom);

                        if (Tx_PF[0].ToUpper().Replace(" ", "") != "PASS" || Rx_PF[0].ToUpper().Replace(" ", "") != "PASS")
                        {
                            LMessage.Text += $"TRx_FinalTest\r\nVolt={Voltage}  Temperature={Temperature}  測試資料 Fail\r\n";
                            Refresh();
                            return new Tuple<bool, bool>(true, false);
                        }
                    }
                }
                LMessage.Text += $"測試資料 PASS\r\nTRx_FinalTest\r\n";
                Refresh();
                return new Tuple<bool, bool>(true, true);
            }
            
        }
        //private bool FTCheck_TRx_FinalTest_OLD(string sn, ref bool find)
        //{
        //    bool result = true;

        //    if (cb_DB.Text == "自動" || cb_DB.Text == "低速(外購低速)") // 廠內低速和 外購_nonQSFP 使用同一個資料表
        //    {
        //        string strCommHiFT = $"select [Tx_PF] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}' and [Temperature] != ''";
        //        List<string> txPass = ToolSQL.select_Return_List(strConn_FOE, strCommHiFT);

        //        if (txPass.Count == 0 && cb_DB.Text != "自動")
        //        {
        //            LMessage.Text = $"白牌序號 {sn} \r\n無低速TX測試資料,請重新輸入";
        //            return false;
        //        }

        //        if (txPass.Count != 0)  // 在低速站終測找到 TX 資料
        //        {
        //            find = true;
        //            foreach (var x in txPass)
        //            {
        //                if (x.Trim().ToUpper() != "PASS") result = false;
        //                //MessageBox.Show(x);
        //            }

        //            if (result == false)
        //            {
        //                LMessage.Text = $"白牌序號 {sn} \r\n低速測試 TX_Fail\r\n";
        //                return false;
        //            }
        //            else
        //            {
        //                LMessage.Text = $"白牌序號 {sn} \r\n低速測試 TX_PASS\r\n";
        //            }
        //        }

        //        string strCommLoFT = $"select [Rx_PF] from [FormericaOE].[dbo].[TRx_FinalTest] where [SN] like '{sn}' and [Temperature] != ''";
        //        List<string> rxPass = ToolSQL.select_Return_List(strConn_FOE, strCommLoFT);

        //        if (rxPass.Count == 0 && cb_DB.Text != "自動")
        //        {
        //            LMessage.Text = $"白牌序號 {sn} \r\n無低速RX測試資料,請重新輸入\r\n";
        //            return false;
        //        }

        //        if (rxPass.Count != 0)  // 在低速站終測找到 RX 資料
        //        {
        //            foreach (var x in rxPass)
        //            {
        //                if (x.Trim().ToUpper() != "PASS") result = false;
        //                //MessageBox.Show(x);
        //            }

        //            if (result == false)
        //            {
        //                LMessage.Text = LMessage.Text + $"低速測試 RX_Fail\r\n";
        //                return false;
        //            }
        //            else
        //            {
        //                LMessage.Text = LMessage.Text + $"低速測試 RX_PASS\r\n";

        //                if (find == false)
        //                {
        //                    LMessage.Text += $"缺TX測試資料,請重新輸入\r\n";
        //                    return false;
        //                }
        //            }
        //        }
        //        else result = false;
        //    }

        //    return true;
        //}

        /// <summary>
        /// QSFP_FinalTest 資料表
        /// 外購產品資料匯入
        /// </summary>

        private Tuple<bool, bool> New_FTCheck_QSFP_FinalTest(string sn)
        {

            {
                // 取該 sn 的測試溫度有哪些
                string strCom = $"select DISTINCT [Temperature] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}'";
                List<string> Temperatures = ToolSQL.select_Return_List(strConn_FOE, strCom);

                // 取該 sn 的測試電壓有哪些
                strCom = $"select DISTINCT [Volt] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}'";
                List<string> Voltages = ToolSQL.select_Return_List(strConn_FOE, strCom);

                // 取該 sn 的測試Channel有哪些
                strCom = $"select DISTINCT [Channel] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}'";
                List<string> Channels = ToolSQL.select_Return_List(strConn_FOE, strCom);

                if (Temperatures.Count == 0 || Voltages.Count == 0 || Channels.Count == 0)
                {
                    //LMessage.Text = $"白牌序號 {sn} 測試異常,請確認\r\nQSFP_FinalTest";
                    return new Tuple<bool, bool>(false, false);
                }

                foreach (var Channel in Channels)
                {
                    foreach (var Voltage in Voltages)
                    {
                        foreach (var Temperature in Temperatures)
                        {
                            strCom = $"select top(1) [Tx_PF] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}' and [Channel] = '{Channel}' and [Volt] = '{Voltage}' and [Temperature] = '{Temperature}' order by [Test_Date],[Test_Time] desc";
                            List<string> Tx_PF = ToolSQL.select_Return_List(strConn_FOE, strCom);

                            strCom = $"select top(1) [Rx_PF] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}' and [Channel] = '{Channel}' and [Volt] = '{Voltage}' and [Temperature] = '{Temperature}' order by [Test_Date],[Test_Time] desc";
                            List<string> Rx_PF = ToolSQL.select_Return_List(strConn_FOE, strCom);

                            if (Tx_PF[0].ToUpper().Replace(" ", "") != "PASS" || Rx_PF[0].ToUpper().Replace(" ", "") != "PASS")
                            {
                                LMessage.Text += $"QSFP_FinalTest\r\nChannel={Channel}  ,Volt={Voltage}  ,Temperature={Temperature}  測試資料 Fail\r\n";
                                Refresh();
                                return new Tuple<bool, bool>(true, false);
                            }
                        }
                    }
                }
                LMessage.Text += $"測試資料 PASS\r\nQSFP_FinalTest\r\n";
                Refresh();
                return new Tuple<bool, bool>(true, true);

            }
        }
        //private bool FTCheck_QSFP_FinalTest(string sn, ref bool find)
        //{
        //    //bool result = true;

        //    if (cb_DB.Text == "自動" || cb_DB.Text == "高速")   // 廠內高速
        //    {
        //        // 取該 sn 的測試溫度有哪些
        //        string strCom = $"select DISTINCT [Temperature] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}'";
        //        List<string> Temperatures = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        // 取該 sn 的測試電壓有哪些
        //        strCom = $"select DISTINCT [Volt] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}'";
        //        List<string> Voltages = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        // 取該 sn 的測試Channel有哪些
        //        strCom = $"select DISTINCT [Channel] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}'";
        //        List<string> Channels = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //        if (Temperatures.Count == 0 || Voltages.Count == 0 || Channels.Count == 0)
        //        {
        //            LMessage.Text = $"白牌序號 {sn} 測試異常,請確認\r\n";
        //            return false;
        //        }


        //       find = true;

        //        foreach (var Channel in Channels)
        //        {
        //            foreach (var Voltage in Voltages)
        //            {
        //                foreach (var Temperature in Temperatures)
        //                {
        //                    strCom = $"select top(1) [Tx_PF] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}' and [Channel] = '{Channel}' and [Volt] = '{Voltage}' and [Temperature] = '{Temperature}' order by [Test_Date],[Test_Time] desc";
        //                    List<string> Tx_PF = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //                    strCom = $"select top(1) [Rx_PF] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}' and [Channel] = '{Channel}' and [Volt] = '{Voltage}' and [Temperature] = '{Temperature}' order by [Test_Date],[Test_Time] desc";
        //                    List<string> Rx_PF = ToolSQL.select_Return_List(strConn_FOE, strCom);

        //                    if (Tx_PF[0].ToUpper().Replace(" ","") != "PASS" || Rx_PF[0].ToUpper().Replace(" ","") != "PASS")
        //                    {
        //                        LMessage.Text = $"Channel={Channel}  ,Volt={Voltage}  ,Temperature={Temperature}  測試資料 Fail ";
        //                        Refresh();
        //                        return false;
        //                    }
        //                }
        //            }
        //        }
        //        LMessage.Text += $"測試資料 PASS\r\n";
        //        Refresh();
        //        return true;

        //    }
        //    return false;
        //}

        //private bool FTCheck_QSFP_FinalTest_OLD(string sn, ref bool find)
        //{
        //    bool result = true;

        //    if (cb_DB.Text == "自動" || cb_DB.Text == "外購_QSFP") // 外購_QSFP 使用資料表 [dbo].[QSFP_FinalTest]
        //    {
        //        string strCommHiFT = $"select [Tx_PF] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}' and [Temperature] != ''";
        //        List<string> txPass = ToolSQL.select_Return_List(strConn_FOE, strCommHiFT);

        //        if (txPass.Count == 0 && cb_DB.Text != "自動")
        //        {
        //            LMessage.Text = $"白牌序號 {sn} \r\n無外購_QSFP TX測試資料,請重新輸入";
        //            return false;
        //        }

        //        if (txPass.Count != 0)  // 在外購_QSFP 終測找到資料
        //        {
        //            find = true;

        //            if (result == false)
        //            {
        //                LMessage.Text = $"白牌序號 {sn} \r\n外購_QSFP測試 TX_Fail\r\n";
        //                return false;
        //            }
        //            else
        //            {
        //                LMessage.Text = $"白牌序號 {sn} \r\n外購_QSFP測試 TX_PASS\r\n";
        //            }
        //        }

        //        string strCommLoFT = $"select [Rx_PF] from [FormericaOE].[dbo].[QSFP_FinalTest] where [SN] like '{sn}' and [Temperature] != ''";
        //        List<string> rxPass = ToolSQL.select_Return_List(strConn_FOE, strCommLoFT);

        //        if (rxPass.Count == 0 && cb_DB.Text == "外購_QSFP")
        //        {
        //            LMessage.Text = $"白牌序號 {sn} \r\n無外購_QSFP RX測試資料,請重新輸入\r\n";
        //            return false;
        //        }

        //        if (rxPass.Count != 0)
        //        {

        //            if (result == false)
        //            {
        //                LMessage.Text = LMessage.Text + $"外購_QSFP測試 RX_Fail\r\n";
        //                return false;
        //            }
        //            else
        //            {
        //                LMessage.Text = LMessage.Text + $"外購_QSFP測試 RX_PASS\r\n";
        //                if (find == false)
        //                {
        //                    LMessage.Text += $"缺TX測試資料,請重新輸入\r\n";
        //                    return false;
        //                }
        //            }
        //        }
        //        else result = false;

        //    }

        //    return true;
        //}



        private Tuple<bool, bool> POBM_TEST(string sn)
        {
            //bool result = true;
            //[Left_switch_status],[Right_switch_status]
            //[FormericaOE].[dbo].[POBM_Test]
            string A850 = "850";
            string B850 = "850";
            string A1310 = "1310";
            string B1310 = "1310";
            {
                // 取該 sn 的Left_switch_status ,850nm
                //將 TemperLeft_switch_statusatures_850nm 的value 存入 List裡面  
                string strCom = $"select DISTINCT [Left_switch_status] from [FormericaOE].[dbo].[POBM_Test] where [SN] like '{sn}' and [Wavelength] like'{A850}'";
                List<string> Left_switch_statusatures_850nm = ToolSQL.select_Return_List(strConn_FOE, strCom);
                // 取該 sn 的Right_switch_status ,850nm
                //將 Right_switch_status_850nm的 Value 存入 List裡面  
                strCom = $"select DISTINCT [Right_switch_status] from [FormericaOE].[dbo].[POBM_Test] where [SN] like '{sn}' and [Wavelength] like '{B850}'";
                List<string> Right_switch_status_850nm = ToolSQL.select_Return_List(strConn_FOE, strCom);
                // 取該 sn 的Left_switch_status ,1310nm
                //將TemperLeft_switch_statusatures_1310nm 的value 存入 List裡面  
                strCom = $"select DISTINCT [Left_switch_status] from [FormericaOE].[dbo].[POBM_Test] where [SN] like '{sn}' and [Wavelength] like'{A1310}'";
                List<string> Left_switch_statusatures_1310nm = ToolSQL.select_Return_List(strConn_FOE, strCom);
                // 取該 sn 的Right_switch_status ,1310nm
                //將Right_switch_status_1310nm的value 存入 List裡面  
                strCom = $"select DISTINCT [Right_switch_status] from [FormericaOE].[dbo].[POBM_Test] where [SN] like '{sn}' and [Wavelength] like '{B1310}'";
                List<string> Right_switch_status_1310nm = ToolSQL.select_Return_List(strConn_FOE, strCom);
                //情況一 根本不會跳到這邊 因都搜尋到SN了  測報格式都是固定的 數量基本上不會是0
                //情況二 return false  ,LMessage 的文字被覆蓋掉了
                if (Left_switch_statusatures_850nm.Count == 0 || Right_switch_status_850nm.Count == 0 || Left_switch_statusatures_1310nm.Count == 0 || Right_switch_status_1310nm.Count == 0)
                {
                    //LMessage.Text = $"白牌序號 {sn} 測試異常,請確認1POBM_TEST(!!找不到測報OR 測報PASS 數量異常)";
                    return new Tuple<bool, bool>(false, false);
                }

                foreach (var Right_switch_status_850nms in Right_switch_status_850nm)
                {
                    foreach (var Left_switch_statusatures_850nms in Left_switch_statusatures_850nm)
                    {
                        foreach (var Right_switch_status_1310nms in Right_switch_status_1310nm)
                        {
                            foreach (var Left_switch_statusatures_1310nms in Left_switch_statusatures_1310nm)
                            {
                                strCom = $"select top(1) [Left_switch_status] from [FormericaOE].[dbo].[POBM_Test] where [SN] like '{sn}' and [Wavelength] like'{A850}' ";
                                List<string> Left_switch_status_850nm = ToolSQL.select_Return_List(strConn_FOE, strCom);

                                strCom = $"select top(1) [Right_switch_status] from [FormericaOE].[dbo].[POBM_Test] where [SN] like '{sn}' and [Wavelength] like'{A850}'";
                                List<string> Right_switch_statuss_850nm = ToolSQL.select_Return_List(strConn_FOE, strCom);

                                strCom = $"select top(1) [Left_switch_status] from [FormericaOE].[dbo].[POBM_Test] where [SN] like '{sn}' and [Wavelength] like'{A1310}'";
                                List<string> Left_switch_status_1310nm = ToolSQL.select_Return_List(strConn_FOE, strCom);

                                strCom = $"select top(1) [Right_switch_status] from [FormericaOE].[dbo].[POBM_Test] where [SN] like '{sn}' and [Wavelength] like'{B1310}'";
                                List<string> Left_switch_status_1310nms = ToolSQL.select_Return_List(strConn_FOE, strCom);

                                //POBM 要加東西 Wavelength 有850 跟1310 所以要檢查的有兩行 一行 有兩個pass  共四個pass
                                if (Left_switch_status_850nm[0].ToUpper().Replace(" ", "") != "PASS" || Right_switch_statuss_850nm[0].ToUpper().Replace(" ", "") != "PASS" || Left_switch_status_1310nm[0].ToUpper().Replace(" ", "") != "PASS" || Left_switch_status_1310nms[0].ToUpper().Replace(" ", "") != "PASS")
                                {
                                    LMessage.Text = $"POBM_Test\r\n測試資料 Fail\r\nLeft_switch_status_850nm={Left_switch_statusatures_850nms}\r\nRight_switch_statuss_850nm={Right_switch_status_850nms}\r\nLeft_switch_status_1310nm={Left_switch_statusatures_1310nms}\r\nRight_switch_status_1310nm={Right_switch_status_1310nms}\r\n測試資料 Fail\r\n ";
                                    Refresh();
                                    return new Tuple<bool, bool>(true, false);
                                }
                            }
                        }
                    }
                }
                LMessage.Text += $"測試資料 PASS\r\n POBM_Test\r\n";
                Refresh();
                return new Tuple<bool, bool>(true, true);
            }
        }


        private Tuple<bool, bool> OBM_TEST(string sn)
        {
            //bool result = true;

            //if (cb_DB.Text == "OBM")
            {
                //LED_staus,Left_switch_status,Right_switch_status                

                // 參考舊的
                // 取該 sn 的LED_staus
                //將[LED_staus] 寫到 list  LED_stauss 裡面
                string strCom = $"select DISTINCT [LED_staus] from [FormericaOE].[dbo].[OBM_extradata] where [SN] like '{sn}'";
                List<string> LED_stauss = ToolSQL.select_Return_List(strConn_FOE, strCom);
                // 取該 sn 的Left_switch_status
                //將[Left_switch_status] 寫到 list  Left_switch_statuss 裡面
                strCom = $"select DISTINCT [Left_switch_status] from [FormericaOE].[dbo].[OBM_extradata] where [SN] like '{sn}'";
                List<string> Left_switch_statuss = ToolSQL.select_Return_List(strConn_FOE, strCom);
                // 取該 sn 的 Right_switch_status
                //將[Right_switch_status] 寫到 list  Right_switch_statuss 裡面
                strCom = $"select DISTINCT [Right_switch_status] from [FormericaOE].[dbo].[OBM_extradata] where [SN] like '{sn}'";
                List<string> Right_switch_statuss = ToolSQL.select_Return_List(strConn_FOE, strCom);

                //情況一 根本不會跳到這邊 因都搜尋到SN了  測報格式都是固定的 數量基本上不會是0
                //情況二 return false  ,LMessage 的文字被覆蓋掉了

                if (LED_stauss.Count == 0 || Left_switch_statuss.Count == 0 || Right_switch_statuss.Count == 0)
                {
                    //LMessage.Text = $"白牌序號 {sn} 測試異常,請確認\r\nOBM_TEST";
                    return new Tuple<bool, bool>(false, false);
                }

                //LED_staus,Left_switch_status,Right_switch_status

                //透過三個迴圈 分別檢查 那三個欄位 是否為PASS
                foreach (var Right_switch_status in Right_switch_statuss)
                {
                    foreach (var Left_switch_status in Left_switch_statuss)
                    {
                        foreach (var LED_staus in LED_stauss)
                        {
                            strCom = $"select top(1) [LED_staus] from [FormericaOE].[dbo].[OBM_extradata] where [SN] like '{sn}'";
                            List<string> LED_staus_num = ToolSQL.select_Return_List(strConn_FOE, strCom);

                            strCom = $"select top(1) [Left_switch_status] from [FormericaOE].[dbo].[OBM_extradata] where [SN] like '{sn}'";
                            List<string> Left_switch_status_num = ToolSQL.select_Return_List(strConn_FOE, strCom);

                            strCom = $"select top(1) [Right_switch_status] from [FormericaOE].[dbo].[OBM_extradata] where [SN] like '{sn}'";
                            List<string> Right_switch_status_num = ToolSQL.select_Return_List(strConn_FOE, strCom);

                            //分別檢查 那三個欄位 是否都為PASS
                            if (LED_staus_num[0].ToUpper().Replace(" ", "") != "PASS" || Left_switch_status_num[0].ToUpper().Replace(" ", "") != "PASS" || Right_switch_status_num[0].ToUpper().Replace(" ", "") != "PASS")
                            {
                                LMessage.Text += $"OBM_extradata\r\nLED_staus={LED_staus}  ,Left_switch_status={Left_switch_status}  ,Right_switch_status={Right_switch_status}\r\n測試資料 Fail \r\n";
                                Refresh();
                                return new Tuple<bool, bool>(true, false);
                            }
                        }
                    }
                }
                //LMessage.Text += $"測試資料 PASS\r\n";
                LMessage.Text += $"測試資料 PASSS\r\nOBM_extradata\r\n";
                Refresh();
                return new Tuple<bool, bool>(true, true);

            }
        }

        private Tuple<bool, bool>FastPhotonics_L19_TEST (string sn)
        {

            string strCom = $"select DISTINCT [ch] from [FormericaOE].[dbo].[FastPhotonics_L19] where [SN] like '{sn}'";
            List<string> Channels = ToolSQL.select_Return_List(strConn_FOE, strCom);

            if (Channels.Count == 0)
            {

                return new Tuple<bool, bool>(false, false);
            }

            foreach (var Channel in Channels)
            {
                        strCom = $"select top(1) [PassFail] from [FormericaOE].[dbo].[FastPhotonics_L19] where [SN] like '{sn}' and [ch] = '{Channel}' order by[Test_Date] desc,[Test_time] desc"; 
                        List<string> PassFail = ToolSQL.select_Return_List(strConn_FOE, strCom);

                        if (PassFail[0].ToUpper().Replace(" ", "") != "PASS")
                        {
                            LMessage.Text += $"FastPhotonics_L19\r\nch={Channel} 測試資料 FAIL\r\n";
                            Refresh();
                            return new Tuple<bool, bool>(true, false);
                        }
                
            }
            LMessage.Text += $"測試資料 PASS\r\nFastPhotonics_L19\r\n";
            Refresh();
            return new Tuple<bool, bool>(true, true);
        }
        /// <summary>
        /// 成品序號 (出貨序號) 輸入
        /// </summary>
        private void txt_Ship_SN_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                shipsn = txt_Ship_SN.Text.Trim().ToUpper();
                txt_Ship_SN.Text = shipsn;

                // 行前檢查
                if (shipsn == "")
                {
                    LMessage.Text = "成品序號不能空白";
                    return;
                }

                LMessage.Text = "";

                //bool Test = true;
                if (cb_Mode.Text == Mode3)  // 2 對 A/B 面
                {
                    if (!ShipSN_Checker2(shipsn + "A", shipsn + " A")) return;
                    if (!ShipSN_Checker2(shipsn + "B", shipsn + " B")) return;
                    Save2DB(mfgsn1, shipsn + " A");
                    Save2DB(mfgsn2, shipsn + " B");
                    show2DGV(mfgsn1, shipsn + " A", txtOP.Text);
                    show2DGV(mfgsn2, shipsn + " B", txtOP.Text);
                }
                else if (cb_Mode.Text == Mode2) //  2 對 1
                {
                    if (!ShipSN_Checker(shipsn)) return;
                    Save2DB(mfgsn1, shipsn);
                    Save2DB(mfgsn2, shipsn);
                    show2DGV(mfgsn1, shipsn, txtOP.Text);
                    show2DGV(mfgsn2, shipsn, txtOP.Text);
                }
                else // 1 對 1
                {
                    if (!ShipSN_Checker(shipsn)) return;
                    Save2DB(mfgsn1, shipsn);
                    show2DGV(mfgsn1, shipsn, txtOP.Text);
                }


                LMessage.Text += "對應成功\r\n\r\n請輸入下一個白牌序號";
                //txt_MFG_SN.Enabled = true;
                txt_MFG_SN1.BackColor = Color.Yellow;
                txt_Ship_SN.BackColor = Color.Gray;
                txt_MFG_SN1.Text = "";
                txt_MFG_SN2.Text = "";
                txt_Ship_SN.Text = "";
                txt_MFG_SN1.Focus();
                //keydown = false;
            }
        }

        private bool ShipSN_Checker(string sn)
        {
            

            // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有 ShipSN
            string strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_Ship_SN] where [SHIP_SN] like '{sn}'";
            List<string> shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

            if (shipSN.Count == 0)
            {
                strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_buyShip_SN] where [SHIP_SN] like '{sn}'";
                shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

                if (shipSN.Count == 0)
                {
                    LMessage.Text = $"出貨序號 {sn} \r\n不存在,請重新輸入";
                    txt_Ship_SN.Text = "";
                    return false;
                }
                    
            }

            // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有重複的 ShipSN
            strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [SHIP_SN] like '{sn}'";
            shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

            if (shipSN.Count != 0)
            {
                LMessage.Text = $"出貨序號 {shipsn} \r\n已對應過,請重新輸入";
                txt_Ship_SN.Text = "";
                return false;
            }

            return true;
          
        }

        private bool ShipSN_Checker2(string sn1, string sn2)
        {

            
            // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有 ShipSN
            string strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_Ship_SN] where [SHIP_SN] like '{sn1}'";
            List<string> shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

            if (shipSN.Count == 0)
            {
                strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_buyShip_SN] where [SHIP_SN] like '{sn1}'";
                shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

                if (shipSN.Count == 0)
                {
                    LMessage.Text = $"出貨序號 {sn1} \r\n不存在,請重新輸入";
                    txt_Ship_SN.Text = "";
                    return false;
                }
            }

            // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有重複的 ShipSN
            strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [SHIP_SN] like '{sn2}'";
            shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

            if (shipSN.Count != 0)
            {
                LMessage.Text = $"出貨序號 {sn2} \r\n已對應過,請重新輸入";
                txt_Ship_SN.Text = "";
                return false;
            }

            return true;

        }

        private void Save2DB(string mfgsn, string shipsn)
        {
            string strCommand = "INSERT INTO [dbo].[Table_MFG_Ship_Mapping] ([MFG_SN],[SHIP_SN],[Date],[Note]) " +
                                            $"VALUES('{mfgsn}', '{shipsn}', GETDATE(), '{txtOP.Text}')";

            try
            {
                using (SqlConnection openCon = new SqlConnection(strConn_MFGSN))
                {
                    openCon.Open();


                    using (SqlCommand cmd = new SqlCommand(strCommand, openCon))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    openCon.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"資料庫發生異常(Save2DB)\r\n{ex.Message}");

                return;
            }
        }

        /// <summary>
        /// DataGridView顯示
        /// </summary>
        private void show2DGV(string mfgsn,string shipsn, string opid)
        {
            // 移除 SelectionChanged 事件處理方法
            suspendSelectionChanged = true;
            dataGridView1.SelectionChanged -= dataGridView1_SelectionChanged;

            dataGridView1.Rows.Add();

            // 重新連結 SelectionChanged 事件處理方法
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            suspendSelectionChanged = false;

            // 清除選取（如果需要）
            dataGridView1.ClearSelection();

            dataGridView1.Rows[row_number].Cells[0].Value = (row_number+1).ToString();
            dataGridView1.Rows[row_number].Cells[1].Value = mfgsn;
            dataGridView1.Rows[row_number].Cells[2].Value = shipsn;
            dataGridView1.Rows[row_number].Cells[3].Value = opid;

            // 滚动到最后一行
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            dataGridView1.Rows[dataGridView1.RowCount-2].Selected = true;
            row_number++;
            
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            suspendSelectionChanged = true;
            if (!suspendSelectionChanged)
            {
                
                // 執行正常的 SelectionChanged 處理程式碼
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    int rowIndex = selectedRow.Index;
                    //MessageBox.Show($"選取的行索引：{rowIndex}");
                }
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 获取选中的行的索引
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int rowIndex = row.Index;
            }
        }

        private void EnableSorting()
        {
            // 启用列排序功能
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic; // 允许程序控制排序
            }

            dataGridView1.SortCompare += dataGridView1_SortCompare; // 订阅排序比较事件
        }

        private void SortColumn(int columnIndex)
        {
            // 执行排序
            dataGridView1.Sort(dataGridView1.Columns[columnIndex], System.ComponentModel.ListSortDirection.Descending);
        }

        private void reNumber()
        {
            int x = dataGridView1.Rows.Count;
            for(int i = 0; i < x-1 ; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableSorting(); // 启用排序功能
            SortColumn(2);   // 按第一列升序排序
            reNumber();
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // 使用后四个字符进行排序
            string value1 = e.CellValue1.ToString().Substring(e.CellValue1.ToString().Length - 4);
            string value2 = e.CellValue2.ToString().Substring(e.CellValue2.ToString().Length - 4);

            e.SortResult = string.Compare(value1, value2);
            e.Handled = true; // 表示自定义排序已处理
        }

        private void btnLot_Search_Click(object sender, EventArgs e)
        {
            txtLot.Text = txtLot.Text.Replace(" ", "");

            if (txtLot.Text == "")
            {
                MessageBox.Show("Lot No 欄位空白");
                return;
            }

            if (chbOutsource.Checked == false) Lot_Search_FOE();
            else Lot_Search_BuyShip();

        }

        private bool Lot_Search_FOE()
        {
            LMessage.Text = $"開始搜尋 ~~~ ";
            Refresh();

            Init_Dgv();

            // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有重複的 ShipSN
            string strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_Ship_SN] where [Work_Order] like '{txtLot.Text}'";
            List<string> shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

            if (shipSN.Count == 0)
            {
                LMessage.Text = $"沒有找到 {txtLot.Text} 的成品序號";
                return false;
            }

            foreach (var x in shipSN)
            {
                strComm = $"select [MFG_SN],[SHIP_SN],[Note] from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [SHIP_SN] like '{x}'";
                DataTable mfgSN = ToolSQL.select_Return_DT(strConn_MFGSN, strComm);

                
                if (mfgSN.Rows.Count != 0)
                {
                    for (int i=0; i< mfgSN.Rows.Count; i++)
                    {
                        show2DGV(mfgSN.Rows[i][0].ToString(), mfgSN.Rows[i][1].ToString(), mfgSN.Rows[i][2].ToString());
                    }
                }
                
            }
            
            LMessage.Text = $"搜尋完成 ";

            return true;
        }

        private bool Lot_Search_BuyShip()
        {
            LMessage.Text = $"開始搜尋 ~~~ ";
            Refresh();

            Init_Dgv();

            // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有重複的 ShipSN
            string strComm = $"select distinct [SHIP_SN] from [MFG_SN].[dbo].[Table_buyShip_SN] where [Work_Order] like '{txtLot.Text}'";
            List<string> shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

            if (shipSN.Count == 0)
            {
                LMessage.Text = $"沒有找到 {txtLot.Text} 的成品序號";
                return false;
            }


            foreach (var x in shipSN)
            {
                strComm = $"select [MFG_SN],[SHIP_SN],[Note] from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [SHIP_SN] like '{x}'";
                DataTable mfgSN = ToolSQL.select_Return_DT(strConn_MFGSN, strComm);


                if (mfgSN.Rows.Count != 0)
                {
                    for (int i = 0; i < mfgSN.Rows.Count; i++)
                    {
                        show2DGV(mfgSN.Rows[i][0].ToString(), mfgSN.Rows[i][1].ToString(), mfgSN.Rows[i][2].ToString());
                    }
                }

            }

            LMessage.Text = $"搜尋完成 ";

            return true;
        }

        private void btnDelete_Enable_Click(object sender, EventArgs e)
        {
            if (ToolSQL.Program_Permissions("SN System_Delete", txtOP.Text))
                btnDelete.Enabled = true;
            else
                MessageBox.Show("此ID 無權限");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                LMessage.Text = $"";
                Refresh();
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string mfgSN = selectedRow.Cells[1].Value.ToString();
                string shipSN = selectedRow.Cells[2].Value.ToString();


                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    if (!item.IsNewRow) // 確保不會刪除新行
                    {
                        dataGridView1.Rows.RemoveAt(item.Index);
                    }
                }

                string strCommand = $"Delete from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [MFG_SN]='{mfgSN}' and [SHIP_SN] = '{shipSN}'";
                try
                {
                    using (SqlConnection openCon = new SqlConnection(strConn_MFGSN))
                    {
                        openCon.Open();


                        using (SqlCommand cmd = new SqlCommand(strCommand, openCon))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        openCon.Close();
                    }

                    LMessage.Text = $"刪除完成 ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"資料庫發生異常(btnDelete_Click)\r\n{ex.ToString()}");

                    return;
                }

                int r = dataGridView1.RowCount;

                if (r < 2) Init_Dgv();
                else ReCaculateNO();

            }
        }

        private void ReCaculateNO()
        {
            int rowCounts = dataGridView1.RowCount - 1;

            for (int i = 0; i < rowCounts; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Init_Dgv();
        }

        private void btnSorting_Click(object sender, EventArgs e)
        {
            string strComm;
            List<string> shipSN;

            if (txtLot.Text == "")
            {
                MessageBox.Show("Lot No 欄位空白");
                return;
            }

            LMessage.Text = "Sorting ....";
            Refresh();

            Init_Dgv();

            if (cb_SortBy.Text == "by 日期")
            {
                DateTime dt = dateTimePicker1.Value;

                string x = dt.ToString("yyyy" + "-" + "MM" + "-" + "dd" + " 00:00:00");

                dt = dt.AddDays(1);
                string y = dt.ToString("yyyy" + "-" + "MM" + "-" + "dd" + " 00:00:00");


                // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有重複的 ShipSN
                strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_Ship_SN] where [Work_Order] = '{txtLot.Text}' and [Date] >= '{x}' and [Date] < '{y}'";
                shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

                if (shipSN.Count == 0)
                {
                    LMessage.Text = $"沒有找到此條件的的出貨序號";
                    return;
                }
            }
            else if (cb_SortBy.Text == "by 出貨序號")
            {
                // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有重複的 ShipSN
                strComm = $"select [SHIP_SN] from [MFG_SN].[dbo].[Table_Ship_SN] where [Work_Order] = '{txtLot.Text}'";
                shipSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

                if (shipSN.Count == 0)
                {
                    LMessage.Text = $"沒有找到 {txtLot.Text} 的成品序號";
                    return;
                }
            }
            else 
            {
                LMessage.Text = $"這個功能尚未開發完成";
                return;
            }


            foreach (var x in shipSN)
            {
                strComm = $"select [MFG_SN] from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [SHIP_SN] like '{x}'";
                List<string> mfgSN = ToolSQL.select_Return_List(strConn_MFGSN, strComm);

                if (mfgSN.Count != 0)
                {
                    foreach (var y in mfgSN)
                        show2DGV(y, x, "");
                }
            }

            LMessage.Text = $"排序完成 ";
        }

        private void cb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Init_Dgv();

            if (cb_Mode.Text == Mode1)
            {
                txt_MFG_SN2.Visible = false;
                txt_MFG_SN2.Enabled = false;
            }
            else if (cb_Mode.Text == Mode2 || cb_Mode.Text == Mode3)
            {
                txt_MFG_SN2.Visible = true;
                txt_MFG_SN2.Enabled = true;
            }
            else if (cb_Mode.Text == SMode)
            {
                txt_MFG_SN1.Enabled = true;
                txt_Ship_SN.Enabled = true;
                txt_MFG_SN2.Visible = false;
                txt_Ship_SN.BackColor = Color.Yellow;
                txt_MFG_SN1.BackColor = Color.Yellow;
                LMessage.Text = "輸入白牌序號或成品序號後,按下 \"by SN搜尋\" 按鈕開始搜尋";
                txt_MFG_SN1.Focus();
                return;
            }
            else return;

            txt_MFG_SN1.Enabled = true;
            txt_Ship_SN.Enabled = true;
            txt_MFG_SN1.Text = "";
            txt_MFG_SN2.Text = "";
            txt_Ship_SN.Text = "";
            txt_MFG_SN2.BackColor = Color.Gray;
            txt_Ship_SN.BackColor = Color.Gray;

            LMessage.Text = "請輸入白牌序號 1";
            txt_MFG_SN1.BackColor = Color.Yellow;
            txt_MFG_SN1.Focus();
        }

        private void txtLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLot.Text = txtLot.Text.Replace(" ", "");

                if (txtLot.Text == "")
                {
                    MessageBox.Show("Lot No 不能空白");
                    cb_Mode.Enabled = false;
                    return;
                }

                if (txtLot.Text != "" && txtOP.Text != "")
                    cb_Mode.Enabled = true;
            }
        }

        private void btnSN_Search_Click(object sender, EventArgs e)
        {
            if (txt_MFG_SN1.Text == "" && txt_Ship_SN.Text == "")
            {
                MessageBox.Show("請輸入白牌序號 or 成品序號");
                return;
            }

            Sn_Search_FOE(txt_MFG_SN1.Text.Replace(" ",""), txt_Ship_SN.Text.Replace(" ", ""));

        }

        private bool Sn_Search_FOE(string mfgsn, string shipsn)
        {
            DataTable SN;

            LMessage.Text = $"開始搜尋 ~~~ ";
            Refresh();

            Init_Dgv();

            if (mfgsn != "")
            {
                // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有 MfgSN
                string strComm = $"select [MFG_SN],[SHIP_SN],[Note] from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [MFG_SN] like '{mfgsn}'";
                SN = ToolSQL.select_Return_DT(strConn_MFGSN, strComm);

                if (SN.Rows.Count == 0)
                {
                    LMessage.Text = $"沒有找到 {mfgsn} 的白牌序號";
                    return false;
                }
            }
            else
            {
                // 查詢資料庫(MFG_SN)/資料表(Table_MFG_Ship_Mapping) 是否有 ShipSN
                string strComm = $"select [MFG_SN],[SHIP_SN],[Note] from [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] where [SHIP_SN] like '{shipsn}'";
                SN = ToolSQL.select_Return_DT(strConn_MFGSN, strComm);

                if (SN.Rows.Count == 0)
                {
                    LMessage.Text = $"沒有找到 {shipsn} 的成品序號";
                    return false;
                }
            }

            for (int i = 0; i < SN.Rows.Count; i++)
            {
                show2DGV(SN.Rows[i][0].ToString(), SN.Rows[i][1].ToString(), SN.Rows[i][2].ToString());
            }

            LMessage.Text = $"搜尋完成 ";

            return true;
        }


        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }

        }

        
        class ToolSQL  // From YRSQL
        {

            public static List<string> select_Return_List(string connstr, string selectstr)
            {
                using (SqlConnection openCon = new SqlConnection(connstr))
                using (SqlCommand cmd = new SqlCommand(selectstr, openCon))
                {
                    openCon.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();//建立DataSet例項  
                    da.Fill(dt);//使用DataAdapter的Fill方法(填充)，呼叫SELECT命令 

                    List<string> mylist = new List<string>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        mylist.Add(dt.Rows[i][0].ToString());
                    }

                    openCon.Close();
                    return mylist;
                }
            }
            public static DataTable select_Return_DT(string connstr, string selectstr)
            {
                using (SqlConnection openCon = new SqlConnection(connstr))
                using (SqlCommand cmd = new SqlCommand(selectstr, openCon))
                {
                    openCon.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();//建立DataSet例項  
                    da.Fill(dt);//使用DataAdapter的Fill方法(填充)，呼叫SELECT命令                 

                    openCon.Close();
                    return dt;
                }
            }

            /// <summary>
            /// 開啟 Excel 
            /// </summary>
            /// <param name="progName"></param>
            /// <param name="ID"></param>
            /// <returns></returns>
            public static bool Program_Permissions(string progName, string ID)
            {
                int currentRow = 0;
                int currentCol = 0;
                bool found = false;
                string cellValue = string.Empty;

                ID = ID.Replace(" ", "");

                // 設定Excel應用程式
                Excel.Application excelApp = new Excel.Application();
                //excelApp.Visible = true; // 使Excel應用程式可見，方便觀察

                // 選擇要讀取的Excel檔案
                string filePath = @"\\egoserver\共同區\共用-技術中心\FOE_Program\程式使用權限表.xlsx";

                // 開啟工作簿
                Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

                // 選擇要讀取的工作表，這裡使用第一個工作表
                Excel.Worksheet worksheet = workbook.Sheets[1];

                // 讀取資料
                Excel.Range usedRange = worksheet.UsedRange;
                int rowCount = usedRange.Rows.Count;
                int colCount = usedRange.Columns.Count;

                for (int row = 1; row <= rowCount; row++)
                {
                    cellValue = Convert.ToString((usedRange.Cells[row, 1] as Excel.Range).Value2);
                    if (cellValue == ID)
                    {
                        currentRow = row;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    MessageBox.Show($"此 ID {ID}  無效");
                    // 關閉Excel檔案
                    workbook.Close(false);
                    excelApp.Quit();

                    // 釋放資源
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    // 回收
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    return false;
                }
                found = false;

                for (int col = 1; col <= colCount; col++)
                {
                    cellValue = Convert.ToString((usedRange.Cells[1, col] as Excel.Range).Value2);
                    if (cellValue == progName)
                    {
                        currentCol = col;
                        found = true;
                        break;
                    }
                    //MessageBox.Show(cellValue);
                }

                if (!found)
                {
                    MessageBox.Show($"找不到此程式名稱 {progName}");
                    // 關閉Excel檔案
                    workbook.Close(false);
                    excelApp.Quit();

                    // 釋放資源
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    // 回收
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    return false;
                }

                cellValue = Convert.ToString((usedRange.Cells[currentRow, currentCol] as Excel.Range).Value2);

                if (cellValue != "Y")
                {
                    //MessageBox.Show("此 ID 沒有使用權限");
                    // 關閉Excel檔案
                    workbook.Close(false);
                    excelApp.Quit();

                    // 釋放資源
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    // 回收
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    return false;
                }

                //ReadDataFromExcel(worksheet);
                //string a = worksheet.Rows[1];


                // 關閉Excel檔案
                workbook.Close(false);
                excelApp.Quit();

                // 釋放資源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                // 回收
                GC.Collect();
                GC.WaitForPendingFinalizers();
                return true;
            }
        }
    }
}
