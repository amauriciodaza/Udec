using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeoShield : MonoBehaviour
{
    bool destructible;
    public float Shield;
    public bool DamageActive;

    public Text ShieldTXT;
    // Start is called before the first frame update
    void Start()
    {
        ShieldTXT.text = "";
        destructible = true;
        DamageActive = false;
    }

    void Update()
    {
        if (Shield == 0)
        {
            ShieldTXT.enabled = false;
        }
        else
        {
            ShieldTXT.text = "Escudo: " + (int)Shield;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Blade")
        {
            if (Shield >= 1)
            {
                Shield = Shield - Shield * 0.0035f;
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
