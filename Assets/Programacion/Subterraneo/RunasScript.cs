using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunasScript : MonoBehaviour
{
    public GameObject Personaje;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == Personaje.name) 
        {
            if (Input.GetKeyUp(KeyCode.E)) 
            {
                Personaje.GetComponent<PropiedadesScript>().ContarRunas(1);
                Debug.Log("recogido");
                Destroy(this.gameObject);
                

            }
        
        }
    }
}
