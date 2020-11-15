using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace gts3
{

    public partial class Form13 : Form
    {
        public float L, Hpl, H1, m1, m2, b, z;
        public float x1, x2, x3, x4, x5, x6;
        public float y1, y2, y3, y4, y5, y6;


        public Form13()
        {
            InitializeComponent();
        }

        
                    

        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

 




            float M_x = 0; float M_y = 0; int n, stepM = 0; double p1 = 0, p2; float Ln = 0;
            float Nlev = (Hpl * m2 + b + Hpl * m1 - L) / 3; //расстояние от O_x_pix до левого конца графика
            float dl = Nlev + L;
            string msg;

            while (dl * M_x +50+30+30< pictureBox1.Width)
                {
                    M_x += 0.001f;
                    M_y += 0.001f;
                }// подбираем масштаб


            if (L <= 100)
            {
                while (L > Ln)
                {
                    Ln += 50;
                    stepM += 2;
                }
            }


            else
            {
                while (L > Ln)
                {
                    Ln += 50;
                    stepM += 2;
                }
            }
            //подбираем шаг сетки и подписей 



            float O_x_pix =Nlev*M_x+30;
            float O_y_pix = pictureBox1.Height/2+ Hpl/2*M_y;//координаты смещенных осей XY
                     
                       
            float xz = Hpl - (L - Hpl * m2 - b + Nlev) / m1;
            
            
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;//высокое сглаживание

           
            Pen greenPen_x = new Pen(Color.Black , 2);
            PointF point_inc1 = new PointF(O_x_pix -Nlev * M_x, O_y_pix);
            PointF point_end1 = new PointF(O_x_pix + L * M_x+50, O_y_pix);
            g.DrawLine(greenPen_x, point_inc1, point_end1);//рисуем ось x

            
            Font fx = new Font(this.Font, FontStyle.Bold);
            msg = "X";
            g.DrawString(msg, fx, Brushes.Black, O_x_pix + L * M_x + 30, O_y_pix + 15);//подпись названия оси X

                     

            Pen redPen = new Pen(Color.Gray, 1);
            int j_y; float yy_pix;
            for (j_y = 0; j_y <= Hpl * 1.1f; j_y+=stepM/2)
            {
                yy_pix = O_y_pix - j_y * M_y;
                PointF point_inc2 = new PointF(O_x_pix -Nlev * M_x, yy_pix);
                PointF point_end2 = new PointF(O_x_pix + L * M_x + 50, yy_pix);
                g.DrawLine(redPen, point_inc2, point_end2);//рисуем для сетки копии линии x
            }
                            
            

            Pen greenPen_y = new Pen(Color.Black, 2);
            PointF point_inc3 = new PointF(O_x_pix, O_y_pix - Hpl * 1.1f * M_y);
            PointF point_end3 = new PointF(O_x_pix, O_y_pix);
            g.DrawLine(greenPen_y, point_inc3, point_end3);//рисуем ось y

            Font fy = new Font(this.Font, FontStyle.Bold);
            msg = "Y";
            g.DrawString(msg, fy, Brushes.Black, O_x_pix - 15, O_y_pix - 1.1f * Hpl * M_y - 10);//подпись названия оси Y




            Pen redPen_y = new Pen(Color.Gray , 1);
            int j_x; float xx_pix;
            for (j_x = 0; j_x <=  L+50/M_x; j_x += stepM / 2)
            {
                
                xx_pix = j_x * M_x;
                PointF point_inc4 = new PointF(O_x_pix + xx_pix, O_y_pix - Hpl * 1.1f * M_y);
                PointF point_end4 = new PointF(O_x_pix + xx_pix, O_y_pix);
                g.DrawLine(redPen_y, point_inc4, point_end4);// рисуем для сетки копии линии Y вправо
            }

           
                for (n = 0; n <= L + b / 2; n += stepM)
                {
                    p2 = p1 + n;
                    p2 = Math.Round(p2, 2);
                    msg = "" + p2.ToString() + "";
                    g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 8 + n * M_x, O_y_pix + 2);
                }
                //обозначения по оси +x

                Font ft = new Font("",10);
                msg = "Схема к фильтрационному расчету однородной плотины по методу Е.А.Замарина";
                g.DrawString(msg, ft, Brushes.Black, pictureBox1.Width/2- 250, O_y_pix+60);



            for (j_x = 0; j_x <= Nlev; j_x+=stepM/2)
            {
                
                xx_pix = j_x* M_x;
                PointF point_inc5 = new PointF(O_x_pix - xx_pix, O_y_pix - Hpl * 1.1f * M_y);
                PointF point_end5 = new PointF(O_x_pix - xx_pix, O_y_pix);
                g.DrawLine(redPen_y, point_inc5, point_end5);// рисуем для сетки копии линии y влево
            }

            for (n = 0; n <= Nlev; n += stepM)
            {
                p2 = p1 - n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 8 - n * M_x, O_y_pix + 2);
            }
            //обозначения по оси -x


            Pen graphPen = new Pen(Color.Black, 3);
            PointF point1 = new PointF(x1 * M_x + O_x_pix, O_y_pix - y1 * M_y);
            PointF point2 = new PointF(x2 * M_x + O_x_pix, O_y_pix - y2 * M_y);
            PointF point3 = new PointF(x3 * M_x + O_x_pix, O_y_pix - y3 * M_y);
            PointF point4 = new PointF(x4 * M_x + O_x_pix, O_y_pix - y4 * M_y);
            PointF point5 = new PointF(x5 * M_x + O_x_pix, O_y_pix - y5 * M_y);
            PointF point6 = new PointF(x6 * M_x + O_x_pix, O_y_pix - y6 * M_y);
            PointF[] myCurvePoints = { point1, point2, point3, point4, point5, point6 };
            g.DrawCurve(graphPen, myCurvePoints);//рисуем кривую

            Pen waterPen = new Pen(Color.Black, 3);
            PointF wp1 = new PointF(O_x_pix -Nlev * M_x, O_y_pix - H1 * M_y);
            PointF wp2 = new PointF(O_x_pix + (L - Hpl * m2 - b - Hpl * m1 + H1 * m1) * M_x, O_y_pix - H1 * M_y);
            g.DrawLine(waterPen, wp1, wp2);//линия воды при H1

            Pen water2Pen = new Pen(Color.Black, 3);
            PointF w2p1 = new PointF(O_x_pix + (L - Hpl * m2 - b - Hpl * m1 + H1 * m1) * M_x, O_y_pix - H1 * M_y);
            PointF w2p2 = new PointF(x1 * M_x + O_x_pix, O_y_pix - y1 * M_y);
            g.DrawLine(water2Pen, w2p1, w2p2);//кусочек от линии при H1 до кривой

            Pen plotPen = new Pen(Color.Black, 3);
            PointF ppl1 = new PointF(O_x_pix + L * M_x, O_y_pix);
            PointF ppl2 = new PointF(O_x_pix + L * M_x - Hpl * m2 * M_x, O_y_pix - Hpl * M_y);
            PointF ppl3 = new PointF(O_x_pix + L * M_x - Hpl * m2 * M_x - b * M_x, O_y_pix - Hpl * M_y);
            PointF ppl4 = new PointF(O_x_pix -Nlev* M_x, O_y_pix-xz*M_y);
            PointF[] myPlotPoints = { ppl1, ppl2, ppl3, ppl4 };
            g.DrawLines(plotPen, myPlotPoints);//рисуем плотину       


            
            for (n = stepM; n <= Hpl; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 20, O_y_pix - 8 - n * M_y);
            }
            //обозначения по оси y


            Pen otmPen = new Pen(Color.Black, 1);
            PointF ot1p1 = new PointF(O_x_pix- Nlev*2/3*M_x ,O_y_pix);
            PointF ot1p2 = new PointF(O_x_pix- Nlev*2/3*M_x ,O_y_pix-20);
            PointF ot1p3 = new PointF(O_x_pix- Nlev*2/3*M_x +40,O_y_pix-20);
            PointF ot1p4 = new PointF(O_x_pix- Nlev*2/3*M_x-8 ,O_y_pix-8);
            PointF ot1p5 = new PointF(O_x_pix- Nlev*2/3*M_x+8 ,O_y_pix-8);
            g.DrawLine(otmPen, ot1p1,ot1p2);
            g.DrawLine(otmPen, ot1p2, ot1p3);
            g.DrawLine(otmPen, ot1p1, ot1p4);
            g.DrawLine(otmPen, ot1p1, ot1p5);            
            msg = z.ToString();
            g.DrawString(msg,this.Font, Brushes.Black,O_x_pix- Nlev*2/3*M_x, O_y_pix-35 );//отметка дна



            float xz2 = (L - Hpl * m2 - b - Hpl * m1 + H1 * m1)/3 * M_x;

            PointF ot2p1 = new PointF(O_x_pix + xz2, O_y_pix - H1 * M_y);
            PointF ot2p2 = new PointF(O_x_pix + xz2, O_y_pix - H1 * M_y-20);
            PointF ot2p3 = new PointF(O_x_pix + xz2+40, O_y_pix - H1 * M_y-20);
            PointF ot2p4 = new PointF(O_x_pix + xz2-8, O_y_pix - H1 * M_y-8);
            PointF ot2p5 = new PointF(O_x_pix + xz2+8, O_y_pix - H1 * M_y-8);
            g.DrawLine(otmPen, ot2p1, ot2p2);
            g.DrawLine(otmPen, ot2p2, ot2p3);
            g.DrawLine(otmPen, ot2p1, ot2p4);
            g.DrawLine(otmPen, ot2p1, ot2p5);
            msg = (z + H1).ToString();
            g.DrawString(msg,this.Font, Brushes.Black,O_x_pix + xz2, O_y_pix - H1 * M_y-35 );//отметка при H1

            
            float xz3 = (L - Hpl * m2 - b/3) * M_x;

            PointF ot3p1 = new PointF(O_x_pix+xz3, O_y_pix-Hpl* M_y);
            PointF ot3p2 = new PointF(O_x_pix+xz3, O_y_pix-Hpl* M_y-20);
            PointF ot3p3 = new PointF(O_x_pix+xz3+40, O_y_pix-Hpl* M_y-20);
            PointF ot3p4 = new PointF(O_x_pix+xz3-8, O_y_pix-Hpl* M_y-8);
            PointF ot3p5 = new PointF(O_x_pix+xz3+8, O_y_pix-Hpl* M_y-8);
            g.DrawLine(otmPen, ot3p1, ot3p2);
            g.DrawLine(otmPen, ot3p2, ot3p3);
            g.DrawLine(otmPen, ot3p1, ot3p4);
            g.DrawLine(otmPen, ot3p1, ot3p5);
            msg = (z + Hpl).ToString();
            g.DrawString(msg,this.Font, Brushes.Black,O_x_pix+xz3, O_y_pix-Hpl* M_y-35 );//отметка при Hpl
            
        }



        public void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // сюда копируем все из блока рисования!!!!!!!!!!!!!!!!!!!!!!!!

            





            int xi = e.MarginBounds.Left;
            int yi = e.MarginBounds.Top;  

           

            float M_x = 0; float M_y = 0; int n, stepM = 0; double p1 = 0, p2; float Ln = 0;
            float Nlev = (Hpl * m2 + b + Hpl * m1 - L) / 3; //расстояние от O_x_pix до левого конца графика
            float dl = Nlev + L;
            string msg;

            while (dl * M_x + 50 + 30 + 30 < pictureBox1.Width)
            {
                M_x += 0.001f;
                M_y += 0.001f;
            }// подбираем масштаб


            if (L <= 100)
            {
                while (L > Ln)
                {
                    Ln += 50;
                    stepM += 2;
                }
            }


            else
            {
                while (L > Ln)
                {
                    Ln += 50;
                    stepM += 2;
                }
            }
            //подбираем шаг сетки и подписей 



            float O_x_pix = xi + Nlev * M_x + 30;
            float O_y_pix = yi+ pictureBox1.Height / 2 + Hpl / 2 * M_y;//координаты смещенных осей XY


            float xz = Hpl - (L - Hpl * m2 - b + Nlev) / m1;


            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;//высокое сглаживание


            Pen greenPen_x = new Pen(Color.Black, 2);
            PointF point_inc1 = new PointF(O_x_pix - Nlev * M_x, O_y_pix);
            PointF point_end1 = new PointF(O_x_pix + L * M_x + 50, O_y_pix);
            g.DrawLine(greenPen_x, point_inc1, point_end1);//рисуем ось x


            Font fx = new Font(this.Font, FontStyle.Bold);
            msg = "X";
            g.DrawString(msg, fx, Brushes.Black, O_x_pix + L * M_x + 30, O_y_pix + 15);//подпись названия оси X



            Pen redPen = new Pen(Color.Gray, 1);
            int j_y; float yy_pix;
            for (j_y = 0; j_y <= Hpl * 1.1f; j_y += stepM / 2)
            {
                yy_pix = O_y_pix - j_y * M_y;
                PointF point_inc2 = new PointF(O_x_pix - Nlev * M_x, yy_pix);
                PointF point_end2 = new PointF(O_x_pix + L * M_x + 50, yy_pix);
                g.DrawLine(redPen, point_inc2, point_end2);//рисуем для сетки копии линии x
            }



            Pen greenPen_y = new Pen(Color.Black, 2);
            PointF point_inc3 = new PointF(O_x_pix, O_y_pix - Hpl * 1.1f * M_y);
            PointF point_end3 = new PointF(O_x_pix, O_y_pix);
            g.DrawLine(greenPen_y, point_inc3, point_end3);//рисуем ось y

            Font fy = new Font(this.Font, FontStyle.Bold);
            msg = "Y";
            g.DrawString(msg, fy, Brushes.Black, O_x_pix - 15, O_y_pix - 1.1f * Hpl * M_y - 10);//подпись названия оси Y




            Pen redPen_y = new Pen(Color.Gray, 1);
            int j_x; float xx_pix;
            for (j_x = 0; j_x <= L + 50 / M_x; j_x += stepM / 2)
            {

                xx_pix = j_x * M_x;
                PointF point_inc4 = new PointF(O_x_pix + xx_pix, O_y_pix - Hpl * 1.1f * M_y);
                PointF point_end4 = new PointF(O_x_pix + xx_pix, O_y_pix);
                g.DrawLine(redPen_y, point_inc4, point_end4);// рисуем для сетки копии линии Y вправо
            }


            for (n = 0; n <= L + b / 2; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 8 + n * M_x, O_y_pix + 2);
            }
            //обозначения по оси +x

            Font ft = new Font("", 10);
            msg = "Схема к фильтрационному расчету однородной плотины по методу Е.А.Замарина";
            g.DrawString(msg, ft, Brushes.Black, pictureBox1.Width / 2 - 250, O_y_pix + 60);



            for (j_x = 0; j_x <= Nlev; j_x += stepM / 2)
            {

                xx_pix = j_x * M_x;
                PointF point_inc5 = new PointF(O_x_pix - xx_pix, O_y_pix - Hpl * 1.1f * M_y);
                PointF point_end5 = new PointF(O_x_pix - xx_pix, O_y_pix);
                g.DrawLine(redPen_y, point_inc5, point_end5);// рисуем для сетки копии линии y влево
            }

            for (n = 0; n <= Nlev; n += stepM)
            {
                p2 = p1 - n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 8 - n * M_x, O_y_pix + 2);
            }
            //обозначения по оси -x


            Pen graphPen = new Pen(Color.Black, 3);
            PointF point1 = new PointF(x1 * M_x + O_x_pix, O_y_pix - y1 * M_y);
            PointF point2 = new PointF(x2 * M_x + O_x_pix, O_y_pix - y2 * M_y);
            PointF point3 = new PointF(x3 * M_x + O_x_pix, O_y_pix - y3 * M_y);
            PointF point4 = new PointF(x4 * M_x + O_x_pix, O_y_pix - y4 * M_y);
            PointF point5 = new PointF(x5 * M_x + O_x_pix, O_y_pix - y5 * M_y);
            PointF point6 = new PointF(x6 * M_x + O_x_pix, O_y_pix - y6 * M_y);
            PointF[] myCurvePoints = { point1, point2, point3, point4, point5, point6 };
            g.DrawCurve(graphPen, myCurvePoints);//рисуем кривую

            Pen waterPen = new Pen(Color.Black, 3);
            PointF wp1 = new PointF(O_x_pix - Nlev * M_x, O_y_pix - H1 * M_y);
            PointF wp2 = new PointF(O_x_pix + (L - Hpl * m2 - b - Hpl * m1 + H1 * m1) * M_x, O_y_pix - H1 * M_y);
            g.DrawLine(waterPen, wp1, wp2);//линия воды при H1

            Pen water2Pen = new Pen(Color.Black, 3);
            PointF w2p1 = new PointF(O_x_pix + (L - Hpl * m2 - b - Hpl * m1 + H1 * m1) * M_x, O_y_pix - H1 * M_y);
            PointF w2p2 = new PointF(x1 * M_x + O_x_pix, O_y_pix - y1 * M_y);
            g.DrawLine(water2Pen, w2p1, w2p2);//кусочек от линии при H1 до кривой

            Pen plotPen = new Pen(Color.Black, 3);
            PointF ppl1 = new PointF(O_x_pix + L * M_x, O_y_pix);
            PointF ppl2 = new PointF(O_x_pix + L * M_x - Hpl * m2 * M_x, O_y_pix - Hpl * M_y);
            PointF ppl3 = new PointF(O_x_pix + L * M_x - Hpl * m2 * M_x - b * M_x, O_y_pix - Hpl * M_y);
            PointF ppl4 = new PointF(O_x_pix - Nlev * M_x, O_y_pix - xz * M_y);
            PointF[] myPlotPoints = { ppl1, ppl2, ppl3, ppl4 };
            g.DrawLines(plotPen, myPlotPoints);//рисуем плотину       



            for (n = stepM; n <= Hpl; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 20, O_y_pix - 8 - n * M_y);
            }
            //обозначения по оси y


            Pen otmPen = new Pen(Color.Black, 1);
            PointF ot1p1 = new PointF(O_x_pix - Nlev * 2 / 3 * M_x, O_y_pix);
            PointF ot1p2 = new PointF(O_x_pix - Nlev * 2 / 3 * M_x, O_y_pix - 20);
            PointF ot1p3 = new PointF(O_x_pix - Nlev * 2 / 3 * M_x + 40, O_y_pix - 20);
            PointF ot1p4 = new PointF(O_x_pix - Nlev * 2 / 3 * M_x - 8, O_y_pix - 8);
            PointF ot1p5 = new PointF(O_x_pix - Nlev * 2 / 3 * M_x + 8, O_y_pix - 8);
            g.DrawLine(otmPen, ot1p1, ot1p2);
            g.DrawLine(otmPen, ot1p2, ot1p3);
            g.DrawLine(otmPen, ot1p1, ot1p4);
            g.DrawLine(otmPen, ot1p1, ot1p5);
            msg = z.ToString();
            g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - Nlev * 2 / 3 * M_x, O_y_pix - 35);//отметка дна



            float xz2 = (L - Hpl * m2 - b - Hpl * m1 + H1 * m1) / 3 * M_x;

            PointF ot2p1 = new PointF(O_x_pix + xz2, O_y_pix - H1 * M_y);
            PointF ot2p2 = new PointF(O_x_pix + xz2, O_y_pix - H1 * M_y - 20);
            PointF ot2p3 = new PointF(O_x_pix + xz2 + 40, O_y_pix - H1 * M_y - 20);
            PointF ot2p4 = new PointF(O_x_pix + xz2 - 8, O_y_pix - H1 * M_y - 8);
            PointF ot2p5 = new PointF(O_x_pix + xz2 + 8, O_y_pix - H1 * M_y - 8);
            g.DrawLine(otmPen, ot2p1, ot2p2);
            g.DrawLine(otmPen, ot2p2, ot2p3);
            g.DrawLine(otmPen, ot2p1, ot2p4);
            g.DrawLine(otmPen, ot2p1, ot2p5);
            msg = (z + H1).ToString();
            g.DrawString(msg, this.Font, Brushes.Black, O_x_pix + xz2, O_y_pix - H1 * M_y - 35);//отметка при H1


            float xz3 = (L - Hpl * m2 - b / 3) * M_x;

            PointF ot3p1 = new PointF(O_x_pix + xz3, O_y_pix - Hpl * M_y);
            PointF ot3p2 = new PointF(O_x_pix + xz3, O_y_pix - Hpl * M_y - 20);
            PointF ot3p3 = new PointF(O_x_pix + xz3 + 40, O_y_pix - Hpl * M_y - 20);
            PointF ot3p4 = new PointF(O_x_pix + xz3 - 8, O_y_pix - Hpl * M_y - 8);
            PointF ot3p5 = new PointF(O_x_pix + xz3 + 8, O_y_pix - Hpl * M_y - 8);
            g.DrawLine(otmPen, ot3p1, ot3p2);
            g.DrawLine(otmPen, ot3p2, ot3p3);
            g.DrawLine(otmPen, ot3p1, ot3p4);
            g.DrawLine(otmPen, ot3p1, ot3p5);
            msg = (z + Hpl).ToString();
            g.DrawString(msg, this.Font, Brushes.Black, O_x_pix + xz3, O_y_pix - Hpl * M_y - 35);//отметка при Hpl
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
            }
            catch
            {
                MessageBox.Show("Принтер не доступен");
            }
        }

        public void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                Rectangle r = pictureBox1.RectangleToScreen(pictureBox1.ClientRectangle);
                Bitmap bitmap2 = new Bitmap(r.Width, r.Height);
                Graphics d = Graphics.FromImage(bitmap2);
                d.CopyFromScreen(r.Location, new Point(0, 0), r.Size);
            
            
            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
               string fileName = dlgSaveFile.FileName;
                bitmap2.Save(fileName);
            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            dlgPageSetup.ShowDialog();
            
           
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                printPreviewDialog1.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Принтер не доступен");
            }
        }




    }
           
}
