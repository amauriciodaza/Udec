﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class IACarceleroSub : MonoBehaviour
{
    enum STATES
    {
        IDLE,
        PERSEGUIR,
        ATACAR,
        GOLPE
    }

    STATES CurrentState = STATES.IDLE;
    NavMeshAgent agent;
    public GameObject Cuchilla, Cuchilla2;
    GameObject Character;
    public float currentDistance, cuchillaDistancia, cuchillaDistancia2, vida, escudo;
    public float distanciaPerseguir;
    public float distanciaAtacar, distanciaCorte,a,b;
    public Text protecciontxt, saludtxt;
    public bool esp;
    Animator Animaciones;



    void Start()
    {
        Character = GameObject.Find("Einar");
        Animaciones = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        vida = 100f;
        esp = false;
        escudo = 100f;
     
        protecciontxt.enabled = false;
        saludtxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        Checkconditions();
        Makebehaviur();
        if (escudo >= 1) 
        { 
            protecciontxt.text = "Escudo: " + escudo; 
        } else 
        { 
            protecciontxt.text = "Escudo: 0 "; 
        }
        
        saludtxt.text = "Vida: " + vida;
    }


    void Checkconditions()
    {
        currentDistance = Vector3.Distance(Character.transform.position, transform.position);
        cuchillaDistancia = Vector3.Distance(Cuchilla.transform.position, transform.position);
        cuchillaDistancia2 = Vector3.Distance(Cuchilla2.transform.position, transform.position);

        if (currentDistance <= distanciaPerseguir && currentDistance >= distanciaAtacar && cuchillaDistancia > distanciaCorte && cuchillaDistancia2 > distanciaCorte && esp == false)
        {

            CurrentState = STATES.PERSEGUIR;

        }
        else if (currentDistance < distanciaAtacar && cuchillaDistancia > distanciaCorte && cuchillaDistancia2 > distanciaCorte && esp == false)
        {
            CurrentState = STATES.ATACAR;
        }
        else if ((cuchillaDistancia < distanciaCorte || cuchillaDistancia2 < distanciaCorte) && esp == false)
        {
            CurrentState = STATES.GOLPE;
            a = 2f;
            b = 0;

        }
        else if (esp == true)
        {
            CurrentState = STATES.GOLPE;
            a = 0f;
            b = 5f;
            Debug.Log(" es" + esp);
        }
        else
        {
            CurrentState = STATES.IDLE;
        }
        

    }

    void Makebehaviur()
    {
        switch (CurrentState)
        {
            case STATES.IDLE:
                Idle();
                break;
            case STATES.PERSEGUIR:
                Perseguir();
                break;
            case STATES.ATACAR:
                Atacar();
                break;
            case STATES.GOLPE:
                Reaccionar(a,b);
                break;
            default:
                break;
        }
    }



    void Idle()
    {
        Animaciones.SetInteger("Estado", 0);
        transform.LookAt(Character.transform.position);
    }

    void Perseguir()
    {
        Animaciones.SetInteger("Estado", 1);

        agent.SetDestination(Character.transform.position);
        
    }

    void Atacar()
    {
       
            transform.LookAt(Character.transform.position);
            Animaciones.SetInteger("Estado", 2);
        
    }

    public void Reaccionar(float dañoescudo, float dañovida )
    {
        
        escudo = escudo - dañoescudo;
        Animaciones.SetInteger("Estado", 3);
      
        Debug.Log("En Reaccionar "+esp);
        if (escudo < 1) 
        {
            vida = vida - dañovida;
           
            if (vida < 1)
            {
                transform.LookAt(Character.transform.position);
                GetComponent<NavMeshAgent>().baseOffset = 0;
                Animaciones.SetInteger("Estado", 4);
                GetComponent<IACarceleroSub>().enabled = false;
            }
        }
        esp = false;
    }

   /* public void life(int num) 
    {
        vida = vida - num;
              if (vida < 1)
        {
            transform.LookAt(Character.transform.position);
            Animaciones.SetInteger("Estado", 4);
            GetComponent<IACarceleroSub>().enabled = false;
        }
              
    }*/

}
