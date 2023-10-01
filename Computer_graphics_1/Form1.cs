using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Computer_graphics_1
{
    public partial class Form1 : Form
    {
        private Pikachu pikachu;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            pikachu = new Pikachu(pictureBox1); 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pikachu.Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pikachu.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int newX = Int32.Parse(textBox7.Text);
            int newY = Int32.Parse(textBox6.Text);
            pikachu.Transfer(newX * 10, newY * 10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rotate = Int32.Parse(textBox4.Text);
            pikachu.Rotate(rotate);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            float scale = float.Parse(textBox5.Text);
            pikachu.Scale(scale);
        }
    }

}
