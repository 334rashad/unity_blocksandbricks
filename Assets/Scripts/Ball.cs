
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 paddlePosition;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float ballBounceAngle = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references
    AudioSource myaudioSource;
    AudioClip clip;
    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myaudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidbody2D.velocity = new Vector2(velocityX, velocityY);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, ballBounceAngle), 
            Random.Range(0, ballBounceAngle));

        if (ballSounds.Length > 0)
        {
            clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            if (hasStarted) myaudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
        
    }
}
