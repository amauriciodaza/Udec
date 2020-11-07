using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogosScript : MonoBehaviour
{
    public int fasedialogo;
    public int frases;
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
        if (other.name == "Einar") 
        {
            Debug.Log("entro einar");

           /* do
            {
                if (Input.GetKeyUp(KeyCode.T))
                {
                    Debug.Log("Einar escucha");
                    other.GetComponent<PropiedadesScript>().dialogo(fasedialogo);
                    fasedialogo = fasedialogo + 1;
                }

            } while (fasedialogo < frases);*/
        }
       
    }
}
