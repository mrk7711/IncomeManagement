using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace t1
{
    public partial class Dashboard : Form
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
        public Dashboard()
        {
            InitializeComponent();
            AddFontFromMemory();
            label1.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
            label2.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(this.ClientSize.Width - label1.Width - 20, 20);
            label2.Location = new Point(this.ClientSize.Width - label1.Width - 20, 40);
        }
    }
}
