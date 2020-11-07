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
        REVERSEJUMP,
        IDDLEJUMP,
        DEATH,

        CAMBIOARMAS,

        SWORDIDDLE,
        SWORDRUN,
        SWORDLEFTRUN,
        SWORDRIGHTRUN,
        SWORDIDDLEJUMP,
        SWORDRUNJUMP,
        SWORDREVERSEJUMP,
        SWORDREVERSE,
        SWORDIMPACT,
        SWORDSLASH,
        SWORDJUMPATACK,
        HANDSWORDCOMBO,
        SWORDDEATH   
    }



    STATES currentState = STATES.IDDLE;

    Animator anim;

    public float speedRun;
    public float speedSide;
    public float speedReverse;
    public float impulso;
    public bool armas;
    float seg = 2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        armas = false;
        seg = 2;
    }

    // Update is called once per frame
    void Update()
    {
        checkConditions();
        MakeBehaviour();
    }

    void checkConditions()
    {
        // SIN ESPADA.................................
        if (armas == false)
        {
            //Adelante y combinaciones
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKeyUp(KeyCode.Space))
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
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    currentState = STATES.REVERSEJUMP;
                }
                else
                {
                    currentState = STATES.REVERSE;
                }
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
            else if (Input.GetKeyUp(KeyCode.E))
            {
                currentState = STATES.CAMBIOARMAS;
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    currentState = STATES.IDDLEJUMP;
                }
                else
                {
                    currentState = STATES.IDDLE;
                }
            }
        }
        // CON ESPADA........................................
        else if (armas)
        {
            //Adelante y combinaciones
            if (Input.GetKey(KeyCode.W))
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        currentState = STATES.SWORDJUMPATACK;
                    }
                    else
                    {
                        currentState = STATES.SWORDRUNJUMP;
                    }
                }
                else if (Input.GetKey(KeyCode.Mouse0))
                {
                    currentState = STATES.HANDSWORDCOMBO;
                }
                else
                {
                    currentState = STATES.SWORDRUN;
                }
            }
            //Reversa y combinaciones
            else if (Input.GetKey(KeyCode.S))
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    currentState = STATES.SWORDREVERSEJUMP;
                }
                else
                {
                    currentState = STATES.SWORDREVERSE;
                }
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
            else if (Input.GetKeyUp(KeyCode.E))
            {
                currentState = STATES.CAMBIOARMAS;
            }
            else
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    currentState = STATES.SWORDSLASH;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    currentState = STATES.SWORDIDDLEJUMP;
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
            case STATES.REVERSEJUMP:
                ReverseJump();
                break;
            case STATES.IDDLEJUMP:
                IddleJump();
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
            case STATES.SWORDIDDLEJUMP:
                SwordIddleJump();
                break;
            case STATES.SWORDRUNJUMP:
                SwordRunJump();
                break;
            case STATES.SWORDREVERSEJUMP:
                SwordReverseJump();
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
            case STATES.HANDSWORDCOMBO:
                HandSwordCombo();
                break;
            case STATES.SWORDDEATH:
                SwordDeath();
                break;
        }
    }

    // Sin Espada
    void Iddle()
    {
        anim.SetInteger("Estado", 0);
    }
    void IddleJump()
    {
            Rigidbody rb;
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.up * impulso, ForceMode.Impulse);
            anim.SetInteger("Estado", 8);
    
    }


    void Running()
    {
        anim.SetInteger("Estado", 1);
        transform.Translate(0, 0, speedRun*1f);
    }
    void RunningJump()
    {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * impulso, ForceMode.Impulse);
        anim.SetInteger("Estado", 5);
       
    }


    void Reverse()
    {
        anim.SetInteger("Estado", 6);
        transform.Translate(0, 0, -speedRun*1f);
    }
    void ReverseJump()
    {
        anim.SetInteger("Estado", 7);
        transform.Translate(0, 0, -speedRun*1f);
    }


    void RightRun()
    {
        anim.SetInteger("Estado", 2);
        transform.Translate(speedRun * 1f, 0, 0);
    }
    void LeftRun()
    {
        anim.SetInteger("Estado", 3);
        transform.Translate(-speedRun * 1f, 0, 0);
    }

    void UnarmedImpact()
    {
        anim.SetInteger("Estado", 4);
    }
    void Death()
    {
        anim.SetInteger("Estado", 9);
    }
    // Intermedios, Cambios de Arma
    void CambioArma()
    {
        armas = !armas;
        if (armas)
        {
            anim.SetInteger("Estado", 10);
            //anim.SetInteger("Estado", 12);
        }
        else
        {
            anim.SetInteger("Estado", 11);
            //anim.SetInteger("Estado", 0);
        }

    }
    //Con Espada

    void SwordIddle()
    {
        anim.SetInteger("Estado", 12);
    }
    void SwordIddleJump()
    {
        anim.SetInteger("Estado", 16);
    }


    void SwordRun()
    {
        anim.SetInteger("Estado", 13);
        transform.Translate(0, 0, speedRun * 1f);
    }
    void SwordRunJump()
    {
        anim.SetInteger("Estado", 16);
        transform.Translate(0, 0, speedRun * 1f);
    }


    void SwordReverse()
    {
        anim.SetInteger("Estado", 17);
        transform.Translate(0, 0, -speedReverse * 1f);
    }
    void SwordReverseJump()
    {
        anim.SetInteger("Estado", 16);
        transform.Translate(0, 0, -speedReverse * 1f);
    }


    void SwordRightRun()
    {
        anim.SetInteger("Estado", 15);
        transform.Translate(speedRun * 1f, 0, 0);
    }
    void SwordLeftRun()
    {
        anim.SetInteger("Estado", 14);
        transform.Translate(-speedRun * 1f, 0, 0);
    }


    void SwordSlash()
    {
        anim.SetInteger("Estado", 19);
    }
    void SwordJumpAtack()
    {
        anim.SetInteger("Estado", 20);
        transform.Translate(0, 0, speedRun * 1f);
    }
    void HandSwordCombo()
    {
        anim.SetInteger("Estado", 21);
        transform.Translate(0, 0, speedRun * 1f);
    }


    void SwordImpact()
    {
        anim.SetInteger("Estado", 18);
    }
    void SwordDeath()
    {
        anim.SetInteger("Estado", 22);
    }
}
