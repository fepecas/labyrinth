using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Form_Laberinto
{
    /// <summary>
    /// Esta clase representa a una Habitacion del laberinto
    /// </summary>
    public class Habitacion
    {
        public Habitacion()
        {
            X = Y = -1;
            Tipo = TipoCasilla.LQ;
        }

        public Habitacion(int iX, int iY, TipoCasilla iTipo) //Constructor
        {
            X = iX;
            Y = iY;
            Tipo = iTipo;
            Puerta_Aba = Puerta_Arr = Puerta_Izq = Puerta_Der = false; //Todas inician cerradas
        }

        /// <summary>
        /// Constructor para clonacion
        /// </summary>
        /// <param name="iClone"></param>
        public Habitacion(Habitacion iClone)
        {
            Puerta_Aba = iClone.Puerta_Aba;
            Puerta_Arr = iClone.Puerta_Arr;
            Puerta_Der = iClone.Puerta_Der;
            Puerta_Izq = iClone.Puerta_Izq;
            EsLaEntrada = iClone.EsLaEntrada;
            EsLaSalida = iClone.EsLaSalida;
            X = iClone.X;
            Y = iClone.Y;
            Mapeada = iClone.Mapeada;
            EsSolucion = iClone.EsSolucion;
            Tipo = iClone.Tipo;
        }

        public bool Puerta_Izq { get; set; } //Tiene puerta a la izquierda

        public bool Puerta_Der { get; set; } //Tiene puerta a la derecha

        public bool Puerta_Arr { get; set; } //Tiene puerta arriba

        public bool Puerta_Aba { get; set; } //Tiene puerta abajo

        public bool EsLaEntrada { get; set; } //Identifica qué habitacion es la entrada al laberinto

        public bool EsLaSalida { get; set; } //Identifica qué habitacion es la salida al laberinto

        public int X { get; private set; } //Coordenada X

        public int Y { get; private set; } //Coordenada Y

        public bool Mapeada { get; set; } //Indica si ya fue recorrida en el arbol

        public bool EsSolucion { get; set; } //Indica si es parte del camino solucion

        public TipoCasilla Tipo { get; set; } //Tipo de casila

        public void Dibujar(TipoCasilla iTipo) //Se sobrecargó para hacer más legible el programa...
        {
            Tipo = iTipo;
            Dibujar(true);
        }

        public void Dibujar(ConsoleColor iColor)
        {
            //Console.ForegroundColor = iColor;
            //Dibujar(false);
        }

        public void Dibujar(bool iDefaultColor)
        {
            //String iCadena;
            //switch (Tipo)
            //{
            //    case TipoCasilla.US: iCadena = "US";
            //        if (iDefaultColor) Console.ForegroundColor = ConsoleColor.White;
            //        break;
            //    case TipoCasilla.LQ: iCadena = "LQ";
            //        if (iDefaultColor) Console.ForegroundColor = ConsoleColor.Blue;
            //        break;
            //    case TipoCasilla.PE: iCadena = "PE";
            //        if (iDefaultColor) Console.ForegroundColor = ConsoleColor.Red;
            //        break;
            //    default: iCadena = "XX"; break;
            //}

            //Console.SetCursorPosition(X * 3, Y * 3); //El 3 es para ajustar lo que se imprime
            //Console.Write(iCadena.Substring(0, 2) + " ");
        }

        public void Dibujar(Graphics formGraphics, Color iHorizontal, Color iVertical)
        {
            //Coordenadas dinámicas rectangulos horizontales
            int iH0 = Laberinto.X_ABS + Laberinto.TamanoCasilla * X;
            int iH1 = Laberinto.Y_ABS + Laberinto.TamanoCasilla * Y;
            int iHD = iH1 + Laberinto.TamanoCasilla;

            //Coordenadas dinámicas rectangulos verticales
            int iV0 = Laberinto.X_ABS + Laberinto.TamanoCasilla * X;
            int iV1 = Laberinto.Y_ABS + Laberinto.TamanoCasilla * Y;
            int iVD = iV0 + Laberinto.TamanoCasilla;

            using (SolidBrush b2 = new SolidBrush(iHorizontal))
            {
                if (!Puerta_Arr) //Horizontal arriba
                    formGraphics.FillRectangle(b2, new Rectangle(iH0, iH1, Laberinto.TamanoCasilla, Laberinto.ANCHO_LINEA));
                if (!Puerta_Aba) //Horizontal abajo
                    formGraphics.FillRectangle(b2, new Rectangle(iH0, iHD, Laberinto.TamanoCasilla, Laberinto.ANCHO_LINEA));
            }

            using (SolidBrush b1 = new SolidBrush(iVertical))
            {
                if (!Puerta_Izq) //Vertical izquierda
                    formGraphics.FillRectangle(b1, new Rectangle(iV0, iV1, Laberinto.ANCHO_LINEA, Laberinto.TamanoCasilla));
                if (!Puerta_Der) //Vertical derecha
                    formGraphics.FillRectangle(b1, new Rectangle(iVD, iV1, Laberinto.ANCHO_LINEA, Laberinto.TamanoCasilla));
            }

            //Marca la entrada o la salida
            if (EsLaEntrada || EsLaSalida)
            {
                Punto p = new Punto(Laberinto.TamanoCasilla, iH0, iH1);
                p.Dibujar(formGraphics);
            }
        }

        /// <summary>
        /// Salto de linea cuando se ejecuta en modo consola
        /// </summary>
        public static void Saltar()
        {
            //Console.WriteLine("\n"); //Salto de linea
        }

        /// <summary>
        /// Marca las habitaciones alrededor como PE
        /// </summary>
        public void Alrededor_PE()
        {
            //Arriba de la celda
            if (Y - 1 >= 0)
                if (Laberinto.Matriz[Y - 1].Habitaciones[X].Tipo.Equals(TipoCasilla.US))
                    Laberinto.Matriz[Y - 1].Habitaciones[X].Dibujar(TipoCasilla.PE);
            //Abajo de la celda
            if (Y < Laberinto.Matriz.Count - 1)
                if (Laberinto.Matriz[Y + 1].Habitaciones[X].Tipo.Equals(TipoCasilla.US))
                    Laberinto.Matriz[Y + 1].Habitaciones[X].Dibujar(TipoCasilla.PE);

            //A la izquierda de la celda
            if (X - 1 >= 0)
                if (Laberinto.Matriz[Y].Habitaciones[X - 1].Tipo.Equals(TipoCasilla.US))
                    Laberinto.Matriz[Y].Habitaciones[X - 1].Dibujar(TipoCasilla.PE);

            //A la derecha de la celda
            if (X < Laberinto.Matriz[0].Habitaciones.Count - 1)
                if (Laberinto.Matriz[Y].Habitaciones[X + 1].Tipo.Equals(TipoCasilla.US))
                    Laberinto.Matriz[Y].Habitaciones[X + 1].Dibujar(TipoCasilla.PE);
        }

        /// <summary>
        /// Busca y selecciona aleatoriamente una LQ adyacente
        /// </summary>
        /// <returns></returns>
        public void Conectar_Nueva_LQ()
        {
            Habitacion h_rnd_lq = null;
            Random r = new Random(DateTime.Now.Millisecond);
            bool b_hay_lq = false;
            while (!b_hay_lq) //Mientras que no encuentre una LQ adyacente, sigue buscando
            {
                int rnd_lq_ady = r.Next(1, 5); //Aleatoriamente elije donde buscar

                switch (rnd_lq_ady) //Solo son 4 las posibles celdas adyacentes a una habitacion
                {
                    case 1: //Está arriba de la nueva LQ
                        if (Y - 1 >= 0)
                        {
                            h_rnd_lq = Laberinto.Matriz[Y - 1].Habitaciones[X];
                            if (!h_rnd_lq.Tipo.Equals(TipoCasilla.LQ)) continue;

                            h_rnd_lq.Puerta_Aba = true;
                            Puerta_Arr = true;

                            b_hay_lq = true; //Encontró LQ, entonces rompe el ciclo
                        }
                        break;
                    case 2: //Está abajo de la nueva LQ
                        if (Y < Laberinto.Matriz.Count - 1)
                        {
                            h_rnd_lq = Laberinto.Matriz[Y + 1].Habitaciones[X];
                            if (!h_rnd_lq.Tipo.Equals(TipoCasilla.LQ)) continue;

                            h_rnd_lq.Puerta_Arr = true;
                            Puerta_Aba = true;

                            b_hay_lq = true; //Encontró LQ, entonces rompe el ciclo
                        }
                        break;
                    case 3: //Está a la izquierda de la nueva LQ
                        if (X - 1 >= 0)
                        {
                            h_rnd_lq = Laberinto.Matriz[Y].Habitaciones[X - 1];
                            if (!h_rnd_lq.Tipo.Equals(TipoCasilla.LQ)) continue;

                            h_rnd_lq.Puerta_Der = true;
                            Puerta_Izq = true;

                            b_hay_lq = true; //Encontró LQ, entonces rompe el ciclo
                        }
                        break;
                    case 4: //Está a la derecha de la nueva LQ
                        if (X < Laberinto.Matriz[0].Habitaciones.Count - 1)
                        {
                            h_rnd_lq = Laberinto.Matriz[Y].Habitaciones[X + 1];
                            if (!h_rnd_lq.Tipo.Equals(TipoCasilla.LQ)) continue;

                            h_rnd_lq.Puerta_Izq = true;
                            Puerta_Der = true;

                            b_hay_lq = true; //Encontró LQ, entonces rompe el ciclo
                        }
                        break;
                }
            }

            //h_rnd_lq.Dibujar(ConsoleColor.Yellow); //Color para debug...
        }

        /// <summary>
        /// Resaltra el centro de una habitacion para reconocer la ruta que la resuelve
        /// </summary>
        public void Resaltar(Graphics formGraphics, Color iColor)
        {
            if (EsSolucion)
            {
                using (SolidBrush b = new SolidBrush(iColor))
                {
                    int l = Laberinto.TamanoCasilla;
                    int X0 = X * l + (int)(l / 8) + Laberinto.X_ABS + 2 * Laberinto.ANCHO_LINEA;
                    int Y0 = Y * l + (int)(l / 8) + Laberinto.Y_ABS + Laberinto.ANCHO_LINEA;
                    formGraphics.FillRectangle(b, new Rectangle(X0, Y0, (int)(3 * l / 4), (int)(3 * l / 4)));
                }
            }
        }
    }
}