using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d =  DateTime.Now;
            StringBuilder str = new StringBuilder();
            
            
            TimeSpan t = new TimeSpan(d.Ticks);
            DateTime fechiInicioTimpos = d.AddDays(-t.Days);


            str.AppendLine("Fecha                    " + d.ToString());
            str.AppendLine("fechiInicioTimpos        " + fechiInicioTimpos.ToString());
            str.AppendLine("------------------------------------------------------------------------");

            str.AppendLine("TimeSpan Ticks              " + t.Ticks);

            str.AppendLine("TimeSpan Days              " + t.Days);
            str.AppendLine("TimeSpan Hours              " + t.Hours);
            str.AppendLine("TimeSpan Minutes              " + t.Minutes);
            str.AppendLine("TimeSpan Seconds              " + t.Seconds);
            str.AppendLine("------------------------------------------------------------------------");
            str.AppendLine("TimeSpan TotalDays              " + t.TotalDays);

            

            str.AppendLine("TimeSpan TotalHours         " + t.TotalHours);
            str.AppendLine("TimeSpan TotalMinutes       " + t.TotalMinutes);
            str.AppendLine("TimeSpan TotalSeconds       " + t.TotalSeconds);
            str.AppendLine("TimeSpan TotalMilliseconds  " + t.TotalMilliseconds);
            str.AppendLine("TimeSpan Ticks/10000        " + t.Ticks/1000);
            str.AppendLine("------------------------------------------------------------------------");
            str.AppendLine("TimeSpan TotalMinutes       " + t.TotalMinutes);
            str.AppendLine("Time Start hh:mm             " + String.Concat(d.ToString("hh"), ":", d.ToString("mm")));


            TimeSpan res = d- fechiInicioTimpos;
            str.AppendLine("------------------------------------------------------------------------");
            str.AppendLine("TimeSpan resultado restar ambas fechas         " + res.TotalMilliseconds);

            textBox1.Text = str.ToString();
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            string timeStart = textBox2.Text; //String.Concat(d.ToString("hh"), ":", d.ToString("mm"));
            TimeSpan TimeStart_timesp = TimeSpan.Parse(timeStart);
            //str.AppendLine("d h:m:s " +
            //    string.Concat(TimeStart_timesp.Days.ToString(), " ",
            //    TimeStart_timesp.Hours.ToString(), ":",
            //    TimeStart_timesp.Minutes.ToString(), ":",
            //    TimeStart_timesp.Seconds.ToString())
            //    );
            
            str.AppendLine("TimeSpan Ticks " + TimeStart_timesp.Ticks);
            str.AppendLine("TimeSpan TotalMilliseconds " + TimeStart_timesp.TotalMilliseconds);
            str.AppendLine("TimeSpan Ticks/10000 " + TimeStart_timesp.Ticks / 1000);
            str.AppendLine("TimeSpan TotalMinutes" + TimeStart_timesp.TotalMinutes);
            str.AppendLine("Time Start hh:mm " + String.Concat(TimeStart_timesp.ToString("hh"), ":", TimeStart_timesp.ToString("mm")));
            textBox1.Text = str.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            //[d.] hh:mm[:ss[. ff]] }[ws]
            var ti = TimeSpan.Parse("00:00");
            var tf = TimeSpan.Parse("23:59:59");

            str.AppendLine("ti " + ti.TotalMinutes);
            str.AppendLine("ti " + tf.TotalMinutes);
            textBox1.Text = str.ToString();

        }
    }
}
