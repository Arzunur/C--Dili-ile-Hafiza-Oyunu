using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaGame2
{
    public partial class Form1 : Form
    {
        Image[] resimler = {
            Properties.Resources._11, //resimlere bu koddan erişiyoruz. Resimleri Properties.Resources.resx eklemiştik.
            Properties.Resources._22, 
            Properties.Resources._33,
            Properties.Resources._44,
            Properties.Resources._55,
            Properties.Resources._66,
            Properties.Resources._77,
            Properties.Resources._88,
        };
        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
        PictureBox ilkkutu;
        int ilkIndeks, bulunan, deneme;
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mixingpicture();
        }

        private void mixingpicture()
        {
            Random rnd = new Random();
            for (int i = 0; i < 16; i++) //16 yerine indeksler.Length de denilebilirdi.
            {
                int sayi = rnd.Next(16);//0-15 kadar rastgele bir sayı seç 
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10));
            int indeksNo = indeksler[kutuNo - 1];
            kutu.Image = resimler[indeksNo];
            kutu.Refresh();

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkIndeks = indeksNo;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                ilkkutu.Image = null;
                kutu.Image = null;

                if (ilkIndeks == indeksNo)
                {
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;
                    if (bulunan == 8)
                    {
                        label1.Visible = true;
                        label1.Text = "TEBRİKLER";
                        label2.Visible = true;
                        label2.Text = deneme + ". denemede buldunuz.";
                        bulunan = 0;
                        deneme = 0;
                        foreach (Control kontrol in Controls) //Controls forma eklenen denetimleri,kontroller tutar
                        {
                            kontrol.Visible = true;
                        }
                        mixingpicture();
                    }
                    
                }
                ilkkutu = null;
            }
        }
    }
}

