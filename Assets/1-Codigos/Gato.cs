using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gato.Game;

namespace Gato.Game
{

    class Gato : Mascota
    {
        public AudioClip sFire1;
        public AudioClip sFire2;
        public AudioClip sJump;
        public AudioClip sHit;
        public AudioClip sTierno;
        public AudioClip wip;
        public AudioClip sError;
        public AudioClip sMoneda;
        public AudioClip sMario;
        public AudioClip sSonic;

        private AudioSource fuenteAudio;

        
        private float horizontalMove;
        private float verticalMove;
        //private Vector3 playerInput;
        private Control playerInput;
        private Vector3 playerVelocity;

        public CharacterController player; 
        public float playerSpeed;
        private Vector3 movePlayer;

        public float gravity = -9.8f;
        public float fallVellocity;
        public float jumpHeight;

        public Camera mainCamera;
        private Vector3 camForward;
        private Vector3 camRight;

        public bool isOnSlope = false;
        private Vector3 hitNormal;

        public float slideVelocity;
        public float slopeForceDown;

        private Animator _animator;

        [HideInInspector]
        public Vector2 PAD;
        [HideInInspector]
        public bool YSaltar;
        [HideInInspector]
        public bool XGolpear;
        [HideInInspector]
        public bool ALanzar;
        [HideInInspector]
        public bool BRugir;
        [HideInInspector]
        public float HInput;
        [HideInInspector]
        public float VInput;

        public GameObject barraDeVida;
        public int dañoGolpeBase;
        
        public GameObject pelota;        
        public int velPoelota;
        public Transform posPelota;
        public GameObject libro;
        public int velLibro;

        public ParticleSystem efectoDañoRugido;
        public float Area;
        public float DañoArea;
        public LayerMask CapaDañable;

        public ControladorPausaGameOver pausaGameOver;

        private void Awake()
        {
            playerInput = new Control();
            player = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            fuenteAudio = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            playerInput.Enable();
        }
        private void OnDisable()
        {
            playerInput.Disable();
        }

        // SOLO UNA VEZ AL INICIO
        void Start()
        {            
            fuenteAudio.clip = sError;
            fuenteAudio.Play();
            _animator.SetTrigger("Caca");
        }

        void Update()
        {
            //horizontalMove = PAD.x;
            //verticalMove = PAD.y;

            Vector2 movementInput = playerInput.ControlMovimiento.Move.ReadValue<Vector2>();
            movePlayer = (mainCamera.transform.forward * movementInput.y + mainCamera.transform.right * movementInput.x);
            movePlayer.y = 0f;

            player.Move(movePlayer * Time.deltaTime * playerSpeed);

            if( movePlayer != Vector3.zero)
            {
                gameObject.transform.forward = movePlayer;
            }

            if( playerInput.ControlMovimiento.Jump.triggered) //&& player.isGrounded
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                
                _animator.SetTrigger("Salta");
                fuenteAudio.clip = sJump;
                fuenteAudio.Play();
            }

            playerVelocity.y += gravity * Time.deltaTime;
            player.Move(playerVelocity * Time.deltaTime);

            //if (player.isGrounded && YSaltar)
            //{                
            //    movePlayer.y = jumpHeight;
            //    _animator.SetTrigger("Salta");
            //    fuenteAudio.clip = sJump;
            //    fuenteAudio.Play();
            //    YSaltar = false;
            //}

            //movePlayer = movePlayer * playerSpeed;
            //CamDirection();
            //movePlayer = playerInput.x * camRight + playerInput.z * camForward;
            //player.transform.LookAt(player.transform.position + movePlayer);

            //SetGravity();

            PlayerSkills();

            

            //manejo de animaciones
            if (_animator == null) return;
            _animator.SetFloat("VelX", movementInput.x);
            _animator.SetFloat("VelY", movementInput.y);
        }


        public override void Curarse(float cantidadCuracion)
        {
            if (!EstaVivo())
            {
                return;
            }
            if (!invencible && Vida > 0)
            {
                fuenteAudio.clip = sTierno;
                fuenteAudio.Play();
                _animator.SetTrigger("Salud");
                barraDeVida.SendMessage("Curarse", cantidadCuracion);

                Vida += cantidadCuracion;
                StartCoroutine(Invulnerabilidad());
            }            
        }



        public override void TomarDaño(float cantidadDaño) 
        {
            if (!EstaVivo())
            { 
                return;
            }
            if (!invencible && Vida > 0)
            {
                fuenteAudio.clip = sHit;
                fuenteAudio.Play();
                _animator.SetTrigger("Golpeado");
                barraDeVida.SendMessage("TomarDaño", cantidadDaño);

                Vida -= cantidadDaño;
                StartCoroutine(Invulnerabilidad());
            }
            if (Muerto)
            {
                Morir();
            }           
        }

      
        public override void Morir()
        {            
            fuenteAudio.clip = sTierno;
            fuenteAudio.Play();
            _animator.SetTrigger("Muere");
            Time.timeScale = 0.25f;
            pausaGameOver.SendMessage("ActivarPanelGameOver");
        }

        

