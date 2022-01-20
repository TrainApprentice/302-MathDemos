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
        transform.position = AnimMath.Lerp(pointA.position, pointB.position, percent);
        transform.rotation = AnimMath.Lerp(pointA.rotation, pointB.rotation, percent);
    }

    private void OnValidate()
    {
        DoInterpolation();
    }

}
