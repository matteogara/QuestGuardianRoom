using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianDebugger : MonoBehaviour
{
    public SaveLoad saveLoad;
    public DrawLine drawLine;
    public Simplifier simplifier;
    public ProceduralRoom proceduralRoom;

    Guardian guardian;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) guardian = saveLoad.Load();

        if (Input.GetKeyDown(KeyCode.D)) drawLine.UpdateLine(BiToTriPoints(guardian.points));

        if (Input.GetKeyDown(KeyCode.S)) guardian = simplifier.SimplifyPolygon(guardian);

        if (Input.GetKeyDown(KeyCode.W)) proceduralRoom.CreateWalls(BiToTriPoints(guardian.points));
    }


    List<Vector3> BiToTriPoints(List<Vector2> points) {
        List<Vector3> newPoints = new List<Vector3>();

        for (int i = 0; i < points.Count; i++) {
            newPoints.Add(new Vector3(points[i].x, 0, points[i].y));
        }

        return newPoints;
    }
}
