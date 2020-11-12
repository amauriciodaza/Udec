using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidacionScript : MonoBehaviour
{
    public GameObject Carcelero;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Einar")
        {
            Carcelero.GetComponent<Carcelerohacedaño>().op = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Einar")
        {
            Carcelero.GetComponent<Carcelerohacedaño>().op = false  ;
        }

    }
}
