using UnityEngine;

public class npcMover : MonoBehaviour
{
    public Transform tar1;
    public Transform tar2;
    public Transform currentTar;
    public UnityEngine.AI.NavMeshAgent agent;
    void Start()
    {
        agent.destination=tar1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination= currentTar.transform.position;
        
    }
   void  onTriggerEnter(Collider c){
            if(c.gameObject.CompareTag("swap")) {
                swap();

        }
    
                void swap() {
                if (currentTar == tar1)
                {
                    currentTar=tar2;
                }
                else
                {
                    currentTar = tar1;
                }
            }

    }
}
