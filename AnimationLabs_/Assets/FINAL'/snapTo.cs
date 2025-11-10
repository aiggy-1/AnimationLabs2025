using UnityEngine;

public class snapTo : MonoBehaviour
{
    public GameObject sword; 
    public Transform targetPos;
    bool canSnap=false;
    void Update()
    {
        if (canSnap)
        {
            snapToTar();
        }
    }
  void   onTriggerEnter(dragonCollider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Debug.Log("player touch");
           canSnap=true;
        }
    }
   void snapToTar()
    {
       sword.transform.position = targetPos.transform.position; 
    }
}
