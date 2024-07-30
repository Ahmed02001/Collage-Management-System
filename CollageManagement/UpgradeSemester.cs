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
    public partial class UpgradeSemester : Form
    {
        public UpgradeSemester()
        {
            InitializeComponent();
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Major Upgrade Warning!", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();

                con.ConnectionString = "data source = DESKTOP-7J7PHU6; database = University_Database; integrated security = true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Update Students set Major = '" + comboBoxTo.Text + "' where Major = '" + comboBoxFrom.Text + "'";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);

                DataSet DS = new DataSet();

                DA.Fill(DS);

                MessageBox.Show("Upgrade Successfull", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Upgrade Cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
    }
}
