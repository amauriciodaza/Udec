using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour
{
    float ChargeDamage;

    GameObject Character;

    void Start()
    {
        Character = GameObject.Find("Einar");
        ChargeDamage = Character.GetComponent<AtackDamageEinar>().BraceletDamage;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            other.GetComponentInParent<EnemyLife>().Damage(ChargeDamage);
        }
    }
}
