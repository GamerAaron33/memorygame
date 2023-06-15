using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEW_Aaron_Pressler_Memory
{
    public partial class Form2 : Form
    {


        
       


        const string PATH = @"../../Images/";
        const string BACKGROUNDIMAGE = "backgroundimage.png";
        PictureBox pb1 = null;
        PictureBox pb2 = null;


        public static int wincounter = 0;    
        int seconds = 0;
        int minutes = 0;
        int count = 0;

        public Form2()
        {
            InitializeComponent();
        }


       
        private void pictureBox_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true)
            { 
                
                return;
            }
            

            PictureBox pb = (PictureBox)sender;
            seconds++;
            pb.ImageLocation = String.Empty;//<---  Verursacht den Fehler rechts oben


            if (pb1 == null)
            {
                pb1 = pb;
                label1.Visible = false;

            }
            else
            {

                pb2 = pb;
                label1.Visible = false;

                if (pb1.Tag.Equals(pb2.Tag))
                {
                    pb1.Enabled = false;
                    pb2.Enabled = false;
                    wincounter++;
                    CheckForWinner(wincounter);

                    label1.Visible = true;

                    pb1 = null;
                    pb2 = null;


                }
                else
                {
                    tableLayoutPanel1.Enabled = false;
                    timer1.Start();
                    tableLayoutPanel1.Enabled = true;
                    if (pb1 == pb2)
                    {

                        label1.Visible = false;
                        timer1.Interval = 1000;
                        pb1.ImageLocation = PATH + BACKGROUNDIMAGE;
                        pb2.ImageLocation = PATH + BACKGROUNDIMAGE;


                        pb1 = null;
                        pb2 = null;
                        return;
                    }


                }

            }

        }

        private void CheckForWinner(int wincounter)
        {
            if (wincounter == 8)
            {
                MessageBox.Show("You matched all the pictures! " + seconds.ToString() + " seconds needed", "well done");

            }



        }

        private void RandomizeArray(string[] array)
        {
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int z = r.Next(array.Length);
                string tmp = array[z];
                array[z] = array[i];
                array[i] = tmp;
            }

        }

        private void LoadImage()
        {
            string[] images = new string[16];
            images[0] = "bild1.png";
            images[1] = "bild1.png";
            images[2] = "bild2.png";
            images[3] = "bild2.png";
            images[4] = "bild3.png";
            images[5] = "bild3.png";
            images[6] = "bild4.png";
            images[7] = "bild4.png";
            images[8] = "bild5.png";
            images[9] = "bild5.png";
            images[10] = "bild6.png";
            images[11] = "bild6.png";
            images[12] = "bild7.png";
            images[13] = "bild7.png";
            images[14] = "bild8.png";
            images[15] = "bild8.png";

            RandomizeArray(images);

            int i = 0;
            foreach (PictureBox pb in tableLayoutPanel1.Controls)
            {
                pb.ImageLocation = PATH + BACKGROUNDIMAGE;
                pb.BackgroundImage = Image.FromFile(PATH + images[i]);
                pb.Visible = true;
                pb.Enabled = true;
                pb.Tag = images[i];
                i++;
            }
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            



            timer1.Stop();



            pb2.ImageLocation = PATH + BACKGROUNDIMAGE;
            pb1.ImageLocation = PATH + BACKGROUNDIMAGE;
            pb1.Enabled = true;
            pb2.Enabled = true;
            pb2 = null;
            pb1 = null;




        }



        private void label1_Click_1(object sender, EventArgs e)
        {
            label1.Show();


        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            LoadImage();
            seconds = 0;
            wincounter = 0;
           


        }
    }
}
