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
    public partial class Form42 : Form
    {

        double NPU, H, T1, T2, T3, S1, S2, S3, L1, L2, Ldr;
        double ksi_vh=0, ksi_g1=0, ksi_sh1=0, ksi_sh2=0, ksi_sh3=0, ksi_shp=0, ksi_g2=0, ksi_vyh=0, ksi_sum=0;
        double h1, h2, h3, h4, h5, hx0, hx1, hx2, hx3, hx4, hx5;        
        


        public Form42()
        {
            InitializeComponent();
        }
               

        public void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            try
            {            
                NPU = Convert.ToDouble(textBox1.Text.Replace('.',','));
                H = Convert.ToDouble(textBox2.Text.Replace('.',','));

                T1 = Convert.ToDouble(textBox4.Text.Replace('.',','));
                T2 = Convert.ToDouble(textBox3.Text.Replace('.',','));
                S1 = Convert.ToDouble(textBox8.Text.Replace('.',','));

                L1 = Convert.ToDouble(textBox37.Text.Replace('.',','));
                                
                S2 = Convert.ToDouble(textBox6.Text.Replace('.',','));              
               
                L2 = Convert.ToDouble(textBox39.Text.Replace('.',','));

                T3 = Convert.ToDouble(textBox40.Text.Replace('.',','));
                S3 = Convert.ToDouble(textBox5.Text.Replace('.',','));

                Ldr = Convert.ToDouble(textBox35.Text.Replace('.',','));
                
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }





            if ((T2/T1)>=0.5 & (T2/T1)<=1 & (S1/T2)>=0 & (S1/T2)<=0.8)
            {
                ksi_sh1 = (T1 - T2)/ T1 + 1.5 * (S1 / T2) + (0.5 * (S1 / T2)) / (1 - 0.75 * (S1 / T2));                
            }

            if ((T2 / T1) >= 0.5 & (T2 / T1) <= 1 & (S1 / T2) >= 0.8 & (S1 / T2) <= 0.96)
            {
                ksi_sh1 = (T1 - T2) / T1 + 12*((S1 / T2) - 0.8) + 2.2;
            }
                ksi_vh = ksi_sh1 + 0.44; //коэф сопротивления на входе
            

            
            if (L1 > 0.5 * (S1 + S2))
            {
              ksi_g1=(L1-0.5*(S1+S2))/T2;
            }//коэф сопротивления гориз участка 1



            if ((T3/T2)>=0.5 & (T3/T2)<=1 & (S2/T3)>=0 & (S2/T3)<=0.8)
            {
                ksi_sh2 = (T2 - T3)/ T2 + 1.5 * (S2 / T3) + (0.5 * (S2 / T3)) / (1 - 0.75 * (S2 / T3));                
            }

            if ((T3 / T2) >= 0.5 & (T3 / T2) <= 1 & (S2 / T3) >= 0.8 & (S2 / T3) <= 0.96)
            {
                ksi_sh2 = (T2 - T3) / T2 + 12*((S2 / T3) - 0.8) + 2.2;
            }
                ksi_shp = ksi_sh2; //коэф сопротивления внутр шпунта




            if (L2 > 0.5 * (S2 + S3))
            {
              ksi_g2=(L2-0.5*(S2+S3))/T3;
            }//коэф сопротивления гориз участка 2
            

           
            if ((T3 / T1) >= 0.5 & (T3 / T1) <= 1 & (S3 / T3) >= 0 & (S3 / T3) <= 0.8)
            {
                ksi_sh3 = (T1 - T3) / T1 + 1.5 * (S3 / T3) + (0.5 * (S3 / T3)) / (1 - 0.75 * (S3 / T3));
            }

            if ((T3 / T1) >= 0.5 & (T3 / T1) <= 1 & (S3 / T3) >= 0.8 & (S3 / T3) <= 0.96)
            {
                ksi_sh3 = (T1 - T3) / T1 + 12 * ((S3/ T3) - 0.8) + 2.2;
            }
            ksi_vyh = ksi_sh3 + 0.44; //коэф сопротивления на выходе


            ksi_sum = ksi_vh + ksi_g1 + ksi_shp + ksi_g2 + ksi_vyh;//сумма коэф сопр



            h1 = (H / ksi_sum) * ksi_vh;
            h2 = (H / ksi_sum) * ksi_g1;
            h3 = (H / ksi_sum) * ksi_shp;
            h4 = (H / ksi_sum) * ksi_g2;
            h5 = (H / ksi_sum) * ksi_vyh;//потери напора

            hx0 = 0;
            hx1 = hx0 + h1;
            hx2 = hx1 + h2;
            hx3 = hx2 + h3;
            hx4 = hx3 + h4;
            hx5 = hx4 + h5;//фильтрационный напор         

            


            ksi_vh = Math.Round(ksi_vh, 2);
            ksi_g1 = Math.Round(ksi_g1, 2);
            ksi_shp = Math.Round(ksi_shp, 2);
            ksi_g2 = Math.Round(ksi_g2, 2);
            ksi_vyh = Math.Round(ksi_vyh, 2);

            ksi_sum = Math.Round(ksi_sum, 2);


            h1 = Math.Round(h1, 2);
            h2 = Math.Round(h2, 2);
            h3 = Math.Round(h3, 2);
            h4 = Math.Round(h4, 2);
            h5 = Math.Round(h5, 2);

            hx0 = Math.Round(hx0, 2);
            hx1 = Math.Round(hx1, 2);
            hx2 = Math.Round(hx2, 2);
            hx3 = Math.Round(hx3, 2);
            hx4 = Math.Round(hx4, 2);
            hx5 = Math.Round(hx5, 2);



            textBox10.Text = ksi_vh.ToString();
            textBox11.Text = ksi_g1.ToString();
            textBox12.Text = ksi_shp.ToString();
            textBox13.Text = ksi_g2.ToString();
            textBox14.Text = ksi_vyh.ToString();

            textBox34.Text = ksi_sum.ToString();

            textBox21.Text = h1.ToString();
            textBox20.Text = h2.ToString();
            textBox19.Text = h3.ToString();
            textBox18.Text = h4.ToString();
            textBox17.Text = h5.ToString();

            textBox27.Text = hx0.ToString();
            textBox26.Text = hx1.ToString();
            textBox25.Text = hx2.ToString();
            textBox24.Text = hx3.ToString();
            textBox23.Text = hx4.ToString();
            textBox22.Text = hx5.ToString();
            

            linkLabel1.Enabled = true;
            linkLabel3.Enabled = true;
            linkLabel5.Enabled = true;
            linkLabel4.Enabled = true;
            linkLabel6.Enabled = true;

        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Form43 form43 = new Form43();

            form43.L1 = Convert.ToSingle(L1);
            form43.L2 = Convert.ToSingle(L2);
            form43.Ldr = Convert.ToSingle(Ldr);
            form43.NPU = Convert.ToSingle(NPU);
            form43.H = Convert.ToSingle(H);
            form43.T1 = Convert.ToSingle(T1);
            form43.T2 = Convert.ToSingle(T2);
            form43.T3 = Convert.ToSingle(T3);
            form43.S1 = Convert.ToSingle(S1);
            form43.S2 = Convert.ToSingle(S2);
            form43.S3 = Convert.ToSingle(S3);

            form43.hx1 = Convert.ToSingle(textBox26.Text.Replace('.', ','));
            form43.hx2 = Convert.ToSingle(textBox25.Text.Replace('.', ','));
            form43.hx3 = Convert.ToSingle(textBox24.Text.Replace('.', ','));
            form43.hx4 = Convert.ToSingle(textBox23.Text.Replace('.', ','));
            form43.hx5 = Convert.ToSingle(textBox22.Text.Replace('.', ','));         
            

            form43.ShowDialog();

            
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


   