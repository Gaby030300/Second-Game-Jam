using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseMakeDmg : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(20.0f);
        }
    }
}
