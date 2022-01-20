using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TweenDemo : MonoBehaviour
{
    public AnimationCurve curve;

    public Transform pointA, pointB;

    private float currTime;
    private bool isPlaying = false;
    
    [Range(.25f,5f)]
    public float duration;

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            currTime += Time.deltaTime;
            DoInterp();
        }
    }

    public void StartTween()
    {
        isPlaying = true;
        currTime = 0;
    }

    private void DoInterp()
    {
        if (pointA == null || pointB == null) return;
        float p = currTime / duration;
        

        p = curve.Evaluate(p);

        Vector3 pos = AnimMath.Lerp(pointA.position, pointB.position, p);

        transform.position = pos;

        if (currTime >= duration) isPlaying = false;
    }
}
[CustomEditor(typeof(TweenDemo))]
public class EditorTweenDemo : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Start Tween"))
        {
            (target as TweenDemo).StartTween();
        }

    }
}
