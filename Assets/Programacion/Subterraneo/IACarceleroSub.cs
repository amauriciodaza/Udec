using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

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
    public GameObject Character, Cuchilla;
    public float currentDistance, cuchillaDistancia, vida;
    public float distanciaPerseguir;
    public float distanciaAtacar, distanciaCorte;

    Animator Animaciones;



    void Start()
    {
        Animaciones = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        vida = 100f;

    }

    // Update is called once per frame
    void Update()
    {

        Checkconditions();
        Makebehaviur();
    }


    void Checkconditions()
    {
        currentDistance = Vector3.Distance(Character.transform.position, transform.position);
        cuchillaDistancia = Vector3.Distance(Cuchilla.transform.position, transform.position);

        if (currentDistance <= distanciaPerseguir && currentDistance >= distanciaAtacar && cuchillaDistancia > distanciaCorte)
        {

            CurrentState = STATES.PERSEGUIR;

        }
        else if (currentDistance < distanciaAtacar && cuchillaDistancia > distanciaCorte)
        {
            CurrentState = STATES.ATACAR;
        }
        else if (cuchillaDistancia < distanciaCorte)
        {
            CurrentState = STATES.GOLPE;
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
                Reaccionar(1);
                break;
            default:
                break;
        }
    }



    void Idle()
    {
        Animaciones.SetInteger("Estado", 0);
    }

    void Perseguir()
    {
        Animaciones.SetInteger("Estado", 1);

        agent.SetDestination(Character.transform.position);
        
    }

    void Atacar()
    {
        Animaciones.SetInteger("Estado", 2);
    }

    public void Reaccionar(float daño)
    {
        vida = vida - daño;
        Animaciones.SetInteger("Estado", 3);
    }

}
