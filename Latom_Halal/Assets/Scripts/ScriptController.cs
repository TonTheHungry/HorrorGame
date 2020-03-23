using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptController : MonoBehaviour
{
    public bool followOn;
    public bool monsterOn;

    //This script is meant to allow the other scripts to turn on and off.
    void Update()
    {
        if (followOn == true)
        {
        GetComponent<Follow>().enabled = true;
        }
        else
        {
            GetComponent<Follow>().enabled = false;
        }
    }
}
