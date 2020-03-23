using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public float monHealth;
   

    void Start()
    {
        monHealth = 100;
    }

    void Update()
    {
        if (monHealth >= 75)
        {
           
        }
        else if (monHealth < 75 && monHealth >= 51)
        {

        }
        else if (monHealth < 51 && monHealth >= 26)
        {

        }
        else
        {

        }
    }
}
