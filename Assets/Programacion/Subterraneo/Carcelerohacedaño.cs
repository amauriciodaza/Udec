using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcelerohacedaño : MonoBehaviour
{

    public int herida;
    public GameObject Personaje;
    // Start is called before the first frame update
   
    
    public void daño()
    {
          Debug.Log("golpeo");
            Personaje.GetComponent<PropiedadesScript>().Daño(herida);
    }
}
