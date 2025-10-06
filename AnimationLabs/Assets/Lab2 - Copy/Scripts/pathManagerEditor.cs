using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(pathManager))]
public class pathManagerEditor : Editor
{
    [SerializeField]
    pathManager pathManager_;

    [SerializeField]
    List<wayPoint> thePath; 
    List<int> toDelete;

    wayPoint selectedPoint = null;
    bool doRepaint = true;

    private void OnSceneGUI()
    {
        thePath = pathManager_.getPath();
        DrawPath(thePath);

    }
    private void OnEnable()
    {
        pathManager_=target as pathManager;
        toDelete = new List<int>();
    }

     public override void OnInspectorGUI()
    {
        this.serializedObject.Update();
        thePath = pathManager_.getPath();

        base.OnInspectorGUI();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Path");

        DrawGUIForPoints();

        //button for adding a point to path
        if(GUILayout.Button("Add Point to Path"))
        {
            pathManager_.createAddPoint();
        }
        EditorGUILayout.EndVertical();
        SceneView.RepaintAll();
    }
    void DrawGUIForPoints()
    {
        if (thePath != null && thePath.Count > 0)
        {
            for (int i = 0; i < thePath.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                wayPoint p = thePath[i];

                Color c = GUI.color;
                if (selectedPoint == p) GUI.color = Color.green;

                
                Vector3 oldPos = p.getPos();
                Vector3 newPos = EditorGUILayout.Vector3Field("", oldPos);

                if (EditorGUI.EndChangeCheck()) p.setPos(newPos);

                //del button

                if (GUILayout.Button("-", GUILayout.Width(25)))
                {
                    toDelete.Add(i);
                }
                GUI.color = c;
                EditorGUILayout.EndHorizontal();

            }
        }
        if (toDelete.Count > 0)
        {
            foreach(int i in toDelete)
            {
                thePath.RemoveAt(i);
                toDelete.Clear();
            }
        }
    }
    public void DrawPath(List<wayPoint> path)
    {
        if (path != null)
        { 
            int current = 0; 
            foreach(wayPoint wp in  path)
            {
                doRepaint = DrawPoint(wp);  
                int next = (current +1)% path.Count;
                wayPoint wpnext=path[next];

                DrawPathLine(wp,wpnext);
                //advance counter
                current += 1;
            }
        }
        if (doRepaint) Repaint();
    }
    public void DrawPathLine(wayPoint p1,wayPoint p2)
    {
        Color c = Handles.color;
        Handles.color = Color.gray;
        Handles.DrawLine(p1.getPos(), p2.getPos());
        Handles.color = c;
    }
    public bool DrawPoint(wayPoint p)
    {
        bool isChanged = false;
        if (selectedPoint == p)
        {
            Color c = Handles.color;
            Handles.color = Color.green;

            EditorGUI.BeginChangeCheck();
            Vector3 oldPos = p.getPos();
            Vector3 newPos = Handles.PositionHandle(oldPos, Quaternion.identity);

            float handleSize = HandleUtility.GetHandleSize(newPos);
            Handles.SphereHandleCap(-1, newPos, Quaternion.identity, 0.25f * handleSize, EventType.Repaint);

            if (EditorGUI.EndChangeCheck())
            {
                p.setPos(newPos);
            }
            Handles.color = c;
        }
        else
        {


            Vector3 currPos = p.getPos();
            float handleSize = HandleUtility.GetHandleSize(currPos);
            if (Handles.Button(currPos, Quaternion.identity, 0.25f * handleSize, 0.25f * handleSize, Handles.SphereHandleCap))
            {
                isChanged = true;
                selectedPoint = p;
            }
        }
        return isChanged;
    }



}
