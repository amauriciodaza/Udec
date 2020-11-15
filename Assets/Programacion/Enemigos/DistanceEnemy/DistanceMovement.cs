using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DistanceMovement : MonoBehaviour
{

    // Start is called before the first frame update
    enum STATES
    {
        IDDLE,
        RUNNING,
        REVERSE,
        POINTING,
        ATACK,
        IMPACT,
        DEATH
    }

    STATES currentState;

    NavMeshAgent agent;
    GameObject character;

    Animator DistanceAnimator;

    public float currentDistance;
    public float distanceToMovement;
    public float distanceToReverse;
    public float distanceToAtack;
    public float distanceToPointing;
    public float speedRunning;
    public float speedReverse;

    public float RunTime;

    void Start()
    {
        DistanceAnimator = GetComponent<Animator>();
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

        if (currentState == STATES.IMPACT || currentState == STATES.DEATH || currentState == STATES.ATACK
        || currentState == STATES.REVERSE)
        {
            return;
        }
        if (currentDistance > distanceToPointing && currentDistance <= distanceToMovement)
        {
            currentState = STATES.RUNNING;
        }
        else if (currentDistance <= distanceToPointing && currentDistance > distanceToAtack)
        {
            currentState = STATES.POINTING;
        }
        else if (currentDistance <= distanceToAtack && currentDistance > distanceToReverse )
        {
            currentState = STATES.ATACK;
        }
        else if (currentDistance <= distanceToReverse)
        {
            currentState = STATES.REVERSE;
        }
        else if (currentDistance > distanceToMovement)
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
            case STATES.RUNNING:
                running();
                break;
            case STATES.REVERSE:
                reverse();
                break;
            case STATES.POINTING:
                pointing();
                break;
            case STATES.ATACK:
                atack();
                break;
            case STATES.IMPACT:
                impact();
                break;
            case STATES.DEATH:
                death();
                break;
        }
    }


    void iddle()
    {
        agent.SetDestination(transform.position);
        DistanceAnimator.SetInteger("Estado",0);
    }
    //El Estoping distance debe ser igual a la distanceToPointing
    void running()
    {
        agent.SetDestination(character.transform.position);
        DistanceAnimator.SetInteger("Estado", 1);
        transform.Translate( 0, 0, speedRunning * Time.deltaTime);
    }
    void reverse()
    {
        DistanceAnimator.SetInteger("Estado", 2);
        transform.Translate( 0, 0, - speedReverse * Time.deltaTime);
        StartCoroutine(MantenerCarrera());
    }
    void pointing()
    {
        agent.SetDestination(transform.position);

        DistanceAnimator.SetInteger("Estado", 5);
    }
    void atack()
    {
        agent.SetDestination(transform.position);
        DistanceAnimator.SetInteger("Estado", 3);
    }
    void impact()
    {
        agent.SetDestination(transform.position);

        DistanceAnimator.SetInteger("Estado", 4);
    }
    void death()
    {
        agent.SetDestination(transform.position);

        DistanceAnimator.SetInteger("Estado", 6);
    }

    void Atacar()
    {
        currentState = STATES.ATACK;
    }

    public void DesblockMovements()
    {
        currentState = STATES.IDDLE;
    }

    IEnumerator MantenerCarrera()
    {
        yield return new WaitForSeconds(RunTime);
        Atacar();
    }
    //Funcion para mirar al personaje a cierta distancia
    void Seguir()
    {
        if (currentDistance <= distanceToMovement)
        {
            transform.LookAt(character.transform.position);
        }
    }
}
