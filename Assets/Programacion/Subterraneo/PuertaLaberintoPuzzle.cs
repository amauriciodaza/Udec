using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaLaberintoPuzzle : MonoBehaviour
{
    public GameObject Personaje;
    int run;
    public Text Instrucciontxt;
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
            Instrucciontxt.enabled = true;
            Instrucciontxt.text = "Abrir (F)";
            if (Input.GetKeyUp(KeyCode.F))
            {
                run = Personaje.GetComponent<PropiedadesScript>().runas;
                if (run == 4)
                {
                    GetComponent<Animator>().SetBool("Estado", true);
                    GetComponent<AdministrarSonidos>().AbrirPuerta();
                }
                else
                {
                    Instrucciontxt.text = "Debes recoger todas las runas";
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Instrucciontxt.enabled = false;
    }
}
