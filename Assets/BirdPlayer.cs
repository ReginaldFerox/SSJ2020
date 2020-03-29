using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayer : MonoBehaviour
{
    public float playerSpeed;
    public float jumpHeight;
    public int numberOfFlaps = 0;
    private Vector3 currentVelocity;
    public bool infiniteFlaps = false;
    private bool isHuman;
    public bool canChangeForm;
    private void FixedUpdate()
    {
        currentVelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;

        if (Input.GetKeyDown("d"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, currentVelocity.y);
        }
        if (Input.GetKeyDown("a"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-playerSpeed, currentVelocity.y);
        }
        if (Input.GetKeyDown("w"))
        {
            if (infiniteFlaps) {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
            }
            else if (numberOfFlaps<=5)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
                numberOfFlaps++;
            }
        }
        if (Input.GetKeyDown("Shift")) {

        

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
