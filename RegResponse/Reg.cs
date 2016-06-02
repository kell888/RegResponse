using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace RegResponse
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        public string RegCode = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("注册申请码不能为空！");
                return;
            }
            string HDSN = textBox1.Text.Trim();
            string pwd = KellCommons.KellCommon.GetRegCodeByHardDiskSN(HDSN);
            textBox2.Text = RegCode = pwd;
            KellCommons.KellCommon.WriteIni("AppSettings", "RegCode", RegCode, KellCommons.KellCommon.IniFile);
            if (MessageBox.Show("注册成功！\n是否闭关本注册窗口？", "成功提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                this.Close();
        }
    }
}