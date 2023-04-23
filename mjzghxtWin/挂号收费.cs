using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mjzghxtWin
{
    public partial class 挂号收费 : Form
    {
        string 收费员;
        bool 急诊挂号;
        public 挂号收费(string 收费员,bool 急诊挂号)
        {
            InitializeComponent();
            this.收费员 = 收费员;
            this.急诊挂号 = 急诊挂号;
            if (急诊挂号)
            {
                this.Text = "急诊挂号收费";
            }
        }

        private void 病人查询_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns=false;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {   
            //只显示未收费且未退号的挂号记录
            string sql = "select 病人.*,挂号.挂号日期,挂号.挂号序号,挂号.就诊卡号,挂号.挂号科室,挂号.挂号医生," +
                "挂号.号别,挂号.挂号费,挂号.是否收费,挂号.是否退号 from 病人,挂号 where 病人.门诊号=挂号.门诊号" +
                " and 挂号.是否收费=0 and 挂号.是否退号=0";
            string 门诊号 = toolStripTextBox1.Text;
            string 姓名 = toolStripTextBox2.Text;
            
            if (门诊号.Length > 0)
            {
                sql += " and 门诊号='" + 门诊号 + "'";
            }
            if(姓名.Length > 0)
            {
                sql += " and 姓名 like N'%" + 姓名 + "%'";
            }
            if (急诊挂号)
            {
                sql += " and 挂号.急诊挂号=1";
            }
            else
            {
                sql += " and 挂号.急诊挂号=0";
            }

            //查询数据库
            bindingSource1.Clear();
            SqlDataReader reader = SqlUtil.ExecuteReader(sql);
            if(reader.HasRows)
                bindingSource1.DataSource = reader;


            //if (reader.Read())
            //{
            //    MessageBox.Show("OK!");
            //}
            //dataGridView1与bindingSource1绑定
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();


        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            {
                MessageBox.Show("请选择要挂号的病人");
                return;
            }
            //询问用户是否收费
            DialogResult dr = MessageBox.Show("确认收费？ ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;
            IDataRecord record = bindingSource1.Current as IDataRecord;
            if (record == null) return;
            
            string 挂号序号 = record["挂号序号"].ToString();
            string 门诊号 = record["门诊号"].ToString();
            bool 是否收费 = (bool)record["是否收费"];
            bool 是否退号 = (bool)record["是否退号"];
            decimal 挂号费 = (decimal)record["挂号费"];
            int 就诊卡号 = (int)record["就诊卡号"];
            if (是否收费)
            {
                MessageBox.Show("该病人已收取挂号费，不允许修改");
                return;
            }
            if (是否退号)
            {
                MessageBox.Show("该病人的挂号已退号，无法收费");
                return;
            }
            //需要使用事务
            SqlConnection con = SqlUtil.CreateConnection();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Transaction = trans;
                string sql = "insert into 收费表(挂号序号,就诊卡号,收费类别,收费日期,收费员,收费金额) values('" + 挂号序号
                    + "',"+就诊卡号.ToString()+",N'挂号费',getdate(),N'" + 收费员 + "'," + 挂号费.ToString() + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                sql = "update 挂号 set 是否收费=1 where 挂号序号=" + 挂号序号;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                trans.Commit();
                MessageBox.Show("收费成功！");
                toolStripButton4_Click(null, null);
            }
            catch (Exception)
            {   
                //回滚事务
                trans.Rollback();
                throw;
            }
            finally
            {
                //关闭数据库
                con.Close();
            }
            
        }
    }
}
