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
    public partial class Splash : Form
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
        public Splash()
        {
            InitializeComponent();
            AddFontFromMemory();
            label2.Font = new Font(PFC.Families[0], 20, System.Drawing.FontStyle.Regular);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar2.Value += 10;
            if (progressBar2.Value >= 100)
            {
                timer2.Stop();
                MainForm form1 = new MainForm(); // ایجاد فرم ورود
                form1.Show(); // نمایش فرم ورود
                this.Hide(); // مخفی کردن فرم SplashScreen
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Splash_Load(object sender, EventArgs e)
        {
            label2.Location = new Point(
            (this.ClientSize.Width - label2.Width) / 2,
            (this.ClientSize.Height - label2.Height) / 2
            );
            timer2.Start();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
