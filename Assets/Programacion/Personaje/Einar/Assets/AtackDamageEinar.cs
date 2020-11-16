using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackDamageEinar : MonoBehaviour
{
    public float SwordDamage;
    public float BraceletDamage;

    public bool SwordState;
    public bool SwordTypeAtack;

    void Start()
    {
        SwordState = false;
    }

    //Sword States of Atack

    public void ActiveSword(int type)
    {
        if (type == 1)
        {
            SwordTypeAtack = true;
        }
        else
        {
            SwordTypeAtack = false;
        }
        SwordState = true;
    }
    public void UnactiveSword()
    {
        SwordState = false;
        SwordTypeAtack = false;
    }
}
