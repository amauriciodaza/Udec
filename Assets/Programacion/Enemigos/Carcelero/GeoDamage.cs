using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoDamage : MonoBehaviour
{
    GameObject Character;
    public GameObject GeoEnemy;
    float AtackDamage;

    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Einar");
        AtackDamage = GeoEnemy.GetComponent<GeoAtackActive>().AtackDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        // Ataque con brazo derecho
        if (other.name == Character.name && GeoEnemy.GetComponent<GeoAtackActive>().AtackState &&
            this.gameObject.name == "ImpactAreaLeft" && GeoEnemy.GetComponent<GeoAtackActive>().arm)
        {
            Character.GetComponent<LifeManager>().Damage(AtackDamage);
        }
        else if (other.name == Character.name && GeoEnemy.GetComponent<GeoAtackActive>().AtackState &&
        this.gameObject.name == "ImpactAreaRight" && GeoEnemy.GetComponent<GeoAtackActive>().arm == false)
        {
            Character.GetComponent<LifeManager>().Damage(AtackDamage);
        }
    }
}
