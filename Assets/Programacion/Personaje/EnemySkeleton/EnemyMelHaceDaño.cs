using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelHaceDaño : MonoBehaviour
{
    public int herida;
    GameObject Personaje;
    bool op1;
    // Start is called before the first frame update
    void Start()
    {
        Personaje = GameObject.Find("Einar");
    }
    void Update()
    {
        op1 = GetComponent<AtaqueEinarEnemigo>();
    }
    public void DañoGarra()
    {
        if (op1)
        {
            Personaje.GetComponent<PropiedadesScript>().Daño(herida);
        }
    }
}
