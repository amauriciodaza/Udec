using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelHaceDaño : MonoBehaviour
{
    public int herida;
    public GameObject Personaje;
    public bool op;
    // Start is called before the first frame update
    public void DañoGarra()
    {
        if (op)
        {
            Debug.Log("golpeo");
            Personaje.GetComponent<PropiedadesScript>().Daño(herida);
        }
    }
}
