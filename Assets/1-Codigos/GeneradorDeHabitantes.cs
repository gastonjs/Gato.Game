using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Gato.Game
{
    public class GeneradorDeHabitantes : MonoBehaviour
    {
        public static int cantidadCiudadanos = 50;
        public static int cantidadMujeres = 5;
        public static int cantidadPolis = 5;
        public static int cantidadHombresA = 5;
        public static int cantidadHombresB = 15;
        public static int cantidadNenes = 20;
        public static int cantidadZombis = 1;
        public static int cantidadRatas = 1;

        //TODO: Va a haber otro mecanismo esto es para zafar ahora. 
        //Lugares para saciar las necesidades basicas:

        //public Transform [] Sitios;
        //Vida:
        public Transform unaFarmacia;

        //Energia:
        public Transform unRestaurante;

        //Inteligencia:
        public Transform unaEscuela;

        //Dinero:
        public Transform unTrabajo;

        //Felicidad:
        public Transform unBar;

        //Relax:
        public Transform unaCasa;

        //Otra farmacia por bug ciudadanos quietos en farmacia
        public Transform unFarmacity;
        //---------------------------


        public GameObject[] Ciudadanos;

        private Persona Poli_0 = null;
        private Persona Nana_0 = null;
        private Persona OliGarkA_0 = null;
        private Persona ClaseMierda_0 = null;        
        private Persona Benja_0 = null;
        public float deltaTime = 10f;

        void Start()
        {
            cantidadZombis = PlayerPrefs.GetInt("cantidadXZombis", 1);
            GenerarPoblacion(cantidadPolis, cantidadMujeres, cantidadHombresA, cantidadHombresB, cantidadNenes, cantidadZombis, cantidadRatas);
        }

        private void GenerarPoblacion(int cPolis, int cMujeres, int cHombresA, int cHombresB, int cNenes, int cZombis, int cRatas)
        {
            for (int i = 0; i < cPolis; i++)
            {
                Vector3 randomPos = Random.insideUnitSphere * 90;
                NavMesh.SamplePosition(randomPos, out NavMeshHit navHit, 90f, 1);

                randomPos = navHit.position;

                GameObject unPoli = Instantiate( Ciudadanos[6], randomPos, Quaternion.identity );
                GeneradorDeHabitantes generadorDeHabitantes = this;
                unPoli.GetComponent<Amigo>().refGeneradorPoblacional = generadorDeHabitantes;
                unPoli.GetComponent<Amigo>().Nombre = "Poli_" + i;
                
                Poli_0 = unPoli.GetComponent<Poli>();

                //yield return new WaitForSeconds(0.1f);                
            }
            for (int i = 0; i < cMujeres; i++)
            {
                Vector3 randomPos = Random.insideUnitSphere * 90;
                NavMesh.SamplePosition(randomPos, out NavMeshHit navHit, 90f, 1);

                randomPos = navHit.position;

                GameObject unaMujer = Instantiate( Ciudadanos[3], randomPos, Quaternion.identity);
                GeneradorDeHabitantes generadorDeHabitantes = this;
                unaMujer.GetComponent<Amigo>().refGeneradorPoblacional = generadorDeHabitantes;
                unaMujer.GetComponent<Amigo>().Nombre = "Nana_" + i;

                //yield return new WaitForSeconds(0.1f);                
            }
            for (int i = 0; i < cHombresA; i++)
            {
                Vector3 randomPos = Random.insideUnitSphere * 90;
                NavMesh.SamplePosition(randomPos, out NavMeshHit navHit, 90f, 1);

                randomPos = navHit.position;

                GameObject unHombreA = Instantiate(Ciudadanos[4], randomPos, Quaternion.identity);
                GeneradorDeHabitantes generadorDeHabitantes = this;
                unHombreA.GetComponent<Amigo>().refGeneradorPoblacional = generadorDeHabitantes;
                unHombreA.GetComponent<Amigo>().Nombre = "OliGarkA_" + i;
                //yield return new WaitForSeconds(0.1f);

            }
            for (int i = 0; i < cHombresB; i++)
            {
                Vector3 randomPos = Random.insideUnitSphere * 90;
                NavMesh.SamplePosition(randomPos, out NavMeshHit navHit, 90f, 1);

                randomPos = navHit.position;

                GameObject unHombreB = Instantiate(Ciudadanos[5], randomPos, Quaternion.identity);
                GeneradorDeHabitantes generadorDeHabitantes = this;
                unHombreB.GetComponent<Amigo>().refGeneradorPoblacional = generadorDeHabitantes;
                unHombreB.GetComponent<Amigo>().Nombre = "ClaseMierda_" + i;
                //yield return new WaitForSeconds(0.1f);

            }
            for (int i = 0; i < cNenes; i++)
            {
                Vector3 randomPos = Random.insideUnitSphere * 90;
                NavMesh.SamplePosition(randomPos, out NavMeshHit navHit, 90f, 1);

                randomPos = navHit.position;

                GameObject unNene = Instantiate(Ciudadanos[2], randomPos, Quaternion.identity);
                GeneradorDeHabitantes generadorDeHabitantes = this;
                unNene.GetComponent<Amigo>().refGeneradorPoblacional = generadorDeHabitantes;
                unNene.GetComponent<Amigo>().Nombre = "Benja_" + i;
                //yield return new WaitForSeconds(0.1f);
            }
            for (int i = 0; i < cZombis; i++)
            {
                GameObject unZombie = Instantiate(Ciudadanos[1], transform.position, Quaternion.identity);
                GeneradorDeHabitantes generadorDeHabitantes = this;
                unZombie.GetComponent<Ente>().refGeneradorPoblacional = generadorDeHabitantes;
                unZombie.GetComponent<Zombie>().SoyUnEx(4);
            }
            for (int i = 0; i < cRatas; i++)
            {
                GeneradorDeHabitantes generadorDeHabitantes = this;
                GameObject unaRata = Instantiate(Ciudadanos[0], transform.position, Quaternion.identity);
                unaRata.GetComponent<Ente>().refGeneradorPoblacional = generadorDeHabitantes;
            }
        }

        public void CrearZombieEnQueEra(Vector3 pos, int eraUn)
        {
            GeneradorDeHabitantes generadorDeHabitantes = this;
            GameObject unZombie = Instantiate(Ciudadanos[1], pos, Quaternion.identity);
            unZombie.GetComponent<Zombie>().SoyUnEx(eraUn);
            unZombie.GetComponent<Ente>().refGeneradorPoblacional = generadorDeHabitantes;

            //yield return new WaitForSeconds(0.1f);
        }

        internal void CrearCiudadanoEnQueEra(Vector3 position, int soyUnEx)
        {
            GameObject unCiudadano = Instantiate( Ciudadanos[soyUnEx], position, Quaternion.identity);
            GeneradorDeHabitantes generadorDeHabitantes = this;
            unCiudadano.GetComponent<Ente>().refGeneradorPoblacional = generadorDeHabitantes;
        }

        //private void FixedUpdate()
        //{
        //    deltaTime += Time.deltaTime;

        //    if (
        //        (deltaTime >= 10f) 
        //       )
        //    {
        //        Debug.Log("Logueando desde GeneradorDeHabilidades cada: "+deltaTime);
        //        Debug.Log("Nombre: "+ Poli_0.Nombre);


        //        deltaTime = 0;
        //    }
        //}
    }
}

