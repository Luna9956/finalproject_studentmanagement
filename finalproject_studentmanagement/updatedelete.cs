using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace finalproject_studentmanagement
{
    public partial class updatedelete : Form
    {
        
        public updatedelete()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LUNA\\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True");
        SqlCommand cmd ;
        SqlDataAdapter da;
        DataTable dt;

        private bool AreControlsFilled()
        {
            var textBoxes = Controls.OfType<TextBox>();
            if (textBoxes.Any(textBox => string.IsNullOrEmpty(textBox.Text)))
            {
                MessageBox.Show("Please fill in all text boxes.");
                return false;
            }

            var pictureBoxes = Controls.OfType<PictureBox>();
            if (pictureBoxes.Any(pictureBox => pictureBox.Image == null))
            {
                MessageBox.Show("Please select an image in all picture boxes.");
                return false;
            }

            var radioButtons = Controls.OfType<RadioButton>();
            if (!radioButtons.Any(radioButton => radioButton.Checked))
            {
                MessageBox.Show("Please select at least one radio button.");
                return false;
            }

            if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Please select a date.");
                return false;
            }
            return true;
        }

        private void parameters()
        {
            
            cmd.Parameters.AddWithValue("@fname", textBoxfname.Text);
            cmd.Parameters.AddWithValue("@lname", textBoxlname.Text);
            cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Gender", Getradiovalue());
            cmd.Parameters.AddWithValue("@Cnic", textBoxcnic.Text);
            cmd.Parameters.AddWithValue("@Phone", textBoxphone.Text);
            cmd.Parameters.AddWithValue("@Address", textBoxaddress.Text);
            cmd.Parameters.AddWithValue("@Picture", getPhoto());
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (AreControlsFilled())
            {
                cmd = new SqlCommand("UPDATE dbo.student_tbl set fname=@fname,lname=@lname,DOB=@DOB,Gender=@Gender,Cnic=@Cnic,Phone=@Phone,Address=@Address,Picture=@Picture WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id",textBox1.Text);
                parameters();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                MessageBox.Show("Updated successfully");
                new StudentForms().Show();
                this.Hide();
            }

        }
        private string Getradiovalue()
        {
            foreach (Control control in Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {

                    switch (radioButton.Name)
                    {
                        case "radioButtonmale":
                            return "Male";
                        case "radioButtonfemale":
                            return "Female";
                        case "radioButtonother":
                            return "Other";

                        default:
                            return "Unknown";
                    }
                }
            }
            return "Unknown";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new StudentForms().Show();
            this.Hide();
        }
        private byte[] getPhoto()
        {
            MemoryStream stream = new MemoryStream();
            pictureBoxstudent.Image.Save(stream, pictureBoxstudent.Image.RawFormat);
            return stream.ToArray();
        }
        private void buttonuploadimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxstudent.Image = new Bitmap(ofd.FileName);
            }
        }
        public void ClearControls()
        {

            foreach (Control control in Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
                else if (control is PictureBox pictureBox)
                {
                    pictureBox.Image = null;
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = dateTimePicker.MinDate;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this student", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cmd = new SqlCommand("DELETE FROM dbo.student_tbl where ID = @id", con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                parameters();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted");
                ClearControls();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxstudent_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBoxaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBoxphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBoxcnic_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonother_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonfemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonmale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxlname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void updatedelete_Load(object sender, EventArgs e)
        {

        }
    }
 }


