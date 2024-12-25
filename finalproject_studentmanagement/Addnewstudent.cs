using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;
using TextBox = System.Windows.Forms.TextBox;

namespace finalproject_studentmanagement
{
    public partial class Addnewstudent : Form
    {
        public Addnewstudent()
        {
            InitializeComponent();
        }
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
        private void buttonadd_Click(object sender, EventArgs e)
        {
            if (AreControlsFilled())
            {
                MessageBox.Show("Processing");
                try
                {

                    SqlConnection con = new SqlConnection("Data Source=LUNA\\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.student_tbl (fname,lname,DOB,Gender,CNIC,Phone,Address,Picture) VALUES (@fname, @lname,@DOB,@Gender,@Cnic,@Phone,@Address,@Picture)", con);


                    cmd.Parameters.AddWithValue("@fname", textBoxfname.Text);
                    cmd.Parameters.AddWithValue("@lname", textBoxlname.Text);
                    cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Gender", Getradiovalue());
                    cmd.Parameters.AddWithValue("@Cnic", textBoxcnic.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBoxphone.Text);
                    cmd.Parameters.AddWithValue("@Address", textBoxaddress.Text);
                    cmd.Parameters.AddWithValue("@Picture", getPhoto());


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Addition successful");
                        ClearControls();
                    }

                    else
                    {
                        MessageBox.Show("Addition failed");

                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill all fields");
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
        private byte[] getPhoto()
        {
            if (pictureBoxstudent != null && pictureBoxstudent.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                pictureBoxstudent.Image.Save(stream, pictureBoxstudent.Image.RawFormat);
                return stream.ToArray();
            }
            else
            {
                return new byte[0]; ;
            }
        }
        private void buttonuploadimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
           if(ofd.ShowDialog()== DialogResult.OK)
            {
                pictureBoxstudent.Image=new Bitmap(ofd.FileName);
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



        private void buttoncancel_Click(object sender, EventArgs e)
        {
            ClearControls();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Mainform().Show();
            this.Hide();
        }

        private void Addnewstudent_Load(object sender, EventArgs e)
        {

        }
    }
    
}
        
               