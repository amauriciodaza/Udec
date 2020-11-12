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
        UNARMEDIMPACT,
        RUNNINGJUMP,
        REVERSE,
        DEATH,

        CAMBIOARMAS,

        SWORDIDDLE,
        SWORDRUN,
        SWORDLEFTRUN,
        SWORDRIGHTRUN,
        SWORDRUNJUMP,
        SWORDREVERSE,
        SWORDIMPACT,
        SWORDSLASH,
        SWORDJUMPATACK,
        SWORDDEATH,

        SHOOTING
    }
    STATES currentState = STATES.IDDLE;

    Animator anim;

    Rigidbody rb;

    //Velocidades Direccionales
    public float speedRun;
    public float speedSide;
    public float speedReverse;
    public float Invert;

    //Velocidades de Ataque
    public float speedSwordJumpAttack;
    public float UpRunJump;//Con o sin Espada

    //Restrictores
    public bool armas;
    //float seg = 2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        armas = false;
        rb = GetComponent<Rigidbody>();
        Invert = 1;
    }

    // Update is called once per frame
    void Update()
    {
        checkConditions();
        MakeBehaviour();
    }

    void checkConditions()
    {
        if (currentState == STATES.SWORDJUMPATACK || currentState == STATES.RUNNINGJUMP ||
            currentState == STATES.SWORDRUNJUMP || currentState == STATES.SHOOTING)
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
            //Daño sin Espada
            /*else if ()
            {
                currentState = STATES.UNARMEDIMPACT;
            }*/
            //Muerte sin Espada
            /*else if ()
            {
                currentState = STATES.DEATH;
            }*/
            //Reposo y Combinaciones
            else if (Input.GetKey(KeyCode.Mouse1) && GetComponent<BracerFunction>().bracerCollected == true)
            {
                currentState = STATES.SHOOTING;
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
            //Daño con Espada
            /*else if ()
            {
                currentState = STATES.SWORDIMPACT;
            }*/
            //Muerte con Espada
            /*else if ()
            {
                currentState = STATES.SWORDDEATH;
            }*/
            //Reposo y Combinaciones
            
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    currentState = STATES.SWORDSLASH;
                }
                else
                {
                    currentState = STATES.SWORDIDDLE;
                }
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
            case STATES.UNARMEDIMPACT:
                UnarmedImpact();
                break;
            case STATES.RUNNINGJUMP:
                RunningJump();
                break;
            case STATES.REVERSE:
                Reverse();
                break;
            case STATES.DEATH:
                Death();
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
            case STATES.SWORDIMPACT:
                SwordImpact();
                break;
            case STATES.SWORDSLASH:
                SwordSlash();
                break;
            case STATES.SWORDJUMPATACK:
                SwordJumpAtack();
                break;
            case STATES.SWORDDEATH:
                SwordDeath();
                break;

            case STATES.SHOOTING:
                Shooting();
                break;
        }
    }

    // Sin Espada
    void Iddle()
    {
        anim.SetInteger("Estado", 0);
        anim.speed = 1f;
    }


    void Running()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 1);
        transform.Translate(0, 0, speedRun * Time.deltaTime);
    }
    void RunningJump()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 5);
        transform.Translate(0, UpRunJump * Invert * Time.deltaTime, speedRun * Time.deltaTime);
    }


    void Reverse()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 6);
        transform.Translate(0, 0, -speedReverse * Time.deltaTime);
    }


    void RightRun()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 2);
        transform.Translate(speedSide * Time.deltaTime, 0, 0);
    }
    void LeftRun()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 3);
        transform.Translate(-speedSide * Time.deltaTime, 0, 0);
    }

    void UnarmedImpact()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 4);
    }
    void Death()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 9);
    }
    // Intermedios, Cambios de Arma
    void CambioArma()
    {
        armas = !armas;
        if (armas)
        {
            anim.speed = 1f;
            anim.SetInteger("Estado", 10);
            //anim.SetInteger("Estado", 12);
        }
        else
        {
            anim.speed = 1f;
            anim.SetInteger("Estado", 11);
            //anim.SetInteger("Estado", 0);
        }

    }
    //Con Espada

    void SwordIddle()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 12);
    }


    void SwordRun()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 13);
        transform.Translate(0, 0, speedRun * Time.deltaTime);
    }
    void SwordRunJump()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 16);
        transform.Translate(0, UpRunJump * Invert * Time.deltaTime, speedRun * Time.deltaTime);
    }


    void SwordReverse()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 17);
        transform.Translate(0, 0, -speedReverse * Time.deltaTime);
    }


    void SwordRightRun()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 15);
        transform.Translate(speedSide * Time.deltaTime, 0, 0);
    }
    void SwordLeftRun()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 14);
        transform.Translate(-speedSide * Time.deltaTime, 0, 0);
    }


    void SwordSlash()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 19);
    }
    void SwordJumpAtack()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 20);
        transform.Translate(0, 0, speedSwordJumpAttack * Time.deltaTime);
    }


    void SwordImpact()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 18);
    }
    void SwordDeath()
    {
        anim.speed = 1f;
        anim.SetInteger("Estado", 22);
    }


    void Shooting()
    {
        anim.SetInteger("Estado",23);
        GetComponent<BracerFunction>().bracerFunctional = true;
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
}
