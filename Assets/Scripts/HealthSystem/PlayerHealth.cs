using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;

    public Slider healthBar;
    private Animator anim;

    private void Start()
    {
        curHealth = maxHealth;
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;
        anim = GetComponent<Animator>();
    }

     void Update()
    {
        float Hit = anim.GetFloat("Hit");

        if(Hit > 0)
        {
            Hit -= Time.deltaTime * 3;
            anim.SetFloat("Hit", Hit);
        }
        if(curHealth < 1)
        {
            anim.SetBool("Death", true);


            
        }
        if (Input.GetKey(KeyCode.P))
        {
            SendDamage(10);
        }
    }

    public void SendDamage(float damageValue)
    {
        curHealth -= damageValue;
        healthBar.value = curHealth;
        anim.SetFloat("Hit",1);
    }
}
