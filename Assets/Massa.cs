using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Massa : MonoBehaviour
{
    public float mass = -1;
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
    public void MassInput(string input)
    {
        mass = int.Parse(input);
    }


}
