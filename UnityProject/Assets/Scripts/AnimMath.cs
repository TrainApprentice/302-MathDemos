using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimMath 
{
    public static float Lerp(float a, float b, float percent, bool allowExtrapolation = false)
    {
        if (!allowExtrapolation)
        {
            if (percent > 1) percent = 1;
            if (percent < 0) percent = 0;
        }

        return (b - a) * percent + a;
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float percent, bool allowExtrapolation = false)
    {
        if (!allowExtrapolation)
        {
            if (percent > 1) percent = 1;
            if (percent < 0) percent = 0;
        }

        return (b - a) * percent + a;
    }

    public static Quaternion Lerp(Quaternion a, Quaternion b, float percent, bool allowExtrapolation = false)
    {
        if (!allowExtrapolation)
        {
            if (percent > 1) percent = 1;
            if (percent < 0) percent = 0;
        }

        var lx = Lerp(a.x, b.x, percent, allowExtrapolation);
        var ly = Lerp(a.y, b.y, percent, allowExtrapolation);
        var lz = Lerp(a.z, b.z, percent, allowExtrapolation);
        var lw = Lerp(a.w, b.w, percent, allowExtrapolation);

        return new Quaternion(lx, ly, lz, lw);
        
    }

    public static float Map(float val, float inMin, float inMax, float outMin, float outMax)
    {
        float p = (val - inMin) / (inMax - inMin);

        return Lerp(outMin, outMax, p);
    }

    public static float Ease(float current, float target, float percentLeftAfter1Second, float dt = -1)
    {
        if (dt < 0) dt = Time.deltaTime;
        float p = 1 - Mathf.Pow(percentLeftAfter1Second, dt);

        return Lerp(current, target, p);
    }

    public static Vector3 Ease(Vector3 current, Vector3 target, float percentLeftAfter1Second, float dt = -1)
    {
        if (dt < 0) dt = Time.deltaTime;
        float p = 1 - Mathf.Pow(percentLeftAfter1Second, dt);

        return Lerp(current, target, p);
    }
    
}
