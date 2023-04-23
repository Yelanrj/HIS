using System.Data.SqlClient;

namespace mjzghxtWin
{
    public partial class 用户登录 : Form
    {
        public 用户登录()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 工号 = textBox1.Text;
            string 密码 = textBox2.Text;
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
            if (职务.Length <= 0)
            {
                MessageBox.Show("请选择职务");
                return;
            }

            string sql = "select * from 职工 where 工号='" + 工号 + "' and 密码='" + 密码
                + "' and 职务=N'" + 职务 + "'";

            SqlDataReader reader=SqlUtil.ExecuteReader(sql);
            bool ret=reader.Read();
            if (ret)
            {   
                string 姓名 = reader["姓名"].ToString();
                reader.Close();
                //隐藏窗体
                this.Hide();
                主窗口 form=new 主窗口();
                form.SetLoginInfo(工号, 姓名, 职务);
                form.SetLoginForm(this);
                form.Show();

            }
            else
            {
                MessageBox.Show("账号密码输入有误");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                textBox2.PasswordChar = '*';
            else
                textBox2.PasswordChar = (char)0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            用户注册 form = new 用户注册();
            //this.Hide();
            form.Show();
        }
    }
}