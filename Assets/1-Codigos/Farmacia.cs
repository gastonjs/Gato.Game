using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Gato.Game
{

    class Farmacia : Sitio
    {
        public GameObject Salud50;
        public Quaternion anguloSalud;
        public Transform posSalud;

        protected override void HacerTransaccion(Collider other)
        {
            other.gameObject.GetComponent<Persona>().ComprarMedicamentos();
            other.gameObject.GetComponent<Persona>().Tranquilo();

            //Instantiate(Salud50, posSalud.position, anguloSalud);
        }
    }
}
