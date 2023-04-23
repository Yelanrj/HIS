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
    public partial class 挂号 : Form
    {
        public int 就诊卡号;
        public readonly int 急诊挂号;
        public 挂号(int 就诊卡号,bool 急诊挂号)
        {
            InitializeComponent();
            this.就诊卡号 = 就诊卡号;
            this.急诊挂号 = 急诊挂号 ? 1 : 0;
            if (急诊挂号)
            {
                this.Text = "病人急诊挂号确认";
            }
        }

        private void 病人挂号_Load(object sender, EventArgs e)
        {


            //查询门诊号
            string sql = "select count(*) as 最大门诊号 from 病人";
            SqlDataReader reader = SqlUtil.ExecuteReader(sql);

            if (reader.Read())
            {
                int maxid = (int)reader["最大门诊号"]+1;
                textBox1.Text = maxid.ToString();
                //设置只读
                textBox1.ReadOnly = true;
                //关闭SqlDataReader
                reader.Close();

            }
            else
            {
                reader.Close();
                MessageBox.Show("未查询到病人信息！");
                this.Close();
            }
            //查询病人信息
            string sql2 = "select * from 访客 where 就诊卡号='" + 就诊卡号 + "'";
            SqlDataReader reader2 = SqlUtil.ExecuteReader(sql2);

            if (reader2.Read())
            {
                textBox2.Text = reader2["姓名"].ToString();
                textBox3.Text = reader2["联系电话"].ToString();
                textBox4.Text = reader2["家庭住址"].ToString();
                textBox5.Text = reader2["身份证号"].ToString();


            }
            //关闭SqlDataReader
            reader2.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string 门诊号 = textBox1.Text;
            string 挂号科室 = comboBox3.Text;
            string 挂号医生 = comboBox4.Text;
            string 号别 = comboBox2.Text;
            string 挂号费 = textBox9.Text;

            string 姓名 = textBox2.Text;
            string 身份证号 = textBox5.Text;
            string 家庭住址 = textBox4.Text;
            string 联系电话 = textBox3.Text;
            string 既往史 = textBox6.Text;
            string 现病史 = textBox7.Text;
            string 过敏史 = textBox8.Text;
            string 性别 = comboBox1.Text;
            string 年龄 = numericUpDown1.Value.ToString();

            //校验
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
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("请输入年龄");
                return;
            }
            if (姓名.Length <= 0)
            {
                MessageBox.Show("请输入姓名");
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
            //插入数据到病人表
            string bingsql = "insert into 病人(门诊号,姓名,性别,年龄,联系电话,家庭住址,身份证号," +
            "既往史,现病史,过敏史)values('" + 门诊号 + "',N'" + 姓名 + "',N'" + 性别 + "'," + 年龄
            + ",'" + 联系电话 + "',N'" + 家庭住址 + "',N'" + 身份证号 + "',N'" + 既往史 + "',N'"
             + 现病史 + "',N'" + 过敏史 + "')";
            //MessageBox.Show(sql);
            SqlUtil.ExecuteSql(bingsql);
            //插入数据到挂号表
            string sql = "insert into 挂号(门诊号,就诊卡号,挂号日期,挂号科室,挂号医生,号别,挂号费" +
                ",急诊挂号)values('" + 门诊号 + "',"+就诊卡号.ToString()+",getdate(),N'" + 挂号科室 + "',N'" + 挂号医生 + "',N'" + 号别
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
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

            comboBox1.Text = "";
            numericUpDown1.Value = 0;
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {   
            if((!comboBox2.Text.Equals("")) && (!comboBox3.Text.Equals("")))
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
