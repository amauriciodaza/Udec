using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruccionPuzzle : MonoBehaviour
{
    public GameObject Numero1;
    public GameObject Numero2;
    public GameObject Numero3;
    public GameObject Numero4;
    public GameObject Numero5;
    public float t;
    public bool op;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        op = false;
        Numero1.SetActive(false);
        Numero2.SetActive(false);
        Numero3.SetActive(false);
        Numero4.SetActive(false);
        Numero5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (op == true)
        {
            t = t + Time.deltaTime;
            if (t < 5)
            {
                Numero1.SetActive(true);
                Numero2.SetActive(true);
                Numero3.SetActive(true);
                Numero4.SetActive(true);
                Numero5.SetActive(true);
            }
            else
            {
                Numero1.SetActive(false);
                Numero2.SetActive(false);
                Numero3.SetActive(false);
                Numero4.SetActive(false);
                Numero5.SetActive(false);
                op = false;
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Einar")
        {
            op = true;
        }
    }

  
}
