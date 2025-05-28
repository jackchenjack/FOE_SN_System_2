using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRspace_SQL
{
    class YRSQL
    {
        public static List<string> select_return_list (string connstr, string selectstr)
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

                return mylist;
            }


        }

        public static DataTable select_return_dt(string connstr, string selectstr)
        {
            using (SqlConnection openCon = new SqlConnection(connstr))
            using (SqlCommand cmd = new SqlCommand(selectstr, openCon))
            {
                openCon.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();//建立DataSet例項  
                da.Fill(dt);//使用DataAdapter的Fill方法(填充)，呼叫SELECT命令                 

                return dt;
            }


        }
    }
}
