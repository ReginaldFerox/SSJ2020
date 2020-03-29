using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedCage : MonoBehaviour
{
    public GameObject bird;
    public void OpenCage()
    {

        bird.GetComponent<FreeBird>().birdSpeed = 2;
        GetComponent<SpriteRenderer>().forceRenderingOff = true;
    }

 
}
