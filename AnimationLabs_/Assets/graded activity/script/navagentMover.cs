using UnityEngine;

public class navagentMover : MonoBehaviour
{
    Animator animator;

    public GameObject target;
    private UnityEngine.AI.NavMeshAgent agent;
    bool isMoving; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateTowardsTarget();
        agent.destination = target.transform.position;
    }
    void rotateTowardsTarget()
    {
        Debug.Log("R");
      //  transform.rotation = target.transform.rotation;
    }
    void atTarget()
    {
        if (agent.transform.position == target.transform.position)
        {
            isMoving=false;
        }
    }
  void  onTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Target"))
        {
            Debug.Log("Hit Object!");
            c.gameObject.SetActive(false);
        }
        if (c.gameObject.CompareTag("sword"))
        {
            Debug.Log("Got Sword!");
            c.gameObject.SetActive(false);
            animator.SetTrigger("sword");
            animator.SetFloat("Blend", 2.0f);

        }
    }
}
