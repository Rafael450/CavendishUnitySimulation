using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Massa : MonoBehaviour
{
    public float mass = 10;
    public float radius;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        radius = Math.Abs(transform.position.x);
    }
    public float InertiaMoment()
    {
        return mass * radius * radius;
    }


}
