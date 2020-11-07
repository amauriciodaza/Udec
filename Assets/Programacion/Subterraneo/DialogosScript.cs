using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogosScript : MonoBehaviour
{
    public int fasedialogo;
    public int fasedialogolimite;
    GameObject other;
    bool op;
    // Start is called before the first frame update
    void Start()
    {
        other = GameObject.Find("Einar");
        
    }

    // Update is called once per frame
    void Update()
    {

        if (op == true)
        {
            other.GetComponent<CharacterController>().enabled = false;
            if (Input.GetKeyUp(KeyCode.T) && fasedialogo <= fasedialogolimite)
            {
                Debug.Log("Einar escucha " + fasedialogo);
                other.GetComponent<PropiedadesScript>().dialogo(fasedialogo);
                fasedialogo = fasedialogo + 1;
            }
            
            if (fasedialogo > fasedialogolimite) 
            {
                op = false;
                other.GetComponent<CharacterController>().enabled = true;
                Destroy(this.gameObject);
                
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Einar")
        {
            op = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Einar")
        {
            op = false;
        }
    }


}
