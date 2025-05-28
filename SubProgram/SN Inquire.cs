using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormSN_System.SubProgram
{
    public partial class Form2 : Form
    {
        string connectionString = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";


        public Form2()
        {
            InitializeComponent();
        }


        private void txtMFG_SN_IN_KeyDown(object sender, KeyEventArgs e)
        {
            // 判斷是否按下 Enter 鍵
            if (e.KeyCode == Keys.Enter)
            {
                txtMFG_SN_IN.Text = txtMFG_SN_IN.Text.ToUpper();
                btnSearch_ShipSN_Click(sender, e);
                //button1_Click(sender, e);

                // 防止 Enter 鍵繼續觸發事件
                e.Handled = true;
            }
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            txtMFG_SN_IN.Focus();
        }

        private void txtShip_SN_IN_KeyDown(object sender, KeyEventArgs e)
        {
            // 判斷是否按下 Enter 鍵
            if (e.KeyCode == Keys.Enter)
            {
                txtShip_SN_IN.Text = txtShip_SN_IN.Text.ToUpper();
                btnSearch_MFGsn_Click(sender, e);

                // 防止 Enter 鍵繼續觸發事件
                e.Handled = true;
            }
        }

        private void btnSearch_ShipSN_Click(object sender, EventArgs e)
        {
            // 取得輸入的字串資料
            string searchValue = txtMFG_SN_IN.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("請輸入查詢字串");
                return;
            }
            // 使用 SqlConnection 連接資料庫
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // 開啟資料庫連接
                    connection.Open();
                    // 使用 SqlCommand 準備 SQL 查詢語句
                    string query = "SELECT SHIP_SN FROM [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] WHERE MFG_SN = @SearchValue";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 宣告 SqlParameter 並將其值設定為使用者輸入的字串
                        SqlParameter parameter = new SqlParameter("@SearchValue", searchValue);
                        command.Parameters.Add(parameter);
                        // 執行查詢並讀取結果
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 讀取 SHIP_SN 欄位的值
                                string shipSN = reader["SHIP_SN"].ToString().ToUpper();
                                // 將結果顯示在 textBox2 中
                                txtShip_SN_OUT.Text = shipSN;
                            }
                            else
                            {
                                txtShip_SN_OUT.Text = "未找到符合資料";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"資料庫查詢發生錯誤：{ex.Message}");
                }
            }
        }

        private void btnSearch_MFGsn_Click(object sender, EventArgs e)
        {
            // 取得輸入的字串資料
            string searchValue = txtShip_SN_IN.Text.Trim();

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("請輸入查詢字串");
                return;
            }
            // 使用 SqlConnection 連接資料庫
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // 開啟資料庫連接
                    connection.Open();
                    // 使用 SqlCommand 準備 SQL 查詢語句
                    string query = "SELECT MFG_SN FROM [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] WHERE SHIP_SN = @SearchValue";
                    //string query = $"SELECT MFG_SN FROM [MFG_SN].[dbo].[Table_MFG_Ship_Mapping] WHERE SHIP_SN = {searchValue}";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 宣告 SqlParameter 並將其值設定為使用者輸入的字串
                        SqlParameter parameter = new SqlParameter("@SearchValue", searchValue);
                        command.Parameters.Add(parameter);
                        // 執行查詢並讀取結果
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 讀取 MFG_SN 欄位的值
                                string MFGSN = reader["MFG_SN"].ToString().ToUpper();
                                // 將結果顯示在 textBox2 中
                                txtMFG_SN_Out.Text = MFGSN;
                            }
                            else
                            {
                                txtMFG_SN_Out.Text = "未找到符合資料";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"資料庫查詢發生錯誤：{ex.Message}");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMFG_SN_IN.Text = "";
            txtMFG_SN_Out.Text = "";
            txtShip_SN_IN.Text = "";
            txtShip_SN_OUT.Text = "";
        }
    }
}
