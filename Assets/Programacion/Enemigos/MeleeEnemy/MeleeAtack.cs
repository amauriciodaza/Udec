using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    public bool AtackState;
    public float AtackDamage;

    void Start()
    {
        AtackState = false;
    }

    void ActiveAtack()
    {
        AtackState = true;
    }

    void UnactiveAtack()
    {
        Debug.Log("Desactivado");
        AtackState = false;
    }
}
