using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformController : MonoBehaviour
{
    public Rigidbody plataformRB;
    public Transform[] platformPositions;
    public float platformSpeed;
    private int actualPosition = 0;
    private int nextPosition = 1;
    public bool moveToTheNext = true;
    public float waitTime;

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (moveToTheNext)
        {
            StopCoroutine(WaitForMove(0));
            plataformRB.MovePosition(Vector3.MoveTowards(plataformRB.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }        

        if( Vector3.Distance(plataformRB.position, platformPositions[nextPosition].position) <= 0)
        {
            StartCoroutine(WaitForMove(waitTime));
            actualPosition = nextPosition;
            nextPosition++;

            if( nextPosition > platformPositions.Length -1)
            {
                nextPosition = 0;
            }
        }
    }

    IEnumerator WaitForMove(float time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(time);
        moveToTheNext = true;
    }
}
