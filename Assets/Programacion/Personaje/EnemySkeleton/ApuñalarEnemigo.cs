using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApuñalarEnemigo : MonoBehaviour
{
    GameObject carcelero;
    public bool op;

    // Start is called before the first frame update
    void Start()
    {
        op = false;
        carcelero = GameObject.Find("MeleeEnemy");
    }
    public void golpeEinar2()
    {
        if (op)
        {
            carcelero.GetComponent<MeleeEnemyIA>().espa = true;
            Debug.Log("lee el mouse");

        }
    }
}
