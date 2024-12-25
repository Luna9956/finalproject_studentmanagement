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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }
        string connectionstring = @"Data Source=LUNA\SQLEXPRESS;Initial Catalog=student_management;Integrated Security=True;";

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Addnewstudent().Show();
            this.Hide();
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            new StudentForms().Show();
            this.Hide();
                      
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Search().Show();
            this.Hide();
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Statics().Show();
            this.Hide();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Print().Show();
            this.Hide();
        }
    }
}
