using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YRspace_FOE_SN
{
    class FOE_SN
    {
        public static string setWW(DateTime dt)//計算週數
        {
            //下面是 網路上各種神奇週數算法的其中一種
            //DateTime dt = DateTime.Now;
            Calendar cal = new CultureInfo("en-US").Calendar;
            int week = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday); //20221223 DayOfWeek.Monday 改成 DayOfWeek.Sunday --Jonas

            return week.ToString("D2");
        }

        public static int any_to_dec(string sort_char, string nowR)
        {
            int decnn = 0;

            for (int x = 0; x < nowR.Length; x++)
            {
                decnn = decnn + sort_char.IndexOf(nowR[x]) * (int)Math.Pow(34, (2 - x));
            }

            return decnn;
        }

        public static string dec_to_any(string sort_char, int target) //子函數用來算 DEC轉 任何進制
        {
            string strR = "";

            do
            {
                strR = sort_char[target % sort_char.Length] + strR;
                target = target / sort_char.Length;
            } while (target != 0);

            return strR;
        }               

        public static List<string> getxxxx(DataTable dt, List<string> notelist, List<string> substringlist, string Lbl_script_Text)//計算目前流水碼
        {
            List<string> nowSNlist = new List<string>();//SN
            List<int> nowSNlistDEC = new List<int>(); //SN內的流水碼  轉DEC

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string oldnote = dt.Rows[i]["Note"].ToString().Split('#')[0]; //新方法會有取碼字串 要先去掉
                oldnote = oldnote.Split('_')[0];//10051H(TSD-S2CH1-C11M)_Extreme_Shared 取出 10051H(TSD-S2CH1-C11M)

                int indexx = 0, lenn = 0;
                if (notelist.IndexOf(oldnote) == -1 & substringlist.Count != 1)//找不到對映 且 只有一種
                {
                    MessageBox.Show("有點問題  找不到");
                }
                else if (substringlist.Count == 1)
                {
                    string[] ggarr = substringlist[0].Split(',');
                    indexx = Int16.Parse(ggarr[0]); //
                    lenn = Int16.Parse(ggarr[1]);
                }
                else
                {
                    string[] ggarr = substringlist[notelist.IndexOf(oldnote)].Split(',');
                    indexx = Int16.Parse(ggarr[0]); //
                    lenn = Int16.Parse(ggarr[1]);
                }

                if (lenn != 0)
                {
                    nowSNlist.Add(dt.Rows[i]["Ship_SN"].ToString().Substring(indexx, lenn));
                }
                else
                {
                    MessageBox.Show("可能以前的編碼原則 與現在不同 Substring(indexx, lenn) 出現錯誤");
                }

                if (Lbl_script_Text.Contains("+16R4"))
                {
                    nowSNlistDEC.Add(int.Parse(nowSNlist[i], System.Globalization.NumberStyles.HexNumber));
                }
                else if (Lbl_script_Text.Contains("+19AZ-IO_R3"))
                {
                    string gg = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
                    nowSNlistDEC.Add(any_to_dec(gg, nowSNlist[i]));
                }
                else
                {
                    nowSNlistDEC.Add(Int32.Parse(nowSNlist[i]));
                }
            }

            List<string> result = new List<string>();
            result.Add(dt.Rows[nowSNlistDEC.IndexOf(nowSNlistDEC.Max())]["Ship_SN"].ToString());
            result.Add(nowSNlist[nowSNlistDEC.IndexOf(nowSNlistDEC.Max())]);

            return result;
        }

        public static string[] setSN2(string script, string nowR, int numm, string Txt_yy_Text, string Txt_ww_Text, DateTime dateTimePicker1_Value)
        {
            /// <summary>
            /// nowR : 已存在編號的最後一號的流水碼
            /// numm : 此次編號的數量
            /// Txt_yy_Text : 年碼
            /// Txt_ww_Text : 週碼
            /// dateTimePicker1_Value : 選擇的年月日
            /// </summary>

            string[] arrSN = new string[numm];//做一個空array
            for (int z = 0; z < numm; z++)
            {
                arrSN[z] = "";
            }


            string[] sArray = script.Split('+');

            for (int i = 0; i < sArray.Length; i++)  // 以 '+' 號分割段落數量的次數
            {
                if (sArray[i].Substring(0, 1) == "'")
                {
                    //strr = strr + sArray[i].Replace("'", "");
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + sArray[i].Replace("'", "");
                    }
                }
                else if (sArray[i] == "yyyy")
                {
                    //strr = strr + dateTimePicker1.Value.Year.ToString("D4");
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + dateTimePicker1_Value.Year.ToString("D4");
                    }
                }
                else if (sArray[i] == "yy")
                {
                    //strr = strr + Txt_yy.Text;
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + Txt_yy_Text;
                    }
                }
                else if (sArray[i] == "y")
                {
                    //strr = strr + Txt_yy.Text.Substring(1, 1);
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + Txt_yy_Text.Substring(1, 1);
                    }
                }
                else if (sArray[i].Split('_')[0] == "Yminus") //特殊年碼
                {
                    if (dateTimePicker1_Value.Year <= 2024)
                    {
                        int y = dateTimePicker1_Value.Year - Int32.Parse(sArray[i].Split('_')[1]);

                        for (int z = 0; z < numm; z++)
                        {
                            arrSN[z] = arrSN[z] + y.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("廠商給的編碼原則爆炸了 請找RD討論");
                    }
                }
                else if (sArray[i] == "ww")
                {
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + Txt_ww_Text;
                    }
                }
                else if (sArray[i] == "mm")
                {
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + dateTimePicker1_Value.Month.ToString("D2");
                    }
                }
                else if (sArray[i] == "m1")  //一碼 月碼 月份為123456789ABCD 完全就是轉成16進位
                {
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + dateTimePicker1_Value.Month.ToString("X1");
                    }
                }
                else if (sArray[i] == "m2")  //一碼 月碼 WAVESPLITTER 威示波 使用 月份為 1234567890AB
                {
                    string gg = "1234567890AB";
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + gg[dateTimePicker1_Value.Month - 1];
                    }
                }
                else if (sArray[i] == "m3")  //一碼 月碼 Intel 使用 月份為 123456789ABC ; 20221125_Jonas_Insert
                {
                    string gg = "123456789ABC";
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + gg[dateTimePicker1_Value.Month - 1];
                    }
                }
                else if (sArray[i] == "dd")
                {
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + dateTimePicker1_Value.Day.ToString("D2");
                    }
                }
                else if (sArray[i] == "d1")  //一碼 日碼 Intel 使用 日期為 1~9+A~V ; 20221125_Jonas_Insert
                {
                    string gg = "123456789ABCDEFGHIJKLMNOPQRSTUV";
                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + gg[dateTimePicker1_Value.Day - 1];
                    }
                    
                }
                else if (sArray[i].Substring(0, 1) == "R") //流水碼
                {
                    string tostring_format = "D";
                    tostring_format = tostring_format + sArray[i].Substring(1, 1);
                    /////////////////// Jonas 
                    if (nowR == "") nowR = "0"; // 下面 for 迴圈 Int32.Parse(nowR) 指令遇到 nowR="" 時轉型失敗  Jonas 2023/06/07

                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + (Int32.Parse(nowR) + z + 1).ToString(tostring_format);
                    }
                }
                else if (sArray[i] == "AR4")
                {
                    string gg = "123456789ABCDEFGHIJKLMNO";
                    if (nowR.Length<4) nowR = nowR.PadLeft(4, '0');
                    int y = int.Parse(nowR.Substring(1));

                    for (int z = 0; z < numm; z++)
                    {
                        char c = Convert.ToChar(nowR.Substring(0, 1));
                        y++;
                        if (y == 1000)
                        {
                            int index = gg.IndexOf(c);
                            if (index<=22)
                            {
                                nowR = gg.Substring(index + 1, 1) + "000";
                                y = 0;
                            }
                            else
                            {
                                MessageBox.Show("數量超過流水碼第一碼原則,不能超過英文字母 'O'");
                            }

                        }
                        else
                        {
                            nowR = c + Convert.ToString(y).PadLeft(3, '0');
                        }

                        arrSN[z] = arrSN[z] + nowR;
                    }

                }
                else if (sArray[i] == "16R4") //流水碼 16進位流水碼
                {
                    int hex_to_dec = Int32.Parse(nowR, System.Globalization.NumberStyles.HexNumber);

                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + (hex_to_dec + z + 1).ToString("X4");
                    }
                }
                else if (sArray[i] == "19AZ-IO_R3") //特殊流水號  0-9 A-Z 不含 字母I 字母O  總結為34進制
                {
                    string gg = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
                    //以下為34進制 轉 10進制求值
                    int decnn = any_to_dec(gg, nowR);

                    for (int z = 0; z < numm; z++)
                    {
                        arrSN[z] = arrSN[z] + dec_to_any(gg, decnn + z + 1).PadLeft(3, '0');
                    }
                }
                else if (sArray[i].Split('_')[0] == "sum")//檢查碼 NETGEAR用
                {
                    //檢查碼 sum_7 是借用C# String.Insert(Int32, String)概念  指令必須加在最後                    
                    //標籤列印圖上有個對照表

                    string gg = "0123456789ABCDEFGHJKLMNPRSTUVWXY";

                    int insert_num = Int16.Parse(sArray[i].Split('_')[1]);

                    for (int z = 0; z < numm; z++)
                    {
                        int sum_int = 0;
                        for (int k = 0; k < arrSN[z].Length; k++)
                        {
                            sum_int = sum_int + gg.IndexOf(arrSN[z][k]) * (12 - k);
                        }

                        arrSN[z] = arrSN[z].Insert(insert_num, gg[sum_int % 32].ToString());
                    }
                }
                else if (sArray[i] == "addAB") //尾碼 補AorB
                {
                    MessageBox.Show("尾碼 補AorB");
                }
                else if (sArray[i] == "addABCDE") //尾碼 補ABCDE
                {
                    MessageBox.Show("尾碼 補ABCDE");
                }
                else if (sArray[i] == "AorB") //頭碼 補AB
                {
                    MessageBox.Show("頭碼 補AB");
                }
                else
                {
                    MessageBox.Show("script 有點問題");
                }


            }


            if (script.Contains("addABCDE"))
            {
                List<string> listSN = new List<string>();

                for (int i = 0; i < arrSN.Length; i++)
                {
                    listSN.Add(arrSN[i] + "A");
                    listSN.Add(arrSN[i] + "B");
                    listSN.Add(arrSN[i] + "C");
                    listSN.Add(arrSN[i] + "D");
                    listSN.Add(arrSN[i] + "E");
                }

                Array.Resize(ref arrSN, listSN.Count);

                for (int j = 0; j < listSN.Count; j++)
                {
                    arrSN[j] = listSN[j];
                }
            }
            else if (script.Contains("addAB") & !script.Contains("addABCDE"))
            {
                List<string> listSN = new List<string>();

                for (int i = 0; i < arrSN.Length; i++)
                {
                    listSN.Add(arrSN[i] + "A");
                    listSN.Add(arrSN[i] + "B");
                }

                Array.Resize(ref arrSN, listSN.Count);

                for (int j = 0; j < listSN.Count; j++)
                {
                    arrSN[j] = listSN[j];
                }
            }
            else
            {

            }

            return arrSN;
        }
    }
}
