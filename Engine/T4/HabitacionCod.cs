using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form_Laberinto
{
    public partial class Habitacion3D
    {
        private float _x { get; set; }

        private float _y { get; set; }

        private float _z { get; set; }

        private float _rh { get; set; }

        private float _gh { get; set; }

        private float _bh { get; set; }

        private float _rv { get; set; }

        private float _gv { get; set; }

        private float _bv { get; set; }

        public bool Puerta_Izq { get; set; } //Tiene puerta a la izquierda

        public bool Puerta_Der { get; set; } //Tiene puerta a la derecha

        public bool Puerta_Arr { get; set; } //Tiene puerta arriba

        public bool Puerta_Aba { get; set; } //Tiene puerta abajo

        public string ToVRML(Habitacion iHabitacion)
        {
            Puerta_Aba = iHabitacion.Puerta_Aba;
            Puerta_Arr = iHabitacion.Puerta_Arr;
            Puerta_Der = iHabitacion.Puerta_Der;
            Puerta_Izq = iHabitacion.Puerta_Izq;

            _x = VRML._M * (iHabitacion.X * 3);
            _z = VRML._M * (iHabitacion.Y * 3);
            _y = 0;

            _rh = (float)Laberinto.COLOR_HORIZONTAL.R / 255;
            _gh = (float)Laberinto.COLOR_HORIZONTAL.G / 255;
            _bh = (float)Laberinto.COLOR_HORIZONTAL.B / 255;

            _rv = (float)Laberinto.COLOR_VERTICAL.R / 255;
            _gv = (float)Laberinto.COLOR_VERTICAL.G / 255;
            _bv = (float)Laberinto.COLOR_VERTICAL.B / 255;

            return TransformText();
        }
    }
}