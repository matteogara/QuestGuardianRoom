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


    public void UpdateLine(Guardian guardian)
    {
        Vector3[] newPositions = new Vector3[guardian.points.Count];

        for (int i = 0; i < guardian.points.Count; i++) {
            newPositions[i] = new Vector3(guardian.points[i].x, 0, guardian.points[i].y);
        }

        lineRenderer.positionCount = newPositions.Length;
        lineRenderer.SetPositions(newPositions);
    }
}
