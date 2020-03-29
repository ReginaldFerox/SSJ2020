using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayer : MonoBehaviour
{
    public float playerSpeed;
    public float jumpHeight;
    public int numberOfFlaps = 0;
    public float damping = 10;
    public bool infiniteFlaps = false;
    public float maxSpeed = 20;
    public bool isActive;



    private bool activeForm;
    private Rigidbody2D body;
    private float horizontalAxis;
    private Vector3 currentVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
    }
    private void Update()
    {
        if (isActive)
        {
            currentVelocity = GetComponent<Rigidbody2D>().velocity;
            horizontalAxis = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown("w"))
            {
                if (infiniteFlaps)
                {
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
                }
                else if (numberOfFlaps <= 5)
                {
                    this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
                    numberOfFlaps++;
                }
            }





        }
    }

        void FixedUpdate()
        {
            body.velocity = new Vector2(Mathf.Lerp(horizontalAxis, horizontalAxis * playerSpeed, Time.fixedDeltaTime * damping), currentVelocity.y); //Linearlly interpolate between values to determine non-intrusive X velocity.
        }


        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "floor")
            {
                numberOfFlaps = 0;
            }
        }



    }



