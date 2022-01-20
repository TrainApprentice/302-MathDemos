using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseDemo : MonoBehaviour
{

    public Transform target;
    public float percentLeftAfter1Second = .0001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = AnimMath.Lerp(transform.position, target.position, Time.deltaTime);
        transform.position = AnimMath.Ease(transform.position, target.position, percentLeftAfter1Second);
    }
}
