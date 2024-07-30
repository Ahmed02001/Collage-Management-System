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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }

        private void txtRegNumber_TextChanged(object sender, EventArgs e)
        {

            if (txtRegNumber.Text != "")
            {
                SqlConnection con = new SqlConnection();

                con.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select FirstName, LastName, Duration from Students where StudentID = " + txtRegNumber.Text + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();

                DA.Fill(DS);

                if (DS.Tables[0].Rows.Count != 0)
                {
                NameLabel.Text = DS.Tables[0].Rows[0][0].ToString();
                FatherNameLabel.Text = DS.Tables[0].Rows[0][1].ToString();
                DurationLabel.Text = DS.Tables[0].Rows[0][2].ToString();

                }
                else
                {
                    NameLabel.Text = "_____";
                    FatherNameLabel.Text = "_____";
                    DurationLabel.Text = "_____";
                }

            }
            else
            {
                txtRegNumber.Text = "";
                NameLabel.Text = "_____";
                FatherNameLabel.Text = "_____";
                DurationLabel.Text = "_____";
                txtFees.Text = "";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection();

            con.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Fees where FeeID = " + txtRegNumber.Text + "";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);

            if (DS.Tables[0].Rows.Count == 0)
            {
                SqlConnection con1 = new SqlConnection();

                con1.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;
                cmd1.CommandText = "UPDATE Fees SET Amount = " + txtRegNumber.Text + ", where FeeID =  " + txtFees.Text + ")";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();

                DA1.Fill(DS1);

                if (MessageBox.Show("Fees Submition Successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtRegNumber.Text = "";
                    NameLabel.Text = "_____";
                    FatherNameLabel.Text = "_____";
                    DurationLabel.Text = "_____";
                    txtFees.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Fees is AllReady Submited.");
                txtRegNumber.Text = "";
                NameLabel.Text = "_____";
                FatherNameLabel.Text = "_____";
                DurationLabel.Text = "_____";
                txtFees.Text = "";
            }
            
        }
    }
}
