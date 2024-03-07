using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject boxHit;
    public GameObject enemy;
    public GameObject pilleObj;

    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -153.6)
        {
            rb.gravityScale = 0;
        }
        
        if(enemy == null) {
            Destroy(pilleObj);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.gravityScale = 4;
            enemy.SetActive(true);
            Destroy(boxHit);
        }
    }
}
