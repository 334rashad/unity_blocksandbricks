using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{ 
    //configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] AudioClip paddleSound;
    float mouseXPos;
    bool hasStarted = false;

    AudioSource myaudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myaudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            StartTheGame();
        }
        mouseXPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mouseXPos, minX, maxX);
        transform.position = paddlePosition;
        
    }

    private void StartTheGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myaudioSource.Play();
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted) myaudioSource.PlayOneShot(paddleSound);
    }
}
