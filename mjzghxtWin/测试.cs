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
    public partial class 测试 : Form
    {
        public 测试()
        {
            InitializeComponent();
            string sql21 = "select * from 挂号";
            SqlDataReader reader4 = SqlUtil.ExecuteReader(sql21);
            if (reader4 == null) return;
            if (reader4.Read())
            {
                string 病人姓名1 = reader4["门诊号"].ToString();
                MessageBox.Show(病人姓名1);
            }

        }
    }
}
