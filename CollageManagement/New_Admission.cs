using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CollageManagement
{
    public partial class New_Admission : Form
    {
        public New_Admission()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string StudentID = txtStudentID.Text;
            string FirstName = txtFullName.Text;
            string LastName = txtFatherName.Text;
            string gender = "";
            bool isChecked = radioBtnMale.Checked;
            if(isChecked)
            {
                gender = radioBtnMale.Text;
            }
            else
            {
                gender = radioBtnFemale.Text;
            }
            string DateOfBirth = dateTimePicker1.Text;
            Int64 Phone = Int64.Parse(txtMobileNO.Text);
            string Email = txtEmail.Text;
            string GPA = txtGPA.Text;
            string Major = txtProgramming.Text;
            string SchoolName = txtSchoolName.Text;
            string Duration = txtDuration.Text;
            string address = txtAddress.Text;


            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = "insert into Students (StudentID, FirstName, LastName, DateOfBirth, Phone, Gender," +
                " Email, Address, Major, GPA, SchoolName, Duration) Values" +
                " ('" + StudentID + "', '" + FirstName + "', '" + LastName + "', '" + DateOfBirth + "', " + Phone + "," +
                " '" + gender + "', '" + Email + "', '" + address + "', '" + Major + "', '" + GPA + "', '" + SchoolName + "', '" + Duration + "')";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();

            MessageBox.Show("Data Saved, Remember the Registration ID", "Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtFatherName.Clear();  
            radioBtnFemale.Checked = false;
            radioBtnMale.Checked = false;
            txtEmail.Clear();   
            txtMobileNO.Clear();
            txtGPA.ResetText();
            txtProgramming.ResetText();
            txtAddress.Clear(); 
            txtSchoolName.Clear();
            txtDuration.ResetText();


        }

        private void New_Admission_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select MAX(StudentID) from Students";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);

            DataSet DS = new DataSet();
            DA.Fill(DS);


            Int64 abc = Convert.ToInt64(DS.Tables[0].Rows[0][0]);

            label13.Text = abc.ToString();
        }

        
    }
}
