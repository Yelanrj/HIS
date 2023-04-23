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
    public partial class 访客注册 : Form
    {
        public 访客注册()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 注册患者用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string 姓名 = textBox1.Text;
            string 密码 = textBox2.Text;
            string 确认密码 = textBox3.Text;
            string 身份证号 = textBox4.Text;
            string 家庭住址 = textBox5.Text;
            string 联系电话 = textBox6.Text;

            if (姓名.Length <= 0)
            {
                MessageBox.Show("请输入姓名");
                return;
            }
            if (密码.Length <= 0)
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (确认密码.Length <= 0)
            {
                MessageBox.Show("请输入确认密码");
                return;
            }
            if (身份证号.Length <= 0)
            {
                MessageBox.Show("请输入身份证号");
                return;
            }
            if (家庭住址.Length <= 0)
            {
                MessageBox.Show("请输入家庭住址");
                return;
            }
            if (联系电话.Length <= 0)
            {
                MessageBox.Show("请输入联系电话");
                return;
            }
            if (!密码.Equals(确认密码))
            {
                MessageBox.Show("密码错误！请重新输入密码！");
                return ;
            }
            string selectsql1 = "select * from 访客 where 身份证号='N" + 身份证号 + "'";
            SqlDataReader reader = SqlUtil.ExecuteReader(selectsql1);

            if (reader.HasRows)
            {
                MessageBox.Show("您已经注册过，请登录");
                return;
            }
            else
            {
                string selectsql2 = "select max(就诊卡号) as 最大就诊卡号 from 访客";
                SqlDataReader reader2 = SqlUtil.ExecuteReader(selectsql2);
                if (!reader2.Read())
                {
                    MessageBox.Show("没有测试用户！错误！请联系管理员！");
                    return;
                }


                int maxID = 0;
                maxID= (int)reader2["最大就诊卡号"];
                int newID = maxID + 1;
                //MessageBox.Show(maxID.ToString());
                string sql = "insert into 访客(就诊卡号,身份证号,姓名,家庭住址,联系电话,密码)values" +
                "(" + newID + ",N'" + 身份证号 + "',N'" + 姓名 + "',N'" + 家庭住址 + "',N'" + 联系电话 
                + "',N'" + 密码 + "')";
                SqlUtil.ExecuteSql(sql);
                MessageBox.Show("注册成功！\n您的就诊卡号为："+newID.ToString()+"\n请退出后重新登录");

                this.Close();

            }

        }
    }
}
