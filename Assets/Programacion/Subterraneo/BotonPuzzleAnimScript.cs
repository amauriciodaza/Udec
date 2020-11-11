using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPuzzleAnimScript : MonoBehaviour
{
    bool op;
    GameObject other;
    // Start is called before the first frame update
    void Start()
    {
        other = GameObject.Find("Einar");
    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GetComponent<Animator>().SetInteger("Estado", 1);
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
            GetComponent<Animator>().SetInteger("EStado", 0);
        }
    }

}
