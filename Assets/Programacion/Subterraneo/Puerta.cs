using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{ 
    public GameObject Personaje;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.name == Personaje.name)
        {
            GetComponent<Animator>().SetBool("EstadoPuerta", true);
            Debug.Log("Esta Abriendo");
            GetComponent<AdministrarSonidos>().AbrirPuerta();
                
        }
    }
}
