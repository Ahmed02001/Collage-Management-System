using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollageManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void studentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;
            string Password = textBox2.Text;

            if(UserName == "ahmed" &&  Password == "1234")
            {
                menuStrip1.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Admission na = new New_Admission();
            na.Show();
        }

        private void upgradeSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpgradeSemester us = new UpgradeSemester();

            us.Show();

        }

        private void feesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fees fe = new Fees();

            fe.Show();
        }

        private void searchStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchStudent ss = new SearchStudent();
            ss.Show();
        }

        private void indToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentIndividualDetails SI = new StudentIndividualDetails();
            SI.Show();
        }

        private void addTeacherInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Teacher at = new Add_Teacher();
            at.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchTeacher searchTeacher = new SearchTeacher();
            searchTeacher.Show();
        }

        private void removeStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveStudent RS = new RemoveStudent();
            RS.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs about = new AboutUs();
            about.Show();
        }

        private void exitSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Close The Application.", " Exit",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }

        }
    }
}
