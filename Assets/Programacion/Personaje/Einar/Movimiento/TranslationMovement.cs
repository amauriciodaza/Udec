using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationMovement : MonoBehaviour
{
    enum STATES
    {
        IDDLE,
        RUNNING,
        RIGHTRUN,
        LEFTRUN,
        RUNNINGJUMP,
        REVERSE,
        INTERACTING,

        CAMBIOARMAS,

        SWORDIDDLE,
        SWORDRUN,
        SWORDLEFTRUN,
        SWORDRIGHTRUN,
        SWORDRUNJUMP,
        SWORDREVERSE,
        SWORDSLASH,
        SWORDJUMPATACK,

        SHOOTING,

        IMPACT,
        DEATH
    }
    STATES currentState = STATES.IDDLE;

    Animator anim;

    Rigidbody rb;

    //Velocidades Direccionales
    public float speedRun;
    public float speedSide;
    public float speedReverse;
    //Determinante de anulacion o continuidad de transform en saltos
    public float Invert;

    //Velocidades de Ataque
    public float speedSwordJumpAttack;
    public float UpRunJump;//Con o sin Espada

    //Restrictores
    public bool armas;
    bool noChange;
    //float seg = 2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        armas = false;
        Invert = 1;
        noChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkConditions();
        MakeBehaviour();
    }

    void checkConditions()
    {
        //Ciclo condicional para bloquear movimientos
        if (currentState == STATES.SWORDJUMPATACK || currentState == STATES.RUNNINGJUMP || currentState == STATES.SWORDSLASH ||
            currentState == STATES.SWORDRUNJUMP || currentState == STATES.SHOOTING || currentState == STATES.INTERACTING
            || currentState == STATES.IMPACT || currentState == STATES.DEATH)
        {
            return;
        }


        // SIN ESPADA.................................
        if (armas == false)
        {
            //Adelante y combinaciones
            if (Input.GetKeyUp(KeyCode.E))
            {
                currentState = STATES.CAMBIOARMAS;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                //GetComponent<SonidosPersonaje>().Caminar();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentState = STATES.RUNNINGJUMP;
                }
                else
                {
                    currentState = STATES.RUNNING;
                }
            }
            //Reversa y combinaciones
            else if (Input.GetKey(KeyCode.S))
            {
                currentState = STATES.REVERSE;
            }
            //Laterales y combinaciones
            else if (Input.GetKey(KeyCode.A))
            {
                currentState = STATES.LEFTRUN;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                currentState = STATES.RIGHTRUN;
            }
            //Reposo y Combinaciones
            else if (Input.GetKey(KeyCode.Mouse1) && GetComponent<BracerFunction>().bracerCollected == true)
            {
                currentState = STATES.SHOOTING;
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                currentState = STATES.INTERACTING;
            }
            else
            {
                currentState = STATES.IDDLE;
            }

        }
        // CON ESPADA........................................
        else if (armas)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                currentState = STATES.CAMBIOARMAS;
            }
            //Adelante y combinaciones
            else if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Mouse0))
                {
                    currentState = STATES.SWORDJUMPATACK;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    currentState = STATES.SWORDRUNJUMP;
                }
                else
                {
                    currentState = STATES.SWORDRUN;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentState = STATES.SWORDSLASH;
            }
            //Reversa y combinaciones
            else if (Input.GetKey(KeyCode.S))
            {
                currentState = STATES.SWORDREVERSE;
            }
            //Izquierda y Combinaciones
            else if (Input.GetKey(KeyCode.A))
            {
                currentState = STATES.SWORDLEFTRUN;
            }
            //Derecha y Combinaciones
            else if (Input.GetKey(KeyCode.D))
            {
                currentState = STATES.SWORDRIGHTRUN;
            }
            //Reposo y Combinaciones
            else if (Input.GetKeyUp(KeyCode.F))
            {
                currentState = STATES.INTERACTING;
            }
            else
            {
                currentState = STATES.SWORDIDDLE;
            }
        }
    }

    void MakeBehaviour()
    {
        switch (currentState)
        {
            case STATES.IDDLE:
                Iddle();
                break;
            case STATES.RUNNING:
                Running();
                break;
            case STATES.RIGHTRUN:
                RightRun();
                break;
            case STATES.LEFTRUN:
                LeftRun();
                break;
            case STATES.RUNNINGJUMP:
                RunningJump();
                break;
            case STATES.REVERSE:
                Reverse();
                break;
            case STATES.INTERACTING:
                Interacting();
                break;

            case STATES.CAMBIOARMAS:
                CambioArma();
                break;

            case STATES.SWORDIDDLE:
                SwordIddle();
                break;
            case STATES.SWORDRUN:
                SwordRun();
                break;
            case STATES.SWORDLEFTRUN:
                SwordLeftRun();
                break;
            case STATES.SWORDRIGHTRUN:
                SwordRightRun();
                break;
            case STATES.SWORDRUNJUMP:
                SwordRunJump();
                break;
            case STATES.SWORDREVERSE:
                SwordReverse();
                break;
            case STATES.SWORDSLASH:
                SwordSlash();
                break;
            case STATES.SWORDJUMPATACK:
                SwordJumpAtack();
                break;

            case STATES.SHOOTING:
                Shooting();
                break;

            case STATES.IMPACT:
                Impact();
                break;
            case STATES.DEATH:
                Death();
                break;
        }
    }

    // Sin Espada
    void Iddle()
    {
        GetComponent<Sword>().PosSword();
        anim.SetInteger("Estado", 0);
        anim.speed = 1f;
    }


    void Running()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 1);
        transform.Translate(0, 0, speedRun * Time.deltaTime);
    }
    void RunningJump()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 5);
        transform.Translate(0, UpRunJump * Invert * Time.deltaTime, speedRun * Time.deltaTime);
    }


    void Reverse()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 6);
        transform.Translate(0, 0, -speedReverse * Time.deltaTime);
    }


    void RightRun()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 2);
        transform.Translate(speedSide * Time.deltaTime, 0, 0);
    }
    void LeftRun()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 3);
        transform.Translate(-speedSide * Time.deltaTime, 0, 0);
    }

    // Intermedios, Cambios de Arma
    void CambioArma()
    {
        if (noChange)
        {
            armas = !armas;
            if (armas)
            {
                GetComponent<EnergySword>().Cambio = false;
                anim.speed = 1f;
                anim.SetInteger("Estado", 10);
                noChange = false;
                StartCoroutine(NotChange());
            }
            else
            {
                anim.speed = 1f;
                anim.SetInteger("Estado", 11);
                noChange = false;
                StartCoroutine(NotChange());
            }
        }
    }
    //Con Espada

    void SwordIddle()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 12);
    }

    void SwordRun()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 13);
        transform.Translate(0, 0, speedRun * Time.deltaTime);
    }
    void SwordRunJump()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 16);
        transform.Translate(0, UpRunJump * Invert * Time.deltaTime, speedRun * Time.deltaTime);
    }

    void SwordReverse()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 17);
        transform.Translate(0, 0, -speedReverse * Time.deltaTime);
    }

    void SwordRightRun()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 15);
        transform.Translate(speedSide * Time.deltaTime, 0, 0);
    }
    void SwordLeftRun()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 14);
        transform.Translate(-speedSide * Time.deltaTime, 0, 0);
    }


    void SwordSlash()
    {
        GetComponent<Sword>().PosSword(); ;
        anim.speed = 1f;
        anim.SetInteger("Estado", 19);
    }
    void SwordJumpAtack()
    {
        GetComponent<Sword>().PosSword();
        anim.speed = 1f;
        anim.SetInteger("Estado", 20);
        transform.Translate(0, 0, speedSwordJumpAttack * Time.deltaTime);
    }

    void Shooting()
    {
        GetComponent<Sword>().PosSword();
        anim.SetInteger("Estado",7);
    }

    void Interacting()
    {
        GetComponent<Sword>().PosSword();
        anim.SetInteger("Estado", 8);
    }
    //Imapctos al recibir Daño y Muertes
    public void Impact()
    {
        currentState = STATES.IMPACT;
        if (armas)
        {
            GetComponent<Sword>().PosSword();
            anim.speed = 1f;
            anim.SetInteger("Estado", 18);
        }
        else
        {
            GetComponent<Sword>().PosSword();
            anim.speed = 1f;
            anim.SetInteger("Estado", 4);
        }
    }

    public void Death()
    {
        currentState = STATES.DEATH;
        if (armas)
        {
            anim.speed = 1f;
            anim.SetInteger("Estado", 21);
        }
        else
        {
            anim.speed = 1f;
            anim.SetInteger("Estado", 9);
        }
    }
    //Finalizacion de animaciones de Espada
    public void FinishMovement()
    {
        anim.speed = 1f;
        if (armas)
        {
            currentState = STATES.SWORDIDDLE;
        }
        else
        {
            currentState = STATES.IDDLE;
        }
        Invert = 1;
        anim.speed = 1f;
    }
    //Modificar velocidad de animator
    public void AnimVelocity(float Vel)
    {
        anim.speed = Vel * 1f;
    }
    // Funcion llamada en los eventos de animacion de animaciones de salto para detener su transform en y
    public void Invertir(float val)
    {
        Invert = Invert * val;
    }

    //Evitar error al hacer tecleos rapidos en cambio de espadas.
    IEnumerator NotChange()
    {
        yield return new WaitForSeconds(0.25f);
        noChange = true;
    }

}
