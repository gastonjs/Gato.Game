using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gato.Game
{
    abstract class Sitio : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (
                //(other.gameObject.CompareTag("Player"))
                //||
                (other.gameObject.CompareTag("Personas"))
               )
            {
                HacerTransaccion(other);

                other.gameObject.GetComponent<Persona>().Tranquilo();
            }
        }

        protected abstract void HacerTransaccion(Collider other);
    }
}
