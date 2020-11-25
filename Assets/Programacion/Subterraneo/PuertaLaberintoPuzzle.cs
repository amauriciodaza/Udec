using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaLaberintoPuzzle : MonoBehaviour
{
    GameObject Personaje;
    int run;
    public Text Instrucciontxt;

    bool espera;
    // Start is called before the first frame update
    void Start()
    {
        Personaje = GameObject.Find("Einar");
        espera = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == Personaje.name && espera) 
        {
            Instrucciontxt.enabled = true;
            Instrucciontxt.text = "Abrir (F)";
            if (Input.GetKeyUp(KeyCode.F))
            {
                run = Personaje.GetComponent<PropiedadesScript>().runas;
                if (run == Personaje.GetComponent<PropiedadesScript>().totalrunas)
                {
                    GetComponent<Animator>().SetBool("Estado", true);
                    GetComponent<AdministrarSonidos>().SonidoObjeto();
                    Personaje.GetComponent<PropiedadesScript>().Runastxt.enabled = false;
                }
                else
                {
                    Instrucciontxt.text = "Debes recoger todas las runas";
                    espera = false;
                    StartCoroutine(Esperar());
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Instrucciontxt.enabled = false;
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3f);
        espera = true;
    }
}
