using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    
    public ItemObject item;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && this.name.Contains("Sword"))
        {
            collider.gameObject.GetComponent<PlayerController>().HasSword = true;
            Debug.Log("Item picked up");
            Destroy(gameObject);
        }

    }
}
