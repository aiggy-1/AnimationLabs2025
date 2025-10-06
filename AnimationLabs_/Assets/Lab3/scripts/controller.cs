using UnityEngine;
using UnityEngine.AI;

public class controller : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    bool isWalking;
    private Animator Anim; 

    
    void Start()
    {
        isWalking = true;
        agent= GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
            agent.destination = target.transform.position;
        else { agent.destination = transform.position; }
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Dragon"))
        {
            isWalking = false;
            Debug.Log("Within Dragon range");
            Anim.SetTrigger("attack");
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (c.name == "Dragon")
        {
            isWalking = true;
            Anim.SetTrigger("walk");
        }
    }
}
