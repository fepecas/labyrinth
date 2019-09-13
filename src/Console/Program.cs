using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laberinto
{
    /// <summary>
    /// Esta enumeracion sive para abstraer los tipos de casillas
    /// </summary>
    public enum TipoCasilla
    {
        US, //Habitaciones no adyacentes a los cuartos
        LQ, //Habitaciones comunicadas a traves de puertas
        PE  //Habitaciones adyacentes a los cuartos de estar pero sin puertas
    }

    /// <summary>
    /// Cada fila almacena las instancias de sus habitaciones
    /// </summary>
    public class Fila
    {
        public Fila(int iCodigo) //Constructor
        {
            Cod = iCodigo;
            Habitaciones = new List<Habitacion>();
        }

        public int Cod { get; private set; }

        public List<Habitacion> Habitaciones { get; set; }
    }

    /// <summary>
    /// Esta clase representa a una Habitacion del laberinto
    /// </summary>
    public class Habitacion
    {
        public Habitacion(int iX, int iY, TipoCasilla iTipo) //Constructor
        {
            X = iX;
            Y = iY;
            Tipo = iTipo;
            Puerta_Aba = Puerta_Arr = Puerta_Izq = Puerta_Der = false; //Todas inician cerradas
        }

        public bool Puerta_Izq { get; set; } //Tiene puerta a la izquierda

        public bool Puerta_Der { get; set; } //Tiene puerta a la derecha

        public bool Puerta_Arr { get; set; } //Tiene puerta arriba

        public bool Puerta_Aba { get; set; } //Tiene puerta abajo

        public int X { get; private set; } //Coordenada X

        public int Y { get; private set; } //Coordenada T

        public TipoCasilla Tipo { get; set; } //Tipo de casila

        public void Dibujar(TipoCasilla iTipo) //Se sobrecargó para hacer más legible el programa...
        {
            Tipo = iTipo;
            Dibujar(true);
        }

        public void Dibujar(ConsoleColor iColor)
        {
            Console.ForegroundColor = iColor;
            Dibujar(false);
        }

        public void Dibujar(bool iDefaultColor)
        {
            String iCadena;
            switch (Tipo)
            {
                case TipoCasilla.US: iCadena = "US";
                    if (iDefaultColor) Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TipoCasilla.LQ: iCadena = "LQ";
                    if (iDefaultColor) Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case TipoCasilla.PE: iCadena = "PE";
                    if (iDefaultColor) Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default: iCadena = "XX"; break;
            }

            Console.SetCursorPosition(X * 3, Y * 3); //El 3 es para ajustar lo que se imprime
            Console.Write(iCadena.Substring(0, 2) + " ");
        }

        public static void Saltar()
        {
            Console.WriteLine("\n"); //Salto de linea
        }

        /// <summary>
        /// Marca las habitaciones alrededor como PE
        /// </summary>
        public void Alrededor_PE()
        {
            //Arriba de la celda
            if (Y - 1 >= 0)
                if (Program.Matriz[Y - 1].Habitaciones[X].Tipo.Equals(TipoCasilla.US))
                    Program.Matriz[Y - 1].Habitaciones[X].Dibujar(TipoCasilla.PE);
            //Abajo de la celda
            if (Y < Program.Matriz.Count - 1)
                if (Program.Matriz[Y + 1].Habitaciones[X].Tipo.Equals(TipoCasilla.US))
                    Program.Matriz[Y + 1].Habitaciones[X].Dibujar(TipoCasilla.PE);

            //A la izquierda de la celda
            if (X - 1 >= 0)
                if (Program.Matriz[Y].Habitaciones[X - 1].Tipo.Equals(TipoCasilla.US))
                    Program.Matriz[Y].Habitaciones[X - 1].Dibujar(TipoCasilla.PE);

            //A la derecha de la celda
            if (X < Program.Matriz[0].Habitaciones.Count - 1)
                if (Program.Matriz[Y].Habitaciones[X + 1].Tipo.Equals(TipoCasilla.US))
                    Program.Matriz[Y].Habitaciones[X + 1].Dibujar(TipoCasilla.PE);
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
                            h_rnd_lq = Program.Matriz[Y - 1].Habitaciones[X];
                            if (!h_rnd_lq.Tipo.Equals(TipoCasilla.LQ)) continue;

                            h_rnd_lq.Puerta_Aba = true;
                            Puerta_Arr = true;

                            b_hay_lq = true; //Encontró LQ, entonces rompe el ciclo
                        }
                        break;
                    case 2: //Está abajo de la nueva LQ
                        if (Y < Program.Matriz.Count - 1)
                        {
                            h_rnd_lq = Program.Matriz[Y + 1].Habitaciones[X];
                            if (!h_rnd_lq.Tipo.Equals(TipoCasilla.LQ)) continue;

                            h_rnd_lq.Puerta_Arr = true;
                            Puerta_Aba = true;

                            b_hay_lq = true; //Encontró LQ, entonces rompe el ciclo
                        }
                        break;
                    case 3: //Está a la izquierda de la nueva LQ
                        if (X - 1 >= 0)
                        {
                            h_rnd_lq = Program.Matriz[Y].Habitaciones[X - 1];
                            if (!h_rnd_lq.Tipo.Equals(TipoCasilla.LQ)) continue;

                            h_rnd_lq.Puerta_Der = true;
                            Puerta_Izq = true;

                            b_hay_lq = true; //Encontró LQ, entonces rompe el ciclo
                        }
                        break;
                    case 4: //Está a la derecha de la nueva LQ
                        if (X < Program.Matriz[0].Habitaciones.Count - 1)
                        {
                            h_rnd_lq = Program.Matriz[Y].Habitaciones[X + 1];
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
    }

    /// <summary>
    ///Algoritmo de autoconstruccion de laberintos basado
    ///en las teorias de simulacion.
    ///ORIENTADO A OBJETOS... por eso las clases en el programa
    /// </summary>
    internal class Program
    {
        public static List<Fila> Matriz { get; set; }

        private static void Main(string[] args)
        {
            int iAncho, iAlto;
            int rnd_fila, rnd_col;
            Matriz = new List<Fila>();

            try
            {
                //----- i1. Leer tamaño de la matriz
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Generador básico de laberintos v0.1 - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("By @fepecas\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("------------------------");
                Console.WriteLine("-------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n¿Cuánto de ancho?: ");
                iAncho = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("¿Cuánto de alto?: ");
                iAlto = Convert.ToInt32(Console.ReadLine());
                if (iAlto < 4 || iAncho < 4) return; //Debe tener más de 4 filas de alto y 4 columnas de ancho
                Console.Clear();
                Console.WriteLine("Presione repetidamente ENTER para ver autoconstrucción...");
                Console.ReadLine();
                Console.Clear();

                //----- i2. Dibuja toda una matriz con espacios US
                for (int j = 0; j < iAlto; j++)
                {
                    Fila f = new Fila(j + 1); //Crea una nueva fila de habitaciones
                    Matriz.Add(f); //Almacena en la matriz cada fila

                    for (int i = 0; i < iAncho; i++)
                    {
                        Habitacion h = new Habitacion(i, j, TipoCasilla.US);
                        f.Habitaciones.Add(h); //Almacena la instancia
                        h.Dibujar(true);
                    }

                    Habitacion.Saltar();
                }

                //----- i3. Seleccion de una coordenada aleatoria
                Random r = new Random(DateTime.Now.Millisecond);
                rnd_fila = r.Next(1, iAlto) - 1;
                rnd_col = r.Next(1, iAncho) - 1;

                //----- i4. Convierte la celda aleatoria a tipo LQ
                Habitacion h_nueva_lq = Matriz[rnd_fila].Habitaciones[rnd_col];
                h_nueva_lq.Tipo = TipoCasilla.LQ;
                h_nueva_lq.Dibujar(true);

                //----- i5. Selecciona las habitaciones alrededor y las vuelve PE
                h_nueva_lq.Alrededor_PE();

                //----- i6. Elegir aleatoriamente una de las PE que haya en la matriz
                bool b_quedan_pe = true;
                while (b_quedan_pe) //Mientras hayan habitaciones PE en la matríz
                {
                    //Escoge una fila al azar
                    rnd_fila = r.Next(iAlto);

                    //Selecciona todos los PE en esa fila
                    List<Habitacion> ls = Matriz[rnd_fila].Habitaciones.FindAll(t => t.Tipo.Equals(TipoCasilla.PE));

                    //Si no encontró PE, continua el ciclo para buscar otra
                    if (ls == null || ls.Count == 0) continue;

                    Console.ReadLine();

                    Habitacion h_pe = ls[r.Next(ls.Count)]; //Escoge una de las PE al azar
                    h_pe.Dibujar(TipoCasilla.LQ); //Vuelve la PE de tipo LQ
                    h_pe.Alrededor_PE(); //Rodea con PE la nueva LQ. Solo aplica para los US
                    h_pe.Conectar_Nueva_LQ(); //Abre las puertas de la habitacion

                    for (int i = 0; i < Matriz.Count; i++) //Valida que no queden PE en la matriz
                    {
                        List<Habitacion> tmp = Matriz[i].Habitaciones.FindAll(h => h.Tipo.Equals(TipoCasilla.PE));
                        if (tmp.Count > 0)
                        { b_quedan_pe = true; break; }
                        else
                            b_quedan_pe = false;
                    }
                }

                //Mensaje final
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Ya");
                Console.WriteLine("pudo");
                Console.WriteLine("verificar gráficamente");
                Console.WriteLine("cómo se autoconstruye un laberinto.");
                Console.WriteLine("Depure el código fuente de la consola para más detalle.\n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Gracias!!!");
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Ocurrió un error \n\n" + e.ToString());
                throw;
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}