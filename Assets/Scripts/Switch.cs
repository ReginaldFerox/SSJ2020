using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject previousSwitch;
    public float buttonDepressAmount;
    public bool isFinalSwitch;
    public GameObject doorToUnlock;
    private bool isPressed;
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            if (previousSwitch == null && isPressed==false)
            {
                DepressButton();
            }
            else if (previousSwitch.GetComponent<Switch>().isPressed && isPressed == false)
            {
                DepressButton();
            }
            else if(isPressed==true)
            {
                Debug.Log("Not Happening");
            }
            else
            {
                ResetButton();
            }

        }
    }

    private void DepressButton()
    {
        isPressed = true;
        transform.position = new Vector3(transform.position.x, (transform.position.y - buttonDepressAmount), transform.position.z);
        if (isFinalSwitch)
        {
            if (doorToUnlock.GetComponent<DoorTeleporter>()!=null)
            {
                doorToUnlock.GetComponent<DoorTeleporter>().isUnlocked = true;
            }
            else if (doorToUnlock.GetComponent<LockedCage>()!=null)
            {
                doorToUnlock.GetComponent<LockedCage>().OpenCage();
            }
            
        }
    }

    public void ResetButton()
    {
        if (isPressed == true)
        {
            isPressed = false;
            transform.position = new Vector3(transform.position.x, (transform.position.y + buttonDepressAmount), transform.position.z);
        }
        if (previousSwitch != null)
        {
            previousSwitch.GetComponent<Switch>().ResetButton();
        }
    }
}
