using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Jonas_SubFunction
{
    class JonasSQL  // From YRSQL
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
