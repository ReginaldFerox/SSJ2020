using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayer : MonoBehaviour
{
    public float playerSpeed;
    public float jumpHeight;
    public int numberOfFlaps = 0;
    private Vector3 currentVelocity;

    private void Update()
    {
        // Sprint: Can sprint in air. OnShiftDown increase speed, onShiftUp decrease speed
        currentVelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;

        if (Input.GetKeyDown("d"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, currentVelocity.y);
        }
        if (Input.GetKeyDown("a"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-playerSpeed, currentVelocity.y);
        }
        if (Input.GetKeyDown("w") && numberOfFlaps < 5)
        {
            numberOfFlaps++;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
        }
      
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
        {
            numberOfFlaps = 0;
        }
    }

    

}
