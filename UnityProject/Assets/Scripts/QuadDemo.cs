using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuadDemo : MonoBehaviour
{

    public Transform startPoint, endPoint, controlPoint;
    [Range(2, 50)]
    public int curveResolution = 10;
    public float tweenLength = 3;
    public bool useEasing = false;
    public AnimationCurve temporalEasing;
    
    private bool isPlaying = false;
    private float tweenTimer = 0;

    void Update()
    {
        if (isPlaying) tweenTimer += Time.deltaTime;

        float p = tweenTimer / tweenLength;
        p = Mathf.Clamp(p, 0, 1);

        if(useEasing) p = temporalEasing.Evaluate(p);
        

        transform.position = FindPointOnCurve(p);
        if (tweenTimer >= tweenLength) isPlaying = false;
        
    }

    public void StartAnim(bool fromStart = false)
    {
        isPlaying = true;
        if (fromStart) tweenTimer = 0;
    }

    Vector3 FindPointOnCurve(float p)
    {
        Vector3 a = AnimMath.Lerp(startPoint.position, controlPoint.position, p);
        Vector3 b = AnimMath.Lerp(controlPoint.position, endPoint.position, p);

        return AnimMath.Lerp(a, b, p);
    }

    void OnDrawGizmos()
    { 

        for (int i = 0; i < curveResolution; i++)
        {
            Vector3 a = FindPointOnCurve(i / (float)curveResolution);
            Vector3 b = FindPointOnCurve((i+1) / (float)curveResolution);

            Gizmos.DrawLine(a, b);
        }
    }
}
[CustomEditor(typeof(QuadDemo))]
public class QuadDemoEditor: Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Play Tween"))
        {
            (target as QuadDemo).StartAnim(true);
        }

    }
}
