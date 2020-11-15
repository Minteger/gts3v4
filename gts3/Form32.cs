using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace gts3
{
    public partial class Form32 : Form
    {    
        double Hpl, H1, h0,h21,h22,h23, h11, h12, h13, d0,H, b, E, m1, m2, Kt, Ke, tzv, tzn, tzsr, L1, L2, L3;
        double teta,qt, z, delta_v, delta_n, delta_sr,F1, F2, F11, F12, F13, F21, F22, F23, z0, n;
        double h2isk, Lisk, h1isk;
        double x1, x6, x2, x3, x4, x5, r1, r2, r3, r4, r5, r6;
        double yq1, yq2, yq3, yq4, yq5, yq6;
        double y1, y2, y3, y4, y5, y6;


        public Form32()
        {
            InitializeComponent();
        }
               

        public void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            try
            {            
                Hpl = Convert.ToDouble(textBox1.Text.Replace('.',','));
                H1 = Convert.ToDouble(textBox2.Text.Replace('.',','));
                h0 = Convert.ToDouble(textBox4.Text.Replace('.',','));
                d0 = Convert.ToDouble(textBox3.Text.Replace('.',','));

                b = Convert.ToDouble(textBox8.Text.Replace('.',','));
                m1 = Convert.ToDouble(textBox7.Text.Replace('.',','));
                m2 = Convert.ToDouble(textBox6.Text.Replace('.',','));
                Kt = Convert.ToDouble(textBox5.Text.Replace('.',','));
                Ke =Convert.ToDouble(textBox41.Text.Replace('.',','));                
                tzv = Convert.ToDouble(textBox44.Text.Replace('.',','));
                tzn =Convert.ToDouble(textBox43.Text.Replace('.',','));

                E = Convert.ToDouble(textBox9.Text.Replace('.',','));

                delta_v = Convert.ToDouble(textBox39.Text.Replace('.',','));
                delta_n = Convert.ToDouble(textBox40.Text.Replace('.',','));
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }


                delta_sr = (delta_n + delta_v) / 2;
                tzsr=(tzn+tzv)/2;
                teta = Math.Atan(m1);
                n = Kt/Ke;
                z0 = delta_sr * Math.Cos(teta);



                h2isk = 0;
                do
                {
                    h2isk += 0.001f;
                    Lisk = (Hpl - h2isk) * m1 + b + m2 * Hpl - (delta_sr + tzsr) / Math.Sin(teta);
                    h1isk = Lisk / m2 - Math.Sqrt(Math.Pow(Lisk, 2) / Math.Pow(m2, 2) - Math.Pow(h2isk - h0, 2)) + h0;
                    F1 = (Math.Pow(h2isk, 2) - Math.Pow(h1isk, 2)) / (2 * (Lisk - m2 * h1isk));
                    F2 = (Math.Pow(H1, 2) - Math.Pow(h2isk, 2) - Math.Pow(z0, 2)) / (2 * delta_sr * n * Math.Sin(teta));
                }
                while (F1 < F2);//находим h2 при пересечении функций
            

            
                h23 = 1.3f*h2isk;
                h22 = h2isk;
                h21 = 0.7f*h2isk;

                L1 = (Hpl - h21) * m1 + b + m2 * Hpl - (delta_sr + tzsr) / Math.Sin(teta);
                L2 = (Hpl - h22) * m1 + b + m2 * Hpl - (delta_sr + tzsr) / Math.Sin(teta);
                L3 = (Hpl - h23) * m1 + b + m2 * Hpl - (delta_sr + tzsr) / Math.Sin(teta);

                h11 = L1 / m2 - Math.Sqrt(Math.Pow(L1, 2) / Math.Pow(m2, 2) - Math.Pow(h21- h0, 2)) + h0;
                h12 = L2 / m2 - Math.Sqrt(Math.Pow(L2, 2) / Math.Pow(m2, 2) - Math.Pow(h22- h0, 2)) + h0;
                h13 = L3 / m2 - Math.Sqrt(Math.Pow(L3, 2) / Math.Pow(m2, 2) - Math.Pow(h23- h0, 2)) + h0;

                F11 = (Math.Pow(h21,2)-Math.Pow(h11,2))/(2*(L1-m2*h11));
                F12 = (Math.Pow(h22,2)-Math.Pow(h12,2))/(2*(L2-m2*h12));
                F13 = (Math.Pow(h23,2)-Math.Pow(h13,2))/(2*(L3-m2*h13));

                F21 = (Math.Pow(H1, 2) - Math.Pow(h21, 2) - Math.Pow(z0, 2)) / (2 * delta_sr * n * Math.Sin(teta));
                F22 = (Math.Pow(H1, 2) - Math.Pow(h22, 2) - Math.Pow(z0, 2)) / (2 * delta_sr * n * Math.Sin(teta));
                F23 = (Math.Pow(H1, 2) - Math.Pow(h23, 2) - Math.Pow(z0, 2)) / (2 * delta_sr * n * Math.Sin(teta));//данные для таблицы


                
              
         

                qt = (Kt * (Math.Pow(h2isk, 2) - Math.Pow(h1isk, 2))) / (2 * (Lisk - m2 * h1isk));
                H = H1 - h0;
            
            
                x1 = 0;
                x6 = Lisk-m2*h1isk;
                x2 = x1 + (x6 - x1) / 5;
                x3 = x2 + (x6 - x1) / 5;
                x4 = x3 + (x6 - x1) / 5;
                x5 = x4 + (x6 - x1) / 5; 
                        
                   

                r1 = Math.Round((2 * qt * x1) / Kt, 2);
                r2 = Math.Round((2 * qt * x2) / Kt, 2);
                r3 = Math.Round((2 * qt * x3) / Kt, 2);
                r4 = Math.Round((2 * qt * x4) / Kt, 2);
                r5 = Math.Round((2 * qt * x5) / Kt, 2);
                r6 = Math.Round((2 * qt * x6) / Kt, 2);

               
                yq1 = Math.Pow(h2isk, 2) - (2 * qt / Kt) * x1;
                yq2 = Math.Pow(h2isk, 2) - (2 * qt / Kt) * x2;
                yq3 = Math.Pow(h2isk, 2) - (2 * qt / Kt) * x3;
                yq4 = Math.Pow(h2isk, 2) - (2 * qt / Kt) * x4;
                yq5 = Math.Pow(h2isk, 2) - (2 * qt / Kt) * x5;
                yq6 = Math.Pow(h2isk, 2) - (2 * qt / Kt) * x6;

                x1 = Math.Round(x1, 2);
                x2 = Math.Round(x2, 2);
                x3 = Math.Round(x3, 2);
                x4 = Math.Round(x4, 2);
                x5 = Math.Round(x5, 2);
                x6 = Math.Round(x6, 2);


                y1 = Math.Round(Math.Sqrt(yq1), 2);
                y2 = Math.Round(Math.Sqrt(yq2), 2);
                y3 = Math.Round(Math.Sqrt(yq3), 2);
                y4 = Math.Round(Math.Sqrt(yq4), 2);
                y5 = Math.Round(Math.Sqrt(yq5), 2);
                y6 = Math.Round(Math.Sqrt(yq6), 2);

                yq1 = Math.Round(yq1, 2);
                yq2 = Math.Round(yq2, 2);
                yq3 = Math.Round(yq3, 2);
                yq4 = Math.Round(yq4, 2);
                yq5 = Math.Round(yq5, 2);
                yq6 = Math.Round(yq6, 2);


                h2isk = Math.Round(h2isk, 2);
                h1isk = Math.Round(h1isk,2);
                Lisk = Math.Round(Lisk,2);
                qt = Math.Round(qt,5);
                tzsr = Math.Round(tzsr,2);
                delta_sr = Math.Round(delta_sr,2);            

                h21 = Math.Round(h21, 2);
                h22 = Math.Round(h22, 2);
                h23 = Math.Round(h23, 2);
                
                L1 = Math.Round(L1, 2);
                L2 = Math.Round(L2, 2);
                L3 = Math.Round(L3, 2);

                h11= Math.Round(h11, 2);
                h12= Math.Round(h12, 2);
                h13= Math.Round(h12, 2);

                F11 = Math.Round(F11, 2);
                F12 = Math.Round(F12, 2);
                F13 = Math.Round(F13, 2);

                F21 = Math.Round(F21, 2);
                F22 = Math.Round(F22, 2);
                F23 = Math.Round(F23, 2);


                textBox47.Text = h21.ToString();
                textBox48.Text = h22.ToString();
                textBox49.Text = h23.ToString();
            
                textBox52.Text = L1.ToString();
                textBox51.Text = L2.ToString();
                textBox50.Text = L3.ToString();
            
                textBox55.Text = h11.ToString();
                textBox54.Text = h12.ToString();
                textBox53.Text = h13.ToString();
            
                textBox58.Text = F11.ToString();
                textBox57.Text = F12.ToString();
                textBox56.Text = F13.ToString();
            
                textBox61.Text = F21.ToString();
                textBox60.Text = F22.ToString();
                textBox59.Text = F23.ToString();
            


                textBox34.Text = h1isk.ToString();
                textBox45.Text = h2isk.ToString();
                textBox35.Text = Lisk.ToString();   
                textBox36.Text = qt.ToString();
                textBox42.Text = delta_sr.ToString();
                textBox46.Text = tzsr.ToString();
                                
                textBox10.Text = x1.ToString();
                textBox11.Text = x2.ToString();
                textBox12.Text = x3.ToString();
                textBox13.Text = x4.ToString();
                textBox14.Text = x5.ToString();
                textBox15.Text = x6.ToString();

                textBox21.Text = r1.ToString();
                textBox20.Text = r2.ToString();
                textBox19.Text = r3.ToString();
                textBox18.Text = r4.ToString();
                textBox17.Text = r5.ToString();
                textBox16.Text = r6.ToString();

                textBox27.Text = yq1.ToString();
                textBox26.Text = yq2.ToString();
                textBox25.Text = yq3.ToString();
                textBox24.Text = yq4.ToString();
                textBox23.Text = yq5.ToString();
                textBox22.Text = yq6.ToString();

                textBox33.Text = y1.ToString();
                textBox32.Text = y2.ToString();
                textBox31.Text = y3.ToString();
                textBox30.Text = y4.ToString();
                textBox29.Text = y5.ToString();
                textBox28.Text = y6.ToString();

                linkLabel1.Enabled = true;
                linkLabel3.Enabled = true;
                linkLabel5.Enabled = true;
                linkLabel4.Enabled = true;
                linkLabel6.Enabled = true;
                linkLabel7.Enabled = true;

        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Form33 form33 = new Form33();
            
            form33.x1 = Convert.ToSingle(textBox10.Text.Replace('.', ','));
            form33.x2 = Convert.ToSingle(textBox11.Text.Replace('.', ','));
            form33.x3 = Convert.ToSingle(textBox12.Text.Replace('.', ','));
            form33.x4 = Convert.ToSingle(textBox13.Text.Replace('.', ','));
            form33.x5 = Convert.ToSingle(textBox14.Text.Replace('.', ','));
            form33.x6 = Convert.ToSingle(textBox15.Text.Replace('.', ','));

            form33.y1 = Convert.ToSingle(textBox33.Text.Replace('.', ','));
            form33.y2 = Convert.ToSingle(textBox32.Text.Replace('.', ',')); 
            form33.y3 = Convert.ToSingle(textBox31.Text.Replace('.', ','));
            form33.y4 = Convert.ToSingle(textBox30.Text.Replace('.', ',')); 
            form33.y5 = Convert.ToSingle(textBox29.Text.Replace('.', ','));
            form33.y6 = Convert.ToSingle(textBox28.Text.Replace('.', ','));  
            
           
            form33.Hpl=Convert.ToSingle(textBox1.Text.Replace('.', ','));
            form33.H1=Convert.ToSingle(textBox2.Text.Replace('.', ','));
            form33.Lisk = Convert.ToSingle(Lisk);
            form33.m1 = Convert.ToSingle(textBox7.Text.Replace('.', ','));
            form33.m2 = Convert.ToSingle(textBox6.Text.Replace('.', ','));
            form33.b = Convert.ToSingle(textBox8.Text.Replace('.', ','));
            form33.z = Convert.ToSingle(textBox37.Text.Replace('.', ','));
            form33.delta_n = Convert.ToSingle(textBox40.Text.Replace('.', ','));
            form33.delta_v = Convert.ToSingle(textBox39.Text.Replace('.', ','));
            form33.tzsr = Convert.ToSingle(textBox46.Text.Replace('.', ','));
            form33.teta = teta;
            form33.delta_sr=Convert.ToSingle(textBox42.Text.Replace('.', ','));


            form33.ShowDialog();

            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dlgPageSetup2.ShowDialog();   
        }
        

        
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = groupBox4.CreateGraphics();
            Size s = groupBox4.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, groupBox4.ClientRectangle.Width,
                groupBox4.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int xi = e.MarginBounds.Left;
            int yi = e.MarginBounds.Top;
            e.Graphics.DrawImage(memoryImage, xi, yi); 

        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK) printDocument1.Print();
            }
            catch
            {
                MessageBox.Show("Принтер не доступен");
            }
        }

            

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Rectangle r = groupBox4.RectangleToScreen(groupBox4.ClientRectangle);
            Bitmap bitmap2 = new Bitmap(r.Width, r.Height);
            Graphics d = Graphics.FromImage(bitmap2);
            d.CopyFromScreen(r.Location, new Point(0, 0), r.Size);


            if (dlgSaveFile2.ShowDialog() == DialogResult.OK)
            {
                string fileName = dlgSaveFile2.FileName;
                bitmap2.Save(fileName);
            }

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form34 form34 = new Form34();
            form34.h21 = Convert.ToSingle(textBox47.Text.Replace('.', ','));
            form34.h22 = Convert.ToSingle(textBox48.Text.Replace('.', ','));
            form34.h23 = Convert.ToSingle(textBox49.Text.Replace('.', ','));

            form34.F11 = Convert.ToSingle(textBox58.Text.Replace('.', ','));
            form34.F12 = Convert.ToSingle(textBox57.Text.Replace('.', ','));
            form34.F13 = Convert.ToSingle(textBox56.Text.Replace('.', ','));

            form34.F21 = Convert.ToSingle(textBox61.Text.Replace('.', ','));
            form34.F22 = Convert.ToSingle(textBox60.Text.Replace('.', ','));
            form34.F23 = Convert.ToSingle(textBox59.Text.Replace('.', ','));

            form34.ShowDialog();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                CaptureScreen();
                printPreviewDialog1.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Принтер не доступен");
            }
        }                                
              
    }
}


   