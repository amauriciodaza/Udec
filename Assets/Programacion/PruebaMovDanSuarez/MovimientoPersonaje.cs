using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{    enum STATES
    {
        Reposar,
        CaminandoAdelante,
        CaminandoAtras,
    }
    STATES currentState = STATES.Reposar;
    Animator anim;
    public float speedWalk = 0.18f;
    public float speedTurn = 4f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        checkConditions();
        makeBehaviour();
    }
    void checkConditions()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentState = STATES.CaminandoAdelante;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currentState = STATES.CaminandoAtras;
        }
        else
        {
            currentState = STATES.Reposar;
        }
    }
    void makeBehaviour()
    {
        switch (currentState)
        {
            case STATES.Reposar:
                reposar();
                break;
            case STATES.CaminandoAdelante:
                caminarAd();
                break;
            case STATES.CaminandoAtras:
                caminarAt();
                break;
        }
    }
    void reposar()
    {
        anim.SetInteger("Estado", 0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, speedTurn, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -speedTurn, 0);
        }
    }
    void caminarAd()
    {
        anim.SetInteger("Estado", 1);
        transform.Translate(0, 0, speedWalk * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, speedTurn, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -speedTurn, 0);
        }
    }
    void caminarAt()
    {
        anim.SetInteger("Estado", 1);
        transform.Translate(0, 0, -speedWalk * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -speedTurn, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, speedTurn, 0);
        }
    }
}
