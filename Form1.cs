using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace projectScanner
{
    public partial class Form1 : Form
    {

        TextWriter tw;


        public Form1()
        {
            InitializeComponent();
            
        }


        public void ViewOutput(int length,String[,] Output) //called by scanner to print output
        {
            
            
            Form1 form1 = this;
            
            
            form1.label1.Text = "Compiled succsefully";
            form1.label1.Visible = true;
            button2.Enabled = true;
            button3.Enabled = true;

            DataTable dt = new DataTable();
            dt.Columns.Add("Lexeme", typeof(string));
            dt.Columns.Add("Token", typeof(string));
            dataGridView1.DataSource = dt;
             

            DataRow row1;





                 

          
            for (int i = 0; i < length; i++)
            {
                row1 = dt.NewRow();
                row1["Lexeme"] = Output[i,0];
                row1["Token"] = Output[i, 1];
                
                dt.Rows.Add(row1);

             


                if (radioButton3.Checked)
                {
                    try
                    {
                        tw = new StreamWriter(textBox2.Text);

                        tw.Write("Lexeme");
                        tw.Write(" - ");
                        tw.Write("Token");


                        tw.WriteLine();
                        tw.Flush();


                        tw.Write(" ");

                        tw.WriteLine();
                        tw.Flush();


                    }
                    catch (Exception v)
                    { }

                    tw.Write(Output[i, 0]);
                    tw.Write(" , ");
                    tw.Write(Output[i, 1]);

                    


                    tw.WriteLine();
                    tw.Flush();

                }




            }






        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label4.Enabled = false;
            // radioButton1.Checked = true;
            button4.Visible = false;
            textBox1.Visible = false;

            label1.Text = "Compiling ...";
            label1.Visible = true;
            button2.Enabled = false;
            button3.Enabled = false;
            dataGridView1.Visible = false;
            richTextBox1.Visible = true;
            richTextBox1.BringToFront();


            if (radioButton2.Checked)
            {
                try
                {
                    String fileText = System.IO.File.ReadAllText(textBox1.Text);
                    richTextBox1.Text = fileText;
                }
                catch (Exception a)
                {
                    richTextBox1.Text = "";

                }

            }

            Scanner scan = new Scanner(richTextBox1.Text,this);
            scan.Start_Scan();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            richTextBox1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            dataGridView1.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void radioButton1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.Enabled = true;
            richTextBox1.ReadOnly = false;
            dataGridView1.Visible = true;
            richTextBox1.Visible = true;
            richTextBox1.BringToFront();
            button4.Visible = false;
            textBox1.Visible = false;
        }

        private void radioButton2_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox1.ReadOnly = true;
            richTextBox1.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = true;
            textBox1.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }





        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
            label4.Enabled = true;
            label4.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            openFileDialog1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            String fun = "بتتس";

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+ "/important/btates.jpeg";
            button1.Text = fun;
            button2.Text = fun;
            button3.Text = fun;
            button4.Text = fun;
            //button5.Text = fun;
            label1.Text = fun;
            label2.Text = fun;
            radioButton1.Text = fun;

            radioButton2.Text = fun;
            radioButton3.Text = fun;
            radioButton4.Text = fun;
            label3.Text = fun;
            openFileDialog1.FileName = fun;
            openFileDialog2.FileName = fun;

            pictureBox1.Visible = true;
            try
            {
                pictureBox1.Image = new Bitmap(path);
            }
            catch (Exception b)
            {
                // do nothing
            }
            //PictureBox pb1 = new PictureBox();
            //pb1.ImageLocation = funlocation;
            //    pb1.SizeMode = PictureBoxSizeMode.AutoSize;
        }



    

        private void button5_Click(object sender, EventArgs e)
        {
           // button1.Enabled = true;
           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            textBox2.Text = openFileDialog2.FileName;
            if (textBox2.Text == "") { textBox2.Visible = false; }
        }

      

        private void radioButton4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Enabled = false;
            radioButton4.Checked = true;
            radioButton3.Checked = false;
        }

        private void radioButton3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Enabled = true;
            radioButton4.Checked = false;
            radioButton3.Checked = true;

            openFileDialog2.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}



