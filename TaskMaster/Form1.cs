using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace TaskMaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileRead();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addItemForm = new Form2(this);
            addItemForm.ShowDialog();
        }
        private void FileRead()
        {
            using (StreamReader sr = new StreamReader("Tasks.txt", true))
            {
                while (!sr.EndOfStream)
                {
                    listBox1.Items.Add(sr.ReadLine());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
        private void SortListBoxTime()
        {

            List<string> sortedItems = listBox1.Items.Cast<string>()
                .OrderBy(item => DateTime.ParseExact(item.Split('|')[1] + item.Split('|')[2], "dd.MM.yyyyHH:mm", null))
                .ToList();

            // Очищаем ListBox и добавляем отсортированные записи
            listBox1.Items.Clear();
            listBox1.Items.AddRange(sortedItems.ToArray());
        }
        private void SortListBoxLetter()
        {

            List<string> sortedItems = listBox1.Items.Cast<string>()
                .OrderBy(item => item.Split()[0])
                .ToList();

            // Очищаем ListBox и добавляем отсортированные записи
            listBox1.Items.Clear();
            listBox1.Items.AddRange(sortedItems.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SortListBoxTime();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SortListBoxLetter();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) 
            {
                listBox1.Items.Clear();
                FileRead();
            }
            else if (comboBox1.SelectedIndex == 1) { SortListBoxTime(); }
            else if (comboBox1.SelectedIndex == 2) { SortListBoxLetter(); }
        }
    }
}
