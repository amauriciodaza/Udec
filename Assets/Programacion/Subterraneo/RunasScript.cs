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
    public Text Runasinfotxt;
    public string hola;
    float t;
    public Image InfoRunasimg;
    // Start is called before the first frame update
    void Start()
    {
        Personaje = GameObject.Find("Einar");
        other = GameObject.Find("Einar");
        b = true;
        Runasinfotxt.enabled = false;
        InfoRunasimg.enabled = false;

        t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
            t += Time.deltaTime;
            Debug.Log(t + ": tiempo");
            if (t < 8)
            {
                InfoRunasimg.enabled = true;
                Runasinfotxt.enabled = true;
                Runasinfotxt.text = hola;
            }
            else 
            {
                Runasinfotxt.enabled = false;
                InfoRunasimg.enabled = false;
            }    
                if (Input.GetKeyUp(KeyCode.F))
                {
               
                            Personaje.GetComponent<PropiedadesScript>().ContarRunas(1);
                         b = false;
                        Instrucciontxt.enabled = false;
                            t = 0;
                     Runasinfotxt.enabled = false;
                InfoRunasimg.enabled = false;
                Destroy(this.gameObject);
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
