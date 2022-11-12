using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public List<Vector3> linePoints = new List<Vector3>();
    
    //Distance of units from the camera
    public float distance;
    
    private GameObject newLine;
    private LineRenderer drawLine;
    public float lineWidth;
    
    void Start()
    {
        
    }

    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            newLine = new GameObject();
            drawLine = newLine.AddComponent<LineRenderer>();
            drawLine.material = new Material(Shader.Find("Sprites/Default"));
            
            drawLine.startColor = Color.red;
            drawLine.endColor = Color.red;
            
            drawLine.startWidth = lineWidth;
            drawLine.endWidth = lineWidth;
        }
        
        if (Input.GetMouseButton(0))
        {
            linePoints.Add(GetMousePosition());
            drawLine.positionCount = linePoints.Count;
            drawLine.SetPositions(linePoints.ToArray());
        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(newLine);
            linePoints.Clear();
        }
        
    }

    Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction * distance;
    }
    
}
