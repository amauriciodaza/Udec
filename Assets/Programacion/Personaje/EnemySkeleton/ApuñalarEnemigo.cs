using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuñalarEnemigo : MonoBehaviour
{
    GameObject Enemigo;
    public bool op1;
    // Start is called before the first frame update
    void Start()
    {
        op1 = false;
        Enemigo = GameObject.Find("MeleeEnemy");
    }
    public void golpeEinar()
    {
        if (op1)
        {
            Enemigo.GetComponent<MeleeEnemyIA>().espa = true;
        }
    }
}
