using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gato.Game
{

    class Bar : Sitio
    {
        protected override void HacerTransaccion(Collider other)
        {
            other.gameObject.GetComponent<Persona>().ComprarEntrada();
        }
    }
}
