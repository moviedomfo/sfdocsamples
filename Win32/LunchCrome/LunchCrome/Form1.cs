using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LunchCrome
{
    public partial class Form1 : Form
    {
        string url = "https://www.facebook.com/";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Process.Start("chrome.exe", url);
                    
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    Process p = Process.Start("iexplore.exe", url);
                }
            }
            catch (Exception ex)
            {
                throw (new Exception("Se produjo un error lanzando la aplicación.", ex));
            }
           
        }


    }
}
