using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableChecker : MonoBehaviour
{
    public Transform player;
    public GameObject item;
    public Vector3 location;
    public Quaternion direction;
    bool set = false;
    float Ylocate; 
    
    void Start()
    {
        player = GetComponent<Transform>();
        item = GetComponentInChildren<GameObject>();
        location = player.transform.position;
        Ylocate = location.y;
    }

    // This uses the player's transform  Y as a base to see if it's in a room. 
    void Update()
    {
        if (set == true)
        {

        }
        else
        {
            location.x = player.transform.position.x + 1;
            location.z = player.transform.position.z + 2;
            item.transform.SetPositionAndRotation(location, direction);

            if (location.y != player.transform.position.y)
            {
                location.z++;
                item.transform.SetPositionAndRotation(location, direction);
            }
            else
            {
                set = true;
            }
        }
        
    }
}
