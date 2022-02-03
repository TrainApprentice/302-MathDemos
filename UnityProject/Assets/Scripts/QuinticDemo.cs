using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuinticDemo : MonoBehaviour
{
    public Transform startPoint, endPoint, control1, control2, control3, control4;
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

        if (useEasing) p = temporalEasing.Evaluate(p);


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
        Vector3 a = AnimMath.Lerp(startPoint.position, control1.position, p);
        Vector3 b = AnimMath.Lerp(control1.position, control2.position, p);
        Vector3 c = AnimMath.Lerp(control2.position, control3.position, p);
        Vector3 d = AnimMath.Lerp(control3.position, control4.position, p);
        Vector3 e = AnimMath.Lerp(control4.position, endPoint.position, p);
        
        Vector3 midA = AnimMath.Lerp(a, b, p);
        Vector3 midB = AnimMath.Lerp(b, c, p);
        Vector3 midC = AnimMath.Lerp(c, d, p);
        Vector3 midD = AnimMath.Lerp(d, e, p);

        Vector3 thirdA = AnimMath.Lerp(midA, midB, p);
        Vector3 thirdB = AnimMath.Lerp(midB, midC, p);
        Vector3 thirdC = AnimMath.Lerp(midC, midD, p);

        Vector3 lastA = AnimMath.Lerp(thirdA, thirdB, p);
        Vector3 lastB = AnimMath.Lerp(thirdB, thirdC, p);

        return AnimMath.Lerp(lastA, lastB, p);
    }

    void OnDrawGizmos()
    {

        for (int i = 0; i < curveResolution; i++)
        {
            Vector3 a = FindPointOnCurve(i / (float)curveResolution);
            Vector3 b = FindPointOnCurve((i + 1) / (float)curveResolution);

            Gizmos.DrawLine(a, b);
        }
    }
}

[CustomEditor(typeof(QuinticDemo))]
public class QuinticDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Play Tween"))
        {
            (target as QuinticDemo).StartAnim(true);
        }

    }
}

