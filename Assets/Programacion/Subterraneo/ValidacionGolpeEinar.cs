using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidacionGolpeEinar : MonoBehaviour
{
    GameObject Einar;
    void Start()
    {
        Einar = GameObject.Find("Einar");
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CarceleroGeo")
        {
            Einar.GetComponent<ApuñalamientoScript>().op = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "CarceleroGeo")
        {
            Einar.GetComponent<ApuñalamientoScript>().op = false;
        }

    }
}
