using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mjzghxtWin
{
    public partial class 主菜单 : Form
    {
        public 主菜单()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            访客登录 form = new 访客登录();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            用户登录 form = new 用户登录();
            form.Show();
            //this.Close();
        }
    }
}
