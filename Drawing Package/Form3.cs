﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_Package
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void drawAxis()
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            for (int i = 0; i < 600; i++)
            { //x axis drawing
                g.FillRectangle(aBrush, i, 222, 1, 1);
            }
            for (int j = 0; j < 450; j++)
            {//y axis drawing
                g.FillRectangle(aBrush, 292, j, 1, 1);
            }
        }
        private void ddaPlotPoints(float x, float y, Brush color )
        {
            //  var aBrush = Brushes.Black;
            var aBrush = color;
            var g = panel1.CreateGraphics();

            g.FillRectangle(aBrush, 292 + x, 222 - y, 2, 2);
        }
        void lineDDA(int x0, int y0, int xEnd, int yEnd , Brush color )
        {
            int dx = xEnd - x0, dy = yEnd - y0, steps, k;
            float xIncrement, yIncrement, x = x0, y = y0;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            xIncrement = (float)dx / (float)steps;
            yIncrement = (float)dy / (float)steps;

            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;

                try
                {
                    ddaPlotPoints(x, y , color);
                }
                catch (InvalidOperationException)

                {
                    return;
                }

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);

            panel1.Controls.Clear();
            this.Refresh();
            drawAxis();
            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4 , Brushes.Black);


        }
        private void DrawRectangle(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4 , Brush color )
        {
            lineDDA(x1, y1, x2, y2 , color);
            lineDDA(x2, y2, x3, y3 , color);
            lineDDA(x4, y4, x3, y3, color);
            lineDDA(x1, y1, x4, y4, color);
        }

        //Translate

        private void Translate(ref int X, ref int Y, ref int X_Translation, ref int Y_Translation)
        {
            int[,] transArray = { { 1, 0, X_Translation }, { 0, 1, Y_Translation }, { 0, 0, 1 } };

            int[,] point1 = { { X }, { Y }, { 1 } };
            int[,] Result = new int[1, 3];
            for (int i = 0; i < transArray.GetLength(0); i++)
            {
                for (int j = 0; j < transArray.GetLength(1); j++)
                {
                    Result[0, i] += transArray[i, j] * point1[j, 0];
                }

            }
            X = Result[0, 0];
            Y = Result[0, 1];
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);

            int xTrans = Convert.ToInt32(textBox24.Text);
            int yTrans = Convert.ToInt32(textBox25.Text);

            Translate(ref x1, ref y1, ref xTrans, ref yTrans);
            Translate(ref x2, ref y2, ref xTrans, ref yTrans);
            Translate(ref x3, ref y3, ref xTrans, ref yTrans);
            Translate(ref x4, ref y4, ref xTrans, ref yTrans);

            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4 , Brushes.Red);
        }


        //scaling
        private void Scale(ref int X, ref int Y, ref int X_Scale, ref int Y_Scale)
        {
            int[,] scallArray = { { X_Scale, 0, 0 }, { 0, Y_Scale, 0 }, { 0, 0, 1 } };

            int[,] point1 = { { X, 0, 0 }, { 0, Y, 0 }, { 0, 0, 1 } };
            int[,] Result = new int[3, 3];
            for (int i = 0; i < scallArray.GetLength(0); i++)
            {
                for (int j = 0; j < scallArray.GetLength(1); j++)
                {
                    Result[i, j] = scallArray[i, j] * point1[i, j];
                }

            }
            X = Result[0, 0];
            Y = Result[1, 1];
        }
        private void button7_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);
            int xScale = Convert.ToInt32(textBox24.Text);
            int yScale = Convert.ToInt32(textBox25.Text);

            Scale(ref x1, ref y1, ref xScale, ref yScale);
            Scale(ref x2, ref y2, ref xScale, ref yScale);
            Scale(ref x3, ref y3, ref xScale, ref yScale);
            Scale(ref x4, ref y4, ref xScale, ref yScale);

            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4, Brushes.Red);

        }

        //rotation 

        private double cosine(double Angel)
        {
            // return Math.Cos(angle * (Math.PI / 180)) * 1000 / 1000;
            double angel = Convert.ToInt32(Math.Cos(Math.PI * Angel / 180) * 100);
            angel = Convert.ToDouble(angel / 100);
            return angel;

        }
        private double sine(double Angel)
        {
            double theta = Math.Sin(Angel / 180 * Math.PI);
            return theta;
        }
        private void Rotate(ref int X, ref int Y, ref double Angle)
        {

            double sin, cos;
            sin = sine(Angle);
            cos = cosine(Angle);
            double[,] RotateArray = { { cos, -sin, 0 }, { sin, cos, 0 }, { 0, 0, 1 } };

            double[,] point1 = { { X }, { Y }, { 1 } };
            double[,] Result = new double[1, 3];
            for (int i = 0; i < RotateArray.GetLength(0); i++)
            {
                for (int j = 0; j < RotateArray.GetLength(1); j++)
                {
                    Result[0, i] += RotateArray[i, j] * point1[j, 0];
                }

            }

            X = Convert.ToInt32(Math.Round(Result[0, 0]));
            Y = Convert.ToInt32(Math.Round(Result[0, 1]));
        }
        private void button8_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);


            double Theta = Convert.ToDouble(textBox26.Text);


            Rotate(ref x1, ref y1, ref Theta);
            Rotate(ref x2, ref y2, ref Theta);
            Rotate(ref x3, ref y3, ref Theta);
            Rotate(ref x4, ref y4, ref Theta);

            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4, Brushes.Purple);


        }

        //sheering x

        private void ShearX(ref int X, ref int Y, ref int X_Shearing)
        {
            int[,] SheareXArray = { { 1, X_Shearing }, { 0, 1 } };

            int[,] point1 = { { X }, { Y } };
            int[,] Result = new int[1, 3];
            for (int i = 0; i < SheareXArray.GetLength(0); i++)
            {
                for (int j = 0; j < SheareXArray.GetLength(1); j++)
                {
                    Result[0, i] += SheareXArray[i, j] * point1[j, 0];
                }

            }
            X = Result[0, 0];
            Y = Result[0, 1];
        }
        private void button9_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);

            int shx = Convert.ToInt32(textBox27.Text);

            ShearX(ref x1, ref y1, ref shx);
            ShearX(ref x2, ref y2, ref shx);
            ShearX(ref x3, ref y3, ref shx);
            ShearX(ref x4, ref y4, ref shx);

            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4, Brushes.Yellow);

        }
        //sheering y
        private void ShearY(ref int X, ref int Y, ref int Y_Shearing)
        {
            int[,] SheareXArray = { { 1, 0 }, { Y_Shearing, 1 } };

            int[,] point1 = { { X }, { Y } };
            int[,] Result = new int[1, 3];
            for (int i = 0; i < SheareXArray.GetLength(0); i++)
            {
                for (int j = 0; j < SheareXArray.GetLength(1); j++)
                {
                    Result[0, i] += SheareXArray[i, j] * point1[j, 0];
                }

            }
            X = Result[0, 0];
            Y = Result[0, 1];
        }
        private void button10_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);

            int shy = Convert.ToInt32(textBox27.Text);

            ShearY(ref x1, ref y1, ref shy);
            ShearY(ref x2, ref y2, ref shy);
            ShearY(ref x3, ref y3, ref shy);
            ShearY(ref x4, ref y4, ref shy);

            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4, Brushes.Yellow);

        }
        //refliction x
        private void ReflectOverX(ref int X, ref int Y)
        {
            int[,] OverXArray = { { 1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } };

            int[,] point1 = { { X }, { Y }, { 1 } };
            int[,] Result = new int[1, 3];
            for (int i = 0; i < OverXArray.GetLength(0); i++)
            {
                for (int j = 0; j < OverXArray.GetLength(1); j++)
                {
                    Result[0, i] += OverXArray[i, j] * point1[j, 0];
                }

            }
            X = Result[0, 0];
            Y = Result[0, 1];
        }
        private void button11_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);

            ReflectOverX(ref x1, ref y1);
            ReflectOverX(ref x2, ref y2);
            ReflectOverX(ref x3, ref y3);
            ReflectOverX(ref x4, ref y4);

            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4, Brushes.Red);




        }

        //refliction y
        private void ReflectOverY(ref int X, ref int Y)
        {
            int[,] OverYArray = { { -1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

            int[,] point1 = { { X }, { Y }, { 1 } };
            int[,] Result = new int[1, 3];
            for (int i = 0; i < OverYArray.GetLength(0); i++)
            {
                for (int j = 0; j < OverYArray.GetLength(1); j++)
                {
                    Result[0, i] += OverYArray[i, j] * point1[j, 0];
                }

            }
            X = Result[0, 0];
            Y = Result[0, 1];
        }
        private void button12_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);

            ReflectOverY(ref x1, ref y1);
            ReflectOverY(ref x2, ref y2);
            ReflectOverY(ref x3, ref y3);
            ReflectOverY(ref x4, ref y4);

            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4, Brushes.Red);

        }


        //refliction 

        private void ReflectOverOrigin(ref int X, ref int Y)
        {
            int[,] OverOriginArray = { { -1, 0, 0 }, { 0, -1, 0 }, { 0, 0, 1 } };

            int[,] point1 = { { X }, { Y }, { 1 } };
            int[,] Result = new int[1, 3];
            for (int i = 0; i < OverOriginArray.GetLength(0); i++)
            {
                for (int j = 0; j < OverOriginArray.GetLength(1); j++)
                {
                    Result[0, i] += OverOriginArray[i, j] * point1[j, 0];
                }

            }
            X = Result[0, 0];
            Y = Result[0, 1];
        }
        private void button13_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox23.Text);
            int x2 = Convert.ToInt32(textBox22.Text);
            int y2 = Convert.ToInt32(textBox21.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox19.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox17.Text);


            ReflectOverOrigin(ref x1, ref y1);
            ReflectOverOrigin(ref x2, ref y2);
            ReflectOverOrigin(ref x3, ref y3);
            ReflectOverOrigin(ref x4, ref y4);

            DrawRectangle(x1, y1, x2, y2, x3, y3, x4, y4, Brushes.Red);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ClearDrawingPanel_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            this.Refresh();
        }
    }
}
