using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleporter : MonoBehaviour
{
    public GameObject targetLocation;
    public bool isUnlocked;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isUnlocked)
        {
            collision.transform.position = targetLocation.transform.position;
            Debug.Log("Player teleported");
        }
    }
}
