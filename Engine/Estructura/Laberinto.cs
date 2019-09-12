using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Form_Laberinto
{
    public enum Direccion
    {
        Ninguno,
        IzquierdaDerecha,
        ArribaAbajo
    }

    public class Laberinto
    {
        public static List<Fila> Matriz { get; set; } //Contiene toda la matriz

        private static List<Fila> Matriz_Backup { get; set; } //Contiene un respaldo de la matriz original

        #region Constantes

        public const int X_ABS = 10;           //Coordenada superior izquierda donde se pinta el laberinto
        public const int Y_ABS = 30;
        public const int ANCHO_LINEA = 1;     //Ancho de la linea de cada casilla

        #endregion Constantes

        public static int Ancho { get; set; } //Ancho en cantidad de casillas

        public static int Alto { get; set; } //Alto en cantidad de casillas

        public static int Retardo_ms { get; set; } //Retardo en milisegundos para ver efecto

        public static Direccion Recorrido { get; set; } //Indica de dónde a dónde se recorre el laberinto

        public static int[,] AB { get; set; } //Matriz con las coordenadas de entrada y salida

        public static Color[] ColoresCamino { get; set; } //Matriz de colores de los caminos

        public static int Objetivos { get; set; } //Cantidad de objetivos a generar

        public int Y_DIFF { get { return Y_ABS + TamanoCasilla - ANCHO_LINEA; } }//"Y" con desplazamiento para simplificar el código

        public static int TamanoCasilla { get; set; } //Tamaño de una casilla o habitacion

        public static Color COLOR_VERTICAL { get { return Color.Violet; } }

        public static Color COLOR_HORIZONTAL { get { return Color.LightSkyBlue; } }

        public static bool Dibujado { get; set; }

        /// <summary>
        /// Genera un laberinto de las dimensiones especificadas
        /// </summary>
        /// <param name="iAncho"></param>
        /// <param name="iAlto"></param>
        public static void Generar()
        {
            Matriz = new List<Fila>();
            int rnd_fila, rnd_col;

            //----- i1. Leer tamaño de la matriz
            //Console.WriteLine("¿Cuánto de ancho?: ");
            //iAncho = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("¿Cuánto de alto?: ");
            //iAlto = Convert.ToInt32(Console.ReadLine());
            //if (iAlto < 4 || iAncho < 4) return; //Debe tener más de 4 filas de alto y 4 columnas de ancho
            //Console.Clear();

            //----- i2. Dibuja toda una matriz con espacios US
            for (int j = 0; j < Alto; j++)
            {
                Fila f = new Fila(j + 1); //Crea una nueva fila de habitaciones
                Matriz.Add(f); //Almacena en la matriz cada fila

                for (int i = 0; i < Ancho; i++)
                {
                    Habitacion h = new Habitacion(i, j, TipoCasilla.US);
                    f.Habitaciones.Add(h); //Almacena la instancia
                    h.Dibujar(true);
                }

                Habitacion.Saltar();
            }

            //----- i3. Seleccion de una coordenada aleatoria
            Random r = new Random(DateTime.Now.Millisecond);
            rnd_fila = r.Next(1, Alto) - 1;
            rnd_col = r.Next(1, Ancho) - 1;

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
                //Console.ReadKey();

                //Escoge una fila al azar
                rnd_fila = r.Next(Alto);

                //Selecciona todos los PE en esa fila
                List<Habitacion> ls = Matriz[rnd_fila].Habitaciones.FindAll(t => t.Tipo.Equals(TipoCasilla.PE));

                //Si no encontró PE, continua el ciclo para buscar otra
                if (ls == null || ls.Count == 0) continue;

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

            //----- i7. Escoge una entrada-salida al azar
            int a = r.Next(Alto);
            int b = r.Next(Alto);
            int c = r.Next(1, Ancho);
            int d = r.Next(Ancho);

            AB = new int[2, 2]; //Aqui almacenará las coordenadas entrada-salida

            switch (Recorrido)
            {
                case Direccion.IzquierdaDerecha:
                    Matriz[a].Habitaciones[0].EsLaEntrada = true; //Marca la entrada
                    Matriz[b].Habitaciones[Ancho - 1].EsLaSalida = true; //Marca la salida

                    Matriz[a].Habitaciones[0].Puerta_Izq = true;
                    Matriz[b].Habitaciones[Ancho - 1].Puerta_Der = true;

                    AB[0, 0] = 0; AB[0, 1] = a; //A: Coordenada entrada
                    AB[1, 0] = Ancho - 1; AB[1, 1] = b; //B: Coordenada salida
                    break;

                case Direccion.ArribaAbajo:
                    Matriz[0].Habitaciones[c].EsLaEntrada = true;//Marca la entrada
                    Matriz[Alto - 1].Habitaciones[d].EsLaSalida = true;//Marca la salida

                    Matriz[0].Habitaciones[c].Puerta_Arr = true;
                    Matriz[Alto - 1].Habitaciones[d].Puerta_Aba = true;

                    AB[0, 0] = c; AB[0, 1] = 0; //A: Coordenada entrada
                    AB[1, 0] = d; AB[1, 1] = Alto - 1; //B: Coordenada salida
                    break;
            }

            //----- i8. Carga la matriz de colores para los caminos
            ColoresCamino = new Color[11];
            ColoresCamino[0] = Color.Yellow;
            ColoresCamino[1] = Color.Salmon;
            ColoresCamino[2] = Color.Pink;
            ColoresCamino[3] = Color.White;
            ColoresCamino[4] = Color.Blue;
            ColoresCamino[5] = Color.Turquoise;
            ColoresCamino[6] = Color.Tomato;
            ColoresCamino[7] = Color.YellowGreen;
            ColoresCamino[8] = Color.Thistle;
            ColoresCamino[9] = Color.Silver;
            ColoresCamino[10] = Color.Orange;
        }

        /// <summary>
        /// Dibuja el laberinto en pantalla
        /// </summary>
        public static void Dibujar(Graphics formGraphics)
        {
            for (int i = 0; i < Matriz.Count; i++)
                for (int j = 0; j < Matriz[0].Habitaciones.Count; j++)
                    Matriz[i].Habitaciones[j].Dibujar(formGraphics, COLOR_HORIZONTAL, COLOR_VERTICAL);

            formGraphics.Dispose();
            Dibujado = true;
        }

        /// <summary>
        /// Resuelve el laberinto y muestra el resultado
        /// </summary>
        /// <param name="formGraphics"></param>
        public static void Resolver(Graphics formGraphics)
        {
            //Demora para ver efecto
            Thread.Sleep(Retardo_ms);

            //Dibuja tantos objetivos aleatorios como se hayan configurado
            bool bReversar = false;
            Habitacion A = Matriz[AB[0, 1]].Habitaciones[AB[0, 0]]; //Inicia en la entrada
            Habitacion B = null;

            Laberinto3D.Iniciar(); //Inicializa el camino solucion
            Random r = new Random(DateTime.Now.Millisecond);
            for (int p = Laberinto.Objetivos + 1; p > 0; p--)
            {
                if (p == 1)
                    B = Matriz[AB[1, 1]].Habitaciones[AB[1, 0]]; //Finaliza con la salida
                else
                    B = Matriz[r.Next(Alto)].Habitaciones[r.Next(Ancho)]; //Crea un objetivo aleatorio

                //Crea y resuelve el árbol del laberinto
                Nodo arbol = Crear_Arbol(A, B, bReversar);
                bReversar = true;

                //Dibuja la solución en pantalla
                for (int i = 0; i < Matriz.Count; i++)
                    for (int j = 0; j < Matriz[0].Habitaciones.Count; j++)
                        Matriz[i].Habitaciones[j].Resaltar(formGraphics, ColoresCamino[p - 1]);

                //Restaura las habitaciones recorridas resolviendo el laberinto
                for (int i = 0; i < Matriz.Count; i++)
                    for (int j = 0; j < Matriz[0].Habitaciones.Count; j++)
                    {
                        Matriz[i].Habitaciones[j].Mapeada = false;
                        Matriz[i].Habitaciones[j].EsSolucion = false;
                    }

                //Empalma y continua
                A = B;
                Thread.Sleep(Retardo_ms);
            }
        }

        /// <summary>
        /// Crea un arbol de recorrido entre las habitaciones A y B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        private static Nodo Crear_Arbol(Habitacion A, Habitacion B, bool iReservsar)
        {
            //Resuelve el laberinto de A hacia B
            return Recorrer(new Nodo(null, A), B, iReservsar);
        }

        /// <summary>
        /// Algoritmo recursivo para el arbol
        /// </summary>
        /// <param name="N"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        private static Nodo Recorrer(Nodo N, Habitacion B, bool iReversar)
        {
            #region Validación para romper

            //Valida si encontró el destino
            if (N != null)
                if (N.Actual.X == B.X)
                    if (N.Actual.Y == B.Y)
                    {
                        Trazar_Ruta(N, iReversar);
                        return null;
                    }

            #endregion Validación para romper

            #region Busca en habitaciones contiguas

            //Habitacion a la izquierda de N
            int CoordX = 0, CoordY = 0;

            if (N.Actual.Puerta_Izq && N.Actual.X > 0)
            {
                CoordX = N.Actual.X - 1;
                CoordY = N.Actual.Y;
                if (!Matriz[CoordY].Habitaciones[CoordX].Mapeada)
                    N.HijoIzq = Recorrer(new Nodo(N, Matriz[CoordY].Habitaciones[CoordX]), B, iReversar);
            }
            //Habitacion a la derecha de N
            if (N.Actual.Puerta_Der && N.Actual.X != Matriz[0].Habitaciones.Count - 1)
            {
                CoordX = N.Actual.X + 1;
                CoordY = N.Actual.Y;
                if (!Matriz[CoordY].Habitaciones[CoordX].Mapeada)
                    N.HijoDer = Recorrer(new Nodo(N, Matriz[CoordY].Habitaciones[CoordX]), B, iReversar);
            }
            //Habitacion arriba de N
            if (N.Actual.Puerta_Arr && N.Actual.Y > 0)
            {
                CoordX = N.Actual.X;
                CoordY = N.Actual.Y - 1;
                if (!Matriz[CoordY].Habitaciones[CoordX].Mapeada)
                    N.HijoArr = Recorrer(new Nodo(N, Matriz[CoordY].Habitaciones[CoordX]), B, iReversar);
            }
            //Habitacion abajo de N
            if (N.Actual.Puerta_Aba && N.Actual.Y != Matriz.Count - 1)
            {
                CoordX = N.Actual.X;
                CoordY = N.Actual.Y + 1;
                if (!Matriz[CoordY].Habitaciones[CoordX].Mapeada)
                    N.HijoAba = Recorrer(new Nodo(N, Matriz[CoordY].Habitaciones[CoordX]), B, iReversar);
            }

            #endregion Busca en habitaciones contiguas

            return N; //Retorna el nodo y sus hijos
        }

        /// <summary>
        /// Traza la ruta de una habitacion a otra
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        private static void Trazar_Ruta(Nodo iArbol, bool iReversar)
        {
            List<Solucion> lsNuevo = new List<Solucion>();

            //Marca las habitaciones que son solucion
            Nodo N = iArbol;
            while (N != null)
            {
                lsNuevo.Add(new Solucion(N.Actual.X, N.Actual.Y)); //Para el sistema de coordenadas 3D, el X,Y se vuelve X,Z
                N.Actual.EsSolucion = true;
                N = N.Padre;
            }

            lsNuevo.Reverse();
            Laberinto3D.Camino.AddRange(lsNuevo);
        }

        /// <summary>
        /// Cuando hay dos paredes juntas se deja una sola.
        /// Este método corrije las paredes en toda la matriz
        /// </summary>
        public static void QuitarParedesRedunantes()
        {
            for (int i = 0; i < Matriz.Count; i++)
            {
                for (int j = 0; j < Matriz[i].Habitaciones.Count; j++)
                {
                    //Puertas redundantes verticales
                    if (j + 1 <= Matriz[i].Habitaciones.Count - 1)
                        if (!Matriz[i].Habitaciones[j].Puerta_Der)
                            if (!Matriz[i].Habitaciones[j + 1].Puerta_Izq)
                                Matriz[i].Habitaciones[j].Puerta_Der = true;

                    //Puertas redundantes horizontales
                    if (i + 1 <= Matriz.Count - 1)
                        if (!Matriz[i].Habitaciones[j].Puerta_Aba)
                            if (!Matriz[i + 1].Habitaciones[j].Puerta_Arr)
                                Matriz[i].Habitaciones[j].Puerta_Aba = true;
                }
            }
        }

        /// <summary>
        /// Restaura el backup de la matriz para guardar compatibilidad entre 2D y 3D
        /// </summary>
        public static void CrearBackup()
        {
            Matriz_Backup = new List<Fila>();
            for (int i = 0; i < Matriz.Count; i++)
                Matriz_Backup.Add(new Fila(Matriz[i]));
        }

        /// <summary>
        /// Restaura el backup de la matriz para guardar compatibilidad entre 2D y 3D
        /// </summary>
        public static void RestaurarBackup() { Matriz = Matriz_Backup; }
    }
}