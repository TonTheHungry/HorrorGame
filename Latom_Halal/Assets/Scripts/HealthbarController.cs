using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public MonsterHealth monsterHealth;
    public Animator anim;
    public Follow follon;

    void Start()
    {
        currentHealth = maxHealth;
        monsterHealth = GetComponent<MonsterHealth>();
        anim = GetComponent<Animator>();
        follon = GetComponent<Follow>();
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
        anim.Play("Hit");
        currentHealth -= damage;
        monsterHealth.HPSlider.value = currentHealth;

        if (monsterHealth.HPSlider.value <= 0)
        {
            follon.enabled = false; 
            anim.Play("Death");
        }

    }
}
