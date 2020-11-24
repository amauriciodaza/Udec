using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlattform : MonoBehaviour
{
    public GameObject Plataforma;
    Animator Anim;

    void Start()
    {
        Anim = Plataforma.GetComponent<Animator>();
    }

    void Update()
    {
        if (GetComponent<EnemyLife>().life < 1)
        {
            Anim.SetInteger("Estado", 1);
        }
    }
}
