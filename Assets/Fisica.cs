using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisica : MonoBehaviour
{
    Rigidbody pendulo;
    public Massa M1, M2, m1_, m2_; // m# = masses connected to the pendulum, M# = other masses
    public double GravitationalConstant = 6.7e-11, freq = 1;
    public int timeMultiplicator = 1;
    public double dGamma = 0;
    
    public double degree = 0f;




    // Start is called before the first frame update
    void Start()
    {
        pendulo = GetComponent<Rigidbody>();        
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
        return 4*Math.PI*Math.PI*inertiaMoment/(freq * freq);
    }

    private double GetAngularAccerlation()
    {
        double inertiaMoment = m1_.InertiaMoment() + m2_.InertiaMoment();
        return (GetMassTorque(M1, m1_) + GetMassTorque(M2, m2_) + GetStringTorque())/inertiaMoment;
    }


    void Update()
    {
        dGamma += GetAngularAccerlation()*timeMultiplicator*Time.deltaTime;
        pendulo.angularVelocity = new Vector3(0, (float)dGamma, 0);
    }


}
