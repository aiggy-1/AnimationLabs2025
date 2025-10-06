using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dragonCollider : MonoBehaviour
    
{
   public Rigidbody rb;
public pathController pc;

    public Animator anim_;
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("wall")){

            anim_.SetBool("isIdle", true);
            anim_.SetBool("isWalking", false);
            Debug.Log("collided!");
            pc.isWalking = false; 
        }
    }
   
}
