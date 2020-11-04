using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaLaberintoPuzzle : MonoBehaviour
{
    public GameObject Personaje;
    int run;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == Personaje.name) 
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                run = Personaje.GetComponent<CharacterController>().runas;
                if (run == 4)
                {
                    GetComponent<Animator>().SetBool("Estado", true);
                }
            }
        }
    }
}
