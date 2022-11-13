using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GooseController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private float distance;
    [SerializeField] private Animator animGoose;
    [SerializeField] private bool canMove;
    [SerializeField] private Collider collider;

    void Start()
    {
        canMove = true;
        animGoose.SetBool("Die", false);
        agent = GetComponent<NavMeshAgent>();        
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < distance && canMove)
        {
            animGoose.SetBool("Walking",true);
            setDestination();
        }
        else
        {
            animGoose.SetBool("Walking",false);
        }
    }

    public void setDestination()
    {
        agent.SetDestination(player.position);
    }

    public void die()
    {
        collider.enabled = false;
        canMove = false;        
        animGoose.SetBool("Die", true);
    }
}
