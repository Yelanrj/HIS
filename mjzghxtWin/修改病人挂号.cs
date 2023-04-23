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
    public partial class 修改病人挂号 : Form
    {
        public readonly string 挂号序号;
        public readonly string 门诊号;
        public readonly int 急诊挂号;
        public 修改病人挂号(string 挂号序号,string 门诊号, bool 急诊挂号)
        {
            InitializeComponent();
            this.挂号序号 = 挂号序号;
            this.门诊号 = 门诊号;
            this.急诊挂号 = 急诊挂号 ? 1 : 0;
            if (急诊挂号)
            {
                this.Text = "修改病人急诊挂号";
            }
        }

        private void 病人挂号_Load(object sender, EventArgs e)
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

                //设置只读
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;

                comboBox1.DropDownStyle=ComboBoxStyle.DropDownList;
                numericUpDown1.ReadOnly = true;
                //关闭SqlDataReader
                reader.Close();

            }

            else
            {
                reader.Close();
                MessageBox.Show("未查询到病人信息！");
                this.Close();
            }
            //查询挂号信息
            sql = "select * from 挂号 where 挂号序号='" + 挂号序号 + "'";
            reader = SqlUtil.ExecuteReader(sql);
            if (reader.Read())
            {
                //赋值
                comboBox3.Text = reader["挂号科室"].ToString();
                comboBox4.Text = reader["挂号医生"].ToString();

                comboBox2.Text = reader["号别"].ToString();
                textBox9.Text = reader["挂号费"].ToString();
                //关闭SqlDataReader
                reader.Close();

            }

            else
            {
                reader.Close();
                MessageBox.Show("未查询到病人挂号信息！");
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string 门诊号 = textBox1.Text;
            string 挂号科室 = comboBox3.Text;
            string 挂号医生 = comboBox4.Text;
            string 号别 = comboBox2.Text;
            string 挂号费 = textBox9.Text;


            //校验
            if (门诊号.Length <= 0)
            {
                MessageBox.Show("请输入门诊号");
                return;
            }
            if (挂号科室.Length <= 0)
            {
                MessageBox.Show("请选择挂号科室");
                return;
            }
            if (挂号医生.Length <= 0)
            {
                MessageBox.Show("请输入挂号医生");
                return;
            }
            if (号别.Length <= 0)
            {
                MessageBox.Show("请选择号别");
                return;
            }

            //插入数据到病人表
            string sql = "update 挂号 set 挂号科室=N'" + 挂号科室 + "',挂号医生=N'" + 挂号医生
                + "',号别=N'" + 号别 + "',挂号费=" + 挂号费 + " where 挂号序号=" + 挂号序号.ToString();
            //MessageBox.Show(sql);
            SqlUtil.ExecuteSql(sql);
            MessageBox.Show("修改病人挂号成功！");
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
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            numericUpDown1.Value = 0;

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if ((!comboBox2.Text.Equals("")) && (!comboBox3.Text.Equals("")))
            {
                if (comboBox2.Text.Equals("普通号"))
                {
                    textBox9.Text = "10";
                }
                else if (comboBox2.Text.Equals("专家号"))
                {
                    textBox9.Text = "30";
                }
                else
                {
                    textBox9.Text = "";
                }
                //this.Refresh();
            }
        }
    }
}
