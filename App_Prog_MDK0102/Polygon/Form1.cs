using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            this.pictureBox2.BackColor = colorDialog1.Color;
            //this.pictureBox2.BorderStyle = BorderStyle.//Толщина PicturBox ?
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vergeAmount = Convert.ToInt32(this.numericUpDown2.Value);
            double angelA = 2*Math.PI/vergeAmount;
            int[] arrayX = new int[0],arrayY = new int[0];
            Color col = Color.Black;
            //Pen penPolygon = new Pen(this.pictureBox2.BackColor, this.trackBar1.Value);
            //Pen penPolygon = new Pen(col, this.trackBar2.Value);
            Pen penPolygon = new Pen(col, 10);
            //Graphics gr = this.CreateGraphics();//Для формы
            Graphics gr = this.pictureBox1.CreateGraphics();
            //drawLine.DrawLine(penPolygon, pictureBox1.Location.X / 2, pictureBox1.Location.Y / 2, pictureBox1.Location.X / 2, pictureBox1.Location.Y / 2);
            gr.DrawLine(penPolygon, pictureBox1.Height / 2, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics gr = this.pictureBox1.CreateGraphics();
            gr.Clear(Color.White);
        }
    }
}
