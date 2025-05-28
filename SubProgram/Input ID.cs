using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Jonas_SubFunction;

namespace MFG_SN_Mapping
{
    public partial class Input_ID : Form
    {

        //string strConn_FOE = "uid=sa;pwd=dsc;database=FormericaOE;server=dataserver";   // 資料庫_FormericaOE
        //string strConn_MFGSN = "uid=sa;pwd=dsc;database=MFG_SN;server=dataserver";      // 資料庫_MFG_SN
        public bool Result;
        public static string opid;
        public Input_ID()
        {
            InitializeComponent();
        }

        private void txtOPID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOPID.Text = txtOPID.Text.Replace(" ", "");
                Result = Jonas_SubFunction.JonasSQL.Program_Permissions("SN System", txtOPID.Text);

                if (Result) 
                {
                    opid = txtOPID.Text;
                    this.Close();
                } 
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
