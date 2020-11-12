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

    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
            t = t + Time.deltaTime;
            if (t < 5)
            {
                Instrucciontxt.text = "Para Derrotar al Carcelero Deberas Cortarlo";
                protecciontxt.enabled = true;
                saludtxt.enabled = true;
            }
            else
            {
                op = false;
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
