using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEinarEnemigo : MonoBehaviour
{
    public GameObject Enemigo;
    GameObject other;
    public bool op1;
    // Start is called before the first frame update
    void Start()
    {
        other = GameObject.Find("CarceleroGeo");
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
                    Enemigo.GetComponent<IACarceleroSub>().esp = true;
                    Debug.Log("lee el mouse");
                }

            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Einar")
        {
            op1 = true;
            Debug.Log("Entrando");
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.name == "Einar")
        {
            op1 = false;
            Debug.Log("Entrando");
        }
    }
}
