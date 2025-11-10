using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class triggerCheck : MonoBehaviour
{
    public Transform tar1;
    public Transform tar2;
    public Transform currentTar;
    public UnityEngine.AI.NavMeshAgent agent;
    void Start()
    {
      
        currentTar=tar1 ;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTar != null)
        {
            agent.destination = currentTar.transform.position;
        }

    }
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("zombie!");
        if (c.gameObject.CompareTag("swap"))
        {
            swap();

            if (c.gameObject.CompareTag("Player")){
                Debug.Log("Ah! The player!!");
            }
        }
    }
        void swap()
        {
            if (currentTar == tar1)
            {
                currentTar = tar2;
            }
            else if(currentTar == tar2) 
            {
                currentTar = tar1;
            }
        }

    
}
