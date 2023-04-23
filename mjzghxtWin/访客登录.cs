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
    public partial class 访客登录 : Form
    {
        public 访客登录()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                textBox2.PasswordChar = '*';
            else
                textBox2.PasswordChar = (char)0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            访客注册 form = new 访客注册();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 就诊卡号或身份证号 = textBox1.Text;
            string 密码 = textBox2.Text;

            string selectsql1 = "select * from 访客 where 身份证号=N'" + 就诊卡号或身份证号 + "'";
            SqlDataReader reader1 = SqlUtil.ExecuteReader(selectsql1);
            string selectsql2 = "select * from 访客 where 就诊卡号=N'" + 就诊卡号或身份证号 + "'";
            SqlDataReader reader2 = SqlUtil.ExecuteReader(selectsql2);
            if (reader1.Read())
            {
                if (reader1["密码"].ToString().Equals(textBox2.Text))
                {
                    string 姓名 = reader1["姓名"].ToString();
                    this.Hide();
                    主窗口 form = new 主窗口();
                    form.SetLoginInfo(就诊卡号或身份证号, 姓名, "患者");
                    form.SetLoginForm(this);
                    form.Show();

                }

            }
            else if (reader2.Read())
            {
                if (reader2["密码"].ToString().Equals(textBox2.Text))
                {
                    string 姓名 = reader2["姓名"].ToString();
                    this.Hide();
                    主窗口 form = new 主窗口();
                    form.SetLoginInfo(就诊卡号或身份证号, 姓名, "患者");
                    form.SetLoginForm(this);
                    form.Show();

                }
            }
            else
            {
                MessageBox.Show("用户名或密码错误！请重试！");
                return;
            }
        }
    }
}
