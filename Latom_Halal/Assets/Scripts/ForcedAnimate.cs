using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedAnimate : MonoBehaviour
{
    public Animator animator;
    public Vector3 point1;
    public Vector3 point2;
    private Vector3 distance;
    private Vector3 point3;
    public MonsterHealth monsterHealth;
    private int currentHealth = 100;
    public Follow follon;


    void Start()
    {
        animator = GetComponent<Animator>();
        point1 = transform.position;
        point2 = transform.position;
        distance = point2 - point2;
        monsterHealth = GetComponent<MonsterHealth>();
        follon = GetComponent<Follow>();
    }

    void Update()
    {
        point2 = transform.position;
        distance = point3 - point2;

        // An if to change the animation bool & one to stop it. 
        if (point2 != point1)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsAttacking", false);
            point3 = transform.position;
        }

        if (distance.x == 0 && distance.y == 0 && distance.z == 0)
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("CreepyRun", false);
            animator.SetBool("IsAttacking", true);
            TakeDamage(1);
            point1 = point2;
          
        }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        monsterHealth.HPSlider.value = currentHealth; 
    }
}
