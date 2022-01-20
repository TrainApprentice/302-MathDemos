using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDemo : MonoBehaviour
{

    public Transform orbitCenter;
    public bool doFlip = false;

    public float radius = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!orbitCenter) return;

        var x = Mathf.Cos(Time.time) * radius;
        var y = (doFlip) ? Mathf.Sin(Time.time) * -radius : Mathf.Sin(Time.time) * radius;
        var z = Mathf.Sin(Time.time) * radius;

        transform.position = new Vector3(x, y, z) + orbitCenter.position;
    }
}
