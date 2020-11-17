using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoShield : MonoBehaviour
{
    bool destructible;
    public float Shield;
    public bool DamageActive;
    // Start is called before the first frame update
    void Start()
    {
        destructible = true;
        DamageActive = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Blade")
        {
            if (Shield >= 1)
            {
                Shield = Shield - Shield * 0.00125f;
                if (destructible == true)
                {
                    GetComponent<GeoMovement>().impact();
                    destructible = false;
                    StartCoroutine(Indestructible(3.5f));
                }
            }
            else
            {
                Shield = 0;
                destructible = false;
                DamageActive = true;
            }
        }
    }

    IEnumerator Indestructible(float t)
    {
        yield return new WaitForSeconds(t);
        destructible = true;
    }
}
