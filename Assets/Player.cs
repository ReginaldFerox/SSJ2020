using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float jumpHeight;

    private void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed,0);
        }
        if (Input.GetKeyDown("a"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-playerSpeed, 0);
        }
        if (Input.GetKeyDown("w"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(0, jumpHeight);
        }
    }

}
