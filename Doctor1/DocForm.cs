using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Doctor1
{
    public partial class DocForm : Form
    {
        DBconnection con = new DBconnection();
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;


        public DocForm()
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
                // Ensure the connection is open
                if (con.cn.State == ConnectionState.Closed)
                {
                    con.cn.Open();
                }

                // SQL query to fetch patient data
                string query = "SELECT PatientID, Name, Disease, Status FROM patient"; // Fetch only the required columns
                using (cmd = new MySqlCommand(query, con.cn))
                {
                    // Fill the DataTable
                    da = new MySqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed
                if (con.cn.State == ConnectionState.Open)
                {
                    con.cn.Close();
                }
            }
        }
    }
}
