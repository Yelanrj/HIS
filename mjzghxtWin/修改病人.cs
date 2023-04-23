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
    public partial class 修改病人 : Form
    {
        public readonly string 门诊号;

        public 修改病人(string 门诊号)
        {
            InitializeComponent();
            this.门诊号 = 门诊号;
            
        }

        private void 修改病人_Load(object sender, EventArgs e)
        {
            //查询病人信息
            string sql = "select * from 病人 where 门诊号='" + 门诊号 + "'";
            SqlDataReader reader = SqlUtil.ExecuteReader(sql);
            if (reader.Read())
            {   
                //赋值
                textBox1.Text = reader["门诊号"].ToString();
                textBox2.Text = reader["姓名"].ToString();
                textBox3.Text = reader["联系电话"].ToString();
                textBox4.Text = reader["家庭住址"].ToString();
                textBox5.Text = reader["身份证号"].ToString();
                textBox6.Text = reader["既往史"].ToString();
                textBox7.Text = reader["现病史"].ToString();
                textBox8.Text = reader["过敏史"].ToString();

                comboBox1.Text = reader["性别"].ToString();
                numericUpDown1.Value = (int)reader["年龄"];
                //关闭SqlDataReader
                reader.Close();

            }
            else
            {
                reader.Close();
                MessageBox.Show("未查询到病人信息！");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 门诊号 = textBox1.Text;
            string 姓名 = textBox2.Text;
            string 性别 = comboBox1.Text;
            string 年龄 = numericUpDown1.Value.ToString();
            string 联系电话 = textBox3.Text;
            string 家庭住址 = textBox4.Text;
            string 身份证号 = textBox5.Text;
            string 既往史 = textBox6.Text;
            string 现病史 = textBox7.Text;
            string 过敏史 = textBox8.Text;

            //校验
            if (门诊号.Length <= 0)
            {
                MessageBox.Show("请输入门诊号");
                return;
            }
            if (姓名.Length <= 0)
            {
                MessageBox.Show("请输入姓名");
                return;
            }
            if (联系电话.Length <= 0)
            {
                MessageBox.Show("请输入联系电话");
                return;
            }
            if (家庭住址.Length <= 0)
            {
                MessageBox.Show("请输入家庭住址");
                return;
            }
            if (身份证号.Length <= 0)
            {
                MessageBox.Show("请输入身份证号");
                return;
            }
            if (既往史.Length <= 0)
            {
                MessageBox.Show("请输入既往史");
                return;
            }
            if (现病史.Length <= 0)
            {
                MessageBox.Show("请输入现病史");
                return;
            }
            if (过敏史.Length <= 0)
            {
                MessageBox.Show("请输入过敏史");
                return;
            }
            if (性别.Length <= 0)
            {
                MessageBox.Show("请选择性别");
                return;
            }
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("病人年龄不能低于0岁");
                return;
            }

            //插入数据到病人表
            string sql = "update 病人 set 姓名=N'" + 姓名 + "',性别=N'" + 性别
                + "',年龄=" + 年龄 + ",联系电话='" + 联系电话 + "',家庭住址=N'" + 家庭住址 + "',身份证号=N'"
                + 身份证号 + "',既往史=N'" + 既往史 + "',现病史=N'" + 现病史 + "',过敏史=N'" + 过敏史 + "' where " +
                "门诊号='" + 门诊号 + "'";
            //MessageBox.Show(sql);
            SqlUtil.ExecuteSql(sql);
            MessageBox.Show("修改病人建单成功！");

            DialogResult = DialogResult.OK;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            comboBox1.Text = "";
            numericUpDown1.Value = 0;
        }


    }
}
