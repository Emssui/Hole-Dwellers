using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public int patrolDestination;


    // Update is called once per frame
    void Update()
    {
        if(patrolDestination == 0) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position,  patrolPoints[0].position) < .2f) {
                transform.localScale = new Vector3(1, 1, 1);
                patrolDestination = 1;
            }
        }

        if(patrolDestination == 1) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position,  patrolPoints[1].position) < .2f) {
                transform.localScale = new Vector3(-1, 1, 1);

                patrolDestination = 0;
            }
        }
    }
}
