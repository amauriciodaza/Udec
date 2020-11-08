using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunasScript : MonoBehaviour
{
    bool op;
    public GameObject Personaje;
    GameObject other;
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
                if (Input.GetKeyUp(KeyCode.F))
                {
                    Personaje.GetComponent<PropiedadesScript>().ContarRunas(1);
                    Debug.Log("recogido");
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
