using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gato.Game
{ 
    abstract class Persona : Amigo 
    {
        //Lugares para saciar las necesidades basicas:
        //Vida:
        //public Transform [] Sitios;
        

        protected Transform unaFarmacia;

        //Energia:
        protected Transform unRestaurante;

        //Inteligencia:
        protected Transform unaEscuela;

        //Dinero:
        protected Transform unTrabajo;

        //Felicidad:
        protected Transform unBar;

        //Relax:
        protected Transform unaCasa;

        //Otra farmacia
        protected Transform unFarmacity;

        //como saber si esta quieto?
        protected Transform posicionAnterior;

        protected bool primerAtaqueRecibido = true;

        public abstract void ComprarComida();
        public abstract void ComprarMedicamentos();
        public abstract void Dormir();
        public abstract void ComprarEntrada();
        public abstract void ComprarLibro();
        public abstract void Trabajar();
    }
}
