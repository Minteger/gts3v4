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
    public partial class Form22 : Form
    {    
        double Hpl, H1, h0, d0,H, b, E, m1, m2, Kt, Kv,L, Lv, h1, qt, z, delta_v, delta_n, delta_sr, Bplv;
        double x1, x6, x2, x3, x4, x5, r1, r2, r3, r4, r5, r6;
        double yq1, yq2, yq3, yq4, yq5, yq6;
        double y1, y2, y3, y4, y5, y6;


        public Form22()
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
                Kv =Convert.ToDouble(textBox41.Text.Replace('.',','));
                E = Convert.ToDouble(textBox9.Text.Replace('.',','));

                delta_v = Convert.ToDouble(textBox39.Text.Replace('.',','));
                delta_n = Convert.ToDouble(textBox40.Text.Replace('.',','));
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
                L = (E * (H1 - h0) + d0) * m1 + b + m2 * Hpl;           
                H = H1 - h0;
                delta_sr = (delta_n + delta_v) / 2;
                Bplv =b+delta_sr*(Kt/Kv-1);
                //Lv = (E * (H1 - h0) + d0) * m1 + b + m2 * Hpl;
                Lv= (E*H+d0)*m1+Bplv+Hpl*m2;
                h1 = Lv / m2 - Math.Sqrt(Math.Pow(Lv, 2) / Math.Pow(m2, 2) - Math.Pow(H1 - h0, 2)) + h0;
                qt = (Kt * (Math.Pow(H1, 2) - Math.Pow(h1, 2))) / (2 * (Lv - m2 * h1));

               
                x1 = (E * H + d0) * m1;
                x2 = (E * H + d0) * m1+Bplv;

                x6 = Lv-m2*h1;

                x3 = x2 + (x6 - x2) / 4;
                x4 = x3 + (x6 - x2) / 4;
                x5 = x4 + (x6 - x2) / 4;  
                                                              
                   

                r1 = Math.Round((2 * qt * x1) / Kt, 2);
                r2 = Math.Round((2 * qt * x2) / Kt, 2);
                r3 = Math.Round((2 * qt * x3) / Kt, 2);
                r4 = Math.Round((2 * qt * x4) / Kt, 2);
                r5 = Math.Round((2 * qt * x5) / Kt, 2);
                r6 = Math.Round((2 * qt * x6) / Kt, 2);

               
                yq1 = Math.Pow(H1, 2) - (2 * qt / Kt) * x1;
                yq2 = Math.Pow(H1, 2) - (2 * qt / Kt) * x2;
                yq3 = Math.Pow(H1, 2) - (2 * qt / Kt) * x3;
                yq4 = Math.Pow(H1, 2) - (2 * qt / Kt) * x4;
                yq5 = Math.Pow(H1, 2) - (2 * qt / Kt) * x5;
                yq6 = Math.Pow(H1, 2) - (2 * qt / Kt) * x6;

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



                h1 = Math.Round(h1,2);
                Lv = Math.Round(Lv,2);
                qt = Math.Round(qt,5);
                delta_sr = Math.Round(delta_sr,2);
               

                textBox34.Text = h1.ToString(); 
                textBox35.Text = Lv.ToString();   
                textBox36.Text = qt.ToString();
                textBox42.Text = delta_sr.ToString();

                                
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

        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Form23 form23 = new Form23();
            
            form23.x1 = Convert.ToSingle(textBox10.Text.Replace('.', ','));
            form23.x2 = Convert.ToSingle(textBox11.Text.Replace('.', ','));
            form23.x3 = Convert.ToSingle(textBox12.Text.Replace('.', ','));
            form23.x4 = Convert.ToSingle(textBox13.Text.Replace('.', ','));
            form23.x5 = Convert.ToSingle(textBox14.Text.Replace('.', ','));
            form23.x6 = Convert.ToSingle(textBox15.Text.Replace('.', ','));

            form23.y1 = Convert.ToSingle(textBox33.Text.Replace('.', ','));
            form23.y2 = Convert.ToSingle(textBox32.Text.Replace('.', ',')); 
            form23.y3 = Convert.ToSingle(textBox31.Text.Replace('.', ','));
            form23.y4 = Convert.ToSingle(textBox30.Text.Replace('.', ',')); 
            form23.y5 = Convert.ToSingle(textBox29.Text.Replace('.', ','));
            form23.y6 = Convert.ToSingle(textBox28.Text.Replace('.', ','));  
            
           
            form23.Hpl=Convert.ToSingle(textBox1.Text.Replace('.', ','));
            form23.H1=Convert.ToSingle(textBox2.Text.Replace('.', ','));
            form23.L = Convert.ToSingle(L);
            form23.m1 = Convert.ToSingle(textBox7.Text.Replace('.', ','));
            form23.m2 = Convert.ToSingle(textBox6.Text.Replace('.', ','));
            form23.b = Convert.ToSingle(textBox8.Text.Replace('.', ','));
            form23.z = Convert.ToSingle(textBox37.Text.Replace('.', ','));
            form23.delta_n = Convert.ToSingle(textBox40.Text.Replace('.', ','));
            form23.delta_v = Convert.ToSingle(textBox39.Text.Replace('.', ','));

            form23.ShowDialog();

            
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


   