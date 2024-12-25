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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textbox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textbox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textbox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("input not found", " sign up failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == textBox3.Text)
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=LUNA\\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.adminlogin_tbl (username, password) VALUES (@username, @password)", con);


                    cmd.Parameters.AddWithValue("@username", textbox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Signup successful");
                    }
                    else
                    {
                        MessageBox.Show("Signup failed");

                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); 
                }

                textbox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                MessageBox.Show(" your account has been created successfully ", " signup successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new loginform().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("password doesnot match please re-enter", "signup failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new loginform().Show();
            this.Hide();
        }
    }
}
