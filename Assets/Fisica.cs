using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisica : MonoBehaviour
{
    Rigidbody pendulo;
    public GameObject inputs;
    public Massa M1, M2, m1_, m2_; // m# = masses connected to the pendulum, M# = other masses
    public double GravitationalConstant = 6.7e-11, freq = 1;
    public float timeMultiplicator = 1;
    public double dOmega = 0, oldOmega = 0;
    public bool stopped = true, started = false;
    
    public double degree = 0f;




    // Start is called before the first frame update
    void Start()
    {
        pendulo = GetComponent<Rigidbody>();
        pendulo.sleepThreshold = 0;
    }

    // Update is called once per frame

    private double GetMassTorque(Massa M, Massa m_)
    {
        double distance = Vector3.Distance(M.transform.position, m_.transform.position);
        double force = GravitationalConstant * M.mass * m_.mass / (distance * distance);
        return force * m_.radius;
    }

    private double GetStringTorque()
    {
        double inertiaMoment = m1_.InertiaMoment() + m2_.InertiaMoment();
        return 4*Math.PI*Math.PI*inertiaMoment*pendulo.rotation.eulerAngles.y/(freq * freq);
    }

    private double GetAngularAccerlation()
    {
        double inertiaMoment = m1_.InertiaMoment() + m2_.InertiaMoment();
        return (+GetMassTorque(M1, m1_) + GetMassTorque(M2, m2_) - GetStringTorque())/inertiaMoment;
    }


    void Update()
    {
        if(M1.mass > 0 && M2.mass > 0 && m1_.mass > 0 && m2_.mass > 0 && !started)
        {
            started = true;
            Destroy(inputs);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        


        if(!stopped && started)
        {            
            degree = pendulo.rotation.eulerAngles.y;
            dOmega += GetAngularAccerlation()*timeMultiplicator*Time.deltaTime;
            pendulo.angularVelocity = new Vector3(0, (float)dOmega, 0);
            transform.rotation = Quaternion.Euler(0, (float)degree, 0);
        
            if(Math.Abs(dOmega) < Math.Abs(oldOmega))
            {
                stopped = true;
            }
            oldOmega = dOmega;
        }
        else
        {
            pendulo.angularVelocity = Vector3.zero;
        }
    }


}
