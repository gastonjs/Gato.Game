using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gato.Game
{ 
    public class ItemEfectos : MonoBehaviour
    {       
        void Update()
        {
            transform.Rotate(new Vector3(0f, 99f, 0f) * Time.deltaTime);
        }
    }
}