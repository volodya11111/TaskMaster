using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskMaster
{
    public partial class Form2 : Form
    {
        public string task;
        private Form1 _form;
        public Form2(Form1 form)
        {
            InitializeComponent();
            _form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task = $"{textBox1.Text}|{dateTimePicker2.Text}|{dateTimePicker1.Text}";
            _form.listBox1.Items.Add(task);
            using (StreamWriter writer = new StreamWriter("Tasks.txt", true))
            {
                writer.WriteLine(task);
            }
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
