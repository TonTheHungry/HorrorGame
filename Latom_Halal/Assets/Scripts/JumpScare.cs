using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject Mon;
    public Transform placement;
    public Rigidbody monRig;
    public Vector3 monTran;
    public Vector3 floor;
    Random scareTrigger;
    public int spiTerror;
    public int genTerror;
    public int illTerror;

        
    // Sets up the variables.
    void Start()
    {
        monRig = GetComponent<Rigidbody>();
        monTran = Mon.transform.position;
        placement = GetComponent<Transform>();
        floor.x = 0;
        floor.y = 0;
        floor.z = 0;
    }

    void Update()
    {
        if (monTran.y < 1)
        {
            monTran.y = 1;
        }

        if (spiTerror > genTerror && spiTerror > illTerror)
        {

        }
        if (illTerror > genTerror && spiTerror < illTerror)
        {

        }
        if (spiTerror < genTerror && genTerror > illTerror)
        {

        }
    }

    void FallingScare()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }
    }
}
