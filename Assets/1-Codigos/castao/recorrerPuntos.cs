using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script le dice al objeto que debe seguir la ruta dictada por el Script creadorPuntos

public class recorrerPuntos : MonoBehaviour 
{
	public enum TipoDeRecorrido  // Esto crea una lista para seleccionar dentro de Unity
	{
		MovimientoConstante,
		MovimientoCortado
	}

	public TipoDeRecorrido Tipo = TipoDeRecorrido.MovimientoConstante;
	public creadorPuntos recorrido;
	public float velocidad = 1;
	public float DistanciaDelObjetivo = .2f;

	private IEnumerator<Transform> puntosActuales;

	// Use this for initialization
	void Start () 
	{
		if(recorrido == null)
		{
			Debug.LogError("El recorrido no puede ser Nulo", gameObject);
			return;
		}

		puntosActuales = recorrido.creadorEnumerdado ();
		puntosActuales.MoveNext();

		if(puntosActuales.Current == null)
		{
			return;
		}

		transform.position = puntosActuales.Current.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(puntosActuales == null || puntosActuales.Current == null)
		{
			return;
		}

		if(Tipo == TipoDeRecorrido.MovimientoConstante)
		{
			transform.position = Vector3.MoveTowards(transform.position, puntosActuales.Current.position, Time.deltaTime * velocidad);
		}

		else if(Tipo == TipoDeRecorrido.MovimientoCortado)
		{
			transform.position = Vector3.Lerp(transform.position, puntosActuales.Current.position, Time.deltaTime * velocidad);
		}

		var distanciaAlCuadrado = (transform.position - puntosActuales.Current.position).sqrMagnitude;

		if(distanciaAlCuadrado < DistanciaDelObjetivo * DistanciaDelObjetivo)
		{
			puntosActuales.MoveNext();
		}
	}
}
