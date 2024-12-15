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
                con.cn.Open();
                command = new MySqlCommand("Select * from patient", con.cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.cn.Close();
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
    }
}
