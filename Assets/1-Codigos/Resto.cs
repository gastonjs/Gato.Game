using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gato.Game
{

    class Resto : Sitio
    {
        protected override void HacerTransaccion(Collider other)
        {
            other.gameObject.GetComponent<Persona>().ComprarComida();
        }
    }
}
