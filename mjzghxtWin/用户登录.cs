using System.Data.SqlClient;

namespace mjzghxtWin
{
    public partial class �û���¼ : Form
    {
        public �û���¼()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ���� = textBox1.Text;
            string ���� = textBox2.Text;
            string ְ�� = comboBox1.Text;

            if (����.Length <= 0)
            {
                MessageBox.Show("�����빤��");
                return;
            }
            if (����.Length <= 0)
            {
                MessageBox.Show("����������");
                return;
            }
            if (ְ��.Length <= 0)
            {
                MessageBox.Show("��ѡ��ְ��");
                return;
            }

            string sql = "select * from ְ�� where ����='" + ���� + "' and ����='" + ����
                + "' and ְ��=N'" + ְ�� + "'";

            SqlDataReader reader=SqlUtil.ExecuteReader(sql);
            bool ret=reader.Read();
            if (ret)
            {   
                string ���� = reader["����"].ToString();
                reader.Close();
                //���ش���
                this.Hide();
                ������ form=new ������();
                form.SetLoginInfo(����, ����, ְ��);
                form.SetLoginForm(this);
                form.Show();

            }
            else
            {
                MessageBox.Show("�˺�������������");
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
            �û�ע�� form = new �û�ע��();
            //this.Hide();
            form.Show();
        }
    }
}