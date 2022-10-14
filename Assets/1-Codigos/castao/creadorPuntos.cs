using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Lo que hace este Script es crear una ruta para que el objeto la pueda seguir

public class creadorPuntos : MonoBehaviour 
{
	public Transform[] puntos; // Vector con la cantidad de puntos que se usan para generar la ruta del objeto

	public IEnumerator<Transform> creadorEnumerdado()
	{
		if (puntos == null || puntos.Length < 1) 
		{
			yield break;
		}

		var direccion = 1;
		var index = 0;

		while (true)
		{
			yield return puntos [index];

			if(puntos.Length == 1)
			{
				continue;
			}

			if(index <= 0)
			{
				direccion = 1;
			}
			else if(index >= puntos.Length-1)
			{
				direccion = -1;
			}

			index = index + direccion;
		}
	}

	public void OnDrawGizmos() //Esta funcion dibuja una linea entre los GameObject que generan la ruta del objeto
	{
		if(puntos == null || puntos.Length < 2)
		{
			return;
		}

		var Puntos2 = puntos.Where(t => t != null).ToList();

		if(Puntos2.Count < 2)
		{
			return;
		}

		for(var i = 1; i < Puntos2.Count; i++)
		{
			Gizmos.DrawLine(Puntos2[i-1].position, Puntos2[i].position);
		}	
	}
}
