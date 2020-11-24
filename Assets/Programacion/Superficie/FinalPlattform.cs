using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlattform : MonoBehaviour
{
    GameObject SunEnemy;
    Animator Anim;

    void Start()
    {
        SunEnemy = GameObject.Find("SunEnemyMelee");
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (SunEnemy.GetComponent<EnemyLife>().life < 1)
        {
            Anim.SetInteger("Estado", 1);
        }
    }
}
