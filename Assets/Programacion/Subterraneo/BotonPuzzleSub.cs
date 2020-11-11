using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BotonPuzzleSub : MonoBehaviour
{
    public GameObject Personaje, pared;
    public int no;
    public Text Instrucciontxt;
    public int Orden;


    // Start is called before the first frame update
    void Start()
    {
        no = 0;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //TRIGGER STAY PARA QUE EINAR INTERACTUE CON EL BOTON
    private void OnTriggerStay(Collider other)
    {
        if (other.name == Personaje.name)
        {
            // ACTIVAMOS EL Instrucciontxt y le damos la instruccion
            Instrucciontxt.enabled = true;
            Instrucciontxt.text = "INTERACTUAR (F)";
            
            // If para validar el orden dentro de la secuencia de botones para saber que variable setear en la verificacion de la puerta
            if (Input.GetKeyUp(KeyCode.F)&& no==0)
            {   
                GetComponent<Animator>().SetBool("Estado", true);
                if (Orden == 1) 
                {
                    Debug.Log("1 boton");
                    pared.GetComponent<PuertaPuzzleScript>().a = 1;
                }
                else if (Orden == 2)
                {
                    Debug.Log("2 boton");
                    pared.GetComponent<PuertaPuzzleScript>().b = 1;
                }
                else if(Orden == 3)
                {
                    Debug.Log("3 boton");
                    pared.GetComponent<PuertaPuzzleScript>().c = 1;
                }else
                    if (Orden == 4)
                {
                    Debug.Log("4 boton");
                    pared.GetComponent<PuertaPuzzleScript>().d = 1;
                }
                else
                    if (Orden == 5)
                {
                    Debug.Log("5 boton");
                    pared.GetComponent<PuertaPuzzleScript>().e = 1;
                }
               
                no = 1;
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Animator>().SetBool("Estado", false);
        Instrucciontxt.enabled = false;
    }

}
