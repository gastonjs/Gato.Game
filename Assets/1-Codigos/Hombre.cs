using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

namespace Gato.Game
{
    class Hombre : Persona
    {
        bool hacer = true;

        public float VidaMAX = 100f;
        public float EnergiaMAX = 100f;
        public float RelaxMAX = 100f;
        public float FelicidadMAX = 100f;
        public float InteligenciaMAX = 100f;
        
        private Animator animacion;
        public ParticleSystem particulasMuerte;

        public AudioClip sonidoDaño;
        public AudioClip sonidoMuere;
        public AudioClip sonidoDetecta;
        public AudioClip sonidoCamina;
        public AudioClip sonidoBarraActualizada;

        public TextMeshProUGUI barraDeDinero;
        public Image barraDeVida;
        public Image barraDeEnergia;
        public Image barraDeRelax;
        public Image barraDeFelicidad;
        public Image barraDeInteligencia;

        CapsuleCollider colliderZombie;
        
        //Cuando muere el "hombre" nace un zombie (el virus esta en el aire)
        //public GameObject zombiePREFAB;
       

        public GameObject enemigoPublico;
             

        private NavMeshAgent navegacionaIA;
        private Puntuaciones puntuaciones;

        private string estado = "quieto";
        
        private float pausa = 0f;
        private bool alerta = false;
        private float gradoDeAlerta = 50f;

        
        List<RelSitioNecesidad> ListaRel = new List<RelSitioNecesidad>();

        public GameObject Alfanumerico;
        public Transform posAlfanumerico;
        public float tiempoAlfanumerico;
        private float deltaTime = 0;

        private static int cantidad = 0;
        public static int Cantidad() { return cantidad; }

        //////LO QUE ESTUDIE EN LA FACULTAD NO SIRVE EN LA VIDA "REAL"
        //public Hombre()
        //{
        //    cantidad++;
        //}

        //~Hombre()
        //{
        //    cantidad--;
        //}


        private void Awake()
        {
            

            puntuaciones = GetComponent<Puntuaciones>();
            fuenteDeSonido = GetComponent<AudioSource>();
            colliderZombie = GetComponent<CapsuleCollider>();
            animacion = GetComponent<Animator>();
            navegacionaIA = GetComponent<NavMeshAgent>();
            Vida = Random.Range(50.0f, 100.0f);
            Dinero = Random.Range(0.0f, 50.0f);
            Energia = Random.Range(1.0f, 20.0f);
            Relax = Random.Range(10.0f, 100.0f);
            Felicidad = Random.Range(50.0f, 100.0f);
            Inteligencia = Random.Range(0.0f, 100.0f);

            barraDeDinero.SetText("$ " + Dinero.ToString("F2"));
            
        }

        // Start is called before the first frame update
        void Start()
        {
            posicionAnterior = transform;

            unaFarmacia = refGeneradorPoblacional.unaFarmacia;

            unFarmacity = refGeneradorPoblacional.unFarmacity;

            unRestaurante = refGeneradorPoblacional.unRestaurante;
            unaEscuela = refGeneradorPoblacional.unaEscuela;
            unTrabajo = refGeneradorPoblacional.unTrabajo;
            unBar = refGeneradorPoblacional.unBar;
            unaCasa = refGeneradorPoblacional.unaCasa;

            ListaRel.Add(new RelSitioNecesidad("Vida", Vida, unaFarmacia));
            ListaRel.Add(new RelSitioNecesidad("Energia", Energia, unRestaurante));
            ListaRel.Add(new RelSitioNecesidad("Relax", Relax, unaCasa));
            ListaRel.Add(new RelSitioNecesidad("Felicidad", Felicidad, unBar));
            ListaRel.Add(new RelSitioNecesidad("Inteligencia", Inteligencia, unaEscuela));

            TomarDaño(0f);
            ActualizarBarraDe(barraDeFelicidad, Felicidad, 0, FelicidadMAX, sonidoBarraActualizada);
            ActualizarBarraDe(barraDeEnergia, Energia, 0, EnergiaMAX, sonidoBarraActualizada);
            ActualizarBarraDe(barraDeInteligencia, Inteligencia, 0, InteligenciaMAX, sonidoBarraActualizada);
            ActualizarBarraDe(barraDeRelax, Relax, 0, RelaxMAX, sonidoBarraActualizada);
            Tranquilo();
        }

        // Update is called once per frame
        void Update()
        {
            temporizador += Time.deltaTime;
            
            if (EstaVivo())
            {
                animacion.SetFloat("Velosidad", navegacionaIA.velocity.magnitude);

                if (!alerta)
                {
                    IrAUnSitio();
                }
                else
                {
                    if (
                        (navegacionaIA.destination == unaFarmacia.position)
                        &&
                        (transform.position == posicionAnterior.position)
                      )
                    {
                        navegacionaIA.destination = unFarmacity.position;
                    }
                    else
                    {
                        if(navegacionaIA.destination == unFarmacity.position)
                        {
                            navegacionaIA.destination = unFarmacity.position;
                        }
                        else
                        {
                            navegacionaIA.destination = unaFarmacia.position;
                        }                                               
                    }
                    posicionAnterior.position = transform.position;
                    navegacionaIA.speed = 5f;

                    if (primerAtaqueRecibido)
                    {
                        fuenteDeSonido.clip = sonidoDetecta;
                        fuenteDeSonido.Play();

                        primerAtaqueRecibido = false;
                    }
                                       
                }
            }
        }

