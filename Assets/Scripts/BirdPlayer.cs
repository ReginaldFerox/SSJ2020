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
    public bool isBird;



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
        
        
            currentVelocity = GetComponent<Rigidbody2D>().velocity;
            horizontalAxis = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown("w"))
            {
                if (infiniteFlaps && isBird)
                {
                   GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
                }
                else if (numberOfFlaps <= 5 && isBird)
                {
                    GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
                    numberOfFlaps++;
                }
                else if(IsGrounded() && isBird)
            {
                GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
            }
            





        }
    }

        void FixedUpdate()
        {
            body.velocity = new Vector2(Mathf.Lerp(horizontalAxis, horizontalAxis * playerSpeed, Time.fixedDeltaTime * damping), currentVelocity.y); //Linearlly interpolate between values to determine non-intrusive X velocity.
        }


        private bool IsGrounded()
        {
        Debug.Log("Ground check");
        return Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + 0.1F);
    }



    }



