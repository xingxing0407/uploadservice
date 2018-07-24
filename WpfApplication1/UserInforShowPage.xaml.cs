using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;
using System.IO.Packaging;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Printing;
using Ivan.Kary.WPF.ScreenKeyboard.PCKeyboard;
using System.Diagnostics;
using System.Xml;

namespace WpfApplication1
{
    /// <summary>
    /// UserInforShowPage.xaml 的交互逻辑
    /// </summary>
    public partial class UserInforShowPage : Window
    {
        private long m_IDforFindInfor;
        private string m_NameforFindInfor;
        private DateTime m_BeginTime;
        private DateTime m_EndTime;

        public UserInforShowPage()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
        }
       


        //输入信息判断
        private bool JudeIDinfor()
        {
            //if (tb_ID.Text.Replace(" ", "") == "" && addressToCode(this.duns_select.SelectionBoxItem.ToString()) == "" && tb_Name.Text.Replace(" ", "") == "" && tb_ID_doc.Text.Replace(" ", "") == "")
            //{
            //    MessageBox.Show("请输入身份证号/姓名/机构/医生进行查询！！");
            //    return false;
            //}

            if (tb_ID.Text.Replace(" ", "") == "" && tb_dnsc.Text.Replace(" ", "") == "" && tb_dnsc_name.Text.Replace(" ", "") == "" && tb_Name.Text.Replace(" ", "") == "" && tb_ID_doc.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("请输入身份证号/姓名/机构/医生进行查询！！");
                return false;
            }
            return true;
        }

        //根据选项模糊查询
        public void showUserInfor()
        {
            string sql = "select A.*,B.NAME as dunsname from EHR_Arch_OldHerb A left join his_swjg B on " +
                "a.DUNS = B.DUNS where 1 = 1 ";


            //string address = this.duns_select.SelectionBoxItem.ToString();


            if (tb_ID.Text.Replace(" ", "") != "")
            {
                sql += " and A.ARCHIVEID = '" + tb_ID.Text.Replace(" ", "") + "'";
            }
            if (tb_Name.Text.Replace(" ", "") != "")
            {
                sql += " and A.FULLNAME = '" + tb_Name.Text.Replace(" ", "") + "'";
            }

            //if (addressToCode(address) != "")
            //{
            //    sql += "and DUNS = '" + addressToCode(address) + "'";
            //}

            if (tb_dnsc.Text.Replace(" ", "") != "")
            {
                sql += " and A.DUNS = '" + tb_dnsc.Text.Replace(" ", "") + "'";
            }

            if (tb_dnsc_name.Text.Replace(" ", "") != "")
            {
                sql += " and B.Name like '%" + tb_dnsc_name.Text.Replace(" ", "") + "%'";
            }



            if (tb_ID_doc.Text.Replace(" ", "") != "")
            {
                sql += "and A.REPORTDOC = '" + tb_ID_doc.Text.Replace(" ", "") + "'";
            }




            DBhelp.writelog(sql);
          List<User> users  =  DBhelp.getUserInfo(sql);
          
          dg_ShowUserinfor.ItemsSource = users;

        if(users.Count == 0)
            {
                MessageBox.Show("未查询到数据！！");
            }
        }

