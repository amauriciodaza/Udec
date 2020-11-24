using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpheres : MonoBehaviour
{
    GameObject Einar;
    GameObject SunEnemy;

    public float Damage;

    void Start()
    {
        Einar = GameObject.Find("Einar");
        SunEnemy = GameObject.Find("SunEnemyDistance");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Einar")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SunEnemy.GetComponent<SunShield>().DestroyShield(Damage);
                Destroy(gameObject);
            }
        }
    }
}
