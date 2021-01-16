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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form5 = new Form5();
            form5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var from3 = new From3();
            from3.Show();
        }
    }
}
