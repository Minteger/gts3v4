using System.Drawing.Drawing2D;
using System.IO;



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;






namespace gts3
{
    public partial class Form0 : Form
    {

        private WshShellClass WshShell;
       

        public Form0()
        {
            InitializeComponent();        
            
                        
            WshShell = new WshShellClass();                     
            IWshRuntimeLibrary.IWshShortcut MyShortcut;
            string link = (string) Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+ @"\GTS.lnk";
            MyShortcut = (IWshRuntimeLibrary.IWshShortcut)WshShell.CreateShortcut(link);
            MyShortcut.TargetPath = Application.ExecutablePath;
            MyShortcut.Description = "ГТС расчеты";
            MyShortcut.IconLocation = Application.StartupPath + @"\Micon.ico";
            MyShortcut.Save();            
          
        }

        
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form12 form2 = new Form12();            
            form2.ShowDialog();            
           // this.Hide ();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form22 form22 = new Form22();
            form22.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form32 form32 = new Form32();
            form32.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form42 form42 = new Form42();
            form42.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {                  
            info inf = new info();
            inf.ShowDialog();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gdiObj = e.Graphics;
            StringFormat strFormat = new StringFormat();
            strFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            SolidBrush drawBrush = new System.Drawing.SolidBrush(Color.Gray);
            gdiObj.DrawString("info", new Font("Times New Roman", 8F), drawBrush, new PointF(0, 0), strFormat);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            info inf = new info();
            inf.ShowDialog();
        }

        
       
    }
}
