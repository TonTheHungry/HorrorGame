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
    public CanvasGroup deathcanvas;
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    float m_Timer;

    void Start()
    {
        currentHealth = maxHealth;
        monsterHealth = GetComponent<MonsterHealth>();
        anim = GetComponent<Animator>();
        follon = GetComponent<Follow>();
    }

    void Update()
    {
        if (follon.distance.x == 1 )
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        anim.Play("Hit");
        currentHealth -= damage;
        monsterHealth.HPSlider.value = currentHealth;

        if (monsterHealth.HPSlider.value == 0)
        {
            // follon.enabled = false; 
            // anim.Play("Death");
            m_Timer += Time.deltaTime;
            deathcanvas.alpha = m_Timer/fadeDuration;
        }

    }
}
