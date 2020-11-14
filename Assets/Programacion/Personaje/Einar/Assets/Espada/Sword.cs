using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject Espada2;

    bool Change;

    void Start()
    {
        GetComponent<EnergySword>().Seleccionar(false);
        Espada2.SetActive(true);
    }

    public void SacarEspada()
    {
        GetComponent<EnergySword>().Seleccionar (true);
        Espada2.SetActive(false);
    }

    public void GuardarEspada()
    {
        GetComponent<EnergySword>().Seleccionar (false);

        Espada2.SetActive(true);
    }

    public void PosSword()
    {
        if (GetComponent<TranslationMovement>().armas)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TCambio());
            }
            if (Change)
            {
                GetComponent<EnergySword>().Seleccionar (true);

                Espada2.SetActive(false);
                Change = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TCambio());
            }
            if (Change)
            {
                GetComponent<EnergySword>().Seleccionar (false);

                Espada2.SetActive(true);
                Change = false;
            }
        }
    }

    IEnumerator TCambio()
    {
        yield return new WaitForSeconds(0.35f);
        Change = true;

    }
}
