using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPaneles : MonoBehaviour
{
    public GameObject panelMainMenu;
    public GameObject panelMundos;
    public GameObject panelPiano;
    public GameObject panelHighScore;
    public GameObject panelPersonajes;
    public GameObject panelCreditos;
    public GameObject panelSalir;

    public Text MaxORO;

    public AudioClip sTierno;
    public AudioClip sGOT;
    public AudioClip sHighscore;
    public AudioClip sDevaluar;
    public AudioClip sIncrementar;


    public AudioSource fuenteAudio;

    //[SerializeField] Toggle musicaOnOff;

    private void Start()
    {
        MaxORO.text = "MAX $AR: " + PlayerPrefs.GetInt("MAXcantidadMonedas", 0);
    }

    public void AcivarPanelMainMenu() 
    {
        MaxORO.text = "MAX $AR: " + PlayerPrefs.GetInt("MAXcantidadMonedas", 0);
        fuenteAudio.clip = sGOT;
        fuenteAudio.Play();

        panelMainMenu.SetActive(true);
        panelMundos.SetActive(false);
    }

    public void SonidoOff()
    {
        fuenteAudio.Stop();
    }
    public void DesactivarPanelMainMenu()
    {
        panelMainMenu.SetActive(false);        
    }

    public void AcivarPanelMundos()
    {
        panelMundos.SetActive(true);
        fuenteAudio.clip = sTierno;
        fuenteAudio.Play();
        //panelMainMenu.SetActive(false);
    }
    public void DesactivarPanelMundos()
    {        
        panelMainMenu.SetActive(true);
        panelMundos.SetActive(false);
    }

    public void AcivarPanelPiano()
    {
        panelPiano.SetActive(true);
        fuenteAudio.clip = sTierno;
        fuenteAudio.Play();
        //panelMainMenu.SetActive(false);
    }
    public void DesactivarPanelPiano()
    {
        panelMainMenu.SetActive(true);
        panelPiano.SetActive(false);
    }

    public void AcivarPanelPersonajes()
    {
        panelPersonajes.SetActive(true);
        fuenteAudio.clip = sTierno;
        fuenteAudio.Play();
        //panelMainMenu.SetActive(false);
    }
    public void AcivarPanelHighScore()
    {
        panelHighScore.SetActive(true);
        fuenteAudio.clip = sHighscore;
        fuenteAudio.Play();
        //panelMainMenu.SetActive(false);
    }
    public void DesactivarPanelHighScore()
    {
        panelMainMenu.SetActive(true);
        panelHighScore.SetActive(false);
    }
    public void DesactivarPanelPersonajes()
    {
        panelMainMenu.SetActive(true);
        panelPersonajes.SetActive(false);
    }

    public void AcivarPanelCreditos()
    {
        panelCreditos.SetActive(true);
        fuenteAudio.clip = sTierno;
        fuenteAudio.Play();
        //panelMainMenu.SetActive(false);
    }
    public void DesactivarPanelCreditos()
    {
        panelMainMenu.SetActive(true);
        panelCreditos.SetActive(false);
    }

    public void AcivarPanelSalir()
    {
        panelSalir.SetActive(true);
        fuenteAudio.clip = sTierno;
        fuenteAudio.Play();
        //panelMainMenu.SetActive(false);
    }
    public void DesactivarPanelSalir()
    {
        panelMainMenu.SetActive(true);
        panelSalir.SetActive(false);
    }

    public void ResetearMaxORO()
    {
        MaxORO.text = "MAX $AR: 0";
        PlayerPrefs.SetInt("MAXcantidadMonedas", 0);

        fuenteAudio.clip = sHighscore;
        fuenteAudio.Play();
    }

    public void Devaluar()
    {
        int oro = PlayerPrefs.GetInt("MAXcantidadMonedas", 0);
        oro--;
        PlayerPrefs.SetInt("MAXcantidadMonedas", oro);
        MaxORO.text = "MAX $AR: " + oro;        
        
        fuenteAudio.clip = sDevaluar;
        fuenteAudio.Play();
    }

    public void Incrementar()
    {
        int oro = PlayerPrefs.GetInt("MAXcantidadMonedas", 0);
        oro++;
        PlayerPrefs.SetInt("MAXcantidadMonedas", oro);
        MaxORO.text = "MAX $AR: " + oro;

        fuenteAudio.clip = sIncrementar;
        fuenteAudio.Play();
    }

    public void DonarPATREON()
    {
        Application.OpenURL("www.patreon.com/GatoGame");
    }
}
