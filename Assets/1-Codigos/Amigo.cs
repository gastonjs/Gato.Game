using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gato.Game
{
    abstract class Amigo : Ente
    {
        protected string _Nombre;
        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }
        protected float _Energia = 100;
        protected float Energia
        {
            get
            {
                return _Energia;
            }

            set
            {
                _Energia = value;
            }
        }
        protected float _Inteligencia = 0;
        protected float Inteligencia
        {
            get
            {
                return _Inteligencia;
            }

            set
            {
                _Inteligencia = value;
            }
        }
        protected float _Dinero = 0;
        protected float Dinero
        {
            get
            {
                return _Dinero;
            }

            set
            {
                _Dinero = value;
            }
        }
        protected float _Felicidad = 100;
        protected float Felicidad
        {
            get
            {
                return _Felicidad;
            }

            set
            {
                _Felicidad = value;
            }
        }
        protected float _Relax = 100;
        protected float Relax
        {
            get
            {
                return _Relax;
            }

            set
            {
                _Relax = value;
            }
        }        
    }
}
