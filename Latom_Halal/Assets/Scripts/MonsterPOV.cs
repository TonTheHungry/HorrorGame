using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPOV : MonoBehaviour
{ 
    public Transform player;
    bool m_PlayerInRange;

    //This is if we use a collider on the player and monster.
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_PlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_PlayerInRange = false;
        }
    }
     void Update()
    {
        if (m_PlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {

                }
            }
        }
    }
}
