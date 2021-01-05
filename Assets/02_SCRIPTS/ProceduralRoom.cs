using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralRoom : MonoBehaviour
{

    public GameObject wall;
    public GameObject wallWithDoor;
    public GameObject wallWithWindow;
    public float doorChance = 1;
    public float windowChance = 1;
    public float wallChance = 1;

    GameObject newPiece;



    private void Start()
    {
        float totalChance = doorChance + windowChance + wallChance;
        doorChance /= totalChance;
        windowChance /= totalChance;
        wallChance /= totalChance;
    }


    public void CreateWalls(List<Vector3> points) {
        // Destroy previous walls (debug)
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        for (int i = 1; i < points.Count; i++) {
            Vector3 segment = points[i - 1] - points[i];

            if (segment.magnitude > 1.2f) {
                float rnd = Random.Range(0f, 1f);
                if (rnd <= doorChance) WallWithDoor(points[i], segment);
                else if (rnd > doorChance && rnd <= doorChance + windowChance) WallWithWindow(points[i], segment);
                else Wall(points[i], segment);
            } else {
                Wall(points[i], segment);
            }
        }
    }


    void Wall(Vector3 _origin, Vector3 _segment) {
        newPiece = Instantiate(wall, gameObject.transform);
        newPiece.transform.position = _origin;
        newPiece.transform.rotation = Quaternion.LookRotation(_segment);
        newPiece.transform.localScale = new Vector3(1, 1, _segment.magnitude);
    }


    void WallWithDoor(Vector3 _origin, Vector3 _segment) {
        float left = Random.Range(0, _segment.magnitude - 1.2f);
        float right = _segment.magnitude - 1.2f - left;

        newPiece = Instantiate(wall, gameObject.transform);
        newPiece.transform.position = _origin;
        newPiece.transform.rotation = Quaternion.LookRotation(_segment);
        newPiece.transform.localScale = new Vector3(1, 1, left);

        newPiece = Instantiate(wallWithDoor, gameObject.transform);
        newPiece.transform.position = _origin + _segment.normalized * left;
        newPiece.transform.rotation = Quaternion.LookRotation(_segment);

        newPiece = Instantiate(wall, gameObject.transform);
        newPiece.transform.position = _origin + _segment.normalized * (left + 1.2f);
        newPiece.transform.rotation = Quaternion.LookRotation(_segment);
        newPiece.transform.localScale = new Vector3(1, 1, right);
    }


    void WallWithWindow(Vector3 _origin, Vector3 _segment)
    {
        float left = Random.Range(0, _segment.magnitude - 1.2f);
        float right = _segment.magnitude - 1.2f - left;

        newPiece = Instantiate(wall, gameObject.transform);
        newPiece.transform.position = _origin;
        newPiece.transform.rotation = Quaternion.LookRotation(_segment);
        newPiece.transform.localScale = new Vector3(1, 1, left);

        newPiece = Instantiate(wallWithWindow, gameObject.transform);
        newPiece.transform.position = _origin + _segment.normalized * left;
        newPiece.transform.rotation = Quaternion.LookRotation(_segment);

        newPiece = Instantiate(wall, gameObject.transform);
        newPiece.transform.position = _origin + _segment.normalized * (left + 1.2f);
        newPiece.transform.rotation = Quaternion.LookRotation(_segment);
        newPiece.transform.localScale = new Vector3(1, 1, right);
    }
}
