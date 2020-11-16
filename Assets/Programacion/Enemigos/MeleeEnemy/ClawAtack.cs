using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAtack : MonoBehaviour
{
    GameObject Character;
    public GameObject MeleeEnemy;
    float AtackDamage;

    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Einar");
        AtackDamage = MeleeEnemy.GetComponent<MeleeAtack>().AtackDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == Character.name && MeleeEnemy.GetComponent<MeleeAtack>().AtackState)
        {
            Character.GetComponent<LifeManager>().Damage(AtackDamage);
        }
    }
}
