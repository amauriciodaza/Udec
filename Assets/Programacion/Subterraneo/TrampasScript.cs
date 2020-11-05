using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasScript : MonoBehaviour
{
    public int herida;
    public GameObject Personaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Personaje.name) 
        {
            Debug.Log("golpeo");
            Personaje.GetComponent<PropiedadesScript>().Daño(herida);
        }
    }
}
