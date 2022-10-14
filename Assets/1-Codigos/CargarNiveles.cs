using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNiveles : MonoBehaviour
{
    public GameObject panelCargando;
   

    public void CargarNivel001()
    {
        StartCoroutine( EsperaPantallaCargando() );
    }

    public void CargarNivel001(int cZombis)
    {
        PlayerPrefs.SetInt("cantidadXZombis", cZombis);
        StartCoroutine(EsperaPantallaCargando());
    }

    public IEnumerator EsperaPantallaCargando()
    {
        panelCargando.SetActive(true);
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("BuenosAiresCiudadNivel001");
        Time.timeScale = 1;
    }
}
