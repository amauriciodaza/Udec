using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PropiedadesScript : MonoBehaviour
{
    public int runas;
    public int salud;
    public Text Runastxt, Saludtxt;
    //DIALOGOS
    public Text Dialogostxt;
    public Image Dialogosimg;

    // Start is called before the first frame update
    void Start()
    {
        Dialogostxt.enabled = false;
        Dialogosimg.enabled = false;
        runas = 0;
        salud = 100;
    }

    // Update is called once per frame
    void Update()
    {
       
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

    public void dialogo(int num)
    {
        Dialogostxt.enabled = true;
        Dialogosimg.enabled = true;
        switch (num)
        {
            case 1:
                Dialogostxt.text = "TEXTO 1";
                break;
            case 2:
                Dialogostxt.text = "TEXTO 2";
                break;
            case 3:
                Dialogostxt.text = "TEXTO 3";
                break;
        }

    }

}

