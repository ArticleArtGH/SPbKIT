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
        int amountTop = 0;
        int radius = 0;
        int centerX = 0, centerY = 0;
        double cornerA = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox_Mono.BackColor = Color.Black;
            //trackBar_Radius.MaximumSize.Width = pictureBox_Polygon.Width;

        }

        private void pictureBox_Mono_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            this.pictureBox_Mono.BackColor = colorDialog1.Color;
            //this.pictureBox2.BorderStyle = BorderStyle.//Толщина PicturBox ?
        }

        private void pictureBox_Polygon_Click(object sender, EventArgs e)
        {
            
        }

        private void button_Draw_Click(object sender, EventArgs e)
        {
            amountTop = (int)numericUpDown_AmountTop.Value;//Количество вершин
            radius = trackBar_Radius.Value;//Радиус
            cornerA = 2*Math.PI/ amountTop;//Угол А в радианах
            centerX = pictureBox_Polygon.Width / 2;
            centerY = pictureBox_Polygon.Height / 2;
            int[] arrayX = new int[0],arrayY = new int[0];
            for(int i = 0; i< amountTop; i++)
            {
                Array.Resize(ref arrayX, arrayX.Length + 1);
                Array.Resize(ref arrayY, arrayY.Length + 1);
                arrayX[i] = (centerX + (int)(radius * Math.Cos(cornerA)));
                arrayY[i] = (centerY + (int)(radius * Math.Cos(cornerA)));
            }
            Color col = pictureBox_Mono.BackColor;//цвет
            int depth = trackBar_Depth.Value;
            //Pen penPolygon = new Pen(this.pictureBox2.BackColor, this.trackBar1.Value);
            //Pen penPolygon = new Pen(col, this.trackBar2.Value);
            Pen penPolygon = new Pen(col, depth);
            //Graphics gr = this.CreateGraphics();//Для формы
            Graphics gr = this.pictureBox_Polygon.CreateGraphics();
            //drawLine.DrawLine(penPolygon, pictureBox1.Location.X / 2, pictureBox1.Location.Y / 2, pictureBox1.Location.X / 2, pictureBox1.Location.Y / 2);
            for (int i = 0; i < amountTop; i++)
            {
                //gr.DrawLine(penPolygon, centerX, centerY, arrayX[i], arrayY[i]);
                gr.DrawLine(penPolygon, arrayX[i], arrayY[i],0,0);//Как нарисовать вершины ???
            }
            //gr.DrawLine(penPolygon, pictureBox_Polygon.Height / 2, pictureBox_Polygon.Height / 2, pictureBox_Polygon.Width, pictureBox_Polygon.Height / 2);
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Graphics gr = this.pictureBox_Polygon.CreateGraphics();
            gr.Clear(Color.White);
        }
    }
}
