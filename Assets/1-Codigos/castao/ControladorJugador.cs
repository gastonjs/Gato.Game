using UnityEngine;
using System.Collections;

public class ControladorJugador : MonoBehaviour 
{

	public float speed; //variable que altera la velocidad del personaje
	public float jumpForce; //variable que altera el salto dle personaje

	private Rigidbody rb; // variable que alamcena el Rigidbody del personaje

	//inicia el juego tomando el componente rigidbody del personaje
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
		
	//funcion que maneja al personaje
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveUp = Input.GetAxis ("Jump");

		Vector3 movement = new Vector3 (moveHorizontal, moveUp, moveVertical);

		rb.AddForce (movement * speed);
		rb.AddForce (movement * jumpForce);
	}

	//Permite la recoleecion de los objetos con el tag Puntos
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Puntos"))
		{
			other.gameObject.SetActive (false);
		}
	}
}