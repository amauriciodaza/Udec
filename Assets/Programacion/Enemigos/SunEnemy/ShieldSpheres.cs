using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldSpheres : MonoBehaviour
{
    GameObject Einar;
    GameObject SunEnemy;

    public float Damage;
    public Text Instrucciontxt;

    void Start()
    {
        Einar = GameObject.Find("Einar");
        SunEnemy = GameObject.Find("SunEnemyDistance");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Einar")
        {
            Instrucciontxt.enabled = true;
            Instrucciontxt.text = "Desactivar (F)";
            if (Input.GetKeyDown(KeyCode.F))
            {
                SunEnemy.GetComponent<SunShield>().DestroyShield(Damage);
                Destroy(gameObject);
                Instrucciontxt.enabled = false;
            }
        }
    }
}
