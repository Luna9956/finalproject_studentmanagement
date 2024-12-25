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

namespace finalproject_studentmanagement
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
                SqlConnection con = new SqlConnection("Data Source=LUNA\\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.adminlogin_tbl WHERE username = @username and password = @password ", con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    new Mainform().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid input");
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("input not found", " sign up failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';

            }
            else
            {
                textBox2.PasswordChar = '*';

            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            new Signup().Show();
            this.Hide();
        }
    }
    
}
