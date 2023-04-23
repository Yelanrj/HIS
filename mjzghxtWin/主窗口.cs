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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mjzghxtWin
{
    public partial class 主窗口 : Form
    {
        private string 登录信息_工号;
        private string 登录信息_姓名;
        private string 登录信息_职务;
        private 用户登录 登录窗体;
        private 访客登录 访客登录窗体;
        private bool 切换用户=false;
        private int 就诊卡号;

        public 主窗口()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置登录信息
        /// </summary>
        /// <param name="登录信息_工号"></param>
        /// <param name="登录信息_姓名"></param>
        /// <param name="登录信息_职务"></param>
        public 主窗口 SetLoginInfo(string 登录信息_工号, string 登录信息_姓名, string 登录信息_职务)
        {
            this.登录信息_工号 = 登录信息_工号;
            this.登录信息_姓名 = 登录信息_姓名;
            this.登录信息_职务 = 登录信息_职务;

            return this;
        }
        /// <summary>
        /// 设置登录窗体
        /// </summary>
        /// <param name="登录窗体"></param>
        /// <returns></returns>
        public 主窗口 SetLoginForm(用户登录 登录窗体)
        {
            this.登录窗体=登录窗体;
            return this;
        }
        public 主窗口 SetLoginForm(访客登录 访客登录窗体)
        {
            this.访客登录窗体 = 访客登录窗体;
            return this;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssl_time.Text = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒");

        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            切换用户=true;
            //关闭主窗体
            this.Close();
            //显示登录窗体
            if (登录窗体 != null)
            {
                登录窗体.Show();
            }
            else
            {
                访客登录窗体.Show();
            }
        }


        private void 主窗口_FormClosed(object sender, FormClosedEventArgs e)
        {   
            if(!切换用户)
            Application.Exit();
        }

        private void 病人建档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new 病人建档().ShowDialog();

        }

        private void 病人查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            病人查询 form = new 病人查询();
            form.MdiParent = this;
            form.Show();
        }

        private void 门诊挂号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            病人挂号 form = new 病人挂号(false);
            form.MdiParent = this;
            form.Show();
        }

        private void 急诊挂号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            病人挂号 form = new 病人挂号(true);
            form.MdiParent = this;
            form.Show();
        }

        private void 门诊挂号记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            挂号记录 form = new 挂号记录(false);
            form.MdiParent = this;
            form.Show();
        }

        private void 急诊挂号记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            挂号记录 form = new 挂号记录(true);
            form.MdiParent = this;
            form.Show();
        }

        private void 费用查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            挂号收费 form = new 挂号收费(登录信息_姓名,false);
            form.MdiParent = this;
            form.Show();
        }

        private void 急诊挂号收费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            挂号收费 form = new 挂号收费(登录信息_姓名, true);
            form.MdiParent = this;
            form.Show();
        }

        private void 门诊挂号收费查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            挂号收费查询 form = new 挂号收费查询(false);
            form.MdiParent = this;
            form.Show();
        }

        private void 急诊挂号收费查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            挂号收费查询 form = new 挂号收费查询(true);
            form.MdiParent = this;
            form.Show();
        }

        private void 主窗口_Load(object sender, EventArgs e)
        {
            //设置权限
            if (登录信息_职务 == "护士")
            {
                收费ToolStripMenuItem.Visible = false;
                病人挂号ToolStripMenuItem.Visible = false;
                病人缴费ToolStripMenuItem.Visible = false;
                toolStripStatusLabel2.Text = "欢迎！" + 登录信息_姓名 + "护士";
                接诊ToolStripMenuItem.Visible = false;
            }
            else if(登录信息_职务 == "患者")
            {
                病人管理ToolStripMenuItem.Visible = false;
                挂号ToolStripMenuItem.Visible = false;
                收费ToolStripMenuItem.Visible = false;
                接诊ToolStripMenuItem.Visible = false;
                string selectsql1 = "select * from 访客 where 身份证号=N'" + 登录信息_工号 + "'";
                SqlDataReader reader1 = SqlUtil.ExecuteReader(selectsql1);
                string selectsql2 = "select * from 访客 where 就诊卡号=N'" + 登录信息_工号 + "'";
                SqlDataReader reader2 = SqlUtil.ExecuteReader(selectsql2);
                if (reader1.Read())
                {
                    就诊卡号 = (int)reader1["就诊卡号"];

                }
                else if (reader2.Read())
                {
                    就诊卡号 = (int)reader2["就诊卡号"];
                }
                else
                {
                    return;
                }
                reader1.Close();
                reader2.Close();
                //此处默认为门诊挂号
                挂号 form = new 挂号(就诊卡号, false);
                form.MdiParent = this;
                form.Show();
                toolStripStatusLabel2.Text = "欢迎！用户" + 登录信息_姓名;
            }
            else if(登录信息_职务 == "收费员")
            {
                病人管理ToolStripMenuItem.Visible = false;
                挂号ToolStripMenuItem.Visible = false;
                toolStripStatusLabel2.Text = "欢迎！" + 登录信息_姓名;
                接诊ToolStripMenuItem.Visible = false;

            }
            else if(登录信息_职务 == "医生")
            {
                病人管理ToolStripMenuItem.Visible = false;
                挂号ToolStripMenuItem.Visible = false;
                收费ToolStripMenuItem.Visible = false;
                病人挂号ToolStripMenuItem.Visible = false;
                病人缴费ToolStripMenuItem.Visible = false;
                toolStripStatusLabel2.Text = "欢迎！" + 登录信息_姓名 + "医生";
            }
            else
            {
                toolStripStatusLabel2.Text = "欢迎！管理员" + 登录信息_姓名;
            }
            
        }

        private void 病人门诊挂号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            挂号 form = new 挂号(就诊卡号, false);
            form.MdiParent = this;
            form.Show();
        }

        private void 病人急诊挂号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            挂号 form = new 挂号(就诊卡号, true);
            form.MdiParent = this;
            form.Show();
        }

        private void 病人门诊挂号缴费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            访客挂号收费 form = new 访客挂号收费(就诊卡号, false);
            form.MdiParent = this;
            form.Show();
        }

        private void 病人急诊挂号缴费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            访客挂号收费 form = new 访客挂号收费(就诊卡号, true);
            form.MdiParent = this;
            form.Show();
        }

        private void 病人门诊挂号缴费查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            访客挂号缴费查询 form = new 访客挂号缴费查询(就诊卡号, false);
            form.MdiParent = this;
            form.Show();
        }

        private void 病人急诊挂号缴费查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            访客挂号缴费查询 form = new 访客挂号缴费查询(就诊卡号, true);
            form.MdiParent = this;
            form.Show();
        }

        private void 病人门诊挂号查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            访客挂号记录 form = new 访客挂号记录(就诊卡号, false);
            form.MdiParent = this;
            form.Show();
        }

        private void 病人急诊挂号查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            访客挂号记录 form = new 访客挂号记录(就诊卡号, true);
            form.MdiParent = this;
            form.Show();
        }

        private void 接诊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            医生接诊 form = new 医生接诊(登录信息_工号,登录信息_姓名);
            form.MdiParent = this;
            form.Show();
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            测试 form = new 测试();
            form.Show();
        }
    }
}
