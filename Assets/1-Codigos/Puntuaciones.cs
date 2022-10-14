using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

namespace Gato.Game
{
    public class Puntuaciones : MonoBehaviour
    {
        public static int cantidadRugidos = 3;
        public static int cantidadPelotas = 33;
        public static int cantidadCiudadanos = 50;
        public static int cantidadMujeres = 5;
        public static int cantidadPolis = 5;
        public static int cantidadHombresA = 5;
        public static int cantidadHombresB = 15;
        public static int cantidadNenes = 20;
        public static int cantidadZombis = 1;
        public static int cantidadRatas = 1;
        internal static int cantidadMonedas = 0;
        internal static int cantidadAlfanumerico = 0;

        Text tCantidadRugidos;
        Text tCantidadPelotas;
        Text tCantidadCiudadanos;
        Text tCantidadZombies;
        Text tCantidadMonedas;

        public ControladorPausaGameOver controladorPausaGameOver;
        public Text tNotificaciones;
        public AudioClip sonidoFestejo;
        private AudioSource fuenteDeSonido;
        public int premioMataRata = 500;

        private int MAXNivelAlcanzado;
        private int MAXcantidadZombisActual;
        private int MAXcantidadRugidos;
        private int MAXcantidadPelotas;
        private int MAXcantidadCiudadanos;
        private int MAXcantidadMonedas;
        private int MAXcantidadAlfanumerico;

        //Text tPuntajeHamburguesasMax;
        //Text tPuntajePapasMax;
        //Text tPuntajeZombificacionMax;
        //Text tPuntajeGatoVidaMax;

        private void Awake()
        {
            fuenteDeSonido = GetComponent<AudioSource>();            
        }
        // Start is called before the first frame update
        void Start()
        {
            //MAXNivelAlcanzado = PlayerPrefs.GetInt("MAXNivelAlcanzado", 0);
            //MAXcantidadZombisActual = PlayerPrefs.GetInt("MAXcantidadZombisActual", 0);
            //MAXcantidadRugidos = PlayerPrefs.GetInt("MAXcantidadRugidos", 0);
            //MAXcantidadPelotas = PlayerPrefs.GetInt("MAXcantidadPelotas", 0);
            //MAXcantidadCiudadanos = PlayerPrefs.GetInt("MAXcantidadCiudadanos", 0);
            MAXcantidadMonedas = PlayerPrefs.GetInt("MAXcantidadMonedas", 0);
            //MAXcantidadAlfanumerico = PlayerPrefs.GetInt("MAXcantidadAlfanumerico", 0);            

            tCantidadRugidos = GameObject.Find("ContadorRugidos").GetComponent<Text>();
            tCantidadPelotas = GameObject.Find("ContadorPelotas").GetComponent<Text>();
            tCantidadCiudadanos = GameObject.Find("ContadorCiudadanos").GetComponent<Text>();
            tCantidadZombies = GameObject.Find("ContadorZombis").GetComponent<Text>();
            tCantidadMonedas = GameObject.Find("ContadorMonedas").GetComponent<Text>();

            cantidadZombis = PlayerPrefs.GetInt("cantidadXZombis", 1);
            cantidadRatas = 1; //TODO: HAY QUE VER QUE PASA EL DIA QUE QUIERA PONER VARIAS RATAS EN JUEGO.

            MostrarNotificacion();
        }

        internal static void ReiniciarPuntuaciones()
        {
            cantidadRugidos = 3;
            cantidadPelotas = 33;
            cantidadCiudadanos = 50;
            cantidadMujeres = 5;
            cantidadPolis = 5;
            cantidadHombresA = 5;
            cantidadHombresB = 15;
            cantidadNenes = 20;
            cantidadMonedas = 0;
            //PlayerPrefs.SetInt("GOORO", 0);
            cantidadAlfanumerico = 0;            
        }

        private void MostrarNotificacion()
        {
            StartCoroutine(EsperaNotificacion());
        }

        private void MostrarNotificacion(string unaNotificacion)
        {
            StartCoroutine(EsperaNotificacion(unaNotificacion));
        }

        public IEnumerator EsperaNotificacion( string unaNot)
        {
            tNotificaciones.text = unaNot;           

            yield return new WaitForSeconds(3);
            tNotificaciones.text = "";
        }

        public IEnumerator EsperaNotificacion()
        {
            if(cantidadZombis > 1)
            {
                //MostrarNotificacion("Muy Bien !!!");
                fuenteDeSonido.clip = sonidoFestejo;
                fuenteDeSonido.Play();

                tNotificaciones.text = "Cuidado ahora hay " + cantidadZombis + " Zombis";
            }
            else
            {                
                tNotificaciones.text = "Cuidado hay 1 Zombi";
            }
            
            yield return new WaitForSeconds(3);
            tNotificaciones.text = "";            
        }

