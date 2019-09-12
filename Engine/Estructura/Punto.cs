using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Form_Laberinto
{
    public class Punto
    {
        public static Color COLOR_PUNTO { get { return Color.OrangeRed; } }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Diametro { get; private set; }

        public Punto(int iDiametro, int iX, int iY)
        {
            X = iX; Y = iY;
            Diametro = iDiametro;
        }

        public void Dibujar(Graphics formGraphics)
        {
            using (SolidBrush b = new SolidBrush(COLOR_PUNTO))
            {
                int X0 = (int)(X + Diametro / 4) + Laberinto.ANCHO_LINEA;
                int Y0 = (int)(Y + Diametro / 4) + Laberinto.ANCHO_LINEA;
                formGraphics.FillEllipse(b, new Rectangle(X0, Y0, (int)(Diametro / 2), (int)(Diametro / 2)));
            }
        }
    }
}