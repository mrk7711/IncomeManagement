using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace t1
{
    public partial class Login : Form
    {
        PrivateFontCollection PFC = new PrivateFontCollection();
        private void AddFontFromMemory()
        {
            int fontLength = Properties.Resources.BKoodkBd.Length;
            byte[] fontdata = Properties.Resources.BKoodkBd;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            PFC.AddMemoryFont(data, fontLength);
        }
        public Login()
        {
            InitializeComponent();
            AddFontFromMemory();
            label1.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
            label2.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
            label3.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm form1 = new MainForm();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label5.Visible = true;
            }
            if (textBox2.Text == "")
            {
                label6.Visible = true;
            }
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                label5.Visible = false;
                label6.Visible = false;
                MessageBox.Show(textBox1.Text + " شما با موفقیت وارد شدید");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
