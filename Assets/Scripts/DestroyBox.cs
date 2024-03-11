using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    public GameObject destroyBox;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(destroyBox);
        }
    }
}
