using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Simplifier : MonoBehaviour
{
    public float tolerance = 0.2f;


    public Guardian SimplifyPolygon(Guardian guardian)
    {
        List<Vector2> sample = guardian.points;
        sample.RemoveAt(sample.Count - 1);
        LineUtility.Simplify(sample.ToList(), tolerance, sample);

        Vector2 midPoint = sample[Mathf.RoundToInt(sample.Count / 2)];
        int index = guardian.points.IndexOf(midPoint);

        List<Vector2> firstHalf = guardian.points.GetRange(0, index);
        List<Vector2> secondHalf = guardian.points.GetRange(index, guardian.points.Count - index); // forse - 1

        firstHalf.Add(secondHalf[0]);
        secondHalf.Add(firstHalf[0]);

        LineUtility.Simplify(firstHalf.ToList(), tolerance, firstHalf);
        firstHalf.RemoveAt(firstHalf.Count - 1);
        LineUtility.Simplify(secondHalf.ToList(), tolerance, secondHalf);

        guardian.points = firstHalf;
        guardian.points.AddRange(secondHalf);

        Debug.Log("Simplified guardian to " + guardian.points.Count + " points");

        return guardian;
    }
}
