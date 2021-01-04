using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianDebugger : MonoBehaviour
{
    public SaveLoad saveLoad;
    public DrawLine drawLine;
    public Simplifier simplifier;

    Guardian guardian;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) guardian = saveLoad.Load();

        if (Input.GetKeyDown(KeyCode.D)) drawLine.UpdateLine(guardian);

        if (Input.GetKeyDown(KeyCode.S)) guardian = simplifier.SimplifyPolygon(guardian);
    }
}
