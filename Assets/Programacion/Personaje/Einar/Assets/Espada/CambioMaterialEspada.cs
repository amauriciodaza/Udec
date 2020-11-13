using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioMaterialEspada : MonoBehaviour
{
    public bool EstadoColor = false;
    public Material material1;
    public Material material2;
    public Material material3;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = material1;
        EstadoColor = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (EstadoColor == true)
            {
                GetComponent<Renderer>().material= material1;
                EstadoColor = false;
            }
            else
            {
                GetComponent<Renderer>().material = material2;
                EstadoColor = true;
            }
        }
    }
}
