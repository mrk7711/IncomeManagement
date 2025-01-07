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
using System.Data.SqlClient;

namespace t1
{
    public partial class Register : Form
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
        public Register()
        {
            InitializeComponent();
            AddFontFromMemory();
            label1.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
            label2.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
            label3.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
            label4.Font = new Font(PFC.Families[0], 10, System.Drawing.FontStyle.Regular);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void Register_Load(object sender, EventArgs e)
        {

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
            String username, password, email;
            if (textBox1.Text == "")
                {
                label5.Visible = true;
                }
            if (textBox2.Text == "")
            {
                label6.Visible = true;
            }
            if (textBox3.Text == "")
            {
                label7.Visible = true;
            }
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                username = textBox1.Text;
                password = textBox2.Text;
                email = textBox3.Text;
                try
                {
                    string checkQuery = "SELECT COUNT(1) FROM Registertb WHERE name = @name AND pass = @pass";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@name", textBox1.Text);
                    checkCmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("این نام کاربری  قبلاً ثبت شده است. لطفاً اطلاعات دیگری وارد کنید.");
                    }
                    else
                    {
                        String insertquerry = "INSERT INTO Registertb (name, pass, email)  VALUES (@name, @pass, @email)";
                        //String querry = "SELECT * FROM Registertb WHERE name = '" + textBox1.Text + "'AND pass = '" + textBox2.Text + "' AND email = '" + textBox3.Text+"'";
                        SqlCommand cmd = new SqlCommand(insertquerry, conn);
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                        cmd.Parameters.AddWithValue("@email", textBox3.Text);
                        cmd.ExecuteNonQuery();
                        //SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
                        //DataTable dt = new DataTable();
                        //sda.Fill(dt);
                        //if (dt.Rows.Count > 0)
                        //{
                        //username = textBox1.Text;
                        //password = textBox2.Text;
                        // email = textBox3.Text;
                        DialogResult result2 = MessageBox.Show(username + " شما ثبت نام شدید", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result2 == DialogResult.OK)
                        {
                            Dashboard form2 = new Dashboard(); // فرض بر این است که نام فرم بعدی Form2 است
                            form2.Show(); // فرم جدید نمایش داده می‌شود
                            this.Hide(); // فرم فعلی مخفی می‌شود
                        }

                        //}
                        //else
                        //{
                        //MessageBox.Show(" شما ثبت نام نشدید");
                        //}
                    }
                }
                catch 
                {
                    MessageBox.Show("Error!");
                }
                finally { conn.Close(); }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
