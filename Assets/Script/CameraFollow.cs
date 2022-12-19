using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car; // store car position
    public Vector3 offset; 
    // Update is called once per frame
    void Update()
    {
        // هتخلي موقع الكاميرا قبل موقع العربية بمقدار الاوفسيت 
        transform.position = car.position + offset ;
    }
}
