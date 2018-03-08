using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createImage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ang = File.ReadAllLines(@"C:\dysk_d\wywal\ang.txt");
            string[] pol = File.ReadAllLines(@"C:\dysk_d\wywal\pl.txt");
            System.IO.DirectoryInfo di = new DirectoryInfo("translate");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            for (int i = 0; i < 3000; i++)
            {
                Image ss = DrawText(ang[i], pol[i]);
                Console.WriteLine($"id:{i} plik {ang[i]}");
                ss.Save($"translate\\{i}.bmp");
            }

        }

        private static Image DrawText(String angTxt, string polTxt)
        {
            Font font = new Font(FontFamily.GenericSansSerif, 32.0F, FontStyle.Bold);

            Color backColor = Color.Beige;
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);



            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap(400, 110);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush brushAng = new SolidBrush(Color.Red);
            Brush brushPol = new SolidBrush(Color.Green);

            drawing.DrawString(angTxt, font, brushAng, 0, 0);
            int x = 0;
            int y = 45;
            drawing.DrawString(polTxt, font, brushPol, x, y);

            drawing.Save();

            brushAng.Dispose();
            drawing.Dispose();

            return img;

        }
    }
}
