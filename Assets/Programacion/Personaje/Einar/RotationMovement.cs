using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    enum STATES
    {
        LEFT,
        RIGHT,
        NONE
    }

    STATES currentState = STATES.NONE;

    public float speedTurn = 6f;


    // Update is called once per frame
    void Update()
    {
        checkConditions();
        makeBehaviour();
    }

    void checkConditions()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentState = STATES.LEFT;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentState = STATES.RIGHT;
        }
        else
        {
            currentState = STATES.NONE;
        }
    }

    void makeBehaviour()
    {
        switch (currentState)
        {
            case STATES.LEFT:
                Left();
                break;
            case STATES.RIGHT:
                Right();
                break;
            case STATES.NONE:
                break;
        }
    }

    void Right()
    {
        transform.Rotate(0, speedTurn, 0);
    }
    void Left()
    {
        transform.Rotate(0, -speedTurn, 0);
    }
    void None()
    {
        transform.Rotate(0, 0, 0);
    }
}
