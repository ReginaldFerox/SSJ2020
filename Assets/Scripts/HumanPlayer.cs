using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour
{
    public float playerSpeed;
    public float jumpHeight;
    public bool isActive;
    public float damping = 10;

    private Rigidbody2D rigidbody;
    private float horizontalAxis;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            horizontalAxis = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown("w") && IsGrounded())
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpHeight);
            }
        }
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(Mathf.Lerp(horizontalAxis, horizontalAxis * playerSpeed, Time.fixedDeltaTime * damping), rigidbody.velocity.y); //Linearlly interpolate between values to determine non-intrusive X velocity.
    }

    public bool IsGrounded()
    {
        return true;
    }
}