        void OnGUI()
        {
            tCantidadRugidos.text = cantidadRugidos.ToString();
            tCantidadPelotas.text = cantidadPelotas.ToString();
            tCantidadCiudadanos.text = cantidadCiudadanos.ToString();
            tCantidadZombies.text = cantidadZombis.ToString();
            tCantidadMonedas.text = cantidadMonedas.ToString();
            
            //TODO: ESTO ES UNA CAGADA, CORREGIRLO CUANTO ANTES
            PlayerPrefs.SetInt("GOORO", cantidadMonedas);
            if (PlayerPrefs.GetInt("GOORO", 0) > PlayerPrefs.GetInt("MAXcantidadMonedas", 0))
            {
                PlayerPrefs.SetInt("MAXcantidadMonedas", PlayerPrefs.GetInt("GOORO", 0));                
            }
            

            if (0 == cantidadZombis || 0 == cantidadRatas)
            {
                Time.timeScale = 0.25f;
                GeneradorDeHabitantes.cantidadZombis++ ;
                PlayerPrefs.SetInt("cantidadXZombis", GeneradorDeHabitantes.cantidadZombis);

                //GuardarEstado(GeneradorDeHabitantes.cantidadZombis, cantidadZombis, cantidadRugidos, cantidadPelotas, cantidadCiudadanos, cantidadMonedas, cantidadAlfanumerico);

                cantidadZombis = GeneradorDeHabitantes.cantidadZombis;
                
                cantidadCiudadanos = 50;
                cantidadMujeres = 5;
                cantidadPolis = 5;
                cantidadHombresA = 5;
                cantidadHombresB = 15;
                cantidadNenes = 20;

                //SI MATO A LA RATA DEMOSLE UN PREMIO
                if (0 == cantidadRatas)
                {
                    //TODO: ESTO ES UNA CAGADA, CORREGIRLO CUANTO ANTES
                    PlayerPrefs.SetInt("GOORO", PlayerPrefs.GetInt("GOORO", 0) + premioMataRata);
                    cantidadMonedas += premioMataRata;
                    if (PlayerPrefs.GetInt("GOORO", 0) > PlayerPrefs.GetInt("MAXcantidadMonedas", 0))
                    {
                        PlayerPrefs.SetInt("MAXcantidadMonedas", PlayerPrefs.GetInt("GOORO", 0));
                    }
                }

                //TODO: PONER UN DELAY PORQUE PASA MUY RAPIDO TODO Y SE PIERDE EL LOGRO.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }

            if (0 == cantidadCiudadanos)
            {
                //GuardarEstado(GeneradorDeHabitantes.cantidadZombis, cantidadZombis, cantidadRugidos, cantidadPelotas, cantidadCiudadanos, cantidadMonedas, cantidadAlfanumerico);

                controladorPausaGameOver.ActivarPanelGameOver();
            }
        }

        private void GuardarEstado(int cantidadZombisNivel, int cantidadZombisActual, int cantidadRugidos, int cantidadPelotas, int cantidadCiudadanos, int cantidadMonedas, int cantidadAlfanumerico)
        {
            PlayerPrefs.SetInt("NivelAlcanzado", cantidadZombisNivel);
            PlayerPrefs.SetInt("cantidadZombisActual", cantidadZombisActual);
            PlayerPrefs.SetInt("cantidadRugidos", cantidadRugidos);
            PlayerPrefs.SetInt("cantidadPelotas", cantidadPelotas);
            PlayerPrefs.SetInt("cantidadCiudadanos", cantidadCiudadanos);
            PlayerPrefs.SetInt("cantidadMonedas", cantidadMonedas);
            PlayerPrefs.SetInt("cantidadAlfanumerico", cantidadAlfanumerico);
           
            if (cantidadZombisNivel > MAXNivelAlcanzado)
            {
                PlayerPrefs.SetInt("MAXNivelAlcanzado", cantidadZombisNivel);
            }
            if (cantidadZombisActual > MAXcantidadZombisActual)
            {
                PlayerPrefs.SetInt("MAXcantidadZombisActual", cantidadZombisActual);
            }
            if (cantidadRugidos > MAXcantidadRugidos)
            {
                PlayerPrefs.SetInt("MAXcantidadRugidos", cantidadRugidos);
            }
            if (cantidadPelotas > MAXcantidadPelotas)
            {
                PlayerPrefs.SetInt("MAXcantidadPelotas", cantidadPelotas);
            }
            if (cantidadCiudadanos > MAXcantidadCiudadanos)
            {
                PlayerPrefs.SetInt("MAXcantidadCiudadanos", cantidadCiudadanos);
            }
            if (cantidadMonedas > MAXcantidadMonedas)
            {
                PlayerPrefs.SetInt("MAXcantidadMonedas", cantidadMonedas);
            }
            if (cantidadAlfanumerico > MAXcantidadAlfanumerico)
            {
                PlayerPrefs.SetInt("MAXcantidadAlfanumerico", cantidadAlfanumerico);
            }
        }
    }
}

