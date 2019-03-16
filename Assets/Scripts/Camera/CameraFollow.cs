using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float Smoothing = 5f;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 TargetCampos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, TargetCampos,Smoothing*Time.deltaTime);
    }
}
