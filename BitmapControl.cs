using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

public class BitmapControl : UserControl
{
    private Bitmap model;

    public BitmapControl()
    {
        model = new Bitmap(600, 600);
        Paint += teken;
        MouseClick += klik;
        MouseMove += beweeg;
    }
    public int Diameter
    {
        get
        {
            Size s = ClientSize;
            return Math.Min(s.Width , s.Height );
        }
    }
    private void teken(object sender, PaintEventArgs e)
    {
        int w = 6;//model.Breedte;
        int h = 6;//model.Hoogte;
        int d = 70;
        for (int y = 0; y <= 7; y++)
            e.Graphics.DrawLine(Pens.LightGray, 0, y * d, w * d, y * d);
        for (int x = 0; x <= 7; x++)
            e.Graphics.DrawLine(Pens.LightGray, x * d, 0, x * d, h * d);
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                Brush b;
                if (model.vraagKleur(x, y))
                    b = Brushes.DarkRed;
                else b = Brushes.White;
                e.Graphics.FillEllipse(b, x * d + 1, y * d + 1, d - 1, d - 1);
            }
        }
        int rx = w * d + 1;
        int ry = h * d + 1;

        Brush bg = new SolidBrush(BackColor);
        e.Graphics.FillRectangle(bg, rx, 0, Width - rx, Height);
        e.Graphics.FillRectangle(bg, 0, ry, Width, Height - ry);
    }
    override protected void OnPaintBackground(PaintEventArgs e)
    {
    }
    private void vergroot(object sender, EventArgs e)
    {
        Invalidate();
    }
    private void klik(object sender, MouseEventArgs mea)
    {
        int d = Diameter;
        int x = mea.X / d;
        int y = mea.Y / d;
        if (x >= 0 && x < model.Breedte && y >= 0 && y < model.Hoogte)
            model.veranderKleur(x, y, mea.Button == MouseButtons.Left);
        Invalidate();
    }
    private void beweeg(object sender, MouseEventArgs mea)
    {
        if (mea.Button == MouseButtons.Left || mea.Button == MouseButtons.Right)
            klik(sender, mea);
    }
    /*public void uitvoeren(object sender, EventArgs e)
    {
        switch (sender.ToString())
        {
            case "Clear": model.Clear(); break;
            case "Invert": model.Invert(); break;
            case "Bold": model.Bold(); break;
            case "Outline": model.Outline(); break;
            case "Left": model.Left(); break;
            case "Right": model.Right(); break;
            case "Up": model.Up(); break;
            case "Down": model.Down(); break;
            case "Step": model.Life(); break;
        }
        Invalidate();
    }*/
}