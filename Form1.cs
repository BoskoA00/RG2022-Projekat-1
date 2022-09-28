using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat_1_RG
{
    public partial class Form1 : Form
    {
        int xauta = 25, yauta = 250, xoblaka1 = 200, yoblaka1 = 50, xoblaka2 = 600, yoblaka2 = 75,
            xprepreke = 550, yprepreke = 270, skor = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            PomeranjeOblaka();
            PomeranjePrepreke();
            Gubitak();
            if (skor >= 3) { timer1.Interval=50; }
            else if (skor >= 6) { timer1.Interval = 25; }
            else if (skor >= 10) { timer1.Interval = 10; }
            this.Invalidate();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }
        
        public void Gubitak() 
        {
        if((yprepreke>=yauta && yprepreke <=yauta+60) && (xprepreke<=xauta+90 && xprepreke>=xauta )) 
            {
                timer1.Stop();
                MessageBox.Show("Izgubili ste!!! Vas rezultat je " + skor.ToString());
                this.Close();
            }
        
        }

        public void PozicijaPrepreke()
        {
            Random r = new Random();
            int rb = r.Next(10);
            if (rb >= 6)
            {
                yprepreke = 270;
            }
            else if (rb <= 5)
            {
                yprepreke = 380;
            }

        }
        public void PomeranjeOblaka()
        {
           
                xoblaka1 = xoblaka1 - 10;
                xoblaka2 = xoblaka2 - 10;

                if (xoblaka1 + 150 == 0)
                {
                    xoblaka1 = 800;
                }
                if (xoblaka2 + 150 == 0)
                {
                    xoblaka2 = 800;
                }
           
        }
        public void PomeranjePrepreke()
        {
            xprepreke -= 10;
            if (xprepreke + 50 == 0)
            {
                skor += 1;
                xprepreke = 800;
                PozicijaPrepreke();
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics gp1 = e.Graphics, gp2 = e.Graphics;
            Rectangle r1 = new Rectangle(0, this.Height - 230, this.Width, 230);
            Pen p1 = new Pen(Color.White, 10), p2 = new Pen(Color.White, 1);
            SolidBrush sbr = new SolidBrush(Color.Red), sbb = new SolidBrush(Color.Black),
                sbg = new SolidBrush(Color.Gray), sbbl = new SolidBrush(Color.Blue),
                sbbe = new SolidBrush(Color.White), sbbr = new SolidBrush(Color.Brown);
            Rectangle auto= new Rectangle(xauta, yauta, 90, 60),
                prozor = new Rectangle(xauta + 7, yauta + 10, 30, 20),
                tocak = new Rectangle(xauta - 15, yauta + 50, 50, 50),
                felna = new Rectangle(xauta + 1, yauta + 65, 20, 20),
                oblak1 = new Rectangle(xoblaka1, yoblaka1, 150, 100),
                deooblaka1 = new Rectangle(xoblaka1 + 50, yoblaka1 - 30, 50, 50),
                oblak2 = new Rectangle(xoblaka2, yoblaka2, 150, 100),
                deooblaka2 = new Rectangle(xoblaka2 + 25, yoblaka2 - 30, 50, 50),
                prepreka = new Rectangle(xprepreke, yprepreke, 50, 50);
            //staza i nebo
            gp1.FillRectangle(sbb, r1);
            float[] dashValues = { 5, 2 };
            p1.DashPattern = dashValues;
            gp1.DrawLine(p1, new Point(0, this.Height - 130), new Point(this.Width, this.Height - 130));
            gp1.TranslateTransform(0, -270);
            r1.Height = this.Height - 210;
            gp1.FillRectangle(sbbl, r1);
            gp1.ResetTransform();



            //iscrtavanje auta
            gp1.FillRectangle(sbr, auto);
            gp1.FillRectangle(sbbl, prozor);
            gp1.TranslateTransform(40, 0);
            gp1.FillRectangle(sbbl, prozor);
            gp1.TranslateTransform(-40, 0);
            gp1.FillEllipse(sbb, tocak);
            gp1.FillEllipse(sbg, felna);
            gp1.DrawEllipse(p2, tocak);
            gp1.DrawEllipse(p2, felna);
            gp1.TranslateTransform(70, 0);
            gp1.FillEllipse(sbb, tocak);
            gp1.FillEllipse(sbg, felna);
            gp1.DrawEllipse(p2, tocak);
            gp1.DrawEllipse(p2, felna);
            gp1.TranslateTransform(-70, 0);
            gp1.ResetTransform();

            //iscrtavanje oblaka        
            gp1.FillRectangle(sbbe, oblak1);
            gp1.FillRectangle(sbbe, deooblaka1);
            gp1.FillRectangle(sbbe, oblak2);
            gp1.FillRectangle(sbbe, deooblaka2);

            //iscrtavanje prepreke
            gp1.FillEllipse(sbbr, prepreka);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                yauta = 250;
            }
        
            else if (e.KeyCode==Keys.Down) { 
                yauta = 350;
                
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (xauta < 600) 
                {
                    xauta += 10;
                }
                else if(xauta>600) { 
                    xauta = 600;
                }
                
            }
            else if (e.KeyCode == Keys.Left)
            {
                if(xauta>25) { xauta -= 10; }
                else if(xauta<25) { xauta = 25; }
               
            }
            else if (e.KeyCode == Keys.Escape) {
                MessageBox.Show("Vas rezultat je : " + skor.ToString());
                this.Close();
              
            }
            
        }
    }
}
