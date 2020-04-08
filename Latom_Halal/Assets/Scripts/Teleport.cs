using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public int timer = 0;
    public GameObject teleportee;
    public Vector3 start;
    public Quaternion quaternion;
  
    void Start()
    {
        
    }

    void Update()
    {
        if (timer >= 600 && timer < 665)
        {
            teleportee.transform.SetPositionAndRotation(start, quaternion);
            timer = 666;
        }
        else
        {
            timer++;
        }
        
    }
}
