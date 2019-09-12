using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form_Laberinto
{
    public class Nodo
    {
        public Nodo(Nodo iPadre, Habitacion iHabitacion)
        {
            Padre = iPadre;
            Actual = iHabitacion;
            Actual.Mapeada = true;
        }

        public Habitacion Actual { get; set; }

        public Nodo Padre { get; private set; }

        public Nodo HijoArr { get; set; }

        public Nodo HijoAba { get; set; }

        public Nodo HijoDer { get; set; }

        public Nodo HijoIzq { get; set; }
    }
}