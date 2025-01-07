using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-PN3K53M\TEW_SQLEXPRESS;Initial Catalog=Register;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            String username, password;
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
                username = textBox1.Text;
                password = textBox2.Text;
                
                try
                {
                    string loginQuery = "SELECT COUNT(1) FROM Registertb WHERE name = @name AND pass = @pass";
                    SqlCommand cmd = new SqlCommand(loginQuery, conn);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    { 
                        DialogResult result2 = MessageBox.Show(username + " شما با موفقیت وارد شدید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result2 == DialogResult.OK)
                        {
                            Dashboard form2 = new Dashboard(); // فرض بر این است که نام فرم بعدی Form2 است
                            form2.Show(); // فرم جدید نمایش داده می‌شود
                            this.Hide(); // فرم فعلی مخفی می‌شود
                        }
                    }
                    else 
                    {
                        MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
                    }
                }
                catch 
                {
                    MessageBox.Show("Error!");
                }
                finally { conn.Close(); }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
