using UnityEngine;

public class Ball : MonoBehaviour
{

    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //states
    Vector2 paddleToBallVector;
    bool hasStarted;

    //cached component references

    AudioSource myAudioSources;
    Rigidbody2D myRigidBody2D;



    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSources = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (hasStarted != true)
        {
            stickBalltoPaddle();
            LaunchOnMouseclick();
        }

    }

    //launch ball
    private void LaunchOnMouseclick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }


    //sticking the ball moviment to the paddle
    private void stickBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    //playing sounds when ball hits something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSources.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;

        }
    }

}
