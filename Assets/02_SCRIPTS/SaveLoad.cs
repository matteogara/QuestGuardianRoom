using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public bool rescale = false;
    public int oldResolution = 700;
    public int newResolution = 7;

    Guardian guardian;



    public Guardian Save()
    {
        guardian = new Guardian();
        guardian.points.Add(new Vector2(2, 0.5f));
        guardian.points.Add(new Vector2(3, 1));
        guardian.points.Add(new Vector2(0.1f, 33));

        string pointsToJson = JsonUtility.ToJson(guardian, true);
        string path = Application.persistentDataPath + "/PointsData.json";
        System.IO.File.WriteAllText(path, pointsToJson);

        Debug.Log("Saved " + guardian.points.Count + " points from " + path);

        return guardian;
    }


    public Guardian Load()
    {
        string pointsToJson = JsonUtility.ToJson(guardian, true);

        string path = Application.persistentDataPath + "/Guardian.json";
        string jsonToPoints = System.IO.File.ReadAllText(path);
        guardian = JsonUtility.FromJson<Guardian>(jsonToPoints);

        if (rescale) {
            for (int i = 0; i < guardian.points.Count; i++) {
                float x = (guardian.points[i].x / oldResolution - 0.5f) * newResolution;
                float y = (guardian.points[i].y / oldResolution - 0.5f) * newResolution;
                guardian.points[i] = new Vector2(x, y);
            }
        }

        Debug.Log("Loaded " + guardian.points.Count + " points from " + path);

        return guardian;
    }
}
