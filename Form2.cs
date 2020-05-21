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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Name = "Syntax Tree";
        }
        public void Populate_Tree(TreeNode node)
        {
            treeView1.Nodes.Add(node);
            treeView1.ExpandAll();


        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
