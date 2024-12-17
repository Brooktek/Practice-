using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Doc
{
    public partial class Form1 : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand command;
        MySqlDataAdapter da;
        DataTable dt;


        public Form1()
        {
            InitializeComponent();
            con.Connect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnload_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM patient";


                command = new MySqlCommand(query, con.cn);
                da = new MySqlDataAdapter(command);

                dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoResizeColumns();
                
                //con.cn.Open();
                //command = new MySqlCommand("Select * from patient", con.cn);
                //command.ExecuteNonQuery();
                //dt = new DataTable();
                //da = new MySqlDataAdapter(command);
                //da.Fill(dt);
                //dataGridView1.DataSource = dt.DefaultView;
                //con.cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int patientId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PatientID"].Value);
                string patientName = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();


                DetailedPatientForm detailedForm = new DetailedPatientForm(patientId);
                detailedForm.ShowDialog();
            }
        }
    }
}
