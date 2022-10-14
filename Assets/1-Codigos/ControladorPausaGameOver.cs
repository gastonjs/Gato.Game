using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gato.Game
{
    public class ControladorPausaGameOver : MonoBehaviour
    {
        public GameObject panelPausa;
        public GameObject panelGameOver;
        public Text puntaje;
        private AudioSource fuenteAudio;

        void Start()
        {
            fuenteAudio = GetComponent<AudioSource>();            
        }

        public void ActivarPanelPausa()
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0;
        }

        public void DesactivarPanelPausa()
        {
            panelPausa.SetActive(false);
            Time.timeScale = 1;
        }

    
        public void ActivarPanelGameOver()
        {
            puntaje.text =  "$AR: " + PlayerPrefs.GetInt("GOORO", 0);

            fuenteAudio.Play();
            panelGameOver.SetActive(true);
            //Time.timeScale = 0;
        }

        public void DonarPATREON()
        {
            Application.OpenURL("www.patreon.com/GatoGame");
        }

        public void DesactivarPanelGameOver()
        {
            panelGameOver.SetActive(false);
            Time.timeScale = 1;
        }

        public void ReiniciarNivel001()
        {
            //"BuenosAiresCiudadNivel001"
            Puntuaciones.ReiniciarPuntuaciones();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        public void VolverMenu()
        {
            Puntuaciones.ReiniciarPuntuaciones();
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }
    }
}