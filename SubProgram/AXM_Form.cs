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
using Excel = Microsoft.Office.Interop.Excel;

/// <summary>
/// John    20231206    初版開發
/// </summary>
namespace FormSN_System.SubProgram
{
    public partial class AXM_Form : Form
    {
        //string connectionString = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";
        string strConn_MFGSN = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";      // 資料庫_MFG_SN

        public AXM_Form()
        {
            InitializeComponent();
            txt_LotNo.Multiline = false;
            //調整資訊顯示字體和大小
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 12);
            //自動調整欄位
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txt_LotNo.Text = txt_LotNo.Text.Trim();
        }

        private void txt_LotNo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) 
            //{
                //e.SuppressKeyPress = true;
                //Inquire_btn.PerformClick();
            //}
        }

        private void Check_btn_Click(object sender, EventArgs e)
        {
            string searchValue = txt_LotNo.Text.Trim();
            string table;

            if (chbBuy.Checked == true)
                table = "SELECT [Work_Order], [Buy], [Ship_SN] FROM [MFG_SN].[dbo].[Table_buyShip_SN]";
            else
                table = "SELECT [Work_Order], [Ship_SN] FROM [MFG_SN].[dbo].[Table_Ship_SN]";
            

            // 檢查是否已輸入條件
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("     請輸入 Lot No");
                return;
            }
            string query = $"{table} WHERE Work_Order = '{searchValue}' order by right(Ship_SN,4)";
            DataTable dataTable = Jonas_SubFunction.JonasSQL.select_Return_DT(strConn_MFGSN, query);

            // 將 DataTable 資料繫結到 DataGridView
            dataGridView1.DataSource = dataTable;

            //數量顯示
            txt_quantity.Text = dataTable.Rows.Count.ToString();
            /*
            #region 執行查詢 連結 秀出資料集
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //string query = $"SELECT ROW_NUMBER() OVER (ORDER BY Work_Order) AS No, Work_Order, Ship_SN FROM [MFG_SN].[dbo].[Table_buyShip_SN] WHERE Work_Order LIKE '%{searchValue}%' OR Ship_SN LIKE '%{searchValue}%'";
                string query = $"SELECT [Work_Order], [Buy], [Ship_SN] FROM [MFG_SN].[dbo].[Table_buyShip_SN] WHERE Work_Order LIKE '{searchValue}' order by CAST(substring([Ship_SN],10,4) as int)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();

                        // 打開資料庫連接
                        connection.Open();

                        // 使用資料適配器填充 DataTable
                        adapter.Fill(dataTable);

                        // 關閉資料庫連接
                        connection.Close();

                        // 將 DataTable 資料繫結到 DataGridView
                        dataGridView1.DataSource = dataTable;

                       //數量顯示
                       txt_quantity.Text = dataTable.Rows.Count.ToString();
                    }
                }
            }
            #endregion
            */
        }

        private void Export_file_Click(object sender, EventArgs e)
        {
            // 檢查 DataGridView 是否有資料
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("沒有資料，無法匯出 Excel", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #region 資料匯出
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //saveFileDialog.Title = "選擇 Excel 檔案存檔路徑";

            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string filePath = saveFileDialog.FileName;

                // 創建 Excel 應用程式
                Excel.Application excelApp = new Excel.Application();

                // 添加一個新的工作簿
                Excel.Workbook workbook = excelApp.Workbooks.Add();

                // 添加一個新的工作表
                Excel.Worksheet worksheet = workbook.Sheets[1];

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[1, j + 1].Value = dataGridView1.Columns[j].HeaderText;
                }

                // 將 DataGridView 資料複製到 Excel 工作表
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1[j, i].Value != null)
                        {
                            worksheet.Cells[i + 1, j + 1].Value = dataGridView1[j, i].Value.ToString();
                        }
                        else
                        {
                            worksheet.Cells[i + 1, j + 1].Value = string.Empty; 
                        }
                    }
                }
                excelApp.Visible = true;
                //workbook.SaveAs(filePath);

                // 關閉 Excel 應用程式
                //excelApp.Quit();

                //MessageBox.Show("Excel 檔案成功匯出！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }
    }
}
