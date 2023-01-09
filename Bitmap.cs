using System;

delegate bool Functie(bool x, bool y);

public class Bitmap
{
    private bool[,] vakjes;

    public Bitmap(int br, int h)
    {   vakjes = new bool[br, h];
    }
    public Bitmap(Bitmap ander)
    {   vakjes = new bool[ander.Breedte, ander.Hoogte];
        Kopieer(ander);
    }
    public int Breedte
    {   get { return vakjes.GetLength(0); }
    }
    public int Hoogte
    {   get { return vakjes.GetLength(1); }
    }
    public void veranderKleur(int x, int y, bool b)
    {   vakjes[x, y] = b;
    }
    public bool vraagKleur(int x, int y)
    {   return vakjes[x, y];
    }
    private void combineer(Bitmap ander, Functie comb)
    {   for (int x = 0; x < Breedte; x++)
            for (int y = 0; y < Hoogte; y++)
                veranderKleur(x, y, comb(vraagKleur(x, y), ander.vraagKleur(x, y)));
    }
    private void Kopieer(Bitmap ander)
    {   combineer(ander, (a, b) => b);
    }

    private int buren(int x, int y)
    {   int x0 = x - 1; if (x0 < 0) x0 += Breedte;
        int y0 = y - 1; if (y0 < 0) y0 += Hoogte;
        int x1 = x + 1; if (x1 >= Breedte) x1 -= Breedte;
        int y1 = y + 1; if (y1 >= Hoogte) y1 -= Hoogte;
        int n = 0;
        if (vraagKleur(x0, y0)) n++;
        if (vraagKleur(x, y0)) n++;
        if (vraagKleur(x1, y0)) n++;
        if (vraagKleur(x0, y)) n++;
        if (vraagKleur(x1, y)) n++;
        if (vraagKleur(x0, y1)) n++;
        if (vraagKleur(x, y1)) n++;
        if (vraagKleur(x1, y1)) n++;
        return n;
    }
}