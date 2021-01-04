using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralRoom : MonoBehaviour
{

    public GameObject wallPiece;


    public void CreateWalls(List<Vector3> points) {
        // Destroy previous walls (debug)
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < points.Count - 1; i++) {
            GameObject newWall = Instantiate(wallPiece, gameObject.transform);

            Vector3 segment = points[i + 1] - points[i];

            newWall.transform.position = points[i];
            newWall.transform.rotation = Quaternion.LookRotation(segment);
            newWall.transform.localScale = new Vector3(1, 1, segment.magnitude);
        }
    }
}
