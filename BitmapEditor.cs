using System;
using System.Drawing;
using System.Windows.Forms;

public class BitmapEditor : Form
{
    BitmapControl viewer;

    public BitmapEditor()
    {
        this.Text = "Reversi";
        this.BackColor = Color.LightYellow;
        this.ClientSize = new Size(700, 700);
        this.StartPosition= FormStartPosition.CenterScreen;

        viewer = new BitmapControl();
        viewer.Location = new Point(10,200);
        viewer.Size = new Size(600, 600);

        Button help = new Button();
        this.Controls.Add(help);
        help.Text = "Help";
        help.Location = new Point(500, 40);
        help.Size = new Size(100, 20);
        help.BackColor = Color.LightGray;

        Button nieuwSpel = new Button();
        this.Controls.Add(nieuwSpel);
        nieuwSpel.Text = "Nieuw Spel";
        nieuwSpel.Location = new Point(500, 10);
        nieuwSpel.Size = new Size(100, 20);
        nieuwSpel.BackColor = Color.LightGray;

        ComboBox veldgrootte = new(); 
        this.Controls.Add(veldgrootte);
        veldgrootte.Location = new Point(500, 70);
        veldgrootte.Text = "Veldgrootte";
        veldgrootte.Size = new Size(100, 20);
        veldgrootte.Items.Add("4 bij 4");
        veldgrootte.Items.Add("6 bij 6");
        veldgrootte.Items.Add("8 bij 8");

        Controls.Add(viewer);
    }

    
    private void afsluiten(object sender, EventArgs e)
    {
        Close();
    }
}