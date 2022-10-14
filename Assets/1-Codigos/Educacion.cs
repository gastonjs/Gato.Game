using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gato.Game;

public class Educacion : MonoBehaviour
{
    public float Area;
    public float Daño;
    public ParticleSystem explosion;
    public AudioClip sExplosion;
    private AudioSource fuenteAudio;
    public float tiempoDetonacion;
    private float deltaTime = 0;
    public LayerMask CapaDañable;

    // Start is called before the first frame update
    private void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        deltaTime += Time.deltaTime;

        if(deltaTime >= tiempoDetonacion)
        {
            Explotar();
            Destroy(gameObject);
            deltaTime = 0;
        }        
    }

    private void Explotar()
    {
        Vector3 posicionPelota = gameObject.transform.position;
        ParticleSystem particulas = Instantiate<ParticleSystem>(explosion, posicionPelota, Quaternion.identity);
        fuenteAudio.clip = sExplosion;
        fuenteAudio.Play();

        Collider[] colliders = Physics.OverlapSphere(posicionPelota, Area, CapaDañable);

        if(colliders.Length > 0)
        {
            foreach(Collider coll in colliders)
            {                
                if( coll.CompareTag("Enemigo") )
                {
                    if (
                        coll.TryGetComponent<Zombie>( out var zombie)   
                       )
                    {
                        if(zombie.isActiveAndEnabled)
                        {
                            zombie.SendMessage("Educate");
                        }
                        
                    }
                        

                    //coll.SendMessage("Educate");                    
                }
            }
        }
    }
}
