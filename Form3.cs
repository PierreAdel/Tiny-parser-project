using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectScanner
{
    public partial class Form3 : Form
    {
        public Form3(String error)
        {
            InitializeComponent();
            richTextBox1.Text = error;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
