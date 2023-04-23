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
    public partial class 病人挂号确认 : Form
    {

        public readonly string 门诊号;
        public readonly int 急诊挂号;
        public 病人挂号确认(string 门诊号, bool 急诊挂号)
        {
            InitializeComponent();
            this.门诊号 = 门诊号;
            this.急诊挂号 = 急诊挂号 ? 1 : 0;
            if (急诊挂号)
            {
                this.Text = "病人急诊挂号确认";
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
            string sql = "insert into 挂号(门诊号,挂号日期,挂号科室,挂号医生,号别,挂号费" +
                ",急诊挂号)values('" + 门诊号 + "',getdate(),N'" + 挂号科室 + "',N'" + 挂号医生 + "',N'" + 号别
                + "'," + 挂号费 + "," + 急诊挂号.ToString() + ")";
            //MessageBox.Show(sql);
            SqlUtil.ExecuteSql(sql);
            MessageBox.Show("病人挂号成功！");
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
            comboBox3.Text = "";
            comboBox4.Text = "";

            comboBox2.Text = "";
            numericUpDown1.Value = 10;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
