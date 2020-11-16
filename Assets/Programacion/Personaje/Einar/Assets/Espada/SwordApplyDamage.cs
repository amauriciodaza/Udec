using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordApplyDamage : MonoBehaviour
{
    GameObject Character;
    float SwordDamage;

    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Einar");
    }

    void OnTriggerEnter(Collider other)
    {
        SwordDamage = Character.GetComponent<EnergySword>().SwordDamage;

        if (Character.GetComponent<AtackDamageEinar>().SwordTypeAtack)
        {
            SwordDamage = SwordDamage + SwordDamage * 0.25f;
        }
        Debug.Log(other.tag);
        if (other.tag == "Enemy"  && Character.GetComponent<AtackDamageEinar>().SwordState)
        {
            other.GetComponent<EnemyLife>().Damage(SwordDamage);
        }
    }
}
