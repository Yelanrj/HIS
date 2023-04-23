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
    public partial class 病人查询 : Form
    {
        public 病人查询()
        {
            InitializeComponent();
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
            {
                bindingSource1.DataSource = reader;
            }
            //显示总行数
            tssl_record.Text = bindingSource1.Count.ToString();

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
                MessageBox.Show("请选择要修改的病人");
                return;
            }

            IDataRecord record = bindingSource1.Current as IDataRecord;
            if (record == null) return;
            
            string 门诊号 = record["门诊号"].ToString();

            修改病人 form = new 修改病人(门诊号);
            DialogResult dr=form.ShowDialog();
            if(dr == DialogResult.OK)
            {   
                //重新查询数据
                toolStripButton4_Click(null, null);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            {
                MessageBox.Show("请选择要删除的病人");
                return;
            }


            //询问用户是否删除病人
            DialogResult dr = MessageBox.Show("确认删除此病人？ ","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;
            IDataRecord record = bindingSource1.Current as IDataRecord;
            if (record == null) return;
            string 门诊号 = record["门诊号"].ToString();
            //删除数据库中的指定记录
            string sql= "delete from 病人 where 门诊号='" + 门诊号 + "'";
            SqlUtil.ExecuteSql(sql);
            MessageBox.Show("删除成功！");
            //重新查询数据
            toolStripButton4_Click(null, null);

        }
    }
}
