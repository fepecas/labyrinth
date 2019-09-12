using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form_Laberinto
{
    public partial class VRML
    {
        public const int _M = -1;

        private static StringBuilder sbHabitaciones = new StringBuilder();
        private static StringBuilder sbRecorrido = new StringBuilder();
        private static StringBuilder sbAvatar = new StringBuilder();

        /// <summary>
        /// Genera el código VRML para el laberinto autoconstruido
        /// </summary>
        /// <param name="iMatriz"></param>
        /// <returns></returns>
        public static String Crear(List<Fila> iMatriz)
        {
            //Construye las habitaciones
            Laberinto.QuitarParedesRedunantes();
            sbHabitaciones.Clear();
            for (int i = 0; i < iMatriz.Count; i++)
                for (int j = 0; j < iMatriz[0].Habitaciones.Count; j++)
                    sbHabitaciones.Append(new Habitacion3D().ToVRML(iMatriz[i].Habitaciones[j]));

            //Construye el recorrido con la solución
            sbRecorrido.Clear();
            sbRecorrido.Append(new Laberinto3D().TransformText());

            //Construye el Avatar
            sbAvatar.Clear();
            sbAvatar.Append(new Avatar3D().TransformText());

            return new VRML().TransformText();
        }
    }
}