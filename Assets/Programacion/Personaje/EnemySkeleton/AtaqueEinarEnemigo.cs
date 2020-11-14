using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEinarEnemigo : MonoBehaviour
{
    public GameObject Enemigo;
    GameObject other;
    bool op1;
    // Start is called before the first frame update
    void Start()
    {
        op1 = false;
        other = GameObject.Find("MeleeEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (op1 == true)
        {
            if (other.name == Enemigo.name)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Enemigo.GetComponent<MeleeEnemyIA>().espa = true;
                    Debug.Log("Activar espa Ataque Einar ");
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Einar")
        {
            op1 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Einar")
        {
            op1 = false;
        }
    }
}
