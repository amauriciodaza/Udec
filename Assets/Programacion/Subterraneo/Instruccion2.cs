using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruccion2 : MonoBehaviour
{
    public float t;
    public bool op;
    public Text Instrucciontxt;
    public Text protecciontxt, saludtxt;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        protecciontxt.enabled = false;
        saludtxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
            t = t + Time.deltaTime;
            if (t < 10)
            {
                Instrucciontxt.enabled = true;
                Instrucciontxt.text = "Para Derrotar al Carcelero Deberas Cortarlo";
                protecciontxt.enabled = true;
                saludtxt.enabled = true;
            }
            else
            {
                op = false;
                Instrucciontxt.enabled = false;
            }
        }
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Einar")
        {
            op = true;
        }
    }
}
