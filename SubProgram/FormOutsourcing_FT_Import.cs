using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSN_System.SubProgram
{
    public partial class FormOutsourcing_FT_Import : Form
    {
        int Items;
        int Model1 = 4, Model2 = 8; // 設定 Model1 Model2 的欄位數量
        string strConn_FOE = "uid=sa;pwd=dsc;database=FormericaOE;server=dataserver";
        string FTtable_QSFP = "[dbo].[QSFP_FinalTest]";
        string FTtable_nonQSFP = "[dbo].[TRx_FinalTest]";

        //string strConn_MFGSN = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";

        public FormOutsourcing_FT_Import()
        {
            InitializeComponent();
        }

        private void cbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            //Mode_1();
            //SelectFile();
            if (cbCustomer.Text == "Model1")
            {
                Items = Model1;
            }
            else
            {
                Items = Model2;
            }
            Items_Define(Items);

            btnDataPaste.Enabled = true;
            btnFT_Import.Enabled = true;
            btn_ClearData.Enabled = true;

        }

        private void Items_Define(int itemCount)
        {
            dgView1.Rows.Clear();
            dgView1.Columns.Clear();
            //int rows = 0;

            if (itemCount == Model1)
                dgView1.ColumnCount = Model1; // 設定Model1 的欄位數
            else
                dgView1.ColumnCount = Model2; // 設定Model2 的欄位數

            dgView1.Columns[0].HeaderText = "No.";
            dgView1.Columns[1].HeaderText = "SN";
            dgView1.Columns[2].HeaderText = "Optical Power (dBm)";
            dgView1.Columns[3].HeaderText = "Extinction Radio (dB)";
            

            if (itemCount == Model2)
            {
                //dgView1.ColumnCount = 7; // 設定Model2 的欄位名稱
                dgView1.Columns[2].HeaderText = "Ch";
                dgView1.Columns[3].HeaderText = "Optical Power (dBm)";
                dgView1.Columns[4].HeaderText = "Extinction Radio (dB)";
                dgView1.Columns[5].HeaderText = "Receiver Sensitivity (dBm)";
                dgView1.Columns[6].HeaderText = "LOS Assert (dBm)";
                dgView1.Columns[7].HeaderText = "LOS De-Assert (dBm)";
            }

            dgView1.Columns[0].Width = 60; //dgView1.Columns[1].Width = 200; dgView1.Columns[2].Width = 200;
            for (int i = 1; i < Items; i++)
            {
                dgView1.Columns[i].Width = 180;
            }
            //dgView1.Width = 453;
            dgView1.DefaultCellStyle.Font = new Font("Arial", 14); // 使用 Arial 字型，大小為 12
            dgView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // 設定列標題的字型、大小與粗體
            dgView1.ScrollBars = ScrollBars.Both;

        }

        private void DataPaste()
        {
            if (cbCustomer.Text == "")
            {
                MessageBox.Show("Customer 必須選擇");
                return;
            }
            string clipboard = Clipboard.GetText();
            string[] lines = clipboard.Split('\n');

            int currentRow = 0;
            int currentColumn = 1;
            int rowCount = dgView1.Rows.Count;

            DataGridViewCell CurrentCell;

            //增加列數
            if (lines.Length > rowCount - currentRow)
            {
                int cut = lines.Length - (rowCount - currentRow);
                dgView1.Rows.Add(cut);
                Application.DoEvents();
            }

            //將值寫入到DataGridView
            foreach (string line in lines)
            {
                if (line == "") break;
                dgView1[0, currentRow].Value = currentRow+1;
                string[] cells = line.Split('\t');
                for (int i = 0; i < cells.Length; i++)
                {
                    //處理儲存格
                    CurrentCell = dgView1[currentColumn + i, currentRow];
                    string value = cells[i];
                    CurrentCell.Value = value;
                }
                currentRow++;
            }
        }

        private string SelectFile()
        {
            string filename = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "請選擇檔案";
            dialog.Filter = "所有檔案(*.*)|*.*";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = dialog.FileName;
                //MessageBox.Show(filename);
            }
            return filename;
        }

        private void btnDataPaste_Click(object sender, EventArgs e)
        {
            DataPaste();
        }

        private void btnRead_File_Click(object sender, EventArgs e)
        {
            string filenamePath = SelectFile();
            MessageBox.Show(filenamePath);
        }

        private void FormOutsourcing_FT_Import_Load(object sender, EventArgs e)
        {

        }

        private void btn_ClearData_Click(object sender, EventArgs e)
        {
            Items_Define(Items);
        }

        private void btnFT_Import_Click(object sender, EventArgs e)
        {
            string FTtable;

            if (txtCustomer.Text == "" || txtLotNo.Text == "" || txtModelNo.Text == "")
            {
                MessageBox.Show("Lot No & Model No & 外購廠商 欄位必須輸入");
                return;
            }

            if (dgView1.RowCount == 1)
            {
                MessageBox.Show("沒有資料");
                return;
            }

            if (cbCustomer.Text == "Model2")
                FTtable = FTtable_QSFP;
            else
                FTtable = FTtable_nonQSFP;

            //return;

            for (int i=0; i<dgView1.RowCount-1; i++)
            {
                string strSN = dgView1[1, i].Value.ToString();
                string strTemp = txtTemp.Text;
                string strVolt = txtVolt.Text;
                string strTx_Po ;
                string strTx_ER ;
                string strModel = txtModelNo.Text;
                string strDate = DateTime.Now.ToString("yyyyMMdd");
                string strTime = DateTime.Now.ToString("HHmmss");
                string strCustomer = txtCustomer.Text;

                double TxPo ;
                double TxER ;
                /*
                //DB_Data_Check_Delete(FTtable, strSN, strTemp, strVolt, chbOverWrite_DB.Checked);
                if (DB_Data_Check_Delete_nonQSFP(FTtable, strSN, strTemp, strVolt, chbOverWrite_DB.Checked) == false)
                {
                    MessageBox.Show($"SN={strSN} 存在資料庫,請確認");
                    return;
                }
                */
                //return;
                //MessageBox.Show(dgView1[1, i].Value.ToString() + " " + dgView1[2, i].Value.ToString() + " " + dgView1[3, i].Value.ToString());
                if (Items == Model1)
                {
                    strTx_Po = dgView1[2, i].Value.ToString();
                    strTx_ER = dgView1[3, i].Value.ToString();
                    strModel = txtModelNo.Text;

                    if (DB_Data_Check_Delete_nonQSFP(FTtable, strSN, strTemp, strVolt, chbOverWrite_DB.Checked) == false)
                    {
                        MessageBox.Show($"SN={strSN} 存在資料庫,請確認");
                        return;
                    }

                    TxPo = Convert.ToDouble(strTx_Po);
                    TxER = Convert.ToDouble(strTx_ER);
                    // [FormericaOE].[dbo].[TRx_FinalTest]
                    //MessageBox.Show(strSN + " " + strTx_Po + " " + strTx_ER);
                    //DB_Data_Check_Delete(FTtable, strSN, strTemp, strVolt, chbOverWrite_DB.Checked);

                    string strCommand = $"INSERT INTO {FTtable} ([LotNo],[SN],[Temperature],[Volt],[Tx_Po],[Tx_ER],[Rx_S],[Rx_A],[Rx_D],[Model_No],[OP],[Tx_PF],[Rx_PF],[Test_Date],[Test_Time],[Note])" + 
                                        $"VALUES('{txtLotNo.Text}','{strSN}','{strTemp}','{strVolt}',{TxPo},{TxER},{0},{0},{0},'{strModel}','','PASS','PASS','{strDate}','{strTime}','{strCustomer}')";

                    try
                    {
                        using (SqlConnection openCon = new SqlConnection(strConn_FOE))
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
                        //MessageBox.Show(ex.ToString());

                        MessageBox.Show($"資料庫發生異常(btnFT_Import_Click)\r\n{ex.ToString()}");

                        return;
                    }
                }
                else if (Items == Model2)
                {
                    string strCh = dgView1[2, i].Value.ToString();
                    strTx_Po = dgView1[3, i].Value.ToString();
                    strTx_ER = dgView1[4, i].Value.ToString();
                    string strRx_S = dgView1[5, i].Value.ToString();
                    string strRx_A = dgView1[6, i].Value.ToString();
                    string strRx_D = dgView1[7, i].Value.ToString();
                    double Rx_S = Convert.ToDouble(strRx_S);
                    double Rx_A = Convert.ToDouble(strRx_A);
                    double Rx_D = Convert.ToDouble(strRx_D);

                    if (DB_Data_Check_Delete_QSFP(FTtable, strSN, strCh, strTemp, strVolt, chbOverWrite_DB.Checked) == false)
                    {
                        MessageBox.Show($"SN={strSN} 存在資料庫,請確認");
                        return;
                    }

                    TxPo = Convert.ToDouble(strTx_Po);
                    TxER = Convert.ToDouble(strTx_ER);
                    //string strCommand = $"INSERT INTO {FTtable} ([LotNo],[SN],[Temperature],[Volt],[Channel],[Tx_Po],[Tx_ER]) " +
                    //$"VALUES('{txtLotNo.Text}','{strSN}','{txtTemp.Text}','{txtVolt.Text}','{txtCH.Text}','{Convert.ToDouble(strTx_Po)}','{Convert.ToDouble(strTx_ER)}')";
                    string strCommand = $"INSERT INTO {FTtable} ([LotNo],[SN],[Temperature],[Volt],[Channel],[Tx_Po],[Tx_ER],[Rx_S],[Rx_A],[Rx_D],[Model_No],[OP],[Test_Date],[Test_Time],[Note],[Tx_PF],[Rx_PF])" +
                                        $"VALUES('{txtLotNo.Text}','{strSN}','{strTemp}','{strVolt}','{strCh}',{TxPo},{TxER},{Rx_S},{Rx_A},{Rx_D},'{strModel}','','{strDate}','{strTime}','{strCustomer}','PASS','PASS')";

                    try
                    {
                        using (SqlConnection openCon = new SqlConnection(strConn_FOE))
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
                        //MessageBox.Show(ex.ToString());

                        MessageBox.Show($"資料庫發生異常(btnFT_Import_Click)\r\n{ex.Message}");

                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Model select fail");
                    return;
                }

                //MessageBox.Show("資料匯入完成 !");
            }
            MessageBox.Show("資料匯入完成 !");

        }
        private bool DB_Data_Check_Delete_nonQSFP(string DataTable, string SN, string Temp, string Volt, bool Overwrite)
        {
            string strCommand = $"Select [SN] From {DataTable} Where [SN]='{SN}' and [Temperature]='{Temp}' and [Volt]='{Volt}'";
            List<string> mylist = Jonas_SubFunction.JonasSQL.select_Return_List(strConn_FOE, strCommand);

            if (mylist.Count > 0)
            {
                if (Overwrite)
                {
                    strCommand = $"DELETE From {DataTable} Where [SN]='{SN}' and [Temperature]='{Temp}' and [Volt]='{Volt}'";
                    try
                    {
                        using (SqlConnection openCon = new SqlConnection(strConn_FOE))
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
                        //MessageBox.Show(ex.ToString());

                        MessageBox.Show($"資料庫發生異常(DB_Data_Check)\r\n{ex.Message}");

                        return false;
                    }
                }
                else
                {
                    //MessageBox.Show("SN 已存在資料庫");
                    return false;
                }
                    
            }
            
            return true;
        }

        private bool DB_Data_Check_Delete_QSFP(string DataTable, string SN, string Ch, string Temp, string Volt, bool Overwrite)
        {
            string strCommand = $"Select [SN] From {DataTable} Where [SN]='{SN}' and [Channel]='{Ch}' and [Temperature]='{Temp}' and [Volt]='{Volt}'";
            List<string> mylist = Jonas_SubFunction.JonasSQL.select_Return_List(strConn_FOE, strCommand);

            if (mylist.Count > 0)
            {
                if (Overwrite)
                {
                    strCommand = $"DELETE From {DataTable} Where [SN]='{SN}' and [Channel]='{Ch}' and [Temperature]='{Temp}' and [Volt]='{Volt}'";
                    try
                    {
                        using (SqlConnection openCon = new SqlConnection(strConn_FOE))
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
                        //MessageBox.Show(ex.ToString());

                        MessageBox.Show($"資料庫發生異常(DB_Data_Check)\r\n{ex.Message}");

                        return false;
                    }
                }
                else
                {
                    //MessageBox.Show("SN 已存在資料庫");
                    return false;
                }

            }

            return true;
        }
        private bool DB_Data_Delete(string DataTable, string SN, string Temp, string Volt)
        {
            string strCommand = $"DELETE From {DataTable} Where [SN]='{SN}' and [Temperature]='{Temp}' and [Volt]='{Volt}'";
            return false;
        }
    }
}
