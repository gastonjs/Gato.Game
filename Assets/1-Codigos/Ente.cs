using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gato.Game 
{ 
    abstract class Ente : MonoBehaviour
    {
        protected float _Vida = 100;
        protected float Vida 
        {
            get
            {
                return _Vida;
            }

            set 
            {
                _Vida = value;
            }
        }
        protected bool Muerto
        {
            get
            {
                if (Vida <= 0)
                {
                    return true;
                }
                return false;
            }           
        }

        public GeneradorDeHabitantes refGeneradorPoblacional;

        internal abstract void Tranquilo();

        

        protected bool invencible = false;
        protected float tiempoInvencible = 1f;
        
        protected float tiempoEntreAtaque = 1.5f;
        protected float temporizador = 0.0f;
        protected IEnumerator Invulnerabilidad()
        {
            invencible = true;
            yield return new WaitForSeconds(tiempoInvencible);
            invencible = false;
        }

        protected IEnumerator Esperar(float tiempoEspera)
        {
            
            yield return new WaitForSeconds(tiempoEspera);
            
        }


        //protected Estado Esta2 { get => esta2; set => esta2 = value; }
        //private Estado esta2;
        
        protected AudioSource fuenteDeSonido;

        

        //-------------------------------------------------
        public abstract void TomarDaño(float DañoRecibido);
        public abstract void Curarse(float Curacion);
        public abstract void Morir();



        public bool EstaVivo()
        {
            return !Muerto;
        }

        protected struct RelSitioNecesidad 
        {
            public string nombre;
            public float valPropiedad;
            public Transform sitio;

            public RelSitioNecesidad( string nom, float val, Transform sit) 
            {
                this.nombre = nom;
                this.valPropiedad = val;
                this.sitio = sit;
            }
        }
    }
}