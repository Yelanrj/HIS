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
    public partial class 用户注册 : Form
    {
        public 用户注册()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 工号 = textBox1.Text;
            string 密码 = textBox2.Text;
            string 确认密码 = textBox3.Text;
            string 姓名 = textBox4.Text;
            string 职务 = comboBox1.Text;

            if (工号.Length <= 0)
            {
                MessageBox.Show("请输入工号");
                return;
            }
            if (密码.Length <= 0)
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (确认密码.Length <= 0)
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (职务.Length <= 0)
            {
                MessageBox.Show("请选择职务");
                return;
            }
            if (!密码.Equals(确认密码))
            {
                MessageBox.Show("密码与确认密码不符！请重试！");
                return;
            }

            string selectsql = "select * from 职工 where 工号=N'" + 工号 + "'";
            SqlDataReader reader=SqlUtil.ExecuteReader(selectsql);

            if (reader.HasRows)
            {
                MessageBox.Show("已存在工号为“" + 工号 + "”的用户！请重试！");
            }
            else
            {
                string insertsql = "insert into 职工(工号,姓名,职务,密码)values(N'" + 工号 + "',N'" + 姓名 + "',N'" + 职务 + "',N'" + 密码 + "')";
                SqlUtil.ExecuteSql(insertsql);
                MessageBox.Show("注册用户成功！请重新登录");
                this.Close();
            }
        }
    }
}
