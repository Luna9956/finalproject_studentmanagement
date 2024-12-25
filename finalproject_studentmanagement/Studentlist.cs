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
    public partial class StudentForms : Form
    {
        string connectionstring = @"Data Source=LUNA\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True;";
 
        public StudentForms()
        {
            InitializeComponent();
        }

        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           updatedelete upd = new updatedelete();
            upd.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            upd.textBoxfname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            upd.textBoxlname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            upd.dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female")
            {
                upd.radioButtonfemale.Checked = true;
            }
            else if(dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Male")
            {
                upd.radioButtonmale.Checked = true;
            }
            else
            {
                upd.radioButtonother.Checked = true;
            }
            upd.textBoxcnic.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            upd.textBoxphone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            upd.textBoxaddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            upd.pictureBoxstudent.Image=Image.FromStream(picture);
            upd.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Mainform().Show();
            this.Hide();
        }

        private void studenttblBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new updatedelete().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void StudentForms_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.student_tbl", sqlcon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label1.Text=$"TOTAL RECORDS: {(dataGridView1.RowCount)-1}";
            }
        }
    }
}
