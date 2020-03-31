using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    bool hasStarted = false;

    void Update()
    {
        if (!hasStarted) 
        { 
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted) GetComponent<AudioSource>().Play();
    }
}
