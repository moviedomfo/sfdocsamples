using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleGmailAPi
{
    public partial class Form1 : Form
    {
        string body = "What is Lorem Ipsum? Lorem Ipsum is simply dummy text of the printing and typesetting industry.Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtBody.Text = body;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GmailWrapper.Send1(txtTo.Text, txtBody.Text);
            }
            catch(Exception ex)
            {
                textBox1.Text = ex.Message;
            }

             

            //var labels = GmailWrapper.getLabels_Me();
            //StringBuilder str = new StringBuilder();
            //if (labels != null && labels.Count > 0)
            //{
            //    foreach (var labelItem in labels)
            //    {
            //        str.AppendLine(labelItem.Name);
            //    }
            //}

            //textBox1.Text = str.ToString();
        }
    }
}
