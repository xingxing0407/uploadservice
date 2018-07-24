using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace WpfApplication1
{
    public static class DBhelp
    {
        //连接字符串
        //private static string strConn = 
        //    "Data Source =" + System.Windows.Forms.Application.StartupPath + "\\DBM2000.sqlite;";
      
        private static string strConn =
            "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST="+App.ipaddress+")(PORT="+App.strport+"))(CONNECT_DATA=(SERVICE_NAME="+App.strservicename+")));Persist Security Info=True;User ID="+App.userid+";Password="+App.pwd+";";

        internal static void writelog(string msg)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Windows.Forms.Application.StartupPath + "/rlog.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + msg);
            }
        }
        internal static List<User> getUserInfo(string sql)
        {
            List<User> users = new List<User>();
            DataSet datat = GetDataSet(sql);
            int intneednum = datat.Tables["Table"].Rows.Count;
            for (int i = 0; i < intneednum; i++)
            {
                User user = new User();
                user.num = (i + 1).ToString();
                user.id = ObjectToString(datat.Tables["Table"].Rows[i]["ID"]);
                user.archiveid = ObjectToString(datat.Tables["Table"].Rows[i]["ARCHIVEID"]);
                user.name = ObjectToString(datat.Tables["Table"].Rows[i]["FULLNAME"]);
                user.reportDate = ObjectToString(datat.Tables["Table"].Rows[i]["REPORTDATE"]).Substring(0,10);
                user.duns = ObjectToString(datat.Tables["Table"].Rows[i]["dunsname"]);
                users.Add(user);
            }
            return users;
        }

        public static string codeToAddress(string code)
        {
            if (code == "61102443641524X") return "西照川镇中心卫生院";
            if (code == "611024436415258") return "漫川关镇中心卫生院";
            if (code == "611024737998768") return "杨地镇中心卫生院";
            if (code == "611024436415266") return "宽坪镇中心卫生院";
            if (code == "611024436415274") return "户家塬镇中心卫生院";
            if (code == "611024436415282") return "小河口镇中心卫生院";
            if (code == "611024436415290") return "色河铺镇中心卫生院";
            if (code == "611024436415303") return "中村镇中心卫生院";
            if (code == "611024436415397") return "天竺山镇卫生院";
            if (code == "611024436415418") return "双坪镇卫生院";
            if (code == "611024436415450") return "两岭镇卫生院";
            if (code == "611024436415469") return "十里铺街道卫生院";
            if (code == "611024436415477") return "银花镇卫生院";
            if (code == "611024436415485") return "牛耳川镇卫生院";
            if (code == "611024436415506") return "石佛寺镇卫生院";
            if (code == "611024436415661") return "法官镇卫生院";
            if (code == "611024436415717") return "延坪镇卫生院";
            if (code == "611024436415936") return "二峪河乡卫生院";
            if (code == "611024436415987") return "板岩镇中心卫生院";
            if (code == "611024436416234") return "天桥镇卫生院";
            if (code == "611024436416736") return "黄龙乡卫生院";
            if (code == "61102473799875X") return "王阎镇卫生院";
            if (code == "611024436415231") return "城关街道中心卫生院";
            if (code == "611024436415223") return "高坝店镇中心卫生院";
            if (code == "611024436415442") return "板岩镇中心卫生院马滩门诊部";
            return code;
        } 

        public static string addressToCode(string address)
        {
            if (address == "西照川镇中心卫生院") return "61102443641524X";
            if (address == "漫川关镇中心卫生院") return "611024436415258";
            if (address == "杨地镇中心卫生院") return "611024737998768";
            if (address == "宽坪镇中心卫生院") return "611024436415266";
            if (address == "户家塬镇中心卫生院") return "611024436415274";
            if (address == "小河口镇中心卫生院") return "611024436415282";
            if (address == "色河铺镇中心卫生院") return "611024436415290";
            if (address == "中村镇中心卫生院") return "611024436415303";
            if (address == "天竺山镇卫生院") return "611024436415397";
            if (address == "双坪镇卫生院") return "611024436415418";
            if (address == "两岭镇卫生院") return "611024436415450";
            if (address == "十里铺街道卫生院") return "611024436415469";
            if (address == "银花镇卫生院") return "611024436415477";
            if (address == "牛耳川镇卫生院") return "611024436415485";
            if (address == "石佛寺镇卫生院") return "611024436415506";
            if (address == "法官镇卫生院") return "611024436415661";
            if (address == "延坪镇卫生院") return "611024436415717";
            if (address == "二峪河乡卫生院") return "611024436415936";
            if (address == "板岩镇中心卫生院") return "611024436415987";
            if (address == "天桥镇卫生院") return "611024436416234";
            if (address == "黄龙乡卫生院") return "611024436416736";
            if (address == "王阎镇卫生院") return "61102473799875X";
            if (address == "城关街道中心卫生院") return "611024436415231";
            if (address == "高坝店镇中心卫生院") return "611024436415223";
            if (address == "板岩镇中心卫生院马滩门诊部") return "611024436415442";

            return "";
        }

       public static string ObjectToString(Object obj)
       {
           if (obj == null)
           {
               return "";
           }
           else
               return obj.ToString();

       }
        #region  示例
                //public static List<User> GetUsers(string id,string name,string birthday)
                //{
                //    string sql = "";
                //    if(id != null)
                //    {
                //        sql = "select * from [User] where [ID] = '" + id + "'";
                //    }else if(name != null)
                //    {
                //        sql = "select * from [User] where [Name] like '%" + name + "%'";
                //    }else if(birthday != null)
                //    {
                //        sql = "select * from [User] where [Birthday] = '" + birthday + "'";
                //    }
                //    else
                //    {
                //        sql = "select * from [User] order by [RegisterDay] desc";
                //    }

                //   List<User> users =  new List<User>();
                //    DataSet datat = GetDataSet(sql);
                //    int intneednum = datat.Tables["Table"].Rows.Count;
                //    for(int i = 0; i < intneednum; i++)
                //    {
                //        User user = new User();

                //        string str = Utils.ObjToString( datat.Tables["Table"].Rows[i]["ID"]);
                //        string str1 = Utils.ObjToString(datat.Tables["Table"].Rows[i]["Name"]);
                //        string birthDay = Utils.ObjToString(datat.Tables["Table"].Rows[i]["Birthday"]);
                //        string age = Utils.ObjToString(datat.Tables["Table"].Rows[i]["Age"]);
                //        user.RegisterDay = Utils.ObjToString(datat.Tables["Table"].Rows[i]["RegisterDay"]);
                //        user.Foot = Utils.ObjToInt(datat.Tables["Table"].Rows[i]["TestFoot"]);
                //        user.Sex = Utils.ObjToInt(datat.Tables["Table"].Rows[i]["Sex"]);
                //        user.BirthDay = birthDay;
                //        user.ID = str;
                //        user.Age = int.Parse(age);
                //        user.Name = str1;
                //        users.Add(user);
                //    }
                //    return users;
                //}

                //internal static void SetUpdateFlag(string iD)
                //{
                //    string sql = "update [ResultInfo] set [Upload] = '1' where ID = '" + iD+"'";
                //    try
                //    {
                //        ExcuteSQL(sql);
                //    }
                //    catch (Exception e)
                //    {
                //        WindowShow.Show(e.Message);
                //    }
                //}


            //}

            //public static ResultInfo GetResultInfoLast(ResultInfo r)
            //{
            //    string sql = "";
            //    sql = "select * from [ResultInfo] where [UserID] = '" + r.UserID + "' and RecordTime < '"+r.RecordTime + "' order by RecordTime desc";
            //    List<ResultInfo> resultInfos = ResultInfotoResult(sql);
            //    if(resultInfos.Count == 0)
            //        return null;
            //    else
            //        return resultInfos[0];
            //}


            //public static List<ResultInfo> GetResultNotUpdate()
            //{
            //    string sql = "";
            //    sql = "select * from [ResultInfo] where Upload is null";
            //    return ResultInfotoResult(sql);
            //}

            //private static List<ResultInfo> ResultInfotoResult(string sql)
            //{
            //    DataSet datat = GetDataSet(sql);
            //    List<ResultInfo> resultInfos = new List<ResultInfo>();
            //    int intneednum = datat.Tables["Table"].Rows.Count;
            //    for (int i = 0; i < intneednum; i++)
            //    {
            //        ResultInfo resultInfo = new ResultInfo();
            //        resultInfo.ID = Utils.ObjToString(datat.Tables["Table"].Rows[i]["ID"]);
            //        resultInfo.OI = Math.Round(Utils.ObjToDouble(datat.Tables["Table"].Rows[i]["OI"]), 1, MidpointRounding.AwayFromZero);
            //        resultInfo.BUA = Math.Round(Utils.ObjToDouble(datat.Tables["Table"].Rows[i]["BUA"]), 1, MidpointRounding.AwayFromZero);
            //        resultInfo.SOS = Math.Round(Utils.ObjToDouble(datat.Tables["Table"].Rows[i]["SOS"]), 1, MidpointRounding.AwayFromZero);
            //        resultInfo.T_Score = Math.Round(Utils.ObjToDouble(datat.Tables["Table"].Rows[i]["T_Score"]), 2, MidpointRounding.AwayFromZero);
            //        resultInfo.Z_Score = Math.Round(Utils.ObjToDouble(datat.Tables["Table"].Rows[i]["Z_Score"]), 2, MidpointRounding.AwayFromZero);
            //        resultInfo.RecordTime = Utils.ObjToString(datat.Tables["Table"].Rows[i]["RecordTime"]);
            //        resultInfo.UserID = Utils.ObjToString(datat.Tables["Table"].Rows[i]["UserID"]);
            //        resultInfos.Add(resultInfo);
            //    }
            //    return resultInfos;
            //}
        #endregion


    #region 执行查询，返回DataTable对象-----------------------
    public static DataTable GetTable(string strSQL)
        {
            return GetTable(strSQL, null);
        }
        public static DataTable GetTable(string strSQL, SqlParameter[] pas)
        {
            return GetTable(strSQL, pas, CommandType.Text);
        }
        /// <summary>
        /// 执行查询，返回DataTable对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="pas">参数数组</param>
        /// <param name="cmdtype">Command类型</param>
        /// <returns>DataTable对象</returns>
        public static DataTable GetTable(string strSQL, SqlParameter[] pas, CommandType cmdtype)
        {
            DataTable dt = new DataTable(); ;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                da.SelectCommand.CommandType = cmdtype;
                if (pas != null)
                {
                    da.SelectCommand.Parameters.AddRange(pas);
                }
                da.Fill(dt);
            }
            return dt;
        }
        #endregion

        #region 执行查询，返回DataSet对象-------------------------
        public static DataSet GetDataSet(string strSQL)
        {
            return GetDataSet(strSQL, null);
        }

        public static DataSet GetDataSet(string strSQL, SqlParameter[] pas)
        {
            return GetDataSet(strSQL, pas, CommandType.Text);
        }
        /// <summary>
        /// 执行查询，返回DataSet对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="pas">参数数组</param>
        /// <param name="cmdtype">Command类型</param>
        /// <returns>DataSet对象</returns>
        public static DataSet GetDataSet(string strSQL, SqlParameter[] pas, CommandType cmdtype)
        {
            DataSet dt = new DataSet();
            OracleConnection conn = new OracleConnection(strConn);
            conn.Open();
            
                OracleDataAdapter da = new OracleDataAdapter(strSQL, conn);
                da.SelectCommand.CommandType = cmdtype;
                if (pas != null)
                {
                    da.SelectCommand.Parameters.AddRange(pas);
                }
                da.Fill(dt);
            conn.Close();
            return dt;
        }
        #endregion

        #region 执行非查询存储过程和SQL语句-----------------------------

        public static int ExcuteProc(string ProcName)
        {
            return ExcuteSQL(ProcName, null, CommandType.StoredProcedure);
        }

        public static int ExcuteProc(string ProcName, SqlParameter[] pars)
        {
            return ExcuteSQL(ProcName, pars, CommandType.StoredProcedure);
        }

        public static int ExcuteSQL(string strSQL)
        {
            return ExcuteSQL(strSQL, null);
        }

        public static int ExcuteSQL(string strSQL, SqlParameter[] paras)
        {
            return ExcuteSQL(strSQL, paras, CommandType.Text);
        }

        /// 执行非查询存储过程和SQL语句
        /// 增、删、改
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <param name="cmdType">Command类型</param>
        /// <returns>返回影响行数</returns>
        public static int ExcuteSQL(string strSQL, SqlParameter[] paras, CommandType cmdType)
        {
            int i = 0;
            using (OracleConnection conn = new OracleConnection(strConn))
            {
                OracleCommand cmd = new OracleCommand(strSQL, conn);
                cmd.CommandType = cmdType;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                conn.Open();
                i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return i;

        }
        #endregion

        #region 执行查询返回第一行，第一列---------------------------------
        public static int ExcuteScalarSQL(string strSQL)
        {
            return ExcuteScalarSQL(strSQL, null);
        }

        public static int ExcuteScalarSQL(string strSQL, SqlParameter[] paras)
        {
            return ExcuteScalarSQL(strSQL, paras, CommandType.Text);
        }
        public static int ExcuteScalarProc(string strSQL, SqlParameter[] paras)
        {
            return ExcuteScalarSQL(strSQL, paras, CommandType.StoredProcedure);
        }
        /// <summary>
        /// 执行SQL语句，返回第一行，第一列
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <returns>返回影响行数</returns>
        public static int ExcuteScalarSQL(string strSQL, SqlParameter[] paras, CommandType cmdType)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.CommandType = cmdType;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                conn.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            return i;

        }
        #endregion

        #region 查询获取单个值------------------------------------

        /// <summary>
        /// 调用不带参数的存储过程获取单个值
        /// </summary>
        /// <param name="ProcName"></param>
        /// <returns></returns>
        public static object GetObjectByProc(string ProcName)
        {
            return GetObjectByProc(ProcName, null);
        }
        /// <summary>
        /// 调用带参数的存储过程获取单个值
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object GetObjectByProc(string ProcName, SqlParameter[] paras)
        {
            return GetObject(ProcName, paras, CommandType.StoredProcedure);
        }
        /// <summary>
        /// 根据sql语句获取单个值
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static object GetObject(string strSQL)
        {
            return GetObject(strSQL, null);
        }
        /// <summary>
        /// 根据sql语句 和 参数数组获取单个值
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object GetObject(string strSQL, SqlParameter[] paras)
        {
            return GetObject(strSQL, paras, CommandType.Text);
        }

        /// <summary>
        /// 执行SQL语句，返回首行首列
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <returns>返回的首行首列</returns>
        public static object GetObject(string strSQL, SqlParameter[] paras, CommandType cmdtype)
        {
            object o = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.CommandType = cmdtype;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);

                }

                conn.Open();
                o = cmd.ExecuteScalar();
                conn.Close();
            }
            return o;

        }
        #endregion

        #region 查询获取DataReader------------------------------------

        /// <summary>
        /// 调用不带参数的存储过程，返回DataReader对象
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns>DataReader对象</returns>
        public static SqlDataReader GetReaderByProc(string procName)
        {
            return GetReaderByProc(procName, null);
        }
        /// <summary>
        /// 调用带有参数的存储过程，返回DataReader对象
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="paras">参数数组</param>
        /// <returns>DataReader对象</returns>
        public static SqlDataReader GetReaderByProc(string procName, SqlParameter[] paras)
        {
            return GetReader(procName, paras, CommandType.StoredProcedure);
        }
        /// <summary>
        /// 根据sql语句返回DataReader对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <returns>DataReader对象</returns>
        public static SqlDataReader GetReader(string strSQL)
        {
            return GetReader(strSQL, null);
        }
        /// <summary>
        /// 根据sql语句和参数返回DataReader对象
        /// </summary>
        /// <param name="strSQL">sql语句</param>
        /// <param name="paras">参数数组</param>
        /// <returns>DataReader对象</returns>
        public static SqlDataReader GetReader(string strSQL, SqlParameter[] paras)
        {
            return GetReader(strSQL, paras, CommandType.Text);
        }
        /// <summary>
        /// 查询SQL语句获取DataReader
        /// </summary>
        /// <param name="strSQL">查询的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <returns>查询到的DataReader（关闭该对象的时候，自动关闭连接）</returns>
        public static SqlDataReader GetReader(string strSQL, SqlParameter[] paras, CommandType cmdtype)
        {
            SqlDataReader sqldr = null;
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.CommandType = cmdtype;
            if (paras != null)
            {
                cmd.Parameters.AddRange(paras);
            }
            conn.Open();
            //CommandBehavior.CloseConnection的作用是如果关联的DataReader对象关闭，则连接自动关闭
            sqldr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sqldr;
        }
        #endregion

        #region 批量插入数据---------------------------------------------
        /// <summary>
        /// 往数据库中批量插入数据
        /// </summary>
        /// <param name="sourceDt">数据源表</param>
        /// <param name="targetTable">服务器上目标表</param>
        public static void BulkToDB(DataTable sourceDt, string targetTable)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);   //用其它源的数据有效批量加载sql server表中
            bulkCopy.DestinationTableName = targetTable;    //服务器上目标表的名称
            bulkCopy.BatchSize = sourceDt.Rows.Count;   //每一批次中的行数

            try
            {
                conn.Open();
                if (sourceDt != null && sourceDt.Rows.Count != 0)
                    bulkCopy.WriteToServer(sourceDt);   //将提供的数据源中的所有行复制到目标表中
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                if (bulkCopy != null)
                    bulkCopy.Close();
            }

        }

        #endregion


    }
}
