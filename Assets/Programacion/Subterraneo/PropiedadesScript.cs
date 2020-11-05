using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropiedadesScript : MonoBehaviour
{
    public int runas;
    public int salud;
    public Text Runastxt, Saludtxt;

    // Start is called before the first frame update
    void Start()
    {
      
        runas = 0;
        salud = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F1))
       // {
            // turn on the cursor
        
       // }
    }

    public void ContarRunas(int num)
    {
        runas = runas + num;
        Runastxt.text = "RUNAS: " + runas;
    }

    public void Daño(int num)
    {
        salud = salud - num;
        Saludtxt.text = "SALUD: " + salud;
    }
}

