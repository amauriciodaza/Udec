using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Einar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == Character.name)
        {
            Character.GetComponent<PropiedadesScript>().Daño(3);
            Destroy(this.gameObject);
        }
    }
}
