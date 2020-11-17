using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeoMovement : MonoBehaviour
{
    enum STATES
    {
        IDDLE,
        RUNNING,
        ATACK,
        IMPACT,
        DEATH
    }

    STATES currentState;

    NavMeshAgent agent;
    GameObject character;

    Animator GeoAnimator;

    public float currentDistance;
    public float distanceToMovement;
    public float distanceToAtack;

    public float speedRunning;

    bool EnemyActive;

    void Start()
    {
        EnemyActive = true;
        GeoAnimator = GetComponent<Animator>();
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

        if (currentState == STATES.IMPACT || currentState == STATES.DEATH || currentState == STATES.ATACK)
        {
            return;
        }
        if (currentDistance > distanceToAtack && currentDistance <= distanceToMovement)
        {
            currentState = STATES.RUNNING;
        }
        else if (currentDistance <= distanceToAtack && character.GetComponent<LifeManager>().life > 1)
        {
            currentState = STATES.ATACK;
        }
        else if (currentDistance > distanceToMovement || character.GetComponent<LifeManager>().life < 1)
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
        GetComponent<GeoAtackActive>().AtackState = false;
        agent.SetDestination(transform.position);
        GeoAnimator.SetInteger("Estado", 0);
    }
    //El Stopping distance debe ser igual a la distanceToPointing
    void running()
    {
        GetComponent<GeoAtackActive>().AtackState = false;
        agent.SetDestination(character.transform.position);
        GeoAnimator.SetInteger("Estado", 1);
        transform.Translate(0, 0, speedRunning * Time.deltaTime);
    }
    void atack()
    {
        agent.SetDestination(transform.position);
        GeoAnimator.SetInteger("Estado", 2);
    }
    public void impact()
    {
        currentState = STATES.IMPACT;
        agent.SetDestination(transform.position);

        GeoAnimator.SetInteger("Estado", 3);
    }
    public void death()
    {
        EnemyActive = false;
        currentState = STATES.DEATH;
        agent.SetDestination(transform.position);

        GeoAnimator.SetInteger("Estado", 4);
    }

    public void DesblockMovements()
    {
        currentState = STATES.IDDLE;
    }

    //Funcion para mirar al personaje a cierta distancia
    void Seguir()
    {
        if (currentDistance <= distanceToMovement && EnemyActive)
        {
            transform.LookAt(character.transform.position);
        }
    }
}