        private void FixedUpdate()
        {
            deltaTime += Time.deltaTime;

            if (
                (deltaTime >= tiempoAlfanumerico) /*&& (!estado.Equals("quieto")) && (!estado.Equals("buscar"))*/
               )
            {
                Instantiate(Alfanumerico, posAlfanumerico.position, Quaternion.identity);

                fuenteDeSonido.clip = sonidoBarraActualizada;
                fuenteDeSonido.Play();

                deltaTime = 0;
            }
        }

        private void IrAUnSitio()
        {
            navegacionaIA.speed = 1.3f;

            if (Dinero < 20)
            {
                navegacionaIA.SetDestination(unTrabajo.position);
                //navegacionaIA.velocity.magnitude = 1.4f;
            }
            else if (Vida < 20)
            {
                navegacionaIA.SetDestination(unaFarmacia.position);
            }
            else if (Energia < 20)
            {
                navegacionaIA.SetDestination(unRestaurante.position);
            }
            else if (Inteligencia < 20)
            {
                navegacionaIA.SetDestination(unaEscuela.position);
            }
            else if (Felicidad < 20)
            {
                navegacionaIA.SetDestination(unBar.position);
            }
            else if (Relax < 20)
            {
                navegacionaIA.SetDestination(unaCasa.position);
            }
            else
            {
                IrAOtroSitio();
            }

            if (
                (temporizador >= 5f) 
               )
            {                

                fuenteDeSonido.clip = sonidoCamina;
                fuenteDeSonido.Play();

                temporizador = 0;
            }
        }

        private void IrAOtroSitio()
        {
            RelSitioNecesidad registroMIN = ListaRel.OrderBy(o => o.valPropiedad).ToList().FirstOrDefault();
            navegacionaIA.SetDestination( registroMIN.sitio.position );
        }


        //chequea si puede ver al jugador
        //public void Mirar()
        //{
        //    if (vive)
        //    {
        //        RaycastHit rayHit;
        //        if (Physics.Linecast(eyes.position, player.transform.position, out rayHit))
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


