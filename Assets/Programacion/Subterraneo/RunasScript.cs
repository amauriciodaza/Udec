using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunasScript : MonoBehaviour
{
    bool op,b;
    GameObject Personaje;
    GameObject other;
    public Text Instrucciontxt;
    // Start is called before the first frame update
    void Start()
    {
        Personaje = GameObject.Find("Einar");
        other = GameObject.Find("Einar");
        b = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
     
            if (Input.GetKeyUp(KeyCode.F))
                {
                    Personaje.GetComponent<PropiedadesScript>().ContarRunas(1);
                    Debug.Log("recogido");
                    Destroy(this.gameObject);
                b = false;
                Instrucciontxt.enabled = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Einar")
        {
            op = true;
            if (b == true)
            {
                Instrucciontxt.enabled = true;
                Instrucciontxt.text = "RECOGER RUNA (F)";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Einar")
        {
            op = false;
            Instrucciontxt.enabled = false;
        }
    }

}