        private void PlayerSkills()
        {            
            if (playerInput.ControlMovimiento.Pelota.triggered)
            {
                if (Puntuaciones.cantidadPelotas > 0)
                {
                    Puntuaciones.cantidadPelotas--;

                    fuenteAudio.clip = sFire1;
                    fuenteAudio.Play();
                    _animator.SetTrigger("Fire1");

                    //LANZAMIENTO DE PELOTAS:
                    var lanzar = Instantiate(pelota, posPelota.position, Quaternion.identity);
                    lanzar.GetComponent<Rigidbody>().AddForce(posPelota.forward * 1000 * velPoelota);
                    Destroy(lanzar, 6f); 
                }
                else
                {
                    fuenteAudio.clip = sError;
                    fuenteAudio.Play();
                    _animator.SetTrigger("Caca");
                    //TODO: INSTANCIAR UN OBJETO NO ESPERADO JAJA
                }

                XGolpear = false;
            }
            if (playerInput.ControlMovimiento.Rugir.triggered)
            {

                if (Puntuaciones.cantidadRugidos > 0 )
                {
                    Puntuaciones.cantidadRugidos--;

                    fuenteAudio.clip = sFire2;
                    fuenteAudio.Play();
                    _animator.SetTrigger("Fire2");

                    Instantiate<ParticleSystem>(efectoDañoRugido, gameObject.transform.position, Quaternion.identity);
                    Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, Area, CapaDañable);

                    if (colliders.Length > 0)
                    {
                        foreach (Collider coll in colliders)
                        {
                            if (coll.CompareTag("Enemigo"))
                            {
                                coll.SendMessage("TomarDaño", DañoArea);
                            }
                        }
                    } 
                }
                else
                {
                    fuenteAudio.clip = sError;
                    fuenteAudio.Play();
                    _animator.SetTrigger("Caca");
                    //TODO: INSTANCIAR UN OBJETO NO ESPERADO JAJA
                }

                BRugir = false;
            }
            if (playerInput.ControlMovimiento.Libro.triggered) //TODO: PARCHE DEMO-JUGABLE
            {
                if (Puntuaciones.cantidadAlfanumerico >= 0)
                {
                    Puntuaciones.cantidadAlfanumerico -= 1;

                    fuenteAudio.clip = wip;
                    fuenteAudio.Play();
                    _animator.SetTrigger("Fire1");

                    //LANZAMIENTO DE LIBRO:
                    var lanzar = Instantiate(libro, posPelota.position, Quaternion.identity);
                    lanzar.GetComponent<Rigidbody>().AddForce(posPelota.forward * 1000 * velLibro);
                    Destroy(lanzar, 6f);
                }
                else
                {
                    fuenteAudio.clip = sError;
                    fuenteAudio.Play();
                    _animator.SetTrigger("Caca");
                    //TODO: INSTANCIAR UN OBJETO NO ESPERADO JAJA
                }

                ALanzar = false;

            }
        }

        public void Saltar()
        {
            YSaltar = true;
        }
        public void Golpear()
        {
            XGolpear = true;
        }
        public void Rugir()
        {
            BRugir = true;
        }
        public void Lanzar()
        {
            ALanzar = true;
        }

        private void SetGravity()
        {

            if (player.isGrounded)
            {
                fallVellocity = -gravity * Time.deltaTime;
            }
            else
            {
                fallVellocity -= gravity * Time.deltaTime;
            }
            movePlayer.y = fallVellocity;

            SlideDown();
        }

        public void SlideDown()
        {
            isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;

            if (isOnSlope)
            {
                movePlayer.x += ((1f - hitNormal.y) * hitNormal.x) * slideVelocity;
                movePlayer.z += ((1f - hitNormal.y) * hitNormal.z) * slideVelocity;

                movePlayer.y += slopeForceDown;
            }
        }

        void CamDirection()
        {
            camForward = mainCamera.transform.forward;
            camRight = mainCamera.transform.right;

            camForward.y = 0;
            camRight.y = 0;

            camForward = camForward.normalized;
            camRight = camRight.normalized;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            hitNormal = hit.normal;
        }

        //Permite la recoleecion de los objetos con el tag Puntos
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Papas"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                Puntuaciones.cantidadPelotas += 5;
                _animator.SetTrigger("Come");
                fuenteAudio.clip = sTierno;
                fuenteAudio.Play();

            }
            if (other.gameObject.CompareTag("Hamburguesas"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                Puntuaciones.cantidadRugidos++;
                _animator.SetTrigger("Come");
                fuenteAudio.clip = sTierno;
                fuenteAudio.Play();
            }
            if (other.gameObject.CompareTag("Salud50"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                this.Curarse(50);
                _animator.SetTrigger("Salud");
                fuenteAudio.clip = sTierno;
                fuenteAudio.Play();
            }
            if (other.gameObject.CompareTag("Salud1"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                this.Curarse(10);
                _animator.SetTrigger("Come");
                fuenteAudio.clip = sMoneda;
                fuenteAudio.Play();
            }
            if (other.gameObject.CompareTag("Moneda"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                Puntuaciones.cantidadMonedas++;                
                _animator.SetTrigger("Come");
                fuenteAudio.clip = sMoneda;
                fuenteAudio.Play();
            }
            if (other.gameObject.CompareTag("Alfanumerico"))
            {
                Destroy(other.gameObject);
                Puntuaciones.cantidadAlfanumerico++;
                _animator.SetTrigger("Salud");
                fuenteAudio.clip = sMario;
                fuenteAudio.Play();
            }
            if (other.gameObject.CompareTag("Pelota"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                Puntuaciones.cantidadPelotas++;
                _animator.SetTrigger("Salud");
                fuenteAudio.clip = sSonic;
                fuenteAudio.Play();
            }
            if (other.gameObject.CompareTag("Placa"))
            {
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);
                Puntuaciones.cantidadRugidos += 5;
                _animator.SetTrigger("Come");
                fuenteAudio.clip = sSonic;
                fuenteAudio.Play();
            }
            //if (other.gameObject.name == "CuadroDePercepcion")
            //{
            //    other.transform.parent.GetComponent<Zombie>().Mirar();
            //}
        }       

        internal override void Tranquilo()
        {
            
        }
    }
}