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
        viewer.Location = new Point(10,40);
        viewer.Size = new Size(600, 600);

        Button help = new Button();
        this.Controls.Add(help);
        help.Text = "Help";
        help.Location = new Point(10, 10);
        help.BackColor = Color.LightGray;

        Controls.Add(viewer);
    }

    
    private void afsluiten(object sender, EventArgs e)
    {
        Close();
    }
}