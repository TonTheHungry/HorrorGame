using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public MonsterHealth monsterHealth;
    public Animator anim;

   
    void Start()
    {
        currentHealth = maxHealth;
        monsterHealth = GetComponent<MonsterHealth>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
       // anim.Play("Hit");
        currentHealth -= damage;
        monsterHealth.HPSlider.value = currentHealth;

        if (monsterHealth.HPSlider.value <= 0)
        {
            anim.Play("Death");
        }

    }
}
