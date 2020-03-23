using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSwitcher : MonoBehaviour
{
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public int monNum = 0;
    public Animator animator;
    private GameObject current;

    void Start()
    {
        current = Instantiate(switch1, transform.position, transform.rotation);
        current.transform.parent = transform;
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (monNum == 1)
        {
            GameObject thisobject = Instantiate(switch2, transform.position, transform.rotation) as
                GameObject;
            Destroy(current);
            thisobject.transform.parent = transform;
            current = thisobject;
        }
        else if (monNum == 2)
        {
            GameObject thisobject = Instantiate(switch3, transform.position, transform.rotation) as
                GameObject;
            Destroy(current);
            thisobject.transform.parent = transform;
            current = thisobject;
        }
        else
        {
            GameObject thisobject = Instantiate(switch1, transform.position, transform.rotation) as
    GameObject;
            Destroy(current);
            thisobject.transform.parent = transform;
            current = thisobject;
        }
    }
}
