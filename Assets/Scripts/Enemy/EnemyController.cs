using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 endPosition;
    private Vector3 initialPosition;
    private bool moveEnd;
    [SerializeField] private Animator animGoose;
    [SerializeField] private bool canMove;
    [SerializeField] private Collider collider;

    //Audio Effects
    AudioSource audioSource;
    public AudioClip gooseEffect;

    void Start()
    {
        canMove = true;
        initialPosition = transform.position;
        moveEnd = true;
        audioSource = GetComponent<AudioSource>();
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
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinyPosition, speed * Time.deltaTime);
        }
        //Change direction
        if (transform.position == endPosition) 
        {
            moveEnd = false;
            transform.Rotate(Vector3.up, 180);
        }
        if (transform.position == initialPosition) 
        {
            moveEnd = true;
            transform.Rotate(Vector3.up, 180);
        }
    }
    public void Die()
    {
        audioSource.PlayOneShot(gooseEffect, 0.3f);
        collider.enabled = false;
        canMove = false;
        animGoose.SetBool("Die", true);
        animGoose.SetBool("Walking", false);
    }
}