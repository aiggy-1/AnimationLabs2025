using UnityEngine;

public class rayManager : MonoBehaviour
{
    [SerializeField] GameObject target;
    private Camera cam;
    public Transform tar;
    private UnityEngine.AI.NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
               tar.transform.position = hit.point;
                agent.destination=tar.transform.position;
            }
        }
    }
}
