using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySword : MonoBehaviour
{
    public GameObject Sword1;
    public GameObject Sword2;
    public GameObject Sword3;
    public GameObject Sword4;

    float SwordLife;

    bool UbEspada;

    bool DownLife;

    public bool superficie;

    public int currentSword;

    public bool Cambio;

    public float SwordDamage;
    // Start is called before the first frame update
    void Start()
    {
        SwordLife = 100;
        DownLife = true;
        Sword1.SetActive(false);
        Sword2.SetActive(false);
        Sword3.SetActive(false);
        Sword4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UbEspada = GetComponent<TranslationMovement>().armas;
        if (UbEspada && DownLife && SwordLife > 0 && superficie)
        {
            SwordLife = SwordLife - 0.25f;
            DownLife = false;
            StartCoroutine(DeathSword());
            CurrentEnergySword();
        }
    }

    void CurrentEnergySword()
    {
        StartCoroutine(Esperar());
        if (Cambio)
        {
            if (SwordLife >= 66)
            {
                Sword1.SetActive(true);
                Sword2.SetActive(false);
                Sword3.SetActive(false);
                Sword4.SetActive(false);
                currentSword = 0;

                SwordDamage = GetComponent<AtackDamageEinar>().SwordDamage;
            }
            else if (SwordLife < 66 && SwordLife >= 33)
            {
                Sword1.SetActive(false);
                Sword2.SetActive(true);
                Sword3.SetActive(false);
                Sword4.SetActive(false);
                currentSword = 1;

                SwordDamage = GetComponent<AtackDamageEinar>().SwordDamage * 0.75f;
            }
            else if (SwordLife < 33 && SwordLife >= 5)
            {
                Sword1.SetActive(false);
                Sword2.SetActive(false);
                Sword3.SetActive(true);
                Sword4.SetActive(false);
                currentSword = 2;

                SwordDamage = GetComponent<AtackDamageEinar>().SwordDamage * 0.5f;
            }
            else
            {
                Sword1.SetActive(false);
                Sword2.SetActive(false);
                Sword3.SetActive(false);
                Sword4.SetActive(true);
                currentSword = 3;

                SwordDamage = GetComponent<AtackDamageEinar>().SwordDamage * 0.25f;
            }
        } 
    }

    public void Seleccionar(bool active)
    {
        if (currentSword == 0)
        {
            Sword1.SetActive(active);
        }
        else if (currentSword == 1)
        {
            Sword2.SetActive(active);
        }
        else if (currentSword == 2)
        {
            Sword3.SetActive(active);
        }
        else if (currentSword == 3)
        {
            Sword4.SetActive(active);
        }
    }

    IEnumerator DeathSword()
    {
        yield return new WaitForSeconds(0.5f);
        DownLife = true;
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.175f);
        Cambio = true;
    }
}
