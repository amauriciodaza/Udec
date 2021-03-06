﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puerta : MonoBehaviour
{ 
    GameObject Personaje;
    public Text instrucciontxt;

    void Start()
    {
        instrucciontxt.enabled = false;
        Personaje = GameObject.Find("Einar");
    }

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Einar")
        {
         
            instrucciontxt.text = "ABRIR (F)";

            if (Input.GetKey(KeyCode.F))
            {
                GetComponent<Animator>().SetBool("EstadoPuerta", true);
                GetComponent<AdministrarSonidos>().SonidoObjeto();
                instrucciontxt.enabled = false;
            }                
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Animator>().GetBool("EstadoPuerta") == false)
        {
            instrucciontxt.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        instrucciontxt.enabled = false;
    }

}
