using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            UploadThread1 thread = new UploadThread1();
            thread.run();
        }


    }
    public class UploadThread1
    {
        public static string strSerialNum = "";
        public static string strUrl = "";
        private static Thread thread;
        string mysqlString = "Database=tj;Data Source=172.16.1.10;User Id=root;Password=root;pooling=false;CharSet=utf8;port=3306";

        public UploadThread1()
        {
            thread = new Thread(upLoadData);
        }

        public void run()
        {
            thread.Start();
        }

        public void stop()
        {
            if (thread != null && thread.ThreadState == System.Threading.ThreadState.Running)
                thread.Abort();
            thread = null;
        }

        private void upLoadData()
        {
            while (true)
            {
                Console.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"开始生成xml文件");
                string xmlupload = "";
                try
                {
                    //MySqlConnection mySql = new MySqlConnection(mysqlString);
                    //try
                    //{
                    //    mySql.Open();
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine("数据库打开失败" + e.Message);
                    //}

                    SQLiteConnection conn = new SQLiteConnection("Data Source=DB/ZYdatabase.sqlite");
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Select * FROM UserInformation";
                    cmd.ExecuteNonQuery();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "UserInformation");
                    //conn.Close();
                    int intneednum = ds.Tables["UserInformation"].Rows.Count;

                    if (intneednum > 0)
                    {                       
                        for (int icount = 0; icount < intneednum; icount++)//
                        {
                            string MedicalNo = ds.Tables["UserInformation"].Rows[icount]["MedicalNo"].ToString();
                            if (icount == 4316)
                            {
                                Console.WriteLine("");
                            }
                            DateTime now = System.DateTime.Now;
                            string year = now.Year.ToString().Substring(2, 2);
                            string searchstr = "C" + "17" + MedicalNo;
                            string id_no = "12345678";
                            string address = "";
                            string dunc = "";
                            string xmlName = searchstr;

                            //string sqlSearch = "select Event_No,name,id_no,address  from TJZ_info where Event_No='" + searchstr + "'";
                            //MySqlCommand mySqlCommand = new MySqlCommand(sqlSearch, mySql);
                            //MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                            //try
                            //{
                            //    if (mySqlDataReader.Read())
                            //    {
                            //        id_no = mySqlDataReader.GetString(2);
                            //        address = mySqlDataReader.GetString(3);
                                   
                            //        if (address == "")
                            //        {
                            //            Console.WriteLine("没有此人地址信息" + searchstr);
                            //            continue;
                            //        }
                            //        dunc = addressToCode(address);
                            //        if (dunc == "")
                            //        {
                            //            Console.WriteLine("没有此人地址机构码" + searchstr);
                            //            continue;
                            //        }
                            //        if (id_no == "")
                            //        {
                            //            Console.WriteLine("没有匹配到此人的身份证号" + searchstr);
                            //            continue;
                            //        }
                            //        xmlName = id_no;
                            //        Console.WriteLine("|name" + mySqlDataReader.GetString(1) + "|id_no" + mySqlDataReader.GetString(2));
                            //        Console.WriteLine("|address" + mySqlDataReader.GetString(3));
                            //    }
                            //    else
                            //    {
                            //        xmlName = searchstr;
                            //        Console.WriteLine("没有匹配到此人信息" + searchstr);
                            //        continue;
                            //    }
                            //}
                            //catch (Exception e)
                            //{ Console.WriteLine(e.Message); }
                            //finally
                            //{ mySqlDataReader.Close(); }



                            string Name = ds.Tables["UserInformation"].Rows[icount]["Name"].ToString();
                            string Sex = ds.Tables["UserInformation"].Rows[icount]["Sex"].ToString();
                            string Age = ds.Tables["UserInformation"].Rows[icount]["Age"].ToString();
                            string Married = ds.Tables["UserInformation"].Rows[icount]["Married"].ToString();
                            string Nation = ds.Tables["UserInformation"].Rows[icount]["Nation"].ToString();
                            string NativePlace = ds.Tables["UserInformation"].Rows[icount]["NativePlace"].ToString();
                            string Occupation = ds.Tables["UserInformation"].Rows[icount]["Occupation"].ToString();
                            string WorkUnit = ds.Tables["UserInformation"].Rows[icount]["WorkUnit"].ToString();
                            string Telephone = ds.Tables["UserInformation"].Rows[icount]["Telephone"].ToString();
                            string Address = ds.Tables["UserInformation"].Rows[icount]["Address"].ToString();
                            string PhysicalDate = ds.Tables["UserInformation"].Rows[icount]["PhysicalDate"].ToString();

                            string YangXu = ds.Tables["UserInformation"].Rows[icount]["YangXu"].ToString();
                            string YinXu = ds.Tables["UserInformation"].Rows[icount]["YinXu"].ToString();
                            string QiXu = ds.Tables["UserInformation"].Rows[icount]["QiXu"].ToString();
                            string TanShi = ds.Tables["UserInformation"].Rows[icount]["TanShi"].ToString();
                            string ShiRe = ds.Tables["UserInformation"].Rows[icount]["ShiRe"].ToString();
                            string XueYu = ds.Tables["UserInformation"].Rows[icount]["XueYu"].ToString();
                            string TeBing = ds.Tables["UserInformation"].Rows[icount]["TeBing"].ToString();
                            string QiYu = ds.Tables["UserInformation"].Rows[icount]["QiYu"].ToString();
                            string PingHe = ds.Tables["UserInformation"].Rows[icount]["PingHe"].ToString();


                            string date = ds.Tables["UserInformation"].Rows[icount]["PhysicalDate"].ToString();

                            string answer1 = ds.Tables["UserInformation"].Rows[icount]["Answer1"].ToString();
                            string answer2 = ds.Tables["UserInformation"].Rows[icount]["Answer2"].ToString();
                            string answer3 = ds.Tables["UserInformation"].Rows[icount]["Answer3"].ToString();


                            xmlupload += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                            xmlupload += "<businessdata>";
                            xmlupload += "<ObjectInstance name=\"EHR_Arch_OldHerb\">";


                            string[] tis = answer1.Split('$');
                            string[] tis1 = answer2.Split('$');
                            string[] tis2 = answer3.Split('$');
                            if(tis.Length!=32 || tis1.Length!=29 || tis2.Length != 5)
                            {
                                continue;
                            }

                            //string YangXuZF = ds.Tables["UserInformation"].Rows[icount]["YangXuZF"].ToString();//
                            //string YinXuZF = ds.Tables["UserInformation"].Rows[icount]["YinXuZF"].ToString();//
                            //string QiXuZF = ds.Tables["UserInformation"].Rows[icount]["QiXuZF"].ToString();//
                            //string TanShiZF = ds.Tables["UserInformation"].Rows[icount]["TanShiZF"].ToString();
                            //string ShiReZF = ds.Tables["UserInformation"].Rows[icount]["ShiReZF"].ToString();
                            //string XueYuZF = ds.Tables["UserInformation"].Rows[icount]["XueYuZF"].ToString();
                            //string TeBingZF = ds.Tables["UserInformation"].Rows[icount]["TeBingZF"].ToString();
                            //string QiYuZF = ds.Tables["UserInformation"].Rows[icount]["QiYuZF"].ToString();
                            //string PingHeZF = ds.Tables["UserInformation"].Rows[icount]["PingHeZF"].ToString();

                            int YangXuZF = int.Parse(tis[5]) + int.Parse(tis[6]) + int.Parse(tis[8]) + int.Parse(tis[10]);
                            int YinXuZF = int.Parse(tis[15]) + int.Parse(tis[17]) + int.Parse(tis[19]) + int.Parse(tis[20]);
                            int QiXuZF = int.Parse(tis[21]) + int.Parse(tis[22]) + int.Parse(tis[26]) + int.Parse(tis[9]);
                            int TanShiZF = int.Parse(tis[29]) + int.Parse(tis[30]) + int.Parse(tis1[1]) + int.Parse(tis1[3]);
                            int ShiReZF = int.Parse(tis[20]) + int.Parse(tis1[4]) + int.Parse(tis1[5]) + int.Parse(tis1[7]);
                            int XueYuZF = int.Parse(tis1[13]) + int.Parse(tis1[14]) + int.Parse(tis1[15]) + int.Parse(tis1[23]);
                            int TeBingZF = int.Parse(tis1[18]) + int.Parse(tis1[21]) + int.Parse(tis1[22]) + int.Parse(tis1[24]);
                            int QiYuZF = int.Parse(tis[31]) + int.Parse(tis1[25]) + int.Parse(tis1[26]) + int.Parse(tis1[27]);
                            int PingHeZF =24 + int.Parse(tis[12]) - int.Parse(tis[21]) - int.Parse(tis[26]) - int.Parse(tis[8]) - int.Parse(tis1[26]);


                            //显示结果
                            //YangXuYuanShi = Page2_3 + Page2_4 + Page2_5 + Page4_5; //阳虚  1 2 4 6
                            //YinXuYuanShi = Page2_2 + Page3_5 + Page4_2 + Page4_7;//阴虚 15 11 16 13
                            //QiXuYuanShi = Page1_2 + Page1_3 + Page1_4 + Page2_6;//气虚 17 18 22 5
                            //TanShiYuanShi = Page2_1 + Page2_8 + Page4_4 + Page4_8;//痰湿 25 29 26 31
                            //ShiReYuanShi = Page3_7 + Page4_1 + Page4_3 + Page4_6;//湿热 32 33 16 35
                            //XueYuYuanShi = Page3_3 + Page3_6 + Page3_8 + Page5_1;//血瘀 51 41 42 33
                            //TeBingYuanShi = Page2_7 + Page3_1 + Page3_2 + Page3_4;//特禀 46 49 50 52
                            //QiYuYuanShi = Page1_5 + Page1_6 + Page1_7 + Page1_8;//气郁 54 55 53 27
                            //PingHeYuanShi = Page1_1 + Page6_2 + Page6_4 + Page6_5 + Page6_13; //平和 8 6-17 6-22 6-54 6-4


                            xmlupload += "<Attribute name=\"id\">" + id_no + "</Attribute>";
                            xmlupload += "<Attribute name=\"archiveid\">" + id_no + "</Attribute>";
                            xmlupload += "<Attribute name=\"identityno\">" + id_no + "</Attribute>";
                            xmlupload += "<Attribute name=\"fullname\">" + Name + "</Attribute>";


                            xmlupload += "<Attribute name=\"isEnergeti\">" + numTosstr(tis[12]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isTired\">" + numTosstr(tis[21]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isLoseHeart\">" + numTosstr(tis[22]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isDeepVoice\">" + numTosstr(tis[26]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"islistless\">" + numTosstr(tis1[26]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isJitter\">" + numTosstr(tis1[27]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isAlone\">" + numTosstr(tis1[25]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isScare\">" + numTosstr(tis[31]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isHeavy\">" + numTosstr35(tis[29]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isEyeDry\">" + numTosstr(tis[19]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isExtreCold\">" + numTosstr(tis[5]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isAfaidCold\">" + numTosstr(tis[6]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isResistCold\">" + numTosstr(tis[8]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isCatchCold\">" + numTosstr(tis[9]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isSnorty\">" + numTosstr(tis1[18]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isStertorous\">" + numTosstr(tis1[1]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isAllergic\">" + numTosstr36(tis1[21]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isHives\">" + numTosstr(tis1[22]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isEndermicBlood\">" + numTosstr(tis1[23]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isScore\">" + numTosstr(tis1[24]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isFeverDry\">" + numTosstr(tis[15]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isBodyPain\">" + numTosstr(tis1[13]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isFaceLight\">" + numTosstr(tis1[4]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isFleck\">" + numTosstr(tis1[14]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isTetter\">" + numTosstr(tis1[5]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isLikeDrink\">" + numTosstr(tis[20]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"ismouthBitter\">" + numTosstr(tis1[6]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"ifFat\">" + numTosstr37(tis[30]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isScareColdFood\">" + numTosstr(tis[10]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isStoolStick\">" + numTosstr(tis1[7]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isStoolDry\">" + numTosstr(tis[17]) + "</Attribute>";
                            xmlupload += "<Attribute name=\"isLinguaMassin\">" + numTosstr(tis1[3]) + "</Attribute>";
                       xmlupload += "<Attribute name=\"isLinguaVein\">" + numTosstr(tis1[23]) + "</Attribute>";//还未确定用那个题目分数


                            xmlupload += "<Attribute name=\"physique_qxz\">" + shiTosstr(QiXu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"qxz_Score\">" + QiXuZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"qxz_guide\">" + juide(QiXu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"qxz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"physique_yangxz\">" + shiTosstr(YangXu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"yangxz_Score\">" + YangXuZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"yangxz_guide\">" + juide(YangXu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"yangxz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"physique_yinxz\">" + shiTosstr(YinXu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"yinxz_Score\">" + YinXuZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"yinxz_guide\">" + juide(YinXu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"yinxz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"physique_tsz\">" + shiTosstr(TanShi) + "</Attribute>";
                            xmlupload += "<Attribute name=\"tsz_Score\">" + TanShiZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"tsz_guide\">" + juide(TanShi) + "</Attribute>";
                            xmlupload += "<Attribute name=\"tsz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"physique_srz\">" + shiTosstr(ShiRe) + "</Attribute>";
                            xmlupload += "<Attribute name=\"srz_Score\">" + ShiReZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"srz_guide\">" + juide(ShiRe) + "</Attribute>";
                            xmlupload += "<Attribute name=\"srz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"physique_xyz\">" + shiTosstr(XueYu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"xyz_Score\">" + XueYuZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"xyz_guide\">" + juide(XueYu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"xyz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"physique_qyz\">" + shiTosstr(QiYu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"qyz_Score\">" + QiYuZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"qyz_guide\">" + juide(QiYu) + "</Attribute>";
                            xmlupload += "<Attribute name=\"qyz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"physique_tbz\">" + shiTosstr(TeBing) + "</Attribute>";
                            xmlupload += "<Attribute name=\"tbz_Score\">" + TeBingZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"tbz_guide\">" + juide(TeBing) + "</Attribute>";
                            xmlupload += "<Attribute name=\"tbz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"physique_phz\">" + shiTosstr(PingHe) + "</Attribute>";
                            xmlupload += "<Attribute name=\"phz_Score\">" + PingHeZF + "</Attribute>";
                            xmlupload += "<Attribute name=\"phz_guide\">" + juide(PingHe) + "</Attribute>";
                            xmlupload += "<Attribute name=\"phz_guide_other\">" + "" + "</Attribute>";

                            xmlupload += "<Attribute name=\"reportDate\">" + date + "</Attribute>";
                            xmlupload += "<Attribute name=\"reportDoc\">" + "612525196610010191" + "</Attribute>";
                            xmlupload += "<Attribute name=\"duns\">" + dunc + "</Attribute>";
                            xmlupload += "<Attribute name=\"CREATED_DATE\">" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</Attribute>";
                            xmlupload += "<Attribute name=\"CREATED_BY\">" + "611024436415290" + "</Attribute>";
                            xmlupload += "<Attribute name=\"UPDATED_BY\">" + "611024436415290" + "</Attribute> ";
                            xmlupload += "<Attribute name=\"UPDATED_DATE\">" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "</Attribute> ";

                            xmlupload += "</ObjectInstance>";
                            xmlupload += "</businessdata>";

                            FileStream stream = new FileStream("Result/" + xmlName + ".xml", FileMode.Create, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("utf-8"));
                            writer.WriteLine(xmlupload);
                            writer.Close();
                            stream.Close();
                            xmlupload = "";
                        }
                    }
                    Console.WriteLine("-------xml生成完成-------");
                    conn.Close();
                    //mySql.Close();
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }
                Thread.Sleep(10000);
            }
        }

        private string juide(string result)
        {
            if (result == "是" || result == "倾向是" || result == "基本是")
            {
                return "SX0352_1|SX0352_2|SX0352_3|SX0352_4|SX0352_5";
            }
            else
                return "";
        }


        private string numTosstr(string num)
        {
            if (num == "1")
                return "SX0333_1";
            if (num == "2")
                return "SX0333_2";
            if (num == "3")
                return "SX0333_3";
            if (num == "4")
                return "SX0333_4";
            if (num == "5")
                return "SX0333_5";
            return "";
        }
        private string numTosstr34(string num)
        {
            if (num == "1")
                return "SX0334_1";
            if (num == "2")
                return "SX0334_2";
            if (num == "3")
                return "SX0334_3";
            if (num == "4")
                return "SX0334_4";
            if (num == "5")
                return "SX0334_5";
            return "";
        }

        private string numTosstr35(string num)
        {
            if (num == "1")
                return "SX0335_1";
            if (num == "2")
                return "SX0335_2";
            if (num == "3")
                return "SX0335_3";
            if (num == "4")
                return "SX0335_4";
            if (num == "5")
                return "SX0335_5";
            return "";
        }

        private string numTosstr36(string num)
        {
            if (num == "1")
                return "SX0336_1";
            if (num == "2")
                return "SX0336_2";
            if (num == "3")
                return "SX0336_3";
            if (num == "4")
                return "SX0336_4";
            if (num == "5")
                return "SX0336_5";
            return "";
        }

        private string numTosstr37(string num)
        {
            if (num == "1")
                return "SX0337_1";
            if (num == "2")
                return "SX0337_2";
            if (num == "3")
                return "SX0337_3";
            if (num == "4")
                return "SX0337_4";
            if (num == "5")
                return "SX0337_5";
            return "";
        }

        private string numTosstrFan(string num)
        {
            if (num == "1")
                return "SX0333_5";
            if (num == "2")
                return "SX0333_4";
            if (num == "3")
                return "SX0333_3";
            if (num == "4")
                return "SX0333_2";
            if (num == "5")
                return "SX0333_1";
            return "";
        }

        /// <summary>
        /// 是 基本是 倾向是 转代码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string shiTosstr(string num)
        {
            if (num == "是")
                return "SX0401_1";
            if (num == "基本是")
                return "SX0401_2";
            if (num == "倾向是")
                return "SX0401_2";
            return "";
        }
        public string addressToCode(string addr)
        {
            if (addr.Contains("西照川")) { return "61102443641524X"; }
            if (addr.Contains("漫川关")) { return "611024436415258"; }
            if (addr.Contains("杨地")) { return "611024737998768"; }
            if (addr.Contains("宽坪")) { return "611024436415266"; }
            if (addr.Contains("户家塬")) { return "611024436415274"; }
            if (addr.Contains("小河口")) { return "611024436415282"; }
            if (addr.Contains("色河")|| addr.Contains("元子")) { return "611024436415290"; }
            if (addr.Contains("中村")) { return "611024436415303"; }
            if (addr.Contains("天竺山")) { return "611024436415397"; }
            if (addr.Contains("双坪")) { return "611024436415418"; }
            if (addr.Contains("两岭")) { return "611024436415450"; }
            if (addr.Contains("十里")|| addr.Contains("王庄")) { return "611024436415469"; }
            if (addr.Contains("银花")) { return "611024436415477"; }
            if (addr.Contains("牛耳川")) { return "611024436415485"; }
            if (addr.Contains("石佛寺")) { return "611024436415506"; }
            if (addr.Contains("法官")) { return "611024436415661"; }
            if (addr.Contains("延坪")) { return "611024436415717"; }
            if (addr.Contains("二峪河")) { return "611024436415936"; }
            if (addr.Contains("板岩")) { return "611024436415987"; }
            if (addr.Contains("天桥")) { return "611024436416234"; }
            if (addr.Contains("黄龙")) { return "611024436416736"; }
            if (addr.Contains("王阎")) { return "61102473799875X"; }
            if (addr.Contains("城关")|| addr.Contains("葛条") || addr.Contains("伍竹")) { return "611024436415231"; }
            if (addr.Contains("高坝")|| addr.Contains("申家垤")) { return "611024436415223"; }
            if (addr.Contains("板岩")) { return "611024436415442"; }


            return "";
        }

    }
}
