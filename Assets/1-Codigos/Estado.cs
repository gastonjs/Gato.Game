using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gato.Game 
{ 
    public abstract class Estado : MonoBehaviour
    {
        protected bool estadoBooleano = false;

        protected Estado(bool estadoBooleano)
        {
            EstadoBooleano = estadoBooleano;
        }

        protected bool EstadoBooleano { get => estadoBooleano; set => estadoBooleano = value; }
    }

    public class Muerto : Estado
    {
        public Muerto(bool estadoBooleano) : base(estadoBooleano)
        {
        }
    }

    public class Inmobil : Estado
    {
        public Inmobil(bool estadoBooleano) : base(estadoBooleano)
        {
        }
    }

    public class Camina : Estado
    {
        public Camina(bool estadoBooleano) : base(estadoBooleano)
        {
        }
    }
}