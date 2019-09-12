using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form_Laberinto
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

        /// <summary>
        /// Constructor para Backups
        /// </summary>
        /// <param name="iClone"></param>
        public Fila(Fila iClone)
        {
            Cod = iClone.Cod;

            Habitaciones = new List<Habitacion>();
            for (int i = 0; i < iClone.Habitaciones.Count; i++)
                Habitaciones.Add(new Habitacion(iClone.Habitaciones[i]));
        }

        public int Cod { get; private set; }

        public List<Habitacion> Habitaciones { get; set; }
    }
}