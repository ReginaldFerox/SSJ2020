using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w") && GetComponent<BirdPlayer>().isBird)
        {
            anim.SetTrigger("Flap");
        }
    }

   public void SetIdle()
    {
        anim.SetTrigger("Stop");
    }
}
