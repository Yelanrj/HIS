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
    public partial class 医生接诊 : Form
    {
        public readonly string 工号;
        public readonly string 姓名;

        public 医生接诊(string 工号, string 姓名)
        {
            InitializeComponent();
            this.工号 = 工号;
            this.姓名 = 姓名;
        }

        private void 医生接诊_Load(object sender, EventArgs e)
        {
            label3.Text = 工号;
            label4.Text = 姓名;

            //查询数据库
            string sql = "select DISTINCT CONVERT(date, 挂号日期) as Date FROM 挂号";
            //将查询结果绑定到comboBox控件
            DataTable dt = SqlUtil.ExecuteTable(sql);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Date";

            if (bindingSource1.Current == null)
            {
                return;
            }
            comboBox1_TextChanged(sender, e);
            IDataRecord record = bindingSource1.Current as IDataRecord;
            if (record == null) return;

            string 就诊卡号 = record["就诊卡号"].ToString();
            string 挂号序号 = record["挂号序号"].ToString();
            string 门诊号 = record["门诊号"].ToString();

            string sql2 = "select 挂号.*,病人.门诊号,病人.姓名,病人.性别,病人.年龄,病人.既往史,病人.现病史,病人.过敏史 from 挂号,病人 where" +
               " 挂号.挂号序号=" + 挂号序号 + " and 挂号.门诊号=病人.门诊号 and 挂号.是否诊断=0 and 挂号.挂号医生=N'" + 姓名 + "' and 挂号.是否收费=1";
            SqlDataReader reader = SqlUtil.ExecuteReader(sql2);
            if (reader.Read())
            {
                label8.Text = "挂号序号：" + 挂号序号 + "\t就诊卡号：" + 就诊卡号 + "\t门诊号：" + 门诊号
                    + "\n姓名：" + reader["姓名"].ToString() + "\t性别：" + reader["性别"].ToString()
                    + "\t年龄：" + reader["年龄"].ToString();

                textBox6.Text = reader["现病史"].ToString();
                textBox1.Text = reader["既往史"].ToString();
                textBox3.Text = reader["过敏史"].ToString();
            }



        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string datetime = comboBox1.Text;
            string selectsql1 = "SELECT * FROM 挂号 WHERE CONVERT(date, 挂号日期) ='" + datetime + "' and 是否诊断=0 and 挂号医生=N'" + 姓名 + "' and 挂号.是否收费=1";

            //查询数据库
            bindingSource1.Clear();
            SqlDataReader reader1 = SqlUtil.ExecuteReader(selectsql1);
            if (reader1.HasRows)
                bindingSource1.DataSource = reader1;


            //if (reader.Read())
            //{
            //    MessageBox.Show("OK!");
            //}
            //dataGridView1与bindingSource1绑定
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Refresh();

            string selectsql2 = "SELECT * FROM 挂号 WHERE CONVERT(date, 挂号日期) ='" + datetime + "' and 是否诊断=1 and 挂号医生=N'" + 姓名 + "' and 挂号.是否收费=1";

            //查询数据库
            bindingSource2.Clear();
            SqlDataReader reader2 = SqlUtil.ExecuteReader(selectsql2);
            if (reader2.HasRows)
                bindingSource2.DataSource = reader2;


            //if (reader.Read())
            //{
            //    MessageBox.Show("OK!");
            //}
            //dataGridView2与bindingSource2绑定
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = bindingSource2;
            dataGridView2.Refresh();

            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly == true)
            {
                MessageBox.Show("您已经提交过诊断！");
                return;
            }
            if (bindingSource1.Current == null)
            {
                MessageBox.Show("请选择要查看的病人");
                return;
            }
            IDataRecord record = bindingSource1.Current as IDataRecord;
            if (record == null) return;
            string 挂号序号 = record["挂号序号"].ToString();
            string sql = "update 挂号 set 是否诊断=1 where 挂号序号=" + 挂号序号;
            SqlUtil.ExecuteSql(sql);
            MessageBox.Show("提交诊断成功！");
            DialogResult = DialogResult.OK;
            comboBox1_TextChanged(sender, e);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            {
                MessageBox.Show("请选择要查看的病人");
                return;
            }
            IDataRecord record = bindingSource1.Current as IDataRecord;
            if (record == null) return;

            string 就诊卡号 = record["就诊卡号"].ToString();
            string 挂号序号 = record["挂号序号"].ToString();
            string 门诊号 = record["门诊号"].ToString();

            string sql = "select 挂号.*,病人.门诊号,病人.姓名,病人.性别,病人.年龄,病人.既往史,病人.现病史,病人.过敏史 from 挂号,病人 where" +
                " 挂号.挂号序号=" + 挂号序号 + " and 挂号.门诊号=病人.门诊号 and 是否诊断=0 and 挂号.挂号医生=N'" + 姓名 + "' and 挂号.是否收费=1";
            SqlDataReader reader = SqlUtil.ExecuteReader(sql);
            if (reader.Read())
            {
                label8.Text = "挂号序号：" + 挂号序号 + "\t就诊卡号：" + 就诊卡号 + "\t门诊号：" + 门诊号
    + "\n姓名：" + reader["姓名"].ToString() + "\t性别：" + reader["性别"].ToString()
    + "\t年龄：" + reader["年龄"].ToString();

                textBox6.Text = reader["现病史"].ToString();
                textBox1.Text = reader["既往史"].ToString();
                textBox3.Text = reader["过敏史"].ToString();
            }
            textBox6.ReadOnly = false;
            textBox1.ReadOnly = false;
            textBox3.ReadOnly = false;
        }
        ///
        private void button3_Click(object sender, EventArgs e)
        {
            if (bindingSource2.Current == null)
            {
                MessageBox.Show("请选择要查看的病人");
                return;
            }
            IDataRecord record = bindingSource2.Current as IDataRecord;
            if (record == null) return;

            string 就诊卡号 = record["就诊卡号"].ToString();
            string 挂号序号 = record["挂号序号"].ToString();
            string 门诊号 = record["门诊号"].ToString();

            string sql = "select 挂号.*,病人.姓名,病人.性别,病人.年龄,病人.既往史,病人.现病史,病人.过敏史 from 挂号,病人 where 挂号.就诊卡号=" + 就诊卡号
                + " and 挂号.挂号序号=" + 挂号序号 + " and 挂号.门诊号=N'" + 门诊号 + "' and 挂号.门诊号=病人.门诊号  and 是否诊断=1 and 挂号.挂号医生=N'" + 姓名+ "' and 挂号.是否收费=1";
            SqlDataReader reader = SqlUtil.ExecuteReader(sql);
            if (reader.Read())
            {

                label8.Text = "挂号序号：" + 挂号序号 + "\t就诊卡号：" + 就诊卡号 + "\t门诊号：" + 门诊号
                    + "\n姓名：" + reader["姓名"].ToString() + "\t性别：" + reader["性别"].ToString()
                    + "\t年龄：" + reader["年龄"].ToString();

                textBox6.Text = reader["现病史"].ToString();
                textBox1.Text = reader["既往史"].ToString();
                textBox3.Text = reader["过敏史"].ToString();
            }


            //设置只读
            textBox6.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
