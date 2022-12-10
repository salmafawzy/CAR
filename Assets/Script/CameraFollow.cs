using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform car;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position = car.position + offset ;
    }
}
