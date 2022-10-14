using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    float vida, vidaMAX = 100f;
    public Image salud;
    public bool invencible = false;
    public float tiempoInvencible = 1f;
    public GameObject Jugador;

    // Start is called before the first frame update
    void Start()
    {
        vida = vidaMAX;
    }
    
    public void TomarDaño(float cantidad)
    {
        if(!invencible && vida > 0)
        {
            vida = Mathf.Clamp(vida - cantidad, 0f, vidaMAX);
            salud.transform.localScale = new Vector2(vida / vidaMAX, 1);
            //StartCoroutine(Invulnerabilidad());
        }
        if ( vida <= 0)
        {
            Jugador.SendMessage("Morir");
        }
    }

    public void Curarse(float cantidad)
    {
        if (
            (vidaMAX - vida) > cantidad
           )
        {
            vida = Mathf.Clamp(vida + cantidad, 0f, vidaMAX);
        }
        else
        {
            vida = vidaMAX;            
        }
        salud.transform.localScale = new Vector2(vida / vidaMAX, 1);
    }

    IEnumerator Invulnerabilidad()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempoInvencible);
        invencible = false;
    }
}
