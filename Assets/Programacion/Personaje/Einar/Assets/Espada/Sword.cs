using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Espada;
    public GameObject Espada2;

    void Start()
    {
        Espada.SetActive(false);
        Espada2.SetActive(true);
    }

    public void SacarEspada()
    {
        Espada.SetActive(true);
        Espada2.SetActive(false);
    }

    public void GuardarEspada()
    {
        Espada.SetActive(false);
        Espada2.SetActive(true);
    }
}
