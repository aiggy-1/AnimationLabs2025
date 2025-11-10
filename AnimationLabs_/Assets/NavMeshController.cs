using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    private Animator animator; 
    public GameObject Target;
    public GameObject tar2;
    private NavMeshAgent agent;
    bool hasWeapon1;
    bool hasWeapon2;
    bool bareHand;

    public GameObject sword;
    public Transform targetPos;
    bool canSnap = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        if (Target != null) { 
        agent.destination = Target.transform.position;
            if (canSnap)
            {
                snapToTar();
            }
    
    }

    }

     void OnTriggerEnter(Collider c)      //if it hits the target
    {
        Debug.Log("Touching");
       
        if (c.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit Object!");
            c.gameObject.SetActive(false);
            setTarget();
        }
        if (c.gameObject.CompareTag("sword"))
        {
            Debug.Log("Got Sword!");
          //  c.gameObject.SetActive(false);
            animator.SetTrigger("sword");
            animator.SetFloat("Blend", 2.0f);
            canSnap=true;
            //snapToTar();
            Debug.Log("Ah! The player!!");
        }
    }
     void OnTriggerExit(Collider other)
    {
        //if (other.name == "Target")
        //{
        //    setTarget();
        //    //edit here
        //}
    }
    void setTarget()
    {
        Target = tar2; 
    }
    void snapToTar()
    {
        sword.transform.position = targetPos.transform.position;
    }
}
