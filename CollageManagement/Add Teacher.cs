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

namespace CollageManagement
{
    public partial class Add_Teacher : Form
    {
        public Add_Teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string TeacherID = txtTeacherID.Text;
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
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
            string address = txtAddress.Text;
            string Department = txtDepartment.Text;


            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = "insert into Teachers (TeacherID, FirstName, LastName, DateOfBirth, Phone, Gender," +
                " Email, Address, Department) Values" +
                " ('" + TeacherID + "', '" + FirstName + "', '" + LastName + "', '" + DateOfBirth + "', " + Phone + "," +
                " '" + gender + "', '" + Email + "', '" + address + "', '" + Department + "')";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            
            DataSet DS = new DataSet();
            DA.Fill(DS);
            con.Close();

            MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //string TeacherID = txtTeacherID.Text;
            //string FirstName = txtFirstName.Text;
            //string DateOfBirth = dateTimePicker1.Text;
            //Int64 Mobile = Int64.Parse(txtMobileNO.Text);
            //string LastName = txtLastName.Text;
            //string gender = "";
            //bool isChecked = radioBtnMale.Checked;
            //if (isChecked)
            //{
            //    gender = radioBtnMale.Text;
            //}
            //else
            //{
            //    gender = radioBtnFemale.Text;
            //}
            //string Email = txtEmail.Text;
            //string Department = txtDepartment.Text;
            //string Address = txtAddress.Text;


            //SqlConnection con = new SqlConnection();

            //con.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";

            //SqlCommand cmd = new SqlCommand();

            //cmd.Connection = con;

            //cmd.CommandText = "insert into Teachers (TeacherID, FirstName, LastName, DateOfBirth, Mobile, gender, Email, Address, Department) Values " +
            //    "('" + TeacherID + "', '" + FirstName + "', '" + LastName + "', '" + DateOfBirth + "', " + Mobile + "'" + gender + "', , '" + Email + "', '" + Address + "', '" + Department + "')";

            //SqlDataAdapter DA = new SqlDataAdapter(cmd);

            //DataSet DS = new DataSet();

            //DA.Fill(DS);

            //con.Close();

            //MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

       
    }
}
