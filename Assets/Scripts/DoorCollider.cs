using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{

    public GameObject HumanPlayer;
    public GameObject Destination; // Gameobject where they will be teleported to
    public bool doorIsOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Player" && doorIsOpen) 
        {
            other.transform.position = Destination.transform.position;
        }   
       
    }
}
