using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySword : MonoBehaviour
{
    public GameObject[] lights;
    public Material[] Materiales;

    public GameObject SwordBlade;

    float SwordLife;

    bool UbEspada;

    bool DownLife;

    public bool superficie;
    // Start is called before the first frame update
    void Start()
    {
        SwordLife = 100;
        DownLife = true;
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
        }
        CurrentMaterial();
    }

    void CurrentMaterial()
    {
        Renderer rend = SwordBlade.GetComponent<Renderer>();

        if (SwordLife >= 66)
        {
            lights[0].SetActive(true);
            lights[1].SetActive(false);
            lights[2].SetActive(false);
            rend.material = Materiales[0];
        }
        else if (SwordLife < 66 && SwordLife >= 33)
        {
            lights[0].SetActive(false);
            lights[1].SetActive(true);
            lights[2].SetActive(false);
            rend.material = Materiales[1];
        }
        else if (SwordLife < 33 && SwordLife >= 5)
        {
            lights[0].SetActive(false);
            lights[1].SetActive(false);
            lights[2].SetActive(true);
            rend.material = Materiales[2];
        }
        else
        {
            lights[0].SetActive(false);
            lights[1].SetActive(false);
            lights[2].SetActive(false);
            rend.material = Materiales[3];
        }
    }
    



    IEnumerator DeathSword()
    {
        yield return new WaitForSeconds(0.5f);
        DownLife = true;
    }

}
