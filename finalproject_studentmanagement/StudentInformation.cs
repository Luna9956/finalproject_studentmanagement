using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
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
    public partial class StudentInformation : Form
    {
        public StudentInformation()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LUNA\\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.student_tbl WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "dbo.student_tbl");
                

               
                CrystalReport3 crReport = new CrystalReport3();
                crReport.SetDataSource(ds.Tables["dbo.student_tbl"]);
                ReportDocument crDocument = new ReportDocument();
                crDocument.Load("C:\\Users\\saada\\source\\repos\\finalproject_studentmanagement\\finalproject_studentmanagement\\CrystalReport3.rpt");
                
                crystalReportViewer1.ReportSource = crDocument;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
