using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    public Transform pointA, pointB;

    [Range(0, 1)]
    public float percent = 0;
    void DoInterpolation()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, percent);
        transform.rotation = Quaternion.Lerp(pointA.rotation, pointB.rotation, percent);
    }

    private void OnValidate()
    {
        DoInterpolation();
    }

    float Lerp(float min, float max, float percent)
    {
        return (max - min) * percent;
    }

    Vector3 LerpVector(Vector3 a, Vector3 b, float percent)
    {
        float xVal = (b.x - a.x) * percent;
        float yVal = (b.y - a.y) * percent;
        float zVal = (b.z - a.z) * percent;

        return new Vector3(xVal, yVal, zVal);
    }

    float Map(float val, float inMin, float inMax, float outMin, float outMax)
    {
        return (val - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
