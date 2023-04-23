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
    public partial class 访客挂号记录 : Form
    {
        bool 急诊挂号;
        int 就诊卡号;
        public 访客挂号记录(int 就诊卡号,bool 急诊挂号)
        {
            InitializeComponent();
            this.就诊卡号 = 就诊卡号;
            this.急诊挂号 = 急诊挂号;
            if (急诊挂号)
            {
                this.Text = "急诊挂号记录";
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
            string sql = "select 病人.*,挂号.挂号日期,挂号.挂号序号,挂号.就诊卡号,挂号.挂号科室,挂号.挂号医生," +
                "挂号.号别,挂号.挂号费,挂号.是否收费,挂号.是否退号 from 病人,挂号 where 病人.门诊号=挂号.门诊号 and 挂号.就诊卡号="+就诊卡号.ToString();
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

            IDataRecord record = bindingSource1.Current as IDataRecord;
            if (record == null) return;

            string 挂号序号 = record["挂号序号"].ToString();
            string 门诊号 = record["门诊号"].ToString();
            bool 是否收费 = (bool)record["是否收费"];
            bool 是否退号 = (bool)record["是否退号"];
            if (是否收费)
            {
                MessageBox.Show("该病人已收取挂号费，不允许修改");
                return;
            }
            if (是否退号)
            {
                MessageBox.Show("该病人的挂号已退号，不允许修改");
                return;
            }
            修改病人挂号 form = new 修改病人挂号(挂号序号,门诊号,急诊挂号);
            DialogResult dr = form.ShowDialog();
            if(dr == DialogResult.OK)
            {
                toolStripButton4_Click(null, null);
            }
        }
        /// <summary>
        /// 退号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            {
                MessageBox.Show("请选择要挂号的病人");
                return;
            }

            //询问用户是否退号
            DialogResult dr = MessageBox.Show("确认退号？ ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;
            IDataRecord record = bindingSource1.Current as IDataRecord;
            if (record == null) return;

            string 挂号序号 = record["挂号序号"].ToString();
            bool 是否收费 = (bool)record["是否收费"];
            bool 是否退号 = (bool)record["是否退号"];
            if (是否收费)
            {
                MessageBox.Show("该病人的挂号已收取挂号费，无法退号");
                return;
            }

            if (是否退号)
            {
                MessageBox.Show("该病人的挂号已退号，无需重复操作");
                return;
            }

            string sql = "update 挂号 set 是否退号=1 where 挂号序号=" + 挂号序号;
            SqlUtil.ExecuteSql(sql);
            MessageBox.Show("退号成功！");
            toolStripButton4_Click(null, null);
        }
    }
}
