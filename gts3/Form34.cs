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

    public partial class Form34 : Form
    {


        public Form34()
        {
            InitializeComponent();
        }

        
        public float h21, h22, h23, F11, F12, F13, F21, F22, F23, F;


        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            float M_x = 0; float M_y = 0; float n, stepM_x = 0, stepM_y = 0; double p1, p2; float hn = 0;          
            string msg;

            if (F21 > F13) { F = F21; } else { F = F13; }            

                
            while (h23 * M_x+50+30+30 < pictureBox1.Width)
                {
                M_x += 0.001f;
                M_y += 0.005f;
                }//подбор масштаба по длине
            

            while (F* M_y+110 > pictureBox1.Height)
            {
                
                M_y -= 0.005f; 
            }//подбор масштаба по высоте

            if (h23 <= 2)
            {
                while (h23 > hn)
                {
                    hn += 2;
                    stepM_x += 0.2f;
                }
            }


            else
            {
                while (h23 > hn)
                {
                    hn += 2;
                    stepM_x += 0.5f;
                }
            }
            
            stepM_y = stepM_x/5;
            //подбираем шаг сетки и подписей 
                      
                        
            float O_x_pix = 30;
            float O_y_pix = pictureBox1.Height / 2 + (F/2) * M_y;//координаты смещенных осей XY
                     
            
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;//высокое сглаживание


            Pen greenPen_x = new Pen(Color.Black, 2);
            PointF point_inc1 = new PointF(O_x_pix, O_y_pix);
            PointF point_end1 = new PointF(O_x_pix + h23 * M_x + 50, O_y_pix);
            g.DrawLine(greenPen_x, point_inc1, point_end1);//рисуем ось x


            Font fx = new Font(this.Font, FontStyle.Bold);
            msg = "h2";
            g.DrawString(msg, fx, Brushes.Black, O_x_pix + h23 * M_x + 30, O_y_pix + 15);//подпись названия оси X

            Font f0 = new Font(this.Font, FontStyle.Bold);
            msg = "0";
            g.DrawString(msg, f0, Brushes.Black, O_x_pix, O_y_pix+2);//подпись начала осей 

            Pen redPen = new Pen(Color.Gray, 1);
            float j_y=0; float yy_pix;
            while (j_y+stepM_y/10<F*1.05f )
            {
                //j_y += stepM / 60;
                j_y += stepM_y/10;
                yy_pix = O_y_pix - j_y * M_y;
                PointF point_inc2 = new PointF(O_x_pix, yy_pix);
                PointF point_end2 = new PointF(O_x_pix + h23 * M_x + 50, yy_pix);
                g.DrawLine(redPen, point_inc2, point_end2);//рисуем для сетки копии линии x
            }

            n = 0; p1 = 0;j_y=0; 
            while (j_y +stepM_y/2<= F)
            {
                j_y +=stepM_y/2;                
                n += stepM_y/2;
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix-28, O_y_pix - 7-j_y* M_y);
            }
            //обозначения по оси y


            Pen greenPen_y = new Pen(Color.Black, 2);
            PointF point_inc3 = new PointF(O_x_pix, O_y_pix - F * 1.05f * M_y);
            PointF point_end3 = new PointF(O_x_pix, O_y_pix);
            g.DrawLine(greenPen_y, point_inc3, point_end3);//рисуем ось y

            Font fy = new Font(this.Font, FontStyle.Bold);
            msg = "F1(h2),F2(h2)";
            g.DrawString(msg, fy, Brushes.Black, O_x_pix - 15, O_y_pix - 1.05f * F * M_y - 20);//подпись названия оси Y




            Pen redPen_y = new Pen(Color.Gray, 1);
            float j_x=0; float xx_pix;

             while (j_x +stepM_x / 10< h23 + 50 / M_x)
            {
                j_x += stepM_x / 10;
                xx_pix = j_x * M_x;
                PointF point_inc4 = new PointF(O_x_pix + xx_pix, O_y_pix - F * 1.05f * M_y);
                PointF point_end4 = new PointF(O_x_pix + xx_pix, O_y_pix);
                g.DrawLine(redPen_y, point_inc4, point_end4);// рисуем для сетки копии линии Y вправо
            }
            

            Font ft = new Font("", 10);
            msg = "График для определения ординаты h2иск";
            g.DrawString(msg, ft, Brushes.Black, pictureBox1.Width / 2 - 150, O_y_pix + 25);

            
            Pen graphPen = new Pen(Color.Black, 3);
            
            PointF F11p = new PointF(O_x_pix + h21 * M_x, O_y_pix - F11 * M_y);
            PointF F12p = new PointF(O_x_pix + h22 * M_x, O_y_pix - F12 * M_y);
            PointF F13p = new PointF(O_x_pix + h23 * M_x, O_y_pix - F13 * M_y);
            PointF[] myCurvePoints1 = { F11p, F12p, F13p };
            g.DrawCurve(graphPen, myCurvePoints1);
            
           
            PointF F21p = new PointF(O_x_pix + h21 * M_x, O_y_pix - F21 * M_y);
            PointF F22p = new PointF(O_x_pix + h22 * M_x, O_y_pix - F22 * M_y);
            PointF F23p = new PointF(O_x_pix + h23 * M_x, O_y_pix - F23 * M_y);
            PointF[] myCurvePoints2 = {F21p, F22p, F23p};
            g.DrawCurve(graphPen, myCurvePoints2);


            n = 0; p1 = 0;
            while( n+stepM_x <= h23)
            {
                n += stepM_x;
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 8 + n * M_x, O_y_pix + 2);
            }
            //обозначения по оси +x
                
                                    

        }

        public void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // сюда копируем все из блока рисования!!!!!!!!!!!!!!!!!!!!!!!!
            int xi = e.MarginBounds.Left;
            int yi = e.MarginBounds.Top;  


            float M_x = 0; float M_y = 0; float n, stepM_x = 0, stepM_y = 0; double p1, p2; float hn = 0;
            string msg;

            if (F21 > F13) { F = F21; } else { F = F13; }


            while (h23 * M_x + 50 + 30 + 30 < pictureBox1.Width)
            {
                M_x += 0.001f;
                M_y += 0.005f;
            }//подбор масштаба по длине


            while (F * M_y + 110 > pictureBox1.Height)
            {

                M_y -= 0.005f;
            }//подбор масштаба по высоте

            if (h23 <= 2)
            {
                while (h23 > hn)
                {
                    hn += 2;
                    stepM_x += 0.2f;
                }
            }


            else
            {
                while (h23 > hn)
                {
                    hn += 2;
                    stepM_x += 0.5f;
                }
            }

            stepM_y = stepM_x / 5;
            //подбираем шаг сетки и подписей 


            float O_x_pix = xi+30;
            float O_y_pix =yi+ pictureBox1.Height / 2 + (F / 2) * M_y;//координаты смещенных осей XY


            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.HighQuality;//высокое сглаживание


            Pen greenPen_x = new Pen(Color.Black, 2);
            PointF point_inc1 = new PointF(O_x_pix, O_y_pix);
            PointF point_end1 = new PointF(O_x_pix + h23 * M_x + 50, O_y_pix);
            g.DrawLine(greenPen_x, point_inc1, point_end1);//рисуем ось x


            Font fx = new Font(this.Font, FontStyle.Bold);
            msg = "h2";
            g.DrawString(msg, fx, Brushes.Black, O_x_pix + h23 * M_x + 30, O_y_pix + 15);//подпись названия оси X

            Font f0 = new Font(this.Font, FontStyle.Bold);
            msg = "0";
            g.DrawString(msg, f0, Brushes.Black, O_x_pix, O_y_pix + 2);//подпись начала осей 

            Pen redPen = new Pen(Color.Gray, 1);
            float j_y = 0; float yy_pix;
            while (j_y + stepM_y / 10 < F * 1.05f)
            {
                //j_y += stepM / 60;
                j_y += stepM_y / 10;
                yy_pix = O_y_pix - j_y * M_y;
                PointF point_inc2 = new PointF(O_x_pix, yy_pix);
                PointF point_end2 = new PointF(O_x_pix + h23 * M_x + 50, yy_pix);
                g.DrawLine(redPen, point_inc2, point_end2);//рисуем для сетки копии линии x
            }

            n = 0; p1 = 0; j_y = 0;
            while (j_y + stepM_y / 2 <= F)
            {
                j_y += stepM_y / 2;
                n += stepM_y / 2;
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 28, O_y_pix - 7 - j_y * M_y);
            }
            //обозначения по оси y


            Pen greenPen_y = new Pen(Color.Black, 2);
            PointF point_inc3 = new PointF(O_x_pix, O_y_pix - F * 1.05f * M_y);
            PointF point_end3 = new PointF(O_x_pix, O_y_pix);
            g.DrawLine(greenPen_y, point_inc3, point_end3);//рисуем ось y

            Font fy = new Font(this.Font, FontStyle.Bold);
            msg = "F1(h2),F2(h2)";
            g.DrawString(msg, fy, Brushes.Black, O_x_pix - 15, O_y_pix - 1.05f * F * M_y - 20);//подпись названия оси Y




            Pen redPen_y = new Pen(Color.Gray, 1);
            float j_x = 0; float xx_pix;

            while (j_x + stepM_x / 10 < h23 + 50 / M_x)
            {
                j_x += stepM_x / 10;
                xx_pix = j_x * M_x;
                PointF point_inc4 = new PointF(O_x_pix + xx_pix, O_y_pix - F * 1.05f * M_y);
                PointF point_end4 = new PointF(O_x_pix + xx_pix, O_y_pix);
                g.DrawLine(redPen_y, point_inc4, point_end4);// рисуем для сетки копии линии Y вправо
            }


            Font ft = new Font("", 10);
            msg = "График для определения ординаты h2иск";
            g.DrawString(msg, ft, Brushes.Black, pictureBox1.Width / 2 - 150, O_y_pix + 25);


            Pen graphPen = new Pen(Color.Black, 3);

            PointF F11p = new PointF(O_x_pix + h21 * M_x, O_y_pix - F11 * M_y);
            PointF F12p = new PointF(O_x_pix + h22 * M_x, O_y_pix - F12 * M_y);
            PointF F13p = new PointF(O_x_pix + h23 * M_x, O_y_pix - F13 * M_y);
            PointF[] myCurvePoints1 = { F11p, F12p, F13p };
            g.DrawCurve(graphPen, myCurvePoints1);


            PointF F21p = new PointF(O_x_pix + h21 * M_x, O_y_pix - F21 * M_y);
            PointF F22p = new PointF(O_x_pix + h22 * M_x, O_y_pix - F22 * M_y);
            PointF F23p = new PointF(O_x_pix + h23 * M_x, O_y_pix - F23 * M_y);
            PointF[] myCurvePoints2 = { F21p, F22p, F23p };
            g.DrawCurve(graphPen, myCurvePoints2);


            n = 0; p1 = 0;
            while (n + stepM_x <= h23)
            {
                n += stepM_x;
                p2 = p1 + n;
                p2 = Math.Round(p2, 2);
                msg = "" + p2.ToString() + "";
                g.DrawString(msg, this.Font, Brushes.Black, O_x_pix - 8 + n * M_x, O_y_pix + 2);
            }
            //обозначения по оси +x
                            
                      
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
