using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoAtackActive : MonoBehaviour
{
    public bool AtackState;
    public bool arm;// Derecho False, Izquierdo True
    public float AtackDamage;

    void Start()
    {
        AtackState = false;
    }

    void ActiveAtack(int TypeAt)
    {
        AtackState = true;
        if (TypeAt == 1)
        {
            arm = true;
        }
        else if (TypeAt == 2)
        {
            arm = false;
        }
    }

    void UnactiveAtack(int TypeAt)
    {
        AtackState = false;
    }
}
