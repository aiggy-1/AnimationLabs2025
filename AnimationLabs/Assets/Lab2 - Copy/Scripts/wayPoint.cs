using UnityEngine;
[System.Serializable]
public class wayPoint 
{
    [SerializeField]
    public Vector3 pos; 


    public void setPos(Vector3 newPos)
    {
        pos = newPos;
    }

    public Vector3 getPos() { return pos; }

    public wayPoint()
    {
        pos= new Vector3(0,0,0);
    }
}
