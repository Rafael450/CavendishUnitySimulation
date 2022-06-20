using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRot : MonoBehaviour
{
    public GameObject pendulo;
    Rigidbody Laser;
    
    // Start is called before the first frame update
    void Start()
    {
        Laser = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Laser.angularVelocity = pendulo.GetComponent<Rigidbody>().angularVelocity;
        
        
    }
}