using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
public class PropiedadesScript : MonoBehaviour
{
    public int runas;
    public Text Runastxt;
    void Start()
    {
        runas = 0;
        Runastxt.enabled = false;
    }

    void Update()
    {

    }

    public void ContarRunas(int num)
    {
        runas = runas + num;
        Runastxt.enabled = true;
        Runastxt.text = "RUNAS: " + runas+" / 4";
        if (runas >= 1 && runas <= 4)
        {
            GetComponent<SonidosPersonaje>().Runas();
        }
    }
}

