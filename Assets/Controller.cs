using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    Rigidbody rb;
    public GameObject distancia, pendulo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        distancia.GetComponent<TMPro.TextMeshProUGUI>().text = "Distancia: " + (-1*transform.position.z).ToString() + "m\nAngulo entre os raios: " + Math.Round(pendulo.GetComponent<Fisica>().degree*2000000)/1000000f + "º";
        if(!(-10000 < transform.position.z && transform.position.z < 30))
        {
            rb.velocity = new Vector3(0,0,0);
            rb.position = new Vector3(0,0.114F,-10);
        }
        else if(Input.GetKey(KeyCode.W))
            rb.velocity = new Vector3(0,0,150f);
        else if(Input.GetKey(KeyCode.S))
            rb.velocity = new Vector3(0,0,-150f);
        else
             rb.velocity = new Vector3(0,0,0);
    }
}
