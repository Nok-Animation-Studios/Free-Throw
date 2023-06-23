using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControlScript : MonoBehaviour
{
    public Rigidbody ball;
    public float upwardforce = 0;
    public float forwardforce = 10;
    Vector3 originalPosition;
    public Text powerText;
    public bool canThrow = true;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        //Charging
        if (Input.GetKey("space") && canThrow == true)
        {
            //Add to the force for the ball
            upwardforce = upwardforce + 2;
            powerText.text = upwardforce.ToString();
        }

        //Letting go(Throwing)
        if (Input.GetKeyUp("space") && canThrow == true)
        {
            //Add force to the ball
            ball.AddForce(0, upwardforce, upwardforce);

            //Enable gravity
            ball.useGravity = true;

            canThrow = false;
        }

        if (Input.GetKey("r"))
        {
            //Reset ball position
            transform.position = originalPosition;

            //Disabling gravity
            ball.useGravity = false;
            ball.velocity = new Vector3(0, 0, 0);

            //Reset force
            upwardforce = 0;

            //Reset Text
            powerText.text = upwardforce.ToString(); 

            canThrow = true;

        }
    }
}
