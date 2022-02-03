using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitDemo : MonoBehaviour
{

    public Transform orbitCenter;
    public bool doFlip = false;

    public float radius = 2;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = (doFlip) ? 3.14f : 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!orbitCenter) return;

        timer += Time.deltaTime;

        var x = Mathf.Cos(timer) * radius;
        var y = (doFlip) ? Mathf.Sin(timer) * -radius : Mathf.Sin(timer) * radius;
        var z = Mathf.Sin(timer) * radius;

        transform.position = new Vector3(x, y, z) + orbitCenter.position;
    }
}
