using UnityEngine;

public class Ball : MonoBehaviour
{
    // configration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactorUpper = 0.4f;
    [SerializeField] float randomfactorLower = 0.2f;

    // state
    Vector2 PaddleToBallDistance;
    bool hasSatrted = false;

    // cached component reference
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        PaddleToBallDistance = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
     }
    
     // Update is called once per frame
    void Update()
    {
        if (hasSatrted == false)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 Paddle1Pos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = Paddle1Pos + PaddleToBallDistance;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasSatrted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityChange = new Vector2(Random.Range(randomfactorLower, randomFactorUpper), Random.Range(randomfactorLower, randomFactorUpper));
        if (hasSatrted == true)
        {
            myAudioSource.Play();
            myRigidBody2D.velocity += velocityChange;
        }
    }

}