        private void bt_ShowUserInforClick(object sender, RoutedEventArgs e)
        {
            if (JudeIDinfor())
            {
                showUserInfor();
            }
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (JudeIDinfor())
                {
                    showUserInfor();
                }
            }
        }
        public static bool IsUserInforShowPrint;
        //private FlowDocument m_doc;
        private void bt_printClick(object sender, RoutedEventArgs e)
        {
         
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load("Result/config.xml");
                    XmlNode xn = xmlDoc.SelectSingleNode("items/szdy");

                    if (xn.InnerXml == "1")
                    {
                        if (this.dg_ShowUserinfor.SelectedItem != null)
                        {

                            User user = this.dg_ShowUserinfor.SelectedItem as User;
                            str_userID = user.id;
                            string sql = "select * from EHR_Arch_OldHerb where ID = '" + str_userID + "'";
                            DBhelp.writelog(sql);
                            DataSet datat = DBhelp.GetDataSet(sql);

                            int i = 0;

                            string ID = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ID"]);
                            string ARCHIVEID = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ARCHIVEID"]);
                            string IDENTITYNO = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["IDENTITYNO"]);
                            string SERVICEID = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["SERVICEID"]);
                            string SERVICENAME = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["SERVICENAME"]);
                            string FULLNAME = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["FULLNAME"]);
                            string ISENERGETI = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISENERGETI"]));
                            string ISTIRED = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISTIRED"]));
                            string ISLOSEHEART = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISLOSEHEART"]));
                            string ISDEEPVOICE = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISDEEPVOICE"]));
                            string ISLISTLESS = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISLISTLESS"]));
                            string ISJITTER = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISJITTER"]));
                            string ISALONE = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISALONE"]));
                            string ISSCARE = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISSCARE"]));
                            string ISHEAVY = strTosnum34(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISHEAVY"]));
                            string ISEYEDRY = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISEYEDRY"]));
                            string ISEXTRECOLD = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISEXTRECOLD"]));
                            string ISAFAIDCOLD = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISAFAIDCOLD"]));
                            string ISRESISTCOLD = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISRESISTCOLD"]));
                            string ISCATCHCOLD = strTosnum35(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISCATCHCOLD"]));
                            string ISSNORTY = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISSNORTY"]));
                            string ISSTERTOROUS = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISSTERTOROUS"]));
                            string ISALLERGIC = strTosnum36(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISALLERGIC"]));
                            string ISHIVES = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISHIVES"]));
                            string ISENDERMICBLOOD = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISENDERMICBLOOD"]));
                            string ISSCORE = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISSCORE"]));
                            string ISFEVERDRY = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISFEVERDRY"]));
                            string ISBODYPAIN = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISBODYPAIN"]));
                            string ISFACELIGHT = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISFACELIGHT"]));
                            string ISFLECK = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISFLECK"]));
                            string ISTETTER = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISTETTER"]));
                            string ISLIKEDRINK = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISLIKEDRINK"]));
                            string ISMOUTHBITTER = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISMOUTHBITTER"]));
                            string IFFAT = strTosnum37(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["IFFAT"]));
                            string ISSCARECOLDFOOD = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISSCARECOLDFOOD"]));
                            string ISSTOOLSTICK = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISSTOOLSTICK"]));
                            string ISSTOOLDRY = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISSTOOLDRY"]));
                            string ISLINGUAMASSIN = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISLINGUAMASSIN"]));
                            string ISLINGUAVEIN = strTosnum33(DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["ISLINGUAVEIN"]));
                            string PHYSIQUE_QXZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_QXZ"]);
                            string PHYSIQUE_YANGXZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_YANGXZ"]);
                            string PHYSIQUE_YINXZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_YINXZ"]);
                            string PHYSIQUE_TSZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_TSZ"]);
                            string PHYSIQUE_SRZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_SRZ"]);
                            string PHYSIQUE_XYZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_XYZ"]);
                            string PHYSIQUE_QYZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_QYZ"]);
                            string PHYSIQUE_TBZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_TBZ"]);
                            string PHYSIQUE_PHZ = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHYSIQUE_PHZ"]);
                            string REPORTDATE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["REPORTDATE"]);
                            string REPORTDOC = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["REPORTDOC"]);
                            string STATUS = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["STATUS"]);
                            string CREATED_BY = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["CREATED_BY"]);
                            string CREATED_DATE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["CREATED_DATE"]);
                            string UPDATED_BY = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["UPDATED_BY"]);
                            string UPDATED_DATE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["UPDATED_DATE"]);
                            string DISABLED_BY = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["DISABLED_BY"]);
                            string DUNS = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["DUNS"]);
                            string DISABLED_DATE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["DISABLED_DATE"]);
                            string QXZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["QXZ_SCORE"]);
                            string YANGXZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["YANGXZ_SCORE"]);
                            string YINXZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["YINXZ_SCORE"]);
                            string TSZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["TSZ_SCORE"]);
                            string SRZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["SRZ_SCORE"]);
                            string XYZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["XYZ_SCORE"]);
                            string QYZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["QYZ_SCORE"]);
                            string TBZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["TBZ_SCORE"]);
                            string PHZ_SCORE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHZ_SCORE"]);
                            string QXZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["QXZ_GUIDE"]);
                            string YANGXZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["YANGXZ_GUIDE"]);
                            string YINXZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["YINXZ_GUIDE"]);
                            string TSZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["TSZ_GUIDE"]);
                            string SRZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["SRZ_GUIDE"]);
                            string XYZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["XYZ_GUIDE"]);
                            string QYZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["QYZ_GUIDE"]);
                            string TBZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["TBZ_GUIDE"]);
                            string PHZ_GUIDE = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHZ_GUIDE"]);
                            string QXZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["QXZ_GUIDE_OTHER"]);
                            string YANGXZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["YANGXZ_GUIDE_OTHER"]);
                            string YINXZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["YINXZ_GUIDE_OTHER"]);
                            string TSZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["TSZ_GUIDE_OTHER"]);
                            string SRZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["SRZ_GUIDE_OTHER"]);
                            string XYZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["XYZ_GUIDE_OTHER"]);
                            string QYZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["QYZ_GUIDE_OTHER"]);
                            string TBZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["TBZ_GUIDE_OTHER"]);
                            string PHZ_GUIDE_OTHER = DBhelp.ObjectToString(datat.Tables["Table"].Rows[i]["PHZ_GUIDE_OTHER"]);

                            string sql1 = "select docname from EHR_His_doc where card_id = '" + REPORTDOC + "'";
                            DataSet doc = DBhelp.GetDataSet(sql1);
                            string docname = DBhelp.ObjectToString(doc.Tables["Table"].Rows[0]["docname"]);
                            DBhelp.writelog(docname);

                            string str1 = ID + "$" + ARCHIVEID + "$" + IDENTITYNO + "$" + SERVICEID + "$" + SERVICENAME + "$" + FULLNAME + "$" + ISENERGETI + "$" + ISTIRED + "$" + ISLOSEHEART + "$" + ISDEEPVOICE + "$" + ISLISTLESS + "$" + ISJITTER + "$" + ISALONE + "$" + ISSCARE + "$" + ISHEAVY + "$" + ISEYEDRY + "$" + ISEXTRECOLD + "$" + ISAFAIDCOLD + "$" + ISRESISTCOLD + "$" + ISCATCHCOLD + "$" + ISSNORTY + "$" + ISSTERTOROUS + "$" + ISALLERGIC + "$" + ISHIVES + "$" + ISENDERMICBLOOD + "$" + ISSCORE + "$" + ISFEVERDRY + "$" + ISBODYPAIN + "$" + ISFACELIGHT;
                            string str2 = ISFLECK + "$" + ISTETTER + "$" + ISLIKEDRINK + "$" + ISMOUTHBITTER + "$" + IFFAT + "$" + ISSCARECOLDFOOD + "$" + ISSTOOLSTICK + "$" + ISSTOOLDRY + "$" + ISLINGUAMASSIN + "$" + ISLINGUAVEIN + "$" + QXZ_SCORE + "$" + YANGXZ_SCORE + "$" + YINXZ_SCORE + "$" + TSZ_SCORE + "$" + SRZ_SCORE + "$" + XYZ_SCORE + "$" + QYZ_SCORE + "$" + TBZ_SCORE + "$" + PHZ_SCORE + "$" + REPORTDATE + "$" + docname + "$" + PHYSIQUE_QXZ + "$" + PHYSIQUE_YANGXZ + "$" + PHYSIQUE_YINXZ + "$" + PHYSIQUE_TSZ + "$" + PHYSIQUE_SRZ + "$" + PHYSIQUE_XYZ + "$" + PHYSIQUE_QYZ + "$" + PHYSIQUE_TBZ + "$" + PHYSIQUE_PHZ;
                            ;

                            //DBhelp.writelog(str1);
                            //DBhelp.writelog(str2);
                            //  m_doc = LoadDocumentAndRender("OrderDocument.xaml", tabPage);
                            //OrderDocument orderDoc = (OrderDocument)m_doc;
                            //string strPath = FileHelper.SaveXPS(m_doc, false, "w2");
                            //XpsDocument xpsDocument = new XpsDocument(strPath, FileAccess.Read);

                            //FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                            System.Windows.Controls.PrintDialog dialog = new System.Windows.Controls.PrintDialog();
                            dialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();

                            //dialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print");
                            //xpsDocument.Close();

                            //string qustionstrs1 = "201605186110240000202$612525195001181417$58$男$15463216531$苗留成$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1$1";
                            H_Print_trouble h_pr = new H_Print_trouble(str1);
                       
                        string strPath1 = FileHelper.SaveXPS1(h_pr.printArea, false, "w2");
                            XpsDocument xpsDocument1 = new XpsDocument(strPath1, FileAccess.Read);
                        
                            FixedDocumentSequence fixedDocSeq1 = xpsDocument1.GetFixedDocumentSequence();
                        
                            System.Windows.Controls.PrintDialog dialog1 = new System.Windows.Controls.PrintDialog();
                            dialog1.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
                            dialog1.PrintDocument(fixedDocSeq1.DocumentPaginator, FULLNAME+"");
                            xpsDocument1.Close();



                        //string qustionstrs2 = "1$1$1$1$1$1$1$1$1$1$4$4$4$4$4$4$4$4$21$2017/4/17$612525195001181417$$$$$SX0088_1$$$$SX0401_1";
                        H_Print_trouble1 h_pr1 = new H_Print_trouble1(str2);
                        string strPath2 = FileHelper.SaveXPS1(h_pr1.p2, false, "w2");
                        XpsDocument xpsDocument2 = new XpsDocument(strPath2, FileAccess.Read);
                        FixedDocumentSequence fixedDocSeq2 = xpsDocument2.GetFixedDocumentSequence();
                        System.Windows.Controls.PrintDialog dialog2 = new System.Windows.Controls.PrintDialog();
                        dialog2.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();
                        dialog2.PrintDocument(fixedDocSeq2.DocumentPaginator, FULLNAME + "_2");
                        xpsDocument2.Close();






                        H_Print_trouble arv = new H_Print_trouble(str1);
                            string strPath = FileHelper.SaveXPS1(arv.printArea, false, "w2");
                            XpsDocument xpsDocument = new XpsDocument(strPath, FileAccess.Read);
                            FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                            RenderTargetBitmap targetBitmap = new RenderTargetBitmap(1240, 1750, 150d, 150d, PixelFormats.Pbgra32);
                            targetBitmap.Render(arv.printArea);
                            PngBitmapEncoder encoder = new PngBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(targetBitmap));
                            FileStream fs = File.Open(System.AppDomain.CurrentDomain.BaseDirectory + @"\Result\" + FULLNAME + "_1.png", FileMode.Create);
                            encoder.Save(fs);
                            fs.Close();
                            xpsDocument.Close();

                            H_Print_trouble1 arv1 = new H_Print_trouble1(str2);
                             strPath = FileHelper.SaveXPS1(arv1.p2, false, "w2");
                             xpsDocument = new XpsDocument(strPath, FileAccess.Read);
                             fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                             targetBitmap = new RenderTargetBitmap(1240, 1750, 150d, 150d, PixelFormats.Pbgra32);
                            targetBitmap.Render(arv1.p2);
                             encoder = new PngBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(targetBitmap));
                             fs = File.Open(System.AppDomain.CurrentDomain.BaseDirectory + @"\Result\" + FULLNAME + "_2.png", FileMode.Create);
                            encoder.Save(fs);
                            fs.Close();
                            xpsDocument.Close();


                    }
                    else
                    {
                        MessageBox.Show("请选择要打印人员！！");
                    }
                    }

                    //IsUserInforShowPrint = false ;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        private string strTosnum33(string str)
        {
            if (str == "SX0333_1")
                return "1";
            if (str == "SX0333_2")
                return "2";
            if (str == "SX0333_3")
                return "3";
            if (str == "SX0333_4")
                return "4";
            if (str == "SX0333_5")
                return "5";
            return "0";
        }
        private string strTosnum34(string str)
        {
            if (str == "SX0334_1")
                return "1";
            if (str == "SX0334_2")
                return "2";
            if (str == "SX0334_3")
                return "3";
            if (str == "SX0334_4")
                return "4";
            if (str == "SX0334_5")
                return "5";
            return "0";
        }
        private string strTosnum35(string str)
        {
            if (str == "SX0335_1")
                return "1";
            if (str == "SX0335_2")
                return "2";
            if (str == "SX0335_3")
                return "3";
            if (str == "SX0335_4")
                return "4";
            if (str == "SX0335_5")
                return "5";
            return "0";
        }
        private string strTosnum36(string str)
        {
            if (str == "SX0336_1")
                return "1";
            if (str == "SX0336_2")
                return "2";
            if (str == "SX0336_3")
                return "3";
            if (str == "SX0336_4")
                return "4";
            if (str == "SX0336_5")
                return "5";
            return "0";
        }
        private string strTosnum37(string str)
        {
            if (str == "SX0337_1")
                return "1";
            if (str == "SX0337_2")
                return "2";
            if (str == "SX0337_3")
                return "3";
            if (str == "SX0337_4")
                return "4";
            if (str == "SX0337_5")
                return "5";
            return "0";
        }






        //private string numTosstrFan(string num)
        //{
        //    if (num == "1")
        //        return "SX0333_5";
        //    if (num == "2")
        //        return "SX0333_4";
        //    if (num == "3")
        //        return "SX0333_3";
        //    if (num == "4")
        //        return "SX0333_2";
        //    if (num == "5")
        //        return "SX0333_1";
        //    return "";
        //}

        /// <summary>
        /// 是 基本是 倾向是 转代码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string shiTosstr(string num)
        {
            if (num == "是")
                return "SX0088_1";
            if (num == "基本是")
                return "SX0088_2";
            if (num == "倾向是")
                return "SX0088_2";
            return "";
        }

        /// <summary>
        /// 是 基本是 倾向是 转代码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string pingheTosstr(string num)
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
            if (addr.Contains("色河") || addr.Contains("元子")) { return "611024436415290"; }
            if (addr.Contains("中村")) { return "611024436415303"; }
            if (addr.Contains("天竺山")) { return "611024436415397"; }
            if (addr.Contains("双坪")) { return "611024436415418"; }
            if (addr.Contains("两岭")) { return "611024436415450"; }
            if (addr.Contains("十里") || addr.Contains("王庄")) { return "611024436415469"; }
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
            if (addr.Contains("城关") || addr.Contains("葛条") || addr.Contains("伍竹")) { return "611024436415231"; }
            if (addr.Contains("高坝") || addr.Contains("申家垤")) { return "611024436415223"; }
            if (addr.Contains("板岩")) { return "611024436415442"; }


            return "";
        }

        public void LoadXps()
        {
            //构造一个基于内存的xps document
            //MemoryStream ms = new MemoryStream();
            //Package package = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
            //Uri DocumentUri = new Uri("pack://InMemoryDocument.xps");
            //PackageStore.RemovePackage(DocumentUri);
            //PackageStore.AddPackage(DocumentUri, package);
            //XpsDocument xpsDocument = new XpsDocument(package, CompressionOption.Fast, DocumentUri.AbsoluteUri);
            ////将flow document写入基于内存的xps document中去
            //XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            //writer.Write(((IDocumentPaginatorSource)m_doc).DocumentPaginator);
            ////获取这个基于内存的xps document的fixed document
            //xpsDocument.GetFixedDocumentSequence();
            ////关闭基于内存的xps document
            //xpsDocument.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Pressed)
            //{
            //    DragMove();
            //}
            //PCKeyboard.ExitScreenKeyboard(this.tb_ID);
        }

        //public static long m_userID;
        public static string str_userID;
        private void bt_YulanClick(object sender, RoutedEventArgs e)
        {
            //if (this.dg_ShowUserinfor.SelectedItem != null)
            //{
            //    try
            //    {
            //       // m_userID = Convert.ToInt64(((DataRowView)this.dg_ShowUserinfor.SelectedItem).Row.ItemArray[0].ToString().Trim());
            //        str_userID = ((DataRowView)this.dg_ShowUserinfor.SelectedItem).Row.ItemArray[0].ToString().Trim();
            //        PrintPreviewWindow previewWnd = new PrintPreviewWindow("OrderDocument.xaml", tabPage);
            //        previewWnd.Owner = this;
            //        previewWnd.ShowInTaskbar = false;
            //        previewWnd.ShowDialog();
            //    }
            //    //catch { MessageBox.Show("请连接打印机"); }
            //    catch (Exception ex)
            //    { MessageBox.Show(ex.Message); }
            //}
        }

        private void Page_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_min(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string str = duns_select.SelectedValue.ToString();
        //    Console.WriteLine(str);
        //}
    }
}
