using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BotonPuzzleSub : MonoBehaviour
{
    public GameObject Personaje, pared;
    public int Orden;
    public int no;
    // Start is called before the first frame update
    void Start()
    {
        no = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == Personaje.name)
        {
            if (Input.GetKeyUp(KeyCode.F)&& no==0)
            {   
                GetComponent<Animator>().SetBool("Estado", true);
                pared.GetComponent<PuertaPuzzleScript>().Verificar(Orden);
                no = 1;
            }
        }
    }
}
