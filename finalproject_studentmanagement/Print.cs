using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject_studentmanagement
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LUNA\\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LUNA\\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM dbo.student_tbl WHERE id=@id", con))
                    {
                        checkCmd.Parameters.AddWithValue("@id", textBox1.Text);

                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            dataGridView1.Rows.Clear();
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.student_tbl WHERE id=@id", con))
                            {
                                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                                dataGridView1.Refresh();
                            }


                            if (dataGridView1.Rows.Count > 0)
                            {
                                StudentInformation Sc = new StudentInformation();
                                Sc.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                                Sc.textBoxfname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                Sc.textBoxlname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                                Sc.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;


                                if (dataGridView1.CurrentRow.Cells[4].Value != null)
                                {
                                    if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female")
                                    {
                                        Sc.radioButtonfemale.Checked = true;
                                    }
                                    else if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Male")
                                    {
                                        Sc.radioButtonmale.Checked = true;
                                    }
                                    else
                                    {
                                        Sc.radioButtonother.Checked = true;
                                    }
                                }

                                Sc.textBoxcnic.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                                Sc.textBoxphone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                                Sc.textBoxaddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();


                                if (dataGridView1.CurrentRow.Cells[8].Value != null)
                                {
                                    byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
                                    MemoryStream picture = new MemoryStream(pic);
                                    Sc.pictureBoxstudent.Image = Image.FromStream(picture);
                                }

                                Sc.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("No rows in the DataGridView.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("INCORRECT ID");
                        }
                    }
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
