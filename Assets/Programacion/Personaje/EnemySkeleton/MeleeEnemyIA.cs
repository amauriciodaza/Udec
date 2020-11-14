using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MeleeEnemyIA : MonoBehaviour
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
    public GameObject Character;
    public float currentDistance,vida;
    public float distanciaPerseguir;
    public float distanciaAtacar, dañovida;
    public Text saludtxt;
    public bool espa;
    Animator Animaciones;

    void Start()
    {
        Animaciones = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        vida = 100f;
        espa = false;
        //saludtxt.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        Checkconditions();
        Makebehaviur();
        //saludtxt.text = "Vida: " + vida;
    }
    void Checkconditions()
    {
        currentDistance = Vector3.Distance(Character.transform.position, transform.position);
        
        if (currentDistance <= distanciaPerseguir && currentDistance >= distanciaAtacar && espa == false)
        {
            CurrentState = STATES.PERSEGUIR;
        }
        else if (currentDistance < distanciaAtacar)
        {
            CurrentState = STATES.ATACAR;
        }
        else if (espa == false)
        {
            CurrentState = STATES.GOLPE;
            dañovida = 2f;
        }
        else if (espa == true)
        {
            CurrentState = STATES.GOLPE;
            dañovida = 0f;
            Debug.Log(" espadaprueba" + espa);
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
                Reaccionar(dañovida);
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
    public void Reaccionar(float dañovida)
    {
        Animaciones.SetInteger("Estado", 3);

        Debug.Log("En Reaccionar " + espa);
        vida = vida - dañovida;
        if (vida < 1)
        {
            transform.LookAt(Character.transform.position);
            GetComponent<NavMeshAgent>().baseOffset = 0;
            Animaciones.SetInteger("Estado", 4);
            GetComponent<MeleeEnemyIA>().enabled = false;
        }
        espa = false;
    }
}
