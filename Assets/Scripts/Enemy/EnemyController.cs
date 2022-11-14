using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Vector3 endPosition;
    private Vector3 initialPosition;
    private bool moveEnd;

    void Start()
    {
        initialPosition = transform.position;
        moveEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        //1. Calculate end position
        Vector3 destinyPosition = (moveEnd) ? endPosition : initialPosition;
        //2. Move Enemy
        transform.position = Vector3.MoveTowards(transform.position, destinyPosition, speed * Time.deltaTime);
        //Change direction
        if (transform.position == endPosition) moveEnd = false;
        if (transform.position == initialPosition) moveEnd = true;
    }
}