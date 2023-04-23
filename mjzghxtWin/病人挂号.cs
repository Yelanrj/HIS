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
    public partial class 病人挂号 : Form
    {
        bool 急诊挂号;
        public 病人挂号(bool 急诊挂号)
        {
            InitializeComponent();
            this.急诊挂号 = 急诊挂号;
            if (急诊挂号)
            {
                this.Text = "病人急诊挂号";
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
            string sql = "select * from 病人 where 1=1";
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
            
            string 门诊号 = record["门诊号"].ToString();

            病人挂号确认 form = new 病人挂号确认(门诊号,急诊挂号);
            form.ShowDialog();
        }

    }
}
