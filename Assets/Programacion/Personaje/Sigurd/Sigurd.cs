using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
   
    enum STATES
    {
        IDLE,
        FOLLOW
    }
    STATES currentState;
    
    Animator anim;

    public NavMeshAgent agent;
    public GameObject personaje;
    public float currentDistance;
    public float distanceToFollow;
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        personaje = GameObject.Find("Einar");
    }
    // Update is called once per frame
    void Update()
    {
        CheckConditions();
        LlamarImplementacion();
    }
    void CheckConditions()
    {
        currentDistance = Vector3.Distance(transform.position, personaje.transform.position);
        if (currentDistance<= distanceToFollow)
        {
            currentState = STATES.FOLLOW;
        }
        else
        {
            currentState = STATES.IDLE;
        }
    }
    void LlamarImplementacion()
    {
        switch (currentState)
        {
            case STATES.IDLE:
                idle();
                break;
            case STATES.FOLLOW:
                follow();
                break;
        }
    }
    void idle()
    {
        anim.SetInteger("Estado", 0);
        agent.SetDestination(transform.position);
        //transform.Translate(0, 0, -speedWalk * Time.deltaTime);
    }
    void follow()
    {
        anim.SetInteger("Estado", 1);
        agent.SetDestination(personaje.transform.position);
    }
}
