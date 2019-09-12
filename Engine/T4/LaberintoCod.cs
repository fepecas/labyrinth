using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form_Laberinto
{
    /// <summary>
    /// Clase basica para almacenar una coordenada solucion
    /// </summary>
    public class Solucion
    {
        public Solucion(int ix, int iz)
        {
            X = ix; Z = iz;
        }

        public int X { get; set; }

        public int Z { get; set; }
    }

    public partial class Laberinto3D
    {
        public static List<Solucion> Camino { get; set; }

        /// <summary>
        /// Inizializa el camino
        /// </summary>
        public static void Iniciar()
        { Laberinto3D.Camino = new List<Solucion>(); }

        /// <summary>
        /// Construye la llave de interpolación para el movimiento del avatar.
        /// Es de diferencia constante frente al total de movimientos
        /// </summary>
        /// <returns></returns>
        public static String InterpolationKey
        {
            get
            {
                //Calcula la llave para interpolacion
                String sKey = String.Empty;
                float f = (float)1 / (Camino.Count);
                float a = 0;

                for (int i = 0; i < Camino.Count + 1; i++)
                {
                    sKey = sKey + " " + a.ToString() + "\n\t\t\t";
                    a += f;
                }

                sKey = sKey.Replace(',', '.');

                return sKey;
            }
        }
    }
}