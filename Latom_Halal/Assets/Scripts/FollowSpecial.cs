using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpecial : MonoBehaviour
{
    public GameObject player;
    public float speed = 1.0f;
    private Transform target;
    public Vector3 distance;

    void Start()
    {
        target = player.transform;
    }

    void Update()
    {
        distance = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(distance);
        float step;
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.rotation = rotation;
        
    }
}
