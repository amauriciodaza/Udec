using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasScript : MonoBehaviour
{
    public int herida;
    GameObject Personaje;
    // Start is called before the first frame update
    void Start()
    {
        Personaje = GameObject.Find("Einar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Personaje.name) 
        {
            Personaje.GetComponent<LifeManager>().Damage(herida);
        }
    }
}
