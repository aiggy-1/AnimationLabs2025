using UnityEngine;

public class controller_ : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("axe");
            animator.SetFloat("Blend",0.0f);
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("sword");
            animator.SetFloat("Blend", 2.0f);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("bow");
            animator.SetFloat("Blend", 1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //walking
            //animator.SetTrigger("bow");
            animator.SetFloat("Blend", 3.0f);

        }
    }
}
