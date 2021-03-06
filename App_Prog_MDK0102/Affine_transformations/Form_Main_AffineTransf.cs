﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;//для класса Matrix

namespace Polygon
{
    public partial class Form_Main_AffineTransf : Form
    {
        int amountTop = 0;
        int radius = 0;
        int centerX = 0, centerY = 0;
        double cornerA = 0;
        Bitmap buf;//  буфер для Bitmap-изображения
        Graphics gr;//  графический объект — некий холст
        Pen penPolygon;
        int[] arrayX = new int[0], arrayY = new int[0];
        int depth = 0;
        Color col = Color.White;

        public Form_Main_AffineTransf()
        {
            InitializeComponent();
            ////Graphics gr = this.CreateGraphics();//Для формы
            //buf = new Bitmap(pictureBox_Polygon.Width, pictureBox_Polygon.Height);// с размерами

            //gr = this.pictureBox_Polygon.CreateGraphics();

            //pictureBox_Polygon.Image = buf;
            buf = new Bitmap(pictureBox_Polygon.Width, pictureBox_Polygon.Height);
            gr = Graphics.FromImage(buf);// инициализация gr

            this.pictureBox_Mono.BackColor = Color.Black;
            this.pictureBox_Polygon.BackColor = Color.White;
            //trackBar_Radius.MaximumSize.Width = pictureBox_Polygon.Width;

            //checked.Event
            //this.checkBox_Rotate.Checked += new System.EventHandler(EventHandler );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox_Mono_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            this.pictureBox_Mono.BackColor = colorDialog1.Color;
        }

        private void pictureBox_Polygon_Click(object sender, EventArgs e)
        {
            
        }

        private void button_Draw_Click(object sender, EventArgs e)
        {
            centerX = pictureBox_Polygon.Width / 2;
            centerY = pictureBox_Polygon.Height / 2;
            amountTop = (int)numericUpDown_AmountTop.Value;//Количество вершин
            cornerA = Math.Round(2 * Math.PI / amountTop, 2);//Угол А в радианах
            radius = trackBar_Radius.Value;//Радиус
            arrayX = new int[amountTop]; arrayY = new int[amountTop];

            for (int i = 0; i < amountTop; i++)
            {
                //Array.Resize(ref arrayX, arrayX.Length + 1);
                //Array.Resize(ref arrayY, arrayY.Length + 1);
                arrayX[i] = (int)(centerX + (radius * Math.Cos(cornerA*i)));//на i умножать не правильно, т.к.
                arrayY[i] = Convert.ToInt32(centerY + (radius * Math.Sin(cornerA*i)));//может быть больше радиуса (я так думаю)
            }
            col = pictureBox_Mono.BackColor;//цвет
            depth = trackBar_Depth.Value;//толщина пера
            penPolygon = new Pen(col, depth);

            for (int i = 0; i < amountTop; i++)
            {
                if (i == amountTop - 1)
                {
                    gr.DrawLine(penPolygon, arrayX[i], arrayY[i], arrayX[0], arrayY[0]);
                }
                else
                {
                    gr.DrawLine(penPolygon, arrayX[i], arrayY[i], arrayX[i+1], arrayY[i+1]);//Как нарисовать вершины ???
                }
            }
            pictureBox_Polygon.Image = buf;
        }

