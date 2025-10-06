using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonPathController : MonoBehaviour
{
   

    [SerializeField]
    public pathManager pathManager_;
    public Animator Anim;
    bool isWalking;
    List<wayPoint> thePath;
    wayPoint target;

    public float moveSpeed;
    public float rotateSpeed;
    public Rigidbody rb;

    void Start()
    {
        isWalking = false;
        Anim.SetBool("isWalking", false);
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
            isWalking = !isWalking;
            Anim.SetBool("isWalking", true);

        }

    }
    void FixedUpdate() { 
        if (isWalking)
        {
            rotateTowardsTarget();
            moveForward();
        }
    }

    void rotateTowardsTarget()
    {
        float stepSize = rotateSpeed * Time.fixedDeltaTime;
        Vector3 targetDir = target.pos - rb.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepSize, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

    }
    void moveForward()
    {
        float stepSize = Time.fixedDeltaTime * moveSpeed;
        float distanceToTarget = Vector3.Distance(rb.position, target.pos);

        if (distanceToTarget < stepSize)
        {
            //
            return;
        }
        Vector3 moveDir = transform.forward;
        // transform.Translate(moveDir * stepSize);
        rb.MovePosition(rb.position + moveDir * stepSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        target = pathManager_.getNextTarget();
        Debug.Log("triggering!");
    }
}

