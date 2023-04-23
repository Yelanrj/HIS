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
    public partial class 挂号收费查询 : Form
    {
        bool 急诊挂号;

        public 挂号收费查询(bool 急诊挂号)
        {
            InitializeComponent();
            this.急诊挂号 = 急诊挂号;
            if (急诊挂号)
            {
                this.Text = "急诊挂号收费查询";
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
                "挂号.号别,挂号.挂号费,挂号.是否收费,挂号.是否退号 from 病人,挂号 where 病人.门诊号=挂号.门诊号";
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
    }
}
