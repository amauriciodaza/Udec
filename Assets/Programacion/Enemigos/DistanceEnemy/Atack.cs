using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    GameObject Character;
    public float AtackDamage;
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Einar");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == Character.name)
        {
            Destroy(this.gameObject);
            Character.GetComponent<LifeManager>().Damage(AtackDamage);
        }
    }
}
