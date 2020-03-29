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
    public bool isBird = false;
    public LayerMask groundLayer;


    private Rigidbody2D body;
    private float horizontalAxis;
    private Vector3 currentVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
        if (isBird)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }

    }
    private void Update()
    {

        Debug.DrawRay(transform.position, Vector2.right);
        currentVelocity = GetComponent<Rigidbody2D>().velocity;
            horizontalAxis = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown("w") || Input.GetKeyDown("space"))
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
                else if(IsGrounded() && !isBird)
                {
                GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
                }
            }
        if (Input.GetKeyDown("q"))
        {
            SwapForm();
        }
    }

        void FixedUpdate()
        {
            body.velocity = new Vector2(Mathf.Lerp(horizontalAxis, horizontalAxis * playerSpeed, Time.fixedDeltaTime * damping), currentVelocity.y); //Linearlly interpolate between values to determine non-intrusive X velocity.
        }

        private void SwapForm()
        {
            if (isBird)
            {
            Debug.Log("Becoming Human");
            isBird = false;
            GetComponent<SpriteRenderer>().color = Color.red;
            }

            else 
            {
            Debug.Log("Becoming Bird");
            isBird = true;
            GetComponent<SpriteRenderer>().color = Color.blue;
            }

        }
        private bool IsGrounded()
        {
        
        Debug.Log("Ground check");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }



    }



