using System;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                chart1.Legends[0].Enabled = true;
            }
            else
            {
                chart1.Legends[0].Enabled = false;
            }
        }
        public Array get_Days(int count, DateTime start, DateTime finish)
        {
            int[] days = new int[count];
            for (int i = 0; i < count; i++)
            {
                days[i] = finish.AddDays(i).Subtract(start).Days;
            }
            return days;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in chart1.Series)
            {
                item.Points.Clear();
            }

            int count = 7;
            DateTime start = dateTimePicker1.Value;
            DateTime finish = DateTime.Now;
            if (radioButton2.Checked)
            {
                count = 31;
            }
            else if (radioButton3.Checked)
            {
                count = dateTimePicker3.Value.Subtract(dateTimePicker2.Value).Days;
                start = dateTimePicker2.Value;
                finish = dateTimePicker3.Value;
            }

            foreach (int K in get_Days(count, start, finish))
            {
                if (checkBox3.Checked)
                {
                    chart1.Series[0].Points.Add(Math.Sin(2 * Math.PI * K / 23));
                }
                if (checkBox4.Checked)
                {
                    chart1.Series[1].Points.Add(Math.Sin(2 * Math.PI * K / 28));
                }
                if (checkBox5.Checked)
                {
                    chart1.Series[2].Points.Add(Math.Sin(2 * Math.PI * K / 33));
                }
            }
        }
    }
}
