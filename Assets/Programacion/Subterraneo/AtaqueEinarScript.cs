using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEinarScript : MonoBehaviour
{
    public GameObject Carcelero;
    GameObject other;
    bool op;
    // Start is called before the first frame update
    void Start()
    {
        other = GameObject.Find("CarceleroGeo");
    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
            if (other.name == Carcelero.name)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Carcelero.GetComponent<IACarceleroSub>().esp = true;
                    Debug.Log("lee el mouse");
                }

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Einar")
        {
            op = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Einar")
        {
            op = false;
        }
    }
}
