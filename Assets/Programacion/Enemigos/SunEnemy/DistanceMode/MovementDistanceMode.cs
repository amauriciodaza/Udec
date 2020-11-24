using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementDistanceMode : MonoBehaviour
{
    enum STATES
    {
        IDDLE,
        ATACK
    }

    STATES currentState;

    NavMeshAgent agent;
    GameObject character;

    Animator SunAnimator;

    public float currentDistance;
    public float distanceToAtack;

    void Start()
    {
        SunAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        character = GameObject.Find("Einar");
    }

    // Update is called once per frame
    void Update()
    {
        Seguir();
        checkConditions();
        makeBehaviour();
    }

    void checkConditions()
    {
        currentDistance = Vector3.Distance(transform.position, character.transform.position);

        if (currentState == STATES.ATACK)
        {
            return;
        }
        else if (currentDistance <= distanceToAtack && character.GetComponent<LifeManager>().life > 1)
        {
            currentState = STATES.ATACK;
        }
        else if (currentDistance > distanceToAtack || character.GetComponent<LifeManager>().life < 1)
        {
            currentState = STATES.IDDLE;
        }
    }

    void makeBehaviour()
    {
        switch (currentState)
        {
            case STATES.IDDLE:
                iddle();
                break;
            case STATES.ATACK:
                atack();
                break;
        }
    }


    void iddle()
    {
        agent.SetDestination(transform.position);
        SunAnimator.SetInteger("Estado", 0);
    }
    //El Stopping distance debe ser igual a la distanceToPointing
    void atack()
    {
        agent.SetDestination(transform.position);
        SunAnimator.SetInteger("Estado", 1);
    }

    public void DesblockMovements()
    {
        currentState = STATES.IDDLE;
    }

    //Funcion para mirar al personaje a cierta distancia
    void Seguir()
    {
        if (currentDistance <= distanceToAtack )
        {
            transform.LookAt(character.transform.position);
        }
    }
}

