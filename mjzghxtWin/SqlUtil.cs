using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mjzghxtWin
{
    public class SqlUtil
    {
        const string conStr = @"data source=(localdb)\MSSQLLocalDB;initial catalog=mjzglxtWin;" +
            "integrated security=true";
        /// <summary>
        /// 创建SqlConnection对象
        /// </summary>
        /// <returns></returns>
        public static SqlConnection CreateConnection()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            return con;
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSql(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd=con.CreateCommand();
            cmd.CommandText = sql;
            int ret=cmd.ExecuteNonQuery();
            con.Close();
            return ret;
        }
        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        /// <summary>
        /// 查找数据，返回一个结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sql,con);
            con.Open();
            DataTable de_result = new DataTable();
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(de_result);
            return de_result;

        }
    }
}
