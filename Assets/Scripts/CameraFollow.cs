using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followspeede = 2f;
    public Transform targe;

    void Update()
    {
        Vector3 newPos = new Vector3(targe.position.x,targe.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,followspeede*Time.deltaTime);
    }
}