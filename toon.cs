using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseFormConnectDB
{
    public partial class toon : Form
    {
        private MySqlConnection conn;
        private MySqlDataAdapter adpt;
        private MySqlCommandBuilder cmbd;
        private DataTable dt;
        private BindingSource bds;
        private string strQuery;
        public toon()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            var connectionString = "Server=localhost;Database=formdb;Uid=root;Pwd=;";
            conn = new MySqlConnection(connectionString);
            strQuery = "SELECT * FROM toon";

            conn.Open();

            adpt = new MySqlDataAdapter(strQuery, conn);
            cmbd = new MySqlCommandBuilder(adpt);

            dt = new DataTable();
            adpt.Fill(dt);
            bds = new BindingSource();
            bds.DataSource = dt;

            dataGridView1.DataSource = bds;

            conn.Close();
        }

        private void toon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                adpt.Update(dt);
                LoadData();
                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "บันทึกข้อมูลสำเร็จแล้ว", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
