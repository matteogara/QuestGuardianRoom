using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer lineRenderer;



    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    public void UpdateLine(List<Vector3> points)
    {
        Vector3[] newPositions = new Vector3[points.Count];

        for (int i = 0; i < points.Count; i++) {
            newPositions[i] = points[i];
        }

        lineRenderer.positionCount = newPositions.Length;
        lineRenderer.SetPositions(newPositions);
    }
}
