using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Animator _animator;
    public float MaxSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator == null) return;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Move(x, y);
    }

    private void Move(float x, float y)
    {
        _animator.SetFloat("VelX", x);
        _animator.SetFloat("VelY", y);

        transform.position += (Vector3.forward * MaxSpeed) * y * Time.deltaTime;
        transform.position += (Vector3.right * MaxSpeed) * x * Time.deltaTime;
    }



}
