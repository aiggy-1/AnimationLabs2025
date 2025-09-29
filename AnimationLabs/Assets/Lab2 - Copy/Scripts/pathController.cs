using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathController : MonoBehaviour
{
    [SerializeField]
    public pathManager pathManager_;
    public Animator Anim;
    bool isWalking; 
    List<wayPoint> thePath;
    wayPoint target;

    public float moveSpeed;
    public float rotateSpeed;

    void Start()
    {
        isWalking = false;
        Anim.SetBool("isWalking",false);
        thePath = pathManager_.getPath();
        if (thePath != null && thePath.Count > 0)
        {
            target = thePath[0];
        }
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isWalking=!isWalking;
            Anim.SetBool("isWalking", true);

        }if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
        }
    }

    void rotateTowardsTarget() {
        float stepSize= rotateSpeed*Time.deltaTime;
        Vector3 targetDir = target.pos - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation=Quaternion.LookRotation(newDir);
        
        }
    void moveForward() { 
        float stepSize = Time.deltaTime * moveSpeed;
         float distanceToTarget = Vector3.Distance(transform.position, target.pos);
    
    if(distanceToTarget<stepSize){
            //
            return;
        }
        Vector3 moveDir = Vector3.forward;
        transform.Translate(moveDir*stepSize);
}
   
    private void OnTriggerEnter(Collider other)
    {
        target=pathManager_.getNextTarget();
    }
}