        public override void TomarDaño(float cantidadDaño)
        {
            if (!EstaVivo())
                return;

            if (!invencible && Vida > 0)
            {
                fuenteDeSonido.clip = sonidoDaño;
                fuenteDeSonido.Play();

                Vida = Mathf.Clamp(Vida - cantidadDaño, 0f, VidaMAX);
                barraDeVida.transform.localScale = new Vector2(Vida / VidaMAX, 1);

                alerta = true;                

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
            var pos = gameObject.transform.position;
            
            Puntuaciones.cantidadCiudadanos--;
            refGeneradorPoblacional.CrearZombieEnQueEra(pos, 5);
            Puntuaciones.cantidadZombis++;
            //TODO: 2? SE REFIERE A UN HUMANO DE CLASE A O B?
            Destroy(gameObject, 1f);

            Instantiate<ParticleSystem>(particulasMuerte, gameObject.transform.position, Quaternion.identity);
        }

        public override void ComprarComida()
        {
            Dinero -= 10;
            barraDeDinero.SetText("$ " + Dinero.ToString("F2"));

            Energia = ActualizarBarraDe( barraDeEnergia, Energia, 50, EnergiaMAX, sonidoBarraActualizada);
            var index = ListaRel.FindIndex(reg => reg.nombre.Equals("Energia"));
            ListaRel[index] = new RelSitioNecesidad("Energia", Energia, unRestaurante);

            Relax = ActualizarBarraDe(barraDeRelax, Relax, -15, VidaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Relax"));
            ListaRel[index] = new RelSitioNecesidad("Relax", Relax, unaCasa);
        }
        public override void ComprarMedicamentos()
        {
            Dinero -= 10;
            barraDeDinero.SetText("$ " + Dinero.ToString("F2"));
            
            Vida = ActualizarBarraDe(barraDeVida, Vida, 100, VidaMAX, sonidoBarraActualizada);
            var index = ListaRel.FindIndex(reg => reg.nombre.Equals("Vida"));
            if (index >= 0)
            {
                ListaRel[index] = new RelSitioNecesidad("Vida", Vida, unaFarmacia);
            }
            


            Relax = ActualizarBarraDe(barraDeRelax, Relax, -25, VidaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Relax"));
            if (index >= 0)
            {
                ListaRel[index] = new RelSitioNecesidad("Relax", Relax, unaCasa);
            }

            Energia = ActualizarBarraDe(barraDeEnergia, Energia, -15, EnergiaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Energia"));
            if (index >= 0)
            {
                ListaRel[index] = new RelSitioNecesidad("Energia", Energia, unRestaurante);
            }
            alerta = false;
            primerAtaqueRecibido = true;
        }

        public override void Dormir()
        {
            Dinero -= 10; //parece que el flaco alquila por dia xD
            barraDeDinero.SetText("$ " + Dinero.ToString("F2"));

            //Relax += 100;

            Relax = ActualizarBarraDe(barraDeRelax, Relax, 100, VidaMAX, sonidoBarraActualizada);
            var index = ListaRel.FindIndex(reg => reg.nombre.Equals("Relax"));
            ListaRel[index] = new RelSitioNecesidad("Relax", Relax, unaCasa);

            Energia = ActualizarBarraDe(barraDeEnergia, Energia, -15, EnergiaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Energia"));
            ListaRel[index] = new RelSitioNecesidad("Energia", Energia, unRestaurante);

            Inteligencia = ActualizarBarraDe(barraDeInteligencia, Inteligencia, -10, InteligenciaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Inteligencia"));
            ListaRel[index] = new RelSitioNecesidad("Inteligencia", Inteligencia, unaEscuela);
        }

        public override void ComprarEntrada()
        {
            Dinero -= 10;
            barraDeDinero.SetText("$ " + Dinero.ToString("F2"));
            
            Felicidad = ActualizarBarraDe(barraDeFelicidad, Felicidad, 50, FelicidadMAX, sonidoBarraActualizada);
            var index = ListaRel.FindIndex(reg => reg.nombre.Equals("Felicidad"));
            ListaRel[index] = new RelSitioNecesidad("Felicidad", Felicidad, unBar);

            Inteligencia = ActualizarBarraDe(barraDeInteligencia, Inteligencia, -15, InteligenciaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Inteligencia"));
            ListaRel[index] = new RelSitioNecesidad("Inteligencia", Inteligencia, unaEscuela);

            Energia = ActualizarBarraDe(barraDeEnergia, Energia, -15, EnergiaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Energia"));
            ListaRel[index] = new RelSitioNecesidad("Energia", Energia, unRestaurante);

            Relax = ActualizarBarraDe(barraDeRelax, Relax, -15, VidaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Relax"));
            ListaRel[index] = new RelSitioNecesidad("Relax", Relax, unaCasa);
        }

        public override void ComprarLibro()
        {
            Dinero -= 10;
            barraDeDinero.SetText("$ " + Dinero.ToString("F2"));

            Inteligencia = ActualizarBarraDe(barraDeInteligencia, Inteligencia, 20, InteligenciaMAX, sonidoBarraActualizada);
            var index = ListaRel.FindIndex(reg => reg.nombre.Equals("Inteligencia"));
            ListaRel[index] = new RelSitioNecesidad("Inteligencia", Inteligencia, unaEscuela);

            Energia = ActualizarBarraDe(barraDeEnergia, Energia, -15, EnergiaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Energia"));
            ListaRel[index] = new RelSitioNecesidad("Energia", Energia, unRestaurante);

            Relax = ActualizarBarraDe(barraDeRelax, Relax, -15, VidaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Relax"));
            ListaRel[index] = new RelSitioNecesidad("Relax", Relax, unaCasa);
        }

        public override void Trabajar()
        {
            Dinero += 50;
            barraDeDinero.SetText("$ " + Dinero.ToString("F2"));

            Felicidad = ActualizarBarraDe(barraDeFelicidad, Felicidad, -15, FelicidadMAX, sonidoBarraActualizada);
            var index = ListaRel.FindIndex(reg => reg.nombre.Equals("Felicidad"));
            ListaRel[index] = new RelSitioNecesidad("Felicidad", Felicidad, unBar);

            Energia = ActualizarBarraDe(barraDeEnergia, Energia, -15, EnergiaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Energia"));
            ListaRel[index] = new RelSitioNecesidad("Energia", Energia, unRestaurante);

            Relax = ActualizarBarraDe(barraDeRelax, Relax, -15, VidaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Relax"));
            ListaRel[index] = new RelSitioNecesidad("Relax", Relax, unaCasa);

            Inteligencia = ActualizarBarraDe(barraDeInteligencia, Inteligencia, 1, InteligenciaMAX, sonidoBarraActualizada);
            index = ListaRel.FindIndex(reg => reg.nombre.Equals("Inteligencia"));
            ListaRel[index] = new RelSitioNecesidad("Inteligencia", Inteligencia, unaEscuela);
            //hacer = false;            
        }

        private float ActualizarBarraDe(Image unaBarra, float unaPropiedad, float variacion, float MAX, AudioClip sonido)
        {
            if (!EstaVivo())
                return 0;
           
            unaPropiedad = Mathf.Clamp(unaPropiedad + variacion, 0f, MAX);
            unaBarra.transform.localScale = new Vector2(unaPropiedad / MAX, 1);

            fuenteDeSonido.clip = sonido;
            fuenteDeSonido.Play();

            return unaPropiedad;
        }

        internal override void Tranquilo()
        {
            alerta = false;
        }

        public override void Curarse(float Curacion)
        {
            throw new NotImplementedException();
        }
    }
}

