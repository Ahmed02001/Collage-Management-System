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
    public partial class StudentIndividualDetails : Form
    {
        public StudentIndividualDetails()
        {
            InitializeComponent();
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from Students where StudentID = " + textBox1.Text + "";

            SqlDataAdapter da = new SqlDataAdapter(cmd);  
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                labelFullName.Text = ds.Tables[0].Rows[0][1].ToString();
                labelFatherName.Text = ds.Tables[0].Rows[0][2].ToString();
                labelDateOfBirth.Text = ds.Tables[0].Rows[0][3].ToString();
                labelMobile.Text = ds.Tables[0].Rows[0][4].ToString();
                labelGender.Text = ds.Tables[0].Rows[0][5].ToString();
                labelEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                labelAddress.Text = ds.Tables[0].Rows[0][7].ToString();
                labelStandard.Text = ds.Tables[0].Rows[0][8].ToString();
                labelMeduim.Text = ds.Tables[0].Rows[0][9].ToString();
                labelSchooleName.Text = ds.Tables[0].Rows[0][10].ToString();
                labelYear.Text = ds.Tables[0].Rows[0][11].ToString();
            }
            else
            {
                MessageBox.Show("No Record Found.", "Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);

                labelFullName.Text = "__________";
                labelFatherName.Text = "__________";
                labelGender.Text = "__________";
                labelDateOfBirth.Text = "__________";
                labelMobile.Text = "__________";
                labelEmail.Text = "__________";
                labelStandard.Text = "__________";
                labelMeduim.Text = "__________";
                labelSchooleName.Text = "__________";
                labelYear.Text = "__________";
                labelAddress.Text = "__________";
            }

            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            labelFullName.Text = "__________";
            labelFatherName.Text = "__________";
            labelGender.Text = "__________";
            labelDateOfBirth.Text = "__________";
            labelMobile.Text = "__________";
            labelEmail.Text = "__________";
            labelStandard.Text = "__________";
            labelMeduim.Text = "__________";
            labelSchooleName.Text = "__________";
            labelYear.Text = "__________";
            labelAddress.Text = "__________";

            textBox1.Text = "";
        }
    }
}