        private void checkBox_Rotate_CheckedChanged(object sender, EventArgs e)
        {
            centerX = pictureBox_Polygon.Width / 2;
            centerY = pictureBox_Polygon.Height / 2;
            amountTop = (int)numericUpDown_AmountTop.Value;//Количество вершин
            cornerA = Math.Round(2 * Math.PI / amountTop, 2);//Угол А в радианах
            radius = trackBar_Radius.Value;//Радиус
            arrayX = new int[amountTop]; arrayY = new int[amountTop];
            int k = 0;

            if (checkBox_Rotate.Checked == true)
            {
                //gr.Clear(Color.White);
                Matrix matrix = new Matrix();
                int width = 0, height = 0;
                //gr.TranslateTransform(-30.0f, -30.0f);
                gr.TranslateTransform(width+centerX, height+centerY);
                gr = Graphics.FromImage(buf);
                //matrix
                gr.RotateTransform(30.0f);
                pictureBox_Polygon.Image = buf;

                //    for (int i = 0; i < amountTop; i++)
                //    {
                //        //Array.Resize(ref arrayX, arrayX.Length + 1);
                //        //Array.Resize(ref arrayY, arrayY.Length + 1);
                //        if (k == 0)
                //        {
                //            arrayX[i] = (int)(centerX + (radius * Math.Sin(cornerA * i)));//на i умножать не правильно, т.к.
                //            arrayY[i] = Convert.ToInt32(centerY - (radius * Math.Cos(cornerA * i)));//может быть больше радиуса (я так думаю)
                //        }
                //        if (k == 1)
                //        {
                //            arrayX[i] = (int)(centerX + (radius * Math.Cos(cornerA * i)));//на i умножать не правильно, т.к.
                //            arrayY[i] = Convert.ToInt32(centerY + (radius * Math.Sin(cornerA * i)));//может быть больше радиуса (я так думаю)
                //        }
                //    }
                //    k = (k == 0) ? 1 : 0;
                //    col = pictureBox_Mono.BackColor;//цвет
                //    depth = trackBar_Depth.Value;//толщина пера
                //    penPolygon = new Pen(col, depth);
                //    for (int i = 0; i < amountTop; i++)
                //    {
                //        if (i == amountTop - 1)
                //        {
                //            gr.DrawLine(penPolygon, arrayX[i], arrayY[i], arrayX[0], arrayY[0]);
                //        }
                //        else
                //        {
                //            gr.DrawLine(penPolygon, arrayX[i], arrayY[i], arrayX[i + 1], arrayY[i + 1]);//Как нарисовать вершины ???
                //        }
                //    }

            }
            //    if (checkBox_Rotate.Checked == false)
            //        return; // break;
            //    Thread.Sleep((int)this.numericUpDown_Rotate.Value);
        }

        private void checkBox_ConnectTop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ConnectTop.Checked == true)
            {
                if (amountTop > 3)
                {
                    int k = 0;
                    for (int i = 0; i < amountTop; i++)
                    {
                        k = i + 2;
                        for (int j = 0; j < amountTop - 3; j++)
                        {
                            if (k >= amountTop) { k = 0; }
                            gr.DrawLine(penPolygon, arrayX[i], arrayY[i], arrayX[k], arrayY[k]);
                            k++;
                        }
                    }
                }
            }
            if(checkBox_ConnectTop.Checked == false)
            {
                col = pictureBox_Polygon.BackColor;//цвет
                penPolygon = new Pen(col, depth);
                if (amountTop > 3)
                {
                    int k = 0;
                    for (int i = 0; i < amountTop; i++)
                    {
                        k = i + 2;
                        for (int j = 0; j < amountTop - 3; j++)
                        {
                            if (k >= amountTop) { k = 0; }
                            gr.DrawLine(penPolygon, arrayX[i], arrayY[i], arrayX[k], arrayY[k]);
                            k++;
                        }
                    }
                }
                col = pictureBox_Mono.BackColor;//цвет
                int oldDepth = depth;
                penPolygon = new Pen(col, oldDepth);
                for (int i = 0; i < amountTop; i++)
                {
                    if (i == amountTop - 1)
                    {
                        gr.DrawLine(penPolygon, arrayX[i], arrayY[i], arrayX[0], arrayY[0]);
                    }
                    else
                    {
                        gr.DrawLine(penPolygon, arrayX[i], arrayY[i], arrayX[i + 1], arrayY[i + 1]);//Как нарисовать вершины ???
                    }
                }
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            //Graphics gr = this.pictureBox_Polygon.CreateGraphics();
            gr.Clear(Color.White);
            pictureBox_Polygon.Image = buf;
            //gr.DrawImage(Color.White);
        }
    }
}