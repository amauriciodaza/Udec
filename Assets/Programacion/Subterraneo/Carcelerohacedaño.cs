using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcelerohacedaño : MonoBehaviour
{

    public int herida;
    GameObject Personaje;
    public bool op;
    // Start is called before the first frame update
    void Start()
    {
        Personaje = GameObject.Find("Einar");
    }

    public void daño()
    {
        if (op)
        {
          Debug.Log("golpeo");
            Personaje.GetComponent<PropiedadesScript>().Daño(herida);
        }
    }
   

}
