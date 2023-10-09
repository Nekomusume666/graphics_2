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
            pikachu.ClearCanvas();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int transferX = Int32.Parse(textBox7.Text);
            int transferY = Int32.Parse(textBox6.Text);
            int transferZ = Int32.Parse(textBox1.Text);

            pikachu.Move(transferX, transferY, transferZ);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rotateX = Int32.Parse(textBox4.Text);
            pikachu.RotateX(rotateX);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            double scaleX = double.Parse(textBox5.Text);
            double scaleY = double.Parse(textBox2.Text);
            double scaleZ = double.Parse(textBox3.Text);

            pikachu.Scale(scaleX, scaleY, scaleZ);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rotateY = Int32.Parse(textBox4.Text);
            pikachu.RotateY(rotateY);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int rotateZ = Int32.Parse(textBox4.Text);
            pikachu.RotateZ(rotateZ);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pikachu.ConvertToCabine();
        }
    }

}
