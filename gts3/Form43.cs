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

    public partial class Form43 : Form
    {


        public Form43()
        {
            InitializeComponent();
        }

        public float L1, L2, Ldr, NPU, H, T1, T2, T3, S1, S2, S3; 
        public float hx1, hx2, hx3, hx4, hx5;        
        public float y1, y2, y3, y4, y5, y6;
        
               

        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            float M_x = 0; float M_y = 0; int n, stepM = 0; double p1 = 0, p2;float Ln=0;            
            float dl = 2 + L1 + L2 + Ldr+2;
            float UNB = NPU - H;
            float vys = NPU + T1 + 2;
            float vys2 = H + 1 + UNB + T1 - T3 + 1 + 2+5;

            string msg;


            while (dl * M_x +90< pictureBox1.Width)
                {
                    M_x += 0.001f;
                    M_y += 0.001f;
                }// подбираем масштаб по длине

            
              while (vys* M_y+40+40 + vys2 * M_y+40+60 > pictureBox1.Height)
            {
                    M_x -= 0.001f;
                    M_y -= 0.001f;
               
            }//подбор масштаба по высоте
            

           

            if (dl <= 25)
            {
                while (dl > Ln)
                {
                    Ln += 50;
                    stepM += 2;
                }
            }


            else
            {
                while (dl > Ln)
                {
                    Ln += 25;
                    stepM += 2;
                }
            }
             //подбираем шаг сетки и подписей 
            
                                                    

            float O_x_pix =50;
            float O_y_pix =vys*M_y+40;//координаты смещенных осей XY
             
            
            
            
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;//высокое сглаживание

           
            Pen greenPen_x = new Pen(Color.Black, 2);
            PointF point_inc1 = new PointF(O_x_pix, O_y_pix);
            PointF point_end1 = new PointF(O_x_pix + dl * M_x, O_y_pix);
            g.DrawLine(greenPen_x, point_inc1, point_end1);//рисуем ось x

            
            Font fx = new Font(this.Font, FontStyle.Bold);
            msg = "X";
            g.DrawString(msg, fx, Brushes.Black, O_x_pix + (dl-2) * M_x, O_y_pix + 15);//подпись названия оси X



            Pen redPen = new Pen(Color.Gray,1);
            int j_y; float yy_pix;
            for (j_y = 0; j_y <= vys; j_y+=stepM/2)
            {
                yy_pix = O_y_pix - j_y * M_y;
                PointF point_inc2 = new PointF(O_x_pix, yy_pix);
                PointF point_end2 = new PointF(O_x_pix + dl * M_x, yy_pix);
                g.DrawLine(redPen, point_inc2, point_end2);//рисуем для сетки копии линии x
            }



            Pen greenPen_y = new Pen(Color.Black, 2);
            PointF point_inc3 = new PointF(O_x_pix, O_y_pix - vys * M_y);
            PointF point_end3 = new PointF(O_x_pix, O_y_pix);
            g.DrawLine(greenPen_y, point_inc3, point_end3);//рисуем ось y

            Font fy = new Font(this.Font, FontStyle.Bold);
            msg = "Y";
            g.DrawString(msg, fy, Brushes.Black, O_x_pix - 15, O_y_pix - vys * M_y - 20);//подпись названия оси Y




            Pen redPen_y = new Pen(Color.Gray , 1);
            int j_x; float xx_pix;
            for (j_x = 0; j_x <= dl; j_x += stepM / 2)
            {
                
                xx_pix = j_x * M_x;
                PointF point_inc4 = new PointF(O_x_pix + xx_pix, O_y_pix - vys * M_y);
                PointF point_end4 = new PointF(O_x_pix + xx_pix, O_y_pix);
                g.DrawLine(redPen_y, point_inc4, point_end4);// рисуем для сетки копии линии y вправо
            }

           
               

                Font ft = new Font("",10);
                msg = "Фильтрационный расчет методом коэффициентов сопротивления";
                g.DrawString(msg, ft, Brushes.Black, O_x_pix+ pictureBox1.Width/2-270, O_y_pix+27);



            Pen osnPen = new Pen(Color.Black, 2);

            PointF osn1 = new PointF(O_x_pix, O_y_pix - T1 * M_y);
            PointF osn2 = new PointF(O_x_pix + 2 * M_x, O_y_pix - T1 * M_y);
            PointF osn3 = new PointF(O_x_pix + (2+L1 + L2) * M_x, O_y_pix - T1 * M_y);
            PointF osn4 = new PointF(O_x_pix + (2+L1+L2+Ldr) * M_x, O_y_pix - T1 * M_y);
            PointF osn5 = new PointF(O_x_pix + (2+L1+L2+Ldr) * M_x, O_y_pix - (T1-0.5f) * M_y);
            PointF osn6 = new PointF(O_x_pix + (2+L1 + L2) * M_x, O_y_pix - (T1-0.5f)* M_y);
            PointF [] blok1 = {osn1, osn2, osn3, osn4, osn5, osn6};
            g.DrawLines(osnPen, blok1);

            
            PointF osn7 = new PointF(O_x_pix + (2+L1 + L2) * M_x, O_y_pix - T3 * M_y);
            PointF osn8 = new PointF(O_x_pix + (2+L1) * M_x, O_y_pix - T3 * M_y);
            PointF osn8_2 = new PointF(O_x_pix + (2+L1) * M_x, O_y_pix - T1 * M_y);
            PointF [] blok2 = {osn3, osn7, osn8, osn8_2};
            g.DrawLines(osnPen, blok2);

            PointF osn9 = new PointF(O_x_pix + (2+L1) * M_x, O_y_pix - T2 * M_y);
            PointF osn10 = new PointF(O_x_pix + 2 * M_x, O_y_pix - T2 * M_y);
            PointF osn11 = new PointF(O_x_pix + 2 * M_x, O_y_pix - T1 * M_y);
            PointF [] blok3 = { osn8, osn9, osn10, osn11 };
            g.DrawLines(osnPen, blok3);

           
            PointF osn15 = new PointF(O_x_pix + (2+L1+L2+Ldr+2) * M_x, O_y_pix - T1 * M_y);
            g.DrawLine(osnPen, osn4, osn15);          
            //рисуем подземный контур


          
            PointF osn12 = new PointF(O_x_pix + 2 * M_x, O_y_pix - (T2 - S1) * M_y);
            g.DrawLine(osnPen, osn10, osn12);//первый шпунт                     
           
            PointF osn13 = new PointF(O_x_pix + (2+L1) * M_x, O_y_pix - (T3-S2) * M_y);
            g.DrawLine(osnPen, osn8, osn13);//второй шпунт

            PointF osn14 = new PointF(O_x_pix + (2+L1 + L2) * M_x, O_y_pix - (T3-S3) * M_y);
            g.DrawLine(osnPen, osn7, osn14);//третий шпунт


            y1 = NPU;
            y2 = NPU - hx1;
            y3 = NPU - hx2;
            y4 = NPU - hx3;
            y5 = NPU - hx4;
            y6 = NPU - hx5;//коорд линии фильтр напора
            

            PointF nap1 = new PointF(O_x_pix, O_y_pix - (T1+NPU)*M_y);
            PointF nap2 = new PointF(O_x_pix + 2 * M_x, O_y_pix - (T1+y1) * M_y);
            PointF nap3 = new PointF(O_x_pix + 2 * M_x, O_y_pix - (T1+y2) * M_y);
            PointF nap4 = new PointF(O_x_pix + (2+L1) * M_x, O_y_pix - (T1+y3) * M_y);
            PointF nap5 = new PointF(O_x_pix + (2+L1) * M_x, O_y_pix - (T1+y4)* M_y);
            PointF nap6 = new PointF(O_x_pix + (2+L1+L2) * M_x, O_y_pix - (T1+y5) * M_y);
            PointF nap7 = new PointF(O_x_pix + (2+L1+L2) * M_x, O_y_pix - (T1+y6) * M_y);
            PointF nap8 = new PointF(O_x_pix + (2+L1+L2+Ldr+2) * M_x, O_y_pix - (T1+y6) * M_y);
            PointF [] Nap = {nap1, nap2, nap3, nap4, nap5, nap6, nap7, nap8};
            g.DrawLines(osnPen, Nap);//рисуем фильтр напор


            Pen VodPen = new Pen(Color.Black, 2);
            PointF vod1 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - T1 * M_y);
            PointF vod2 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - (T1+NPU-H) * M_y);
            PointF vod3 = new PointF(O_x_pix + (2 + L1+0.5f) * M_x, O_y_pix - (T1+NPU-H) * M_y);
            PointF vod4 = new PointF(O_x_pix + (2 + L1+0.5f) * M_x, O_y_pix - T1 * M_y);
            PointF[] Vod = { vod1, vod2, vod3, vod4 };
            g.DrawLines(VodPen, Vod);//рисуем схем водослив




            for (n = 0; n <= dl; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 8 + n * M_x, O_y_pix + 2);
            }
            //обозначения по оси +x
            
            for (n = stepM; n <= vys; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 20, O_y_pix - 8 - n * M_y);
            }
            //обозначения по оси y


          

            Pen otmPen = new Pen(Color.Black, 1);
            PointF ot1p1 = new PointF(O_x_pix + 1 * M_x , O_y_pix-(T1+NPU)*M_y);
            PointF ot1p2 = new PointF(O_x_pix +1 * M_x , O_y_pix - (T1+NPU)*M_y-20);
            PointF ot1p3 = new PointF(O_x_pix+1 * M_x +40,O_y_pix-(T1+NPU)*M_y-20);
            PointF ot1p4 = new PointF(O_x_pix +1 * M_x- 8, O_y_pix - (T1+NPU)*M_y-8);
            PointF ot1p5 = new PointF(O_x_pix +1* M_x + 8, O_y_pix - (T1+NPU)*M_y-8);
            g.DrawLine(otmPen, ot1p1,ot1p2);
            g.DrawLine(otmPen, ot1p2, ot1p3);
            g.DrawLine(otmPen, ot1p1, ot1p4);
            g.DrawLine(otmPen, ot1p1, ot1p5);            
            msg = "НПУ";
            g.DrawString(msg, this.Font, Brushes.Black, O_x_pix +1* M_x, O_y_pix -(T1+NPU)*M_y-8-25);//отметка НПУ

            
            PointF ot2p1 = new PointF(O_x_pix + (2+L1+L2+2)* M_x , O_y_pix-(T1+y6)*M_y);
            PointF ot2p2 = new PointF(O_x_pix +(2+L1+L2+2)* M_x , O_y_pix - (T1+y6)*M_y-20);
            PointF ot2p3 = new PointF(O_x_pix+(2+L1+L2+2)* M_x +40,O_y_pix-(T1+y6)*M_y-20);
            PointF ot2p4 = new PointF(O_x_pix +(2+L1+L2+2) * M_x- 8, O_y_pix - (T1+y6)*M_y-8);
            PointF ot2p5 = new PointF(O_x_pix +(2+L1+L2+2)* M_x + 8, O_y_pix - (T1+y6)*M_y-8);
            g.DrawLine(otmPen, ot2p1,ot2p2);
            g.DrawLine(otmPen, ot2p2, ot2p3);
            g.DrawLine(otmPen, ot2p1, ot2p4);
            g.DrawLine(otmPen, ot2p1, ot2p5);            
            msg = "УНБ";
            g.DrawString(msg, this.Font, Brushes.Black, O_x_pix +(2+L1+L2+2)* M_x, O_y_pix -(T1+y6)*M_y-8-25);//отметка УНБ



            

            /////////////////////////////////////////////вторая схема//////////           
            

            float O_x2_pix = 50;
            float O_y2_pix = vys* M_y+40+40 + vys2 * M_y+40; //координаты смещенных осей X2Y2

            

            Pen greenPen_x2 = new Pen(Color.Black, 2);
            PointF point_inc1_2 = new PointF(O_x2_pix, O_y2_pix);
            PointF point_end1_2 = new PointF(O_x2_pix + dl * M_x, O_y2_pix);
            g.DrawLine(greenPen_x2, point_inc1_2, point_end1_2);//рисуем ось x2

            
            Font fx2 = new Font(this.Font, FontStyle.Bold);
            msg = "X";
            g.DrawString(msg, fx2, Brushes.Black, O_x2_pix + (dl - 2) * M_x, O_y2_pix + 15);//подпись названия оси X2



            Pen redPen2 = new Pen(Color.Gray, 1);
            int j_y2; float yy_pix2;
            for (j_y2 = 0; j_y2 <= vys2; j_y2 += stepM / 2)
            {
                yy_pix2 = O_y2_pix - j_y2 * M_y;
                PointF point_inc2_2 = new PointF(O_x2_pix, yy_pix2);
                PointF point_end2_2 = new PointF(O_x2_pix + dl * M_x, yy_pix2);
                g.DrawLine(redPen2, point_inc2_2, point_end2_2);//рисуем для сетки копии линии x2
            }


            

            Pen greenPen_y2 = new Pen(Color.Black, 2);
            PointF point_inc3_2 = new PointF(O_x2_pix, O_y2_pix - vys2 * M_y);
            PointF point_end3_2 = new PointF(O_x2_pix, O_y2_pix);
            g.DrawLine(greenPen_y2, point_inc3_2, point_end3_2);//рисуем ось y2

            Font fy2 = new Font(this.Font, FontStyle.Bold);
            msg = "Y";
            g.DrawString(msg, fy2, Brushes.Black, O_x2_pix - 15, O_y2_pix - vys2 * M_y - 20);//подпись названия оси Y2




            Pen redPen_y2 = new Pen(Color.Gray, 1);
            int j_x2; float xx_pix2;
            for (j_x2 = 0; j_x2 <= dl; j_x2 += stepM / 2)
            {

                xx_pix2 = j_x2 * M_x;
                PointF point_inc4_2 = new PointF(O_x2_pix + xx_pix2, O_y2_pix - vys2 * M_y);
                PointF point_end4_2 = new PointF(O_x2_pix + xx_pix2, O_y2_pix);
                g.DrawLine(redPen_y2, point_inc4_2, point_end4_2);// рисуем для сетки копии линии y2 вправо
            }




            Font ft2 = new Font("", 10);
            msg = "Эпюры фильтрационного и взвешивающего давлений";
            g.DrawString(msg, ft2, Brushes.Black, O_x2_pix + pictureBox1.Width / 2 - 230, O_y2_pix + 27);



            for (n = 0; n <= dl; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x2_pix - 8 + n * M_x, O_y2_pix + 2);
            }
            //обозначения по оси +x2

            for (n = stepM; n <= vys2; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x2_pix - 20, O_y2_pix - 8 - n * M_y);
            }
            //обозначения по оси +y2



            PointF ep1 = new PointF(O_x2_pix, O_y2_pix - (T1-T3+1) * M_y-(NPU-H)*M_y);
            PointF ep2 = new PointF(O_x2_pix + (2+L1+L2) * M_x, O_y2_pix - (T1-T3+1) * M_y-(NPU-H)*M_y);
            PointF ep3 = new PointF(O_x2_pix + (2+L1+L2) * M_x, O_y2_pix - 1 * M_y);
            PointF ep4 = new PointF(O_x2_pix + (2+L1) * M_x, O_y2_pix - 1 * M_y);
            PointF ep5 = new PointF(O_x2_pix + (2+L1) * M_x, O_y2_pix - (T1-T2+1) * M_y); 
            PointF ep6 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1-T2+1) * M_y);
            PointF ep7 = new PointF(O_x2_pix, O_y2_pix - (T1-T2+1) * M_y);     
            PointF[] Epur1 = { ep1, ep2, ep3, ep4, ep5, ep6, ep7 };
            g.DrawLines(osnPen,Epur1);//эпюра1
            
            Pen punktPen = new Pen(Color.Black, 1.5f);
            PointF ep8 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T2 + 1) * M_y);
            PointF ep9 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T3 + 1) * M_y);
            g.DrawLine(punktPen, ep8, ep9);
            PointF ep10 = new PointF(O_x2_pix, O_y2_pix - (T1 - T3 + 1) * M_y);
            PointF ep11 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T3 + 1) * M_y);
            g.DrawLine(punktPen, ep10, ep11);//пунктиром хз

            PointF str1 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2) * M_x, O_y2_pix - (T1 - T3 + 1) * M_y - (NPU - H) * M_y); 
            PointF str2 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2) * M_x, O_y2_pix - (T1 - T3 + 1+3) * M_y - (NPU - H) * M_y);
            g.DrawLine(osnPen, str1, str2);
            PointF str3 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2+1) * M_x, O_y2_pix - (T1 - T3 + 1 + 1) * M_y - (NPU - H) * M_y); 
            PointF str4 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2-1) * M_x, O_y2_pix - (T1 - T3 + 1 + 1) * M_y - (NPU - H) * M_y);
            g.DrawLine(osnPen, str2, str3);
            g.DrawLine(osnPen, str2, str4);//стрелка1

            Font ftt = new Font("", 10);
            msg = "Wвзв";
            g.DrawString(msg, ftt, Brushes.Black, O_x2_pix + ((2 + L1 + L2) / 2+2) * M_x, O_y2_pix - (T1 - T3 + 1 + 3) * M_y - (NPU - H) * M_y);

            
            
            PointF ep21 = new PointF(O_x2_pix, O_y2_pix - (T1-T3+1+2) * M_y-(NPU-H+1)*M_y);
            PointF ep22 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1) * M_y);
            PointF ep23 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx1) * M_y);
            PointF ep24 = new PointF(O_x2_pix + (2 + L1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx2) * M_y);
            PointF ep25 = new PointF(O_x2_pix + (2 + L1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx3) * M_y);
            PointF ep26 = new PointF(O_x2_pix + (2 + L1 + L2) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx4) * M_y);
            PointF ep27 = new PointF(O_x2_pix + (2 + L1 + L2) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx5) * M_y);
            PointF ep28 = new PointF(O_x2_pix, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx5) * M_y);
            PointF[] Epur2 = { ep21, ep22, ep23, ep24, ep25, ep26, ep27, ep28 };
            g.DrawLines(osnPen, Epur2);//эпюра2



            PointF str5 = new PointF(O_x2_pix + ((2 + L1 + L2)/2) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx5) * M_y);
            PointF str6 = new PointF(O_x2_pix + ((2 + L1 + L2)/2) * M_x, O_y2_pix - (T1 - T3 + 1 + 2+3) * M_y - (NPU - H + 1 + hx5) * M_y);
            g.DrawLine(osnPen, str5, str6);
            PointF str7 = new PointF(O_x2_pix + ((2 + L1 + L2)/2+1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2+1) * M_y - (NPU - H + 1 + hx5) * M_y);
            PointF str8 = new PointF(O_x2_pix + ((2 + L1 + L2)/2-1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2+1) * M_y - (NPU - H + 1 + hx5) * M_y);
            g.DrawLine(osnPen, str6, str7);
            g.DrawLine(osnPen, str6, str8);//стрелка2

            Font ftz = new Font("", 10);
            msg = "Wф";
            g.DrawString(msg, ftz, Brushes.Black, O_x2_pix + ((2 + L1 + L2) / 2 + 1+1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2 + 1+2) * M_y - (NPU - H + 1 + hx5) * M_y);




            
            
        }



        public void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // сюда копируем все из блока рисования!!!!!!!!!!!!!!!!!!!!!!!!


            int xi = e.MarginBounds.Left;
            int yi = e.MarginBounds.Top;
            


            float M_x = 0; float M_y = 0; int n, stepM = 0; double p1 = 0, p2; float Ln = 0;
            float dl = 2 + L1 + L2 + Ldr + 2;
            float UNB = NPU - H;
            float vys = NPU + T1 + 2;
            float vys2 = H + 1 + UNB + T1 - T3 + 1 + 2 + 5;

            string msg;


            while (dl * M_x + 90 < pictureBox1.Width)
            {
                M_x += 0.001f;
                M_y += 0.001f;
            }// подбираем масштаб по длине


            while (vys * M_y + 40 + 40 + vys2 * M_y + 40 + 60 > pictureBox1.Height)
            {
                M_x -= 0.001f;
                M_y -= 0.001f;

            }//подбор масштаба по высоте




            if (dl <= 25)
            {
                while (dl > Ln)
                {
                    Ln += 50;
                    stepM += 2;
                }
            }


            else
            {
                while (dl > Ln)
                {
                    Ln += 25;
                    stepM += 2;
                }
            }
            //подбираем шаг сетки и подписей 



            float O_x_pix = xi+50;
            float O_y_pix = yi+vys * M_y + 40;//координаты смещенных осей XY




            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;//высокое сглаживание


            Pen greenPen_x = new Pen(Color.Black, 2);
            PointF point_inc1 = new PointF(O_x_pix, O_y_pix);
            PointF point_end1 = new PointF(O_x_pix + dl * M_x, O_y_pix);
            g.DrawLine(greenPen_x, point_inc1, point_end1);//рисуем ось x


            Font fx = new Font(this.Font, FontStyle.Bold);
            msg = "X";
            g.DrawString(msg, fx, Brushes.Black, O_x_pix + (dl - 2) * M_x, O_y_pix + 15);//подпись названия оси X



            Pen redPen = new Pen(Color.Gray, 1);
            int j_y; float yy_pix;
            for (j_y = 0; j_y <= vys; j_y += stepM / 2)
            {
                yy_pix = O_y_pix - j_y * M_y;
                PointF point_inc2 = new PointF(O_x_pix, yy_pix);
                PointF point_end2 = new PointF(O_x_pix + dl * M_x, yy_pix);
                g.DrawLine(redPen, point_inc2, point_end2);//рисуем для сетки копии линии x
            }



            Pen greenPen_y = new Pen(Color.Black, 2);
            PointF point_inc3 = new PointF(O_x_pix, O_y_pix - vys * M_y);
            PointF point_end3 = new PointF(O_x_pix, O_y_pix);
            g.DrawLine(greenPen_y, point_inc3, point_end3);//рисуем ось y

            Font fy = new Font(this.Font, FontStyle.Bold);
            msg = "Y";
            g.DrawString(msg, fy, Brushes.Black, O_x_pix - 15, O_y_pix - vys * M_y - 20);//подпись названия оси Y




            Pen redPen_y = new Pen(Color.Gray, 1);
            int j_x; float xx_pix;
            for (j_x = 0; j_x <= dl; j_x += stepM / 2)
            {

                xx_pix = j_x * M_x;
                PointF point_inc4 = new PointF(O_x_pix + xx_pix, O_y_pix - vys * M_y);
                PointF point_end4 = new PointF(O_x_pix + xx_pix, O_y_pix);
                g.DrawLine(redPen_y, point_inc4, point_end4);// рисуем для сетки копии линии y вправо
            }




            Font ft = new Font("", 10);
            msg = "Фильтрационный расчет методом коэффициентов сопротивления";
            g.DrawString(msg, ft, Brushes.Black, O_x_pix + pictureBox1.Width / 2 - 270, O_y_pix + 27);



            Pen osnPen = new Pen(Color.Black, 2);

            PointF osn1 = new PointF(O_x_pix, O_y_pix - T1 * M_y);
            PointF osn2 = new PointF(O_x_pix + 2 * M_x, O_y_pix - T1 * M_y);
            PointF osn3 = new PointF(O_x_pix + (2 + L1 + L2) * M_x, O_y_pix - T1 * M_y);
            PointF osn4 = new PointF(O_x_pix + (2 + L1 + L2 + Ldr) * M_x, O_y_pix - T1 * M_y);
            PointF osn5 = new PointF(O_x_pix + (2 + L1 + L2 + Ldr) * M_x, O_y_pix - (T1 - 0.5f) * M_y);
            PointF osn6 = new PointF(O_x_pix + (2 + L1 + L2) * M_x, O_y_pix - (T1 - 0.5f) * M_y);
            PointF[] blok1 = { osn1, osn2, osn3, osn4, osn5, osn6 };
            g.DrawLines(osnPen, blok1);


            PointF osn7 = new PointF(O_x_pix + (2 + L1 + L2) * M_x, O_y_pix - T3 * M_y);
            PointF osn8 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - T3 * M_y);
            PointF osn8_2 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - T1 * M_y);
            PointF[] blok2 = { osn3, osn7, osn8, osn8_2 };
            g.DrawLines(osnPen, blok2);

            PointF osn9 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - T2 * M_y);
            PointF osn10 = new PointF(O_x_pix + 2 * M_x, O_y_pix - T2 * M_y);
            PointF osn11 = new PointF(O_x_pix + 2 * M_x, O_y_pix - T1 * M_y);
            PointF[] blok3 = { osn8, osn9, osn10, osn11 };
            g.DrawLines(osnPen, blok3);


            PointF osn15 = new PointF(O_x_pix + (2 + L1 + L2 + Ldr + 2) * M_x, O_y_pix - T1 * M_y);
            g.DrawLine(osnPen, osn4, osn15);
            //рисуем подземный контур



            PointF osn12 = new PointF(O_x_pix + 2 * M_x, O_y_pix - (T2 - S1) * M_y);
            g.DrawLine(osnPen, osn10, osn12);//первый шпунт                     

            PointF osn13 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - (T3 - S2) * M_y);
            g.DrawLine(osnPen, osn8, osn13);//второй шпунт

            PointF osn14 = new PointF(O_x_pix + (2 + L1 + L2) * M_x, O_y_pix - (T3 - S3) * M_y);
            g.DrawLine(osnPen, osn7, osn14);//третий шпунт


            y1 = NPU;
            y2 = NPU - hx1;
            y3 = NPU - hx2;
            y4 = NPU - hx3;
            y5 = NPU - hx4;
            y6 = NPU - hx5;//коорд линии фильтр напора


            PointF nap1 = new PointF(O_x_pix, O_y_pix - (T1 + NPU) * M_y);
            PointF nap2 = new PointF(O_x_pix + 2 * M_x, O_y_pix - (T1 + y1) * M_y);
            PointF nap3 = new PointF(O_x_pix + 2 * M_x, O_y_pix - (T1 + y2) * M_y);
            PointF nap4 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - (T1 + y3) * M_y);
            PointF nap5 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - (T1 + y4) * M_y);
            PointF nap6 = new PointF(O_x_pix + (2 + L1 + L2) * M_x, O_y_pix - (T1 + y5) * M_y);
            PointF nap7 = new PointF(O_x_pix + (2 + L1 + L2) * M_x, O_y_pix - (T1 + y6) * M_y);
            PointF nap8 = new PointF(O_x_pix + (2 + L1 + L2 + Ldr + 2) * M_x, O_y_pix - (T1 + y6) * M_y);
            PointF[] Nap = { nap1, nap2, nap3, nap4, nap5, nap6, nap7, nap8 };
            g.DrawLines(osnPen, Nap);//рисуем фильтр напор


            Pen VodPen = new Pen(Color.Black, 2);
            PointF vod1 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - T1 * M_y);
            PointF vod2 = new PointF(O_x_pix + (2 + L1) * M_x, O_y_pix - (T1 + NPU - H) * M_y);
            PointF vod3 = new PointF(O_x_pix + (2 + L1 + 0.5f) * M_x, O_y_pix - (T1 + NPU - H) * M_y);
            PointF vod4 = new PointF(O_x_pix + (2 + L1 + 0.5f) * M_x, O_y_pix - T1 * M_y);
            PointF[] Vod = { vod1, vod2, vod3, vod4 };
            g.DrawLines(VodPen, Vod);//рисуем схем водослив




            for (n = 0; n <= dl; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 8 + n * M_x, O_y_pix + 2);
            }
            //обозначения по оси +x

            for (n = stepM; n <= vys; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 20, O_y_pix - 8 - n * M_y);
            }
            //обозначения по оси y




            Pen otmPen = new Pen(Color.Black, 1);
            PointF ot1p1 = new PointF(O_x_pix + 1 * M_x, O_y_pix - (T1 + NPU) * M_y);
            PointF ot1p2 = new PointF(O_x_pix + 1 * M_x, O_y_pix - (T1 + NPU) * M_y - 20);
            PointF ot1p3 = new PointF(O_x_pix + 1 * M_x + 40, O_y_pix - (T1 + NPU) * M_y - 20);
            PointF ot1p4 = new PointF(O_x_pix + 1 * M_x - 8, O_y_pix - (T1 + NPU) * M_y - 8);
            PointF ot1p5 = new PointF(O_x_pix + 1 * M_x + 8, O_y_pix - (T1 + NPU) * M_y - 8);
            g.DrawLine(otmPen, ot1p1, ot1p2);
            g.DrawLine(otmPen, ot1p2, ot1p3);
            g.DrawLine(otmPen, ot1p1, ot1p4);
            g.DrawLine(otmPen, ot1p1, ot1p5);
            msg = "НПУ";
            g.DrawString(msg, this.Font, Brushes.Black, O_x_pix + 1 * M_x, O_y_pix - (T1 + NPU) * M_y - 8 - 25);//отметка НПУ


            PointF ot2p1 = new PointF(O_x_pix + (2 + L1 + L2 + 2) * M_x, O_y_pix - (T1 + y6) * M_y);
            PointF ot2p2 = new PointF(O_x_pix + (2 + L1 + L2 + 2) * M_x, O_y_pix - (T1 + y6) * M_y - 20);
            PointF ot2p3 = new PointF(O_x_pix + (2 + L1 + L2 + 2) * M_x + 40, O_y_pix - (T1 + y6) * M_y - 20);
            PointF ot2p4 = new PointF(O_x_pix + (2 + L1 + L2 + 2) * M_x - 8, O_y_pix - (T1 + y6) * M_y - 8);
            PointF ot2p5 = new PointF(O_x_pix + (2 + L1 + L2 + 2) * M_x + 8, O_y_pix - (T1 + y6) * M_y - 8);
            g.DrawLine(otmPen, ot2p1, ot2p2);
            g.DrawLine(otmPen, ot2p2, ot2p3);
            g.DrawLine(otmPen, ot2p1, ot2p4);
            g.DrawLine(otmPen, ot2p1, ot2p5);
            msg = "УНБ";
            g.DrawString(msg, this.Font, Brushes.Black, O_x_pix + (2 + L1 + L2 + 2) * M_x, O_y_pix - (T1 + y6) * M_y - 8 - 25);//отметка УНБ





            /////////////////////////////////////////////вторая схема//////////           


            float O_x2_pix =xi+ 50;
            float O_y2_pix =yi+ vys * M_y + 40 + 40 + vys2 * M_y + 40; //координаты смещенных осей X2Y2



            Pen greenPen_x2 = new Pen(Color.Black, 2);
            PointF point_inc1_2 = new PointF(O_x2_pix, O_y2_pix);
            PointF point_end1_2 = new PointF(O_x2_pix + dl * M_x, O_y2_pix);
            g.DrawLine(greenPen_x2, point_inc1_2, point_end1_2);//рисуем ось x2


            Font fx2 = new Font(this.Font, FontStyle.Bold);
            msg = "X";
            g.DrawString(msg, fx2, Brushes.Black, O_x2_pix + (dl - 2) * M_x, O_y2_pix + 15);//подпись названия оси X2



            Pen redPen2 = new Pen(Color.Gray, 1);
            int j_y2; float yy_pix2;
            for (j_y2 = 0; j_y2 <= vys2; j_y2 += stepM / 2)
            {
                yy_pix2 = O_y2_pix - j_y2 * M_y;
                PointF point_inc2_2 = new PointF(O_x2_pix, yy_pix2);
                PointF point_end2_2 = new PointF(O_x2_pix + dl * M_x, yy_pix2);
                g.DrawLine(redPen2, point_inc2_2, point_end2_2);//рисуем для сетки копии линии x2
            }




            Pen greenPen_y2 = new Pen(Color.Black, 2);
            PointF point_inc3_2 = new PointF(O_x2_pix, O_y2_pix - vys2 * M_y);
            PointF point_end3_2 = new PointF(O_x2_pix, O_y2_pix);
            g.DrawLine(greenPen_y2, point_inc3_2, point_end3_2);//рисуем ось y2

            Font fy2 = new Font(this.Font, FontStyle.Bold);
            msg = "Y";
            g.DrawString(msg, fy2, Brushes.Black, O_x2_pix - 15, O_y2_pix - vys2 * M_y - 20);//подпись названия оси Y2




            Pen redPen_y2 = new Pen(Color.Gray, 1);
            int j_x2; float xx_pix2;
            for (j_x2 = 0; j_x2 <= dl; j_x2 += stepM / 2)
            {

                xx_pix2 = j_x2 * M_x;
                PointF point_inc4_2 = new PointF(O_x2_pix + xx_pix2, O_y2_pix - vys2 * M_y);
                PointF point_end4_2 = new PointF(O_x2_pix + xx_pix2, O_y2_pix);
                g.DrawLine(redPen_y2, point_inc4_2, point_end4_2);// рисуем для сетки копии линии y2 вправо
            }




            Font ft2 = new Font("", 10);
            msg = "Эпюры фильтрационного и взвешивающего давлений";
            g.DrawString(msg, ft2, Brushes.Black, O_x2_pix + pictureBox1.Width / 2 - 230, O_y2_pix + 27);



            for (n = 0; n <= dl; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x2_pix - 8 + n * M_x, O_y2_pix + 2);
            }
            //обозначения по оси +x2

            for (n = stepM; n <= vys2; n += stepM)
            {
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x2_pix - 20, O_y2_pix - 8 - n * M_y);
            }
            //обозначения по оси +y2



            PointF ep1 = new PointF(O_x2_pix, O_y2_pix - (T1 - T3 + 1) * M_y - (NPU - H) * M_y);
            PointF ep2 = new PointF(O_x2_pix + (2 + L1 + L2) * M_x, O_y2_pix - (T1 - T3 + 1) * M_y - (NPU - H) * M_y);
            PointF ep3 = new PointF(O_x2_pix + (2 + L1 + L2) * M_x, O_y2_pix - 1 * M_y);
            PointF ep4 = new PointF(O_x2_pix + (2 + L1) * M_x, O_y2_pix - 1 * M_y);
            PointF ep5 = new PointF(O_x2_pix + (2 + L1) * M_x, O_y2_pix - (T1 - T2 + 1) * M_y);
            PointF ep6 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T2 + 1) * M_y);
            PointF ep7 = new PointF(O_x2_pix, O_y2_pix - (T1 - T2 + 1) * M_y);
            PointF[] Epur1 = { ep1, ep2, ep3, ep4, ep5, ep6, ep7 };
            g.DrawLines(osnPen, Epur1);//эпюра1

            Pen punktPen = new Pen(Color.Black, 1.5f);
            PointF ep8 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T2 + 1) * M_y);
            PointF ep9 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T3 + 1) * M_y);
            g.DrawLine(punktPen, ep8, ep9);
            PointF ep10 = new PointF(O_x2_pix, O_y2_pix - (T1 - T3 + 1) * M_y);
            PointF ep11 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T3 + 1) * M_y);
            g.DrawLine(punktPen, ep10, ep11);//пунктиром хз

            PointF str1 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2) * M_x, O_y2_pix - (T1 - T3 + 1) * M_y - (NPU - H) * M_y);
            PointF str2 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2) * M_x, O_y2_pix - (T1 - T3 + 1 + 3) * M_y - (NPU - H) * M_y);
            g.DrawLine(osnPen, str1, str2);
            PointF str3 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2 + 1) * M_x, O_y2_pix - (T1 - T3 + 1 + 1) * M_y - (NPU - H) * M_y);
            PointF str4 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2 - 1) * M_x, O_y2_pix - (T1 - T3 + 1 + 1) * M_y - (NPU - H) * M_y);
            g.DrawLine(osnPen, str2, str3);
            g.DrawLine(osnPen, str2, str4);//стрелка1

            Font ftt = new Font("", 10);
            msg = "Wвзв";
            g.DrawString(msg, ftt, Brushes.Black, O_x2_pix + ((2 + L1 + L2) / 2 + 2) * M_x, O_y2_pix - (T1 - T3 + 1 + 3) * M_y - (NPU - H) * M_y);



            PointF ep21 = new PointF(O_x2_pix, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1) * M_y);
            PointF ep22 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1) * M_y);
            PointF ep23 = new PointF(O_x2_pix + 2 * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx1) * M_y);
            PointF ep24 = new PointF(O_x2_pix + (2 + L1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx2) * M_y);
            PointF ep25 = new PointF(O_x2_pix + (2 + L1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx3) * M_y);
            PointF ep26 = new PointF(O_x2_pix + (2 + L1 + L2) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx4) * M_y);
            PointF ep27 = new PointF(O_x2_pix + (2 + L1 + L2) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx5) * M_y);
            PointF ep28 = new PointF(O_x2_pix, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx5) * M_y);
            PointF[] Epur2 = { ep21, ep22, ep23, ep24, ep25, ep26, ep27, ep28 };
            g.DrawLines(osnPen, Epur2);//эпюра2



            PointF str5 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2) * M_x, O_y2_pix - (T1 - T3 + 1 + 2) * M_y - (NPU - H + 1 + hx5) * M_y);
            PointF str6 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2) * M_x, O_y2_pix - (T1 - T3 + 1 + 2 + 3) * M_y - (NPU - H + 1 + hx5) * M_y);
            g.DrawLine(osnPen, str5, str6);
            PointF str7 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2 + 1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2 + 1) * M_y - (NPU - H + 1 + hx5) * M_y);
            PointF str8 = new PointF(O_x2_pix + ((2 + L1 + L2) / 2 - 1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2 + 1) * M_y - (NPU - H + 1 + hx5) * M_y);
            g.DrawLine(osnPen, str6, str7);
            g.DrawLine(osnPen, str6, str8);//стрелка2

            Font ftz = new Font("", 10);
            msg = "Wф";
            g.DrawString(msg, ftz, Brushes.Black, O_x2_pix + ((2 + L1 + L2) / 2 + 1 + 1) * M_x, O_y2_pix - (T1 - T3 + 1 + 2 + 1 + 2) * M_y - (NPU - H + 1 + hx5) * M_y);





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

            Bitmap savedBit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(savedBit, pictureBox1.ClientRectangle);
            

            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
               string fileName = dlgSaveFile.FileName;
               savedBit.Save(fileName);                 
            }
        }



        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dlgPageSetup.ShowDialog() == DialogResult.OK)
            { linkLabel1.Enabled = true; }

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
