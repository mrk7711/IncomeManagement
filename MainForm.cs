using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace t1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("آیا قصد خروج دارید؟","خروج",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();  // نمایش فرم ورود
            this.Hide(); // مخفی کردن فرم اصلی (اختیاری)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();  // نمایش فرم ورود
            this.Hide(); // مخفی کردن فرم اصلی (اختیاری)
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            support.Show();  // نمایش فرم ورود
            this.Hide(); // مخفی کردن فرم اصلی (اختیاری)
        }
    }
}
