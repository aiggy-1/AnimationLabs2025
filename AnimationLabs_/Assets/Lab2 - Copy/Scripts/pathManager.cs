using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathManager : MonoBehaviour
{

    [HideInInspector]
    [SerializeField] 
    public List<wayPoint> path;
    public GameObject prefab;
    int currentPointindex = 0;
    public List<GameObject> prefabPoints;


    public void Start()
    {
        prefabPoints = new List<GameObject>();
        //create prefab colliders for path local
        foreach (wayPoint p in path)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.pos;
            prefabPoints.Add(go);
        }
    }
    public void Update()
    {
        //update all prefab to wp locals
        for (int i = 0; i < path.Count; i++)
        {
            wayPoint p = path[i];
            GameObject g = prefabPoints[i];
            g.transform.position = p.pos;
        }
    }
    public List<wayPoint> getPath()
    {
        if (path == null)
        
            path = new List<wayPoint>();
            return path;
        
    }
    public void createAddPoint()
    {
        wayPoint go = new wayPoint();
        path.Add(go);
    }
    public wayPoint getNextTarget()
    {
        int nextPointIndex= (currentPointindex+1)%(path.Count);
        currentPointindex= nextPointIndex;
        return path[nextPointIndex];
    }
}
