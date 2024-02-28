using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsating : MonoBehaviour
{
    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float yPosition = initialY + Mathf.Sin(Time.time * 3) * 0.1f;
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
}
