using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Gato.Game { 
    class Zombie : Enemigo
    {
        public float vidaMAX = 30f;
        
        //esta relacionado con el vector de poblacion en el generador de ciudadanos o de poblacion
        public int soyUnEx = 4;

        private bool soloSeMuereUnaVezEnLaVida = true;
        
        private Animator animacion;
        public ParticleSystem particulasMuerte;
        
        public AudioClip sonidoDaño;
        public AudioClip sonidoMuere;
        public AudioClip sonidoDetecta;
        public AudioClip sonidoGolpea;
        public Image barraDeVida;
        public int dañoGolpeBase;
        
               
        private GameObject enemigoDelZombieVivo = null;
        public Transform Ojos;

        private NavMeshAgent navegacionaIA;

        private string estado = "quieto";        
        private float pausa = 0f;
        private bool alerta = false;
        private float gradoDeAlerta = 50f;

        private static int cantidad = 0;
        public static int Cantidad() { return cantidad; }

        //public Zombie()
        //{
        //    cantidad++;
        //}

        //~Zombie()
        //{
        //    cantidad--;            
        //}      

        private void Awake()
        {            
            fuenteDeSonido = GetComponent<AudioSource>();
            //colliderZombie = GetComponent<CapsuleCollider>();
            animacion = GetComponent<Animator>();
            navegacionaIA = GetComponent<NavMeshAgent>();
            Vida = vidaMAX;           
        } 

        // Start is called before the first frame update
        void Start()
        {
            //Instantiate<ParticleSystem>(particulasMuerte, gameObject.transform.position, Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {
            temporizador += Time.deltaTime;
            //Debug.DrawLine(eyes.position, player.transform.position, Color.green);

            if (EstaVivo())
            {
                animacion.SetFloat("Velosidad", navegacionaIA.velocity.magnitude);
                //Debug.Log(nav.velocity.magnitude.ToString());
                
                if (estado.Equals("quieto"))
                {
                    Vector3 randomPos = Random.insideUnitSphere * gradoDeAlerta;
                    NavMeshHit navHit;
                    NavMesh.SamplePosition(transform.position + randomPos, out navHit, 40f, NavMesh.AllAreas);

                    if (alerta && (enemigoDelZombieVivo != null) ) //si esta en alerta va a ir cerca del ATACABLE, por instinto zombie
                    { //ojo que si el enemigo del zombie fue destruido, ya no existe.
                        
                        NavMesh.SamplePosition(enemigoDelZombieVivo.transform.position + randomPos, out navHit, 30f, NavMesh.AllAreas);
                        gradoDeAlerta += 10f;

                        if (gradoDeAlerta > 40f)
                        {
                            alerta = false;
                            navegacionaIA.speed = 1.2f;
                        }
                    }

                    navegacionaIA.SetDestination(navHit.position);
                    estado = "caminar";
                }
                if (estado.Equals("caminar"))
                {
                    if (
                        (navegacionaIA.remainingDistance <= navegacionaIA.stoppingDistance) && (!navegacionaIA.pathPending)
                      )
                    {
                        estado = "buscar";
                        pausa = 5f;
                    }
                }
                if (estado == "buscar")
                {
                    if (pausa > 0f)
                    {
                        pausa -= Time.deltaTime;
                        transform.Rotate(0f, 120f * Time.deltaTime, 0f);
                    }
                    else
                    {
                        estado = "quieto";
                    }

                }
                if (estado == "perseguir")
                {
                    if (enemigoDelZombieVivo != null)
                    { 


                        navegacionaIA.destination = enemigoDelZombieVivo.transform.position;

                        // se pierde de vista al objetivo
                        float distance = Vector3.Distance(transform.position, enemigoDelZombieVivo.transform.position);
                        if (distance > 20f)
                        {
                            estado = "cazar";
                        }
                        else if (navegacionaIA.remainingDistance <= navegacionaIA.stoppingDistance + 1f && !navegacionaIA.pathPending)
                        {
                            //ATAQUE ZOMBIE
                            if (
                                (enemigoDelZombieVivo.GetComponent<Ente>().EstaVivo()) 
                                &&
                                (temporizador >= tiempoEntreAtaque)
                               )
                            {
                                fuenteDeSonido.clip = sonidoGolpea;
                                fuenteDeSonido.Play();
                                animacion.SetTrigger("Atacar");
                                enemigoDelZombieVivo.SendMessage("TomarDaño", dañoGolpeBase);
                                temporizador = 0;

                                if (!enemigoDelZombieVivo.GetComponent<Ente>().EstaVivo())
                                {
                                    estado = "quieto";
                                    alerta = false;
                                }
                            }
                        }
                    }
                    else 
                    {
                        estado = "quieto";
                        alerta = false;
                    }
                }
                if (estado == "cazar")
                {
                    if (
                        (navegacionaIA.remainingDistance <= navegacionaIA.stoppingDistance) && (!navegacionaIA.pathPending)
                      )
                    {
                        estado = "buscar";
                        pausa = 5f;
                        alerta = true;
                        gradoDeAlerta = 30f;
                        //Mirar();
                    }
                }
                //nav.SetDestination(player.transform.position);
            }
        }


        //chequea si puede ver al jugador
        //public void Mirar()
        //{
        //    if (vive)
        //    {
        //        RaycastHit rayHit;
        //        if (Physics.Linecast(Ojos.position, enemigoDelZombieVivo.transform.position, out rayHit))
        //        {
        //            //print("hit " + rayHit.collider.gameObject.name);
        //            if (rayHit.collider.gameObject.name == "InteractionZone")
        //            {
        //                if (estado != "muerto")
        //                {
        //                    estado = "perseguir";
        //                    navegacionaIA.speed = 3.5f;
        //                    //anim.speed = 3.5f;

        //                    fuenteDeSonido.clip = sonidoDetecta;
        //                    fuenteDeSonido.Play();
        //                }
        //            }
        //        }
        //    }
        //}


        void OnTriggerEnter(Collider other)
        {          
            if ( 
                ( other.gameObject.CompareTag("Player") )
                ||
                ( other.gameObject.CompareTag("Personas") )
               )
            {
                if (EstaVivo())
                {
                    enemigoDelZombieVivo = other.gameObject;
                    estado = "perseguir";
                    navegacionaIA.speed = 3.5f;
                    fuenteDeSonido.clip = sonidoDetecta;
                    fuenteDeSonido.Play();
                }                
            }
        }

        

        public override void TomarDaño(float cantidadDaño)
        {
            if (!EstaVivo())
                return;

            if (!invencible && Vida > 0)
            {
                Vida = Mathf.Clamp(Vida - cantidadDaño, 0f, vidaMAX);
                barraDeVida.transform.localScale = new Vector2(Vida / vidaMAX, 1);

                fuenteDeSonido.clip = sonidoDaño;
                fuenteDeSonido.Play();

                Vida -= cantidadDaño;
                StartCoroutine(Invulnerabilidad());
            }
            if (Vida <= 0)
            {
                Morir();
            }
        }

        public override void Morir()
        {            
            fuenteDeSonido.clip = sonidoMuere;
            fuenteDeSonido.Play();
            animacion.SetTrigger("Morir");

            //StartCoroutine(Esperar(2f));
            Destroy(gameObject, 2f);
            //this.gameObject.SetActive(false);

            Puntuaciones.cantidadZombis--;
            Instantiate<ParticleSystem>(particulasMuerte, gameObject.transform.position, Quaternion.identity);
            
        }

        public void SoyUnEx(int soy)
        {
            soyUnEx = soy;
        }

        public void Educate()
        {
            if (!soloSeMuereUnaVezEnLaVida)
                return;

            fuenteDeSonido.clip = sonidoMuere;
            fuenteDeSonido.Play();
            animacion.SetTrigger("Morir");

            Puntuaciones.cantidadZombis--;
            Instantiate<ParticleSystem>(particulasMuerte, gameObject.transform.position, Quaternion.identity);
            
            refGeneradorPoblacional.CrearCiudadanoEnQueEra(gameObject.transform.position, soyUnEx);            
            Puntuaciones.cantidadCiudadanos++;
            
            soloSeMuereUnaVezEnLaVida = false;
            Destroy(gameObject, 0.1f);
        }

       

        internal override void Tranquilo()
        {
            
        }

        public override void Curarse(float Curacion)
        {
            
        }
    }
}